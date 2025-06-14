// LED Pins
const int led1 = 3;
const int led2 = 5;
const int led3 = 6;
const int led4 = 9;
const int led5 = 10;
const int motionLed = 11;

// Sensor Pins
const int ldr = 8;        
const int trigPin = 4;    
const int echoPin = 7;  

// Variables
unsigned long motionTime = 0;
bool motionDetected = false;
int ledBrightness[6] = {255, 255, 255, 255, 255, 255}; 
unsigned long motionLedDuration = 5000; 
bool ledManualOverride[6] = {false, false, false, false, false, false};
const int ledPins[6] = {led1, led2, led3, led4, led5, motionLed};

void setup() {
//pin mode and reseting leds to off
  for (int i = 0; i < 6; i++) {
    pinMode(ledPins[i], OUTPUT);
    analogWrite(ledPins[i], 0); 
  }
  pinMode(ldr, INPUT);
  pinMode(trigPin, OUTPUT);
  pinMode(echoPin, INPUT);

  // Start serial communication
  Serial.begin(9600);
}

void loop() {
  int light = digitalRead(ldr);
  float distance = measureDistance();

  // auto  led control
  for (int i = 0; i < 5; i++) {
    if (!ledManualOverride[i]) {
      analogWrite(ledPins[i], (light == HIGH) ? ledBrightness[i] : 0);
    }
  }

  // motion detection
  if (distance > 0 && distance < 20) {
    motionDetected = true;
    motionTime = millis();
  }

  // Motion led
  if (!ledManualOverride[5]) {
    if (motionDetected && (millis() - motionTime < motionLedDuration)) {
      analogWrite(motionLed, ledBrightness[5]);
    } else {
      analogWrite(motionLed, 0);
      motionDetected = false;
    }
  }

  handleSerialCommands();

  delay(200); 
}
// ultra sonic code 
float measureDistance() {
  digitalWrite(trigPin, LOW);
  delayMicroseconds(2);
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW);

  long duration = pulseIn(echoPin, HIGH, 20000); 
  return duration * 0.034 / 2; // equation
}

// linking arduino with vb
void handleSerialCommands() {
  if (!Serial.available()) return;

  String cmd = Serial.readStringUntil('\n');
  cmd.trim();

  if (cmd == "Hello") {
    Serial.println("Hello");
  }
  else if (cmd.startsWith("O")) {
    int n = cmd.substring(1).toInt(); forceLedOn(n);
  }
  else if (cmd.startsWith("F")) {
    int n = cmd.substring(1).toInt(); forceLedOff(n);
  }
  else if (cmd.startsWith("A")) {
    int n = cmd.substring(1).toInt(); setLedAuto(n);
  }
  else if (cmd.startsWith("B")) {
    int sp = cmd.indexOf(' ');
    if (sp != -1) {
      int n = cmd.substring(1, sp).toInt();
      int b = cmd.substring(sp + 1).toInt();
      changeLedBrightness(n, b);
    }
  }
  else if (cmd == "GET_LDR_DATA") {
    Serial.println(digitalRead(ldr) == HIGH ? "HIGH" : "LOW");
  }
  else if (cmd == "GET_MOTION_DATA") {
    Serial.println(motionDetected ? "Motion Detected" : "No Motion");
  }
  else if (cmd.startsWith("T")) {
    motionLedDuration = max(1000, cmd.substring(1).toInt() * 1000UL);
    Serial.print("Duration:"); Serial.println(motionLedDuration / 1000);
  }
}


// manual led on function
void forceLedOn(int num) {
  if (num < 1 || num > 6) return;
  ledManualOverride[num - 1] = true;
  analogWrite(ledPins[num - 1], ledBrightness[num - 1]); // turn on at current brightness
  Serial.print("LED "); Serial.print(num); Serial.println(" ON (Manual)");
}
// manual led off function
void forceLedOff(int num) {
  if (num < 1 || num > 6) return;
  ledManualOverride[num - 1] = true;
  analogWrite(ledPins[num - 1], 0); // turn off
  Serial.print("LED "); Serial.print(num); Serial.println(" OFF (Manual)");
}
//seting led to auto again
void setLedAuto(int num) {
  if (num < 1 || num > 6) return;
  ledManualOverride[num - 1] = false;
  Serial.print("LED "); Serial.print(num); Serial.println(" AUTO Mode");
}
// changing brightness for led
void changeLedBrightness(int num, int b) {
  if (num < 1 || num > 6) return;
  b = constrain(b, 0, 255);
  ledBrightness[num - 1] = b;

  if (ledManualOverride[num - 1]) {
    analogWrite(ledPins[num - 1], b);
  }

  Serial.print("LED"); Serial.print(num);
  Serial.print(" brightness set to "); Serial.println(b);
}

