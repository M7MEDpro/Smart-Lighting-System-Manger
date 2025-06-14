Imports System.IO.Ports
Imports System.Threading

Public Class ArduinoConnection
    Private Shared arduinoPort As New SerialPort()
    Private Shared connectionTimeout As Integer = 5000 ' 5 seconds
    Private Shared cancellationTokenSource As CancellationTokenSource
    Private Shared cancellationToken As CancellationToken

    Public Shared Event ConnectionStatusChanged As EventHandler(Of String)

    Public Shared ReadOnly Property SerialPort() As SerialPort
        Get
            Return arduinoPort
        End Get
    End Property

    ' Connect to Arduino
    Public Shared Sub Connect()
        Try
            cancellationTokenSource = New CancellationTokenSource()
            cancellationToken = cancellationTokenSource.Token

            Dim availablePorts As String() = SerialPort.GetPortNames()

            If availablePorts.Length > 0 Then
                For Each port As String In availablePorts
                    If cancellationToken.IsCancellationRequested Then
                        Exit For
                    End If

                    arduinoPort.PortName = port
                    arduinoPort.BaudRate = 9600
                    arduinoPort.ReadTimeout = 1000
                    arduinoPort.WriteTimeout = 1000

                    Try
                        arduinoPort.Open()
                        Thread.Sleep(1000)
                        arduinoPort.WriteLine("Hello")
                        Dim response As String = arduinoPort.ReadLine()

                        If response.Contains("Hello") Then
                            RaiseEvent ConnectionStatusChanged(Nothing, "Connected to " & arduinoPort.PortName)
                            Exit For
                        Else
                            arduinoPort.Close()
                        End If
                    Catch ex As Exception
                        arduinoPort.Close()
                    End Try
                Next

                If Not arduinoPort.IsOpen Then
                    RaiseEvent ConnectionStatusChanged(Nothing, "Unable to connect to any COM ports.")
                End If
            Else
                RaiseEvent ConnectionStatusChanged(Nothing, "No COM ports available!")
            End If
        Catch ex As Exception
            RaiseEvent ConnectionStatusChanged(Nothing, "Error: " & ex.Message)
        Finally
            cancellationTokenSource.Dispose()
        End Try
    End Sub

    ' Disconnect from Arduino
    Public Shared Sub Disconnect()
        If arduinoPort.IsOpen Then
            arduinoPort.Close()
            RaiseEvent ConnectionStatusChanged(Nothing, "Disconnected.")
        End If
    End Sub

    ' Force LED On
    Public Shared Sub ForceLedOn(led As Integer)
        Try
            If arduinoPort.IsOpen Then
                arduinoPort.WriteLine("O" & led.ToString())
            Else
                Throw New InvalidOperationException("Serial port is not open.")
            End If
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        End Try
    End Sub

    ' Force LED Off
    Public Shared Sub ForceLedOff(led As Integer)
        Try
            If arduinoPort.IsOpen Then
                arduinoPort.WriteLine("F" & led.ToString())
            Else
                Throw New InvalidOperationException("Serial port is not open.")
            End If
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        End Try
    End Sub

    ' Set LED to Auto Mode
    Public Shared Sub SetLedAuto(led As Integer)
        Try
            If arduinoPort.IsOpen Then
                arduinoPort.WriteLine("A" & led.ToString())
            Else
                Throw New InvalidOperationException("Serial port is not open.")
            End If
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        End Try
    End Sub

    ' Set LED Brightness
    Public Shared Sub SetLedBrightness(led As Integer, brightness As Integer)
        Try
            If brightness < 0 OrElse brightness > 255 Then
                Throw New ArgumentOutOfRangeException("Brightness must be between 0 and 255.")
            End If

            If arduinoPort.IsOpen Then
                arduinoPort.WriteLine("B" & led.ToString() & " " & brightness.ToString())
            Else
                Throw New InvalidOperationException("Serial port is not open.")
            End If
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        End Try
    End Sub

    ' Get Sensor Data
    Public Shared Function GetSensorData(sensorType As String) As String
        Try
            If arduinoPort.IsOpen Then
                Select Case sensorType.ToUpper()
                    Case "LDR"
                        arduinoPort.WriteLine("GET_LDR_DATA")
                        Return arduinoPort.ReadLine()
                    Case "MOTION"
                        arduinoPort.WriteLine("GET_MOTION_DATA")
                        Return arduinoPort.ReadLine()
                    Case Else
                        Throw New ArgumentException("Invalid sensor type")
                End Select
            Else
                Throw New InvalidOperationException("Serial port is not open.")
            End If
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
            Return String.Empty
        End Try
    End Function

    ' Set Motion LED Duration
    Public Shared Sub SetMotionLedDuration(duration As Integer)
        Try
            If arduinoPort.IsOpen Then
                arduinoPort.WriteLine("T" & duration.ToString())
            Else
                Throw New InvalidOperationException("Serial port is not open.")
            End If
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        End Try
    End Sub
End Class