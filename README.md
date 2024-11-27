# MAUI MVVM Calculator

This is a simple calculator application built with **.NET MAUI** using the **MVVM (Model-View-ViewModel)** pattern. The app performs basic arithmetic operations, with support for square root calculations and a clear interface for displaying formulas and results. It uses **Dangl.Calculator** for formula parsing and calculation.

## Table of Contents
1. [Features](#features)
2. [Architecture](#architecture)
3. [File Structure](#file-structure)
4. [Requirements](#requirements)
5. [Setup and Installation](#setup-and-installation)
6. [Usage](#usage)

---

### Features

- **Basic Arithmetic Operations**: Addition, subtraction, multiplication, and division.
- **Square Root Calculation**: Support for single and chained square root expressions.
- **Backspace and Reset Functionality**: Ability to remove the last input or reset the entire calculation.
- **Instant Feedback**: Real-time updates to the formula and result as input changes.

### Architecture

The application is structured following the **MVVM (Model-View-ViewModel)** pattern, separating UI logic (View) from business logic (ViewModel), which allows for easier testing, maintainability, and scalability.

- **Model**: In this project, the `Dangl.Calculator` library performs the heavy lifting of parsing and calculating formulas.
- **ViewModel (CalcViewModel.cs)**: Manages the calculator’s logic, including input handling, formula processing, and calculation execution. The `INotifyPropertyChanged` interface (auto-implemented by **PropertyChanged.Fody**) updates the UI as properties change.
- **View (CalcView.xaml and CalcView.xaml.cs)**: Defines the layout of the calculator UI and binds elements to the ViewModel, displaying user input and results.

### File Structure

    ├── MAUICalculator
    │   ├── MVVM
    │   │   ├── ViewModels
    │   │   │   ├── CalcViewModel.cs    # Main logic and state for calculator operations
    │   │   ├── Views
    │   │   │   ├── CalcView.xaml       # UI layout
    │   │   │   ├── CalcView.xaml.cs    # View class to bind the UI to CalcViewModel
    │   ├── App.xaml                    # Application entry point
    │   ├── MainPage.xaml               # Main page setup
    │   ├── App.xaml.cs                 # App configuration and initialization

### Requirements

- **.NET 6 or later** (for .NET MAUI)
- **MAUI-compatible IDE**: Visual Studio 2022 or later
- **Dangl.Calculator** NuGet package
- **PropertyChanged.Fody** NuGet package

### Setup and Installation

1. **Clone the Repository**
   ```bash
   git clone https://github.com/your-repo/maui-mvvm-calculator.git
   cd MAUICalculator
   ```

2. **Install Required Packages**
   - In your **IDE** (e.g., Visual Studio 2022), restore the NuGet packages:
     - `Dangl.Calculator`
     - `PropertyChanged`

3. **Build and Run**
   - Open the project in Visual Studio 2022 or your preferred MAUI-compatible IDE.
   - Select the target platform (Android, iOS, or Windows) and run the application.

### Usage

1. **Perform Calculations**
   - **Enter Numbers**: Use the on-screen numeric buttons.
   - **Operators**: Select `+`, `-`, `*`, or `/` for basic arithmetic operations.
   - **Square Root**: Press the `√` button to add a square root to the formula.
   - **Calculate**: Press `=` to evaluate the current formula.

2. **Reset and Clear Operations**
   - **Reset**: Press `C` to reset both the formula and result to their initial states.
   - **Backspace**: Use the backspace button to remove the last character or operator from the formula.

---
