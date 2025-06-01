# Cs-Matala-6

## Overview

Simulates a mobile device managing apps (Navigation, Social, etc.) to practice OOP in C#. Includes abstract classes, interfaces, and validation.

## Features

- `AppSystem`: abstract base class with name, price, and abstract method `AppSystemPurpose()`.
- `Navigation`: navigation app with addresses, vehicle types, and VAT logic.
- `Social`: social app with rating, org targeting, and VAT logic.
- `IApp`: interface with `AddVAT()` method.
- `Validator`: static validation methods.
- `MobileDevice`: holds apps, manages login, and app interaction (in progress).

---

## TODO

### AppSystem
- [x] Created abstract class
- [x] Common fields: appName, price
- [x] Abstract method `AppSystemPurpose()`
- [x] Base `ToString()` logic
- [ ] Maybe add abstract `specialNum` generator if needed (by name or random)

### IApp
- [x] Interface created
- [x] `AddVAT()` declared

### Validator
- [x] Static methods for: string, price, date

### Social
- [x] Inherits from `AppSystem`
- [x] Implements `IApp`
- [x] Fields: ID, name, price, rating, date, isForOrg
- [x] VAT calculation (via constant 1.13)
- [x] Validations via `Validator`
- [x] Static counter for unique ID
- [x] `AppSystemPurpose()` + `ToString()`
- [ ] Verify if final abstract method from AppSystem is handled (recheck spec)

### Navigation
- [x] Class created
- [ ] Understand manager/destination array logic
- [ ] Implement vehicle enum and related fields
- [ ] Add address logic, `AddAddress()`, `ShowRecentLocations()`
- [ ] VAT logic (`AddVAT()`)
- [ ] `AppSystemPurpose()` + `ToString()`

### MobileDevice
- [ ] Create class and fields
- [ ] Add app list management
- [ ] Handle login + retry limit logic
- [ ] Add methods: `AddApp`, `PopularNavigationApp()`, `ShowListAppNavigation()`, `ToString()`, `login()`
- [ ] User menu in `Main`

---

Contact me for more useless assignments.