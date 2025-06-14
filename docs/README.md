# Smart Home Lighting System Manager

An end‑to‑end, fully automated home lighting system with feedback‑based control over interior and exterior LEDs.\
Uses light (LDR) and motion (ultrasonic) sensing to drive auto-on/off and brightness, plus a VB.NET GUI for manual override, power estimation, and statistical analysis.

---

## 🌱 Back Story

This project began as part of our freshman curriculum at the Egyptian‑Chinese University, aiming to apply hands‑on electronics and GUI design skills. Our team wanted to solve the common issue of inflexible home lighting that wastes energy. We designed an Arduino‑based system using an ultrasonic motion sensor and a pre‑built LDR module for ambient detection. A VB.NET application with Guna UI serves as a user interface for manual overrides and brightness tweaking. Without relying on databases, internet connectivity, or complex OOP frameworks, this lean setup delivers real‑time sensor‑driven lighting and granular per‑room control.

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
- **Sleek VB.NET GUI**\*\*
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
│   ├── Smart home lighting system manger final.pdf  ← Project report PDF
│   ├── additional_design.pdf         ← Additional design documentation
│   ├── screenshots/                  ← UI & hardware photos
│   └── videos/                       ← Demo videos
└── LICENSE                           ← MIT License file
```

---

## 🔧 Hardware Requirements

- **Microcontroller:** Arduino Uno
- **Sensors & Actuators:**
  - HC‑SR04 Ultrasonic Sensor (motion)
  - LDR Module (ambient light)
  - White LEDs (with 220 Ω current‑limiting resistors)
- **Miscellaneous:**:\*\* Breadboard, jumper wires, USB cable, 5 V power supply

*(The Wokwi simulation at *[***https://wokwi.com/projects/430155215946846209***](https://wokwi.com/projects/430155215946846209)* shows the exact wiring.)*

---

## 🖥️ Software Prerequisites

- Arduino IDE (no extra libraries required)
- Visual Studio / VB.NET targeting .NET Framework 4.7.2 (or later)
- Guna.UI2.WinForms (latest NuGet package)

---

## ⚙️ Installation & Setup

1. **Build Hardware**
   - Follow the wiring diagram in `/Arduino/wiring-diagram.png` or the Wokwi link above.
2. **Flash Arduino**
   - Open `SmartHomeLight.ino` in the Arduino IDE, select “Arduino Uno” and your COM port, then Upload.
3. **Run VB.NET App**
   - Open `SmartHomeLight.sln` in Visual Studio.
   - Restore NuGet packages (Guna.UI2.WinForms).
   - Compile & Run — the app will auto‑detect the Arduino’s serial port.

---

## 📋 Usage

- **Automatic Mode:** LEDs respond to ambient light and motion, with adjustable brightness based on sensor readings—rooms light up at optimal levels without user input.
- **Manual Mode:** Use sliders and toggles in the GUI to control each room’s LEDs individually—set on/off states and brightness per room.
- **Dashboard:** View live power/current readings and historical consumption graphs for each room and overall system.

---

## 👩‍💻 Team & Acknowledgments

**Team Members** (Egyptian‑Chinese University, Freshmen, March 2025):\
Mohamed Badawy Mohamed, Omar Moustafa Salah, Zeyad Waleed Amin, Khaled Karam Mahmoud, Abdelrhman Waleed Hassan, Hazem Mohamed Hamdy,\
Judy Ehab Abdelmajied, Omar Ahmed Mohamed, Oliver Emad Adly, Adam Tamer Mohamed, Haidy Ahmed Mohamed, Mai Ahmed Mohamed,\
Martina Anwar Azmy, Rodina Mahmoud Sayed, Salma Waeel Salah, Heba Ahmed Mohamed

**Supervision** & Acknowledgments\*\*\
Dr. Noha Hussein for guidance, and Dr. Mohamad Talaat



---

## 📜 License

This project is licensed under the MIT License. See `LICENSE` for details.

---

## 🙋‍♂️ Contact

For questions or contributions, please open an issue or reach out to [bdwym2007@gmail.com](mailto\:bdwym2007@gmail.com)



> “In a world driven by data, smarter homes mean smarter living.”

