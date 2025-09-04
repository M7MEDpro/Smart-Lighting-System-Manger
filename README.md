# Smart Home Lighting System Manager
![Arduino](https://img.shields.io/badge/Arduino-00979D?style=for-the-badge&logo=arduino&logoColor=white)
![VB.NET](https://img.shields.io/badge/VB.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C++](https://img.shields.io/badge/C++-00599C?style=for-the-badge&logo=c%2B%2B&logoColor=white)  
![IoT](https://img.shields.io/badge/IoT-Internet%20of%20Things-orange?style=flat-square)
![Automation](https://img.shields.io/badge/Automation-Smart%20Home-green?style=for-the-badge)
![License](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)  
![University](https://img.shields.io/badge/University-ECU-red?style=for-the-badge)
![Project](https://img.shields.io/badge/Type-Student%20Project-blue?style=for-the-badge)
![Year](https://img.shields.io/badge/Year-Freshman%202025-brightgreen?style=for-the-badge)


An end‑to‑end, fully automated home lighting system with feedback‑based control over interior and exterior LEDs.\
Uses light (LDR) and motion (ultrasonic) sensing to drive auto-on/off and brightness, plus a VB.NET GUI for manual control and power estimation

---

## 🌱 Back Story
Our project originated from the need for a smarter, energy-efficient home electrical system. After conducting an analytical study that considered our team's background, available time, and tight schedule, we identified a problem: most home lighting circuits lack flexibility and real-time responsiveness. We created a system that adapts to ambient sunlight and motion to optimize energy use, using Rapid Application Development (RAD) in VB.NET alongside an Arduino-based sensing network.

As detailed in our proposal, this Smart Home Lighting System Manager automates LED control based on environmental feedback and provides per-room customization along with real-time power/current calculations.

---

## 🚀 Features

- **Automatic Control**
  - Ambient‑light sensing via LDR to adjust interior LEDs
  - Ultrasonic‑motion sensing for stair or gate lighting
- **Manual Override**
  - Toggle any individual LED on/off
  - Fine‑tune brightness for optimal energy savings
- **Real‑Time Metrics**
  - Instantaneous power & current calculation per LED
- **Sleek VB.NET GUI**
  - Built with the latest Guna.UI framework for a modern look
  - Auto‑connects to Arduino on startup

---

## 📦 Repo Structure

```
/
├── Arduino/
│   ├── wiring-diagram.png            ← Fritzing/Wokwi schematic
│   └── SmartHomeLight.ino            ← Main Arduino sketch
├── VBApp/
│   ├── SmartHomeLight.sln            ← VB.NET solution
│   ├── SmartHomeLight/               ← Guna‑based WinForms project
│   └── README-vb.md                  ← App‑specific instructions
├── docs/
│   ├── README.md                     ← Project README (this file)
│   └── screenshots/                  ← UI & hardware photos
└── LICENSE                           ← MIT License file
```

---

## 🔧 Hardware Requirements

- **Microcontroller:** Arduino Uno  
- **Sensors & Actuators:**
  - HC‑SR04 Ultrasonic Sensor (motion)
  - LDR Module (ambient light)
  - White LEDs (with 220 Ω current‑limiting resistors)
- **Miscellaneous:** Breadboard, jumper wires, USB cable, 5 V power supply

*(The Wokwi simulation at [https://wokwi.com/projects/430155215946846209](https://wokwi.com/projects/430155215946846209) shows the exact wiring.)*

---

## 🖥️ Software Prerequisites

- Arduino IDE (no extra libraries required)
- Visual Studio / VB.NET targeting .NET Framework 4.7.2 (or later)
- Guna.UI2.WinForms (latest NuGet package)

### Application Interface
![Smart Home Lighting App](docs/Photos/s4%20app.jpg)
*Modern VB.NET GUI built with Guna.UI2 framework for intuitive control and monitoring*

---

## ⚙️ Installation & Setup

1. **Build Hardware**
   - Follow the wiring diagram in `/Arduino/wiring-diagram.png` or the Wokwi link above.
2. **Flash Arduino**
   - Open `SmartHomeLight.ino` in the Arduino IDE, select "Arduino Uno" and your COM port, then Upload.
3. **Run VB.NET App**
   - Open `SmartHomeLight.sln` in Visual Studio.
   - Restore NuGet packages (Guna.UI2.WinForms).
   - Compile & Run — the app will auto‑detect the Arduino's serial port.

---

## 📋 Usage

- **Automatic Mode:** LEDs respond to ambient light and motion, with adjustable brightness based on sensor readings—rooms light up at optimal levels without user input.
- **Manual Mode:** Use sliders and toggles in the GUI to control each room's LEDs individually—set on/off states and brightness per room.
- **Dashboard:** View live power/current readings and historical consumption graphs for each room and overall system.

---

## 👩‍💻 Team & Acknowledgments

**Team Members**  
*Egyptian‑Chinese University, Freshmen, May 2025:*

- Mohamed Badawy Mohamed – [@M7MEDpro](https://github.com/M7MEDpro)  
- Omar Moustafa Salah  
- Zeyad Waleed Amin – [@Night1Assassin](https://github.com/Night1Assassin)  
- Khaled Karam Mahmoud  - [@khaledkaram688](https://github.com/khaledkaram688)  
- Abdelrhman Waleed Hassan  
- Hazem Mohamed Hamdy  
- Judy Ehab Abdelmajied  
- Omar Ahmed Mohamed  
- Oliver Emad Adly  
- Adam Tamer Mohamed  
- Haidy Ahmed Mohamed  
- Mai Ahmed Mohamed  
- Martina Anwar Azmy  
- Rodina Mahmoud Sayed  
- Salma Waeel Salah  
- Heba Ahmed Mohamed  

**Supervision & Acknowledgments**  
Dr. Noha Hussein for guidance, and Dr. Mohamad Talaat

---

## 📜 License

This project is licensed under the MIT License. See `LICENSE` for details.

---

## 🙋‍♂️ Contact

For questions or contributions, please open an issue or reach out to bdwym2007@gmail.com

---

> "In a world driven by data, smarter homes mean smarter living"
