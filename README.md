# Cs-Matala-6

## Overview

This project simulates a mobile device system that manages various applications. It demonstrates object-oriented principles in C#, such as inheritance, encapsulation, interfaces, exception handling, and system-level design.

## Features

- Abstract base class `AppSystem` for common functionality across apps
- Derived app classes: `Social` and `Navigation`, each with unique fields and behaviors
- Interface `IApp` for enforcing `AddVAT()` implementation
- `MobileDevice` class that simulates a device managing multiple apps
- `NavigationManager` for managing addresses and types of navigation
- Enum `NavigationType` (Car, Bike, Walk)
- Comprehensive `Program.cs` menu for interacting with the system
- Input validation through the `Validator` class
- Full exception safety using try-catch logic
- Console UI that clears between operations and handles edge cases

---

## TODO & Progress

| Component        | Task                                                     | Status       | Priority |
|------------------|----------------------------------------------------------|--------------|----------|
| AppSystem        | Implement base structure                                 | ✅ Done      | -        |
| AppSystem        | Auto-generate special number (optional)                  | ✅ Done      | -        |
| Social           | Create class, connect to validator                       | ✅ Done      | -        |
| Social           | Override abstract method                                 | ✅ Done      | -        |
| Navigation       | Design class, include manager                            | ✅ Done      | -        |
| Navigation       | Connect with NavigationManager logic                     | ✅ Done      | -        |
| NavigationManager| Add location tracking + enum + display methods           | ✅ Done      | -        |
| MobileDevice     | Add, sort, and compare apps                              | ✅ Done      | -        |
| MobileDevice     | Full login flow with retry                               | ✅ Done      | -        |
| Menu             | Add app / show / sort / print / safe travel flow         | ✅ Done      | -        |
| Menu             | Clear UI + return prompt between operations              | ✅ Done      | -        |
| Menu             | Option 3: Navigate & safe travel message                 | ✅ Done      | -        |
| Validation       | Integrate validator in all property setters              | ✅ Done      | -        |
| README.md        | Final summary and checklist                              | ✅ Done      | -        |

---

## How to Run

1. Open the solution in Visual Studio 2022 or compatible IDE
2. Run `Program.cs`
3. Login with one of the predefined users shown at startup
4. Choose options from the menu to interact with your device and apps

---

## Notes

- If you want to extend this system further, consider:
  - Persisting app data to file
  - Adding other app types (e.g., Game, Utility)
  - Using `List<T>` instead of arrays for app management
  - Implementing a real signup/login system with hashed passwords
