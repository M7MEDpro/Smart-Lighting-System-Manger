Imports System.Net.Security

Public Class Form1
    Private WithEvents refreshTimer As New Timer()


    Private Sub page1() Handles MyBase.Load
        ArduinoConnection.Connect()
        SetupPictureShadows()

        For i As Integer = 1 To 6
            prevBrightness(i) = -1
            prevMode(i) = -1
        Next

        refreshTimer.Interval = 250
        refreshTimer.Start()
    End Sub

    Private Sub refreshTimer_Tick(sender As Object, e As EventArgs) Handles refreshTimer.Tick
        UpdateLed(1, Guna2ToggleSwitch1, Guna2ToggleSwitch2, Guna2VTrackBar1)
        UpdateLed(2, Guna2ToggleSwitch3, Guna2ToggleSwitch4, Guna2VTrackBar2)
        UpdateLed(3, Guna2ToggleSwitch5, Guna2ToggleSwitch6, Guna2VTrackBar6)
        UpdateLed(4, Guna2ToggleSwitch7, Guna2ToggleSwitch8, Guna2VTrackBar3)
        UpdateLed(5, Guna2ToggleSwitch9, Guna2ToggleSwitch10, Guna2VTrackBar4)
        UpdateLed(6, Guna2ToggleSwitch11, Guna2ToggleSwitch12, Guna2VTrackBar5)

        Dim totalCurrent As Double = EstimateTotalCurrent()
        Dim totalPower As Double = totalCurrent * VOLTAGE

        LabelC.Text = $"Current: {totalCurrent:F2} A"
        LabelP.Text = $"Power: {totalPower:F2} W"
    End Sub

    Private Sub UpdateLed(index As Integer,
                          autoSwitch As Guna.UI2.WinForms.Guna2ToggleSwitch,
                          overrideSwitch As Guna.UI2.WinForms.Guna2ToggleSwitch,
                          trackBar As Guna.UI2.WinForms.Guna2VTrackBar)

        Dim mode As Integer
        If autoSwitch.Checked Then
            mode = 0 : overrideSwitch.Enabled = False
        ElseIf overrideSwitch.Checked Then
            mode = 1 : overrideSwitch.Enabled = True
        Else
            mode = 2 : overrideSwitch.Enabled = True
        End If

        If mode <> prevMode(index) Then
            Select Case mode
                Case 0 : ArduinoConnection.SetLedAuto(index)
                Case 1 : ArduinoConnection.ForceLedOn(index)
                Case 2 : ArduinoConnection.ForceLedOff(index)
            End Select
            prevMode(index) = mode
        End If

        Dim brightness = 255 - (trackBar.Value * 254 \ 100)
        If brightness <> prevBrightness(index) Then
            ArduinoConnection.SetLedBrightness(index, brightness)
            prevBrightness(index) = brightness
        End If
    End Sub

    Private Function EstimateChannelCurrent(channel As Integer) As Double
        If prevMode(channel) = 2 Then Return 0
        Return LED_CURRENT_FULL * ledCount(channel) * (prevBrightness(channel) / 255.0)
    End Function

    Private Function EstimateTotalCurrent() As Double
        Dim total As Double = 0
        For i As Integer = 1 To 6
            total += EstimateChannelCurrent(i)
        Next
        Return total
    End Function

    Private Sub SetupPictureShadows()
        Dim pics = {Pic1, Pic2, Pic3, Pic4, Pic5, Pic6}
        For Each pic In pics
            pic.ShadowDecoration.Color = Color.RoyalBlue
            pic.ShadowDecoration.Depth = 140
            pic.ShadowDecoration.Enabled = False
        Next
    End Sub

    Public Sub ToggleOutlineBlue(index As Integer)
        Dim pics = {Pic1, Pic2, Pic3, Pic4, Pic5, Pic6}
        For i As Integer = 0 To pics.Length - 1
            pics(i).ShadowDecoration.Enabled = (i = index - 1)
        Next
    End Sub
    Private prevBrightness(6) As Integer
    Private prevMode(6) As Integer

    Private Const VOLTAGE As Double = 5.0
    Private Const LED_CURRENT_FULL As Double = 5 / 450
    Private Shared ReadOnly ledCount() As Integer = {0, 2, 2, 2, 1, 1, 2}

    Private Sub Guna2ImageButton1_Click(sender As Object, e As EventArgs) Handles Guna2ImageButton1.Click
        ToggleOutlineBlue(1)
    End Sub

    Private Sub Guna2ImageButton2_Click(sender As Object, e As EventArgs) Handles Guna2ImageButton2.Click
        ToggleOutlineBlue(2)
    End Sub

    Private Sub Guna2ImageButton3_Click(sender As Object, e As EventArgs) Handles Guna2ImageButton3.Click
        ToggleOutlineBlue(3)
    End Sub

    Private Sub Guna2ImageButton4_Click(sender As Object, e As EventArgs) Handles Guna2ImageButton4.Click
        ToggleOutlineBlue(4)
    End Sub

    Private Sub Guna2ImageButton5_Click(sender As Object, e As EventArgs) Handles Guna2ImageButton5.Click
        ToggleOutlineBlue(5)
    End Sub

    Private Sub Guna2ImageButton6_Click(sender As Object, e As EventArgs) Handles Guna2ImageButton6.Click
        ToggleOutlineBlue(6)
    End Sub

    Private Sub Guna2ImageButton9_Click(sender As Object, e As EventArgs) Handles Guna2ImageButton9.Click

        Application.Restart()
        Environment.Exit(0)
    End Sub

    Private Sub Guna2ImageButton8_Click(sender As Object, e As EventArgs) Handles Guna2ImageButton8.Click
        ArduinoConnection.Disconnect()
        Application.Exit()

    End Sub
End Class
