# ExpanderIssue

This sample reproduces a crash that occurs when the app is start without debuggong / outside Visual Studio (for example, by double-clicking the built `.exe` or launching the packaged app). The crash is triggered by placing an `CommunityToolkit.WinUI.Controls.SettingsExpander` control inside another `CommunityToolkit.WinUI.Controls.SettingsExpander` control.

## Summary

- Project: `ExpanderIssue`
- Symptom: application crashes only when started without debugging or run outside Visual Studio
- Trigger: nested `CommunityToolkit.WinUI.Controls.SettingsExpander` (an `CommunityToolkit.WinUI.Controls.SettingsExpander` inside another `CommunityToolkit.WinUI.Controls.SettingsExpander`)

## Reproduction steps

1. Build the solution in `Debug` or `Release` configuration.
2. Run the app from Visual Studio — it will start and the UI with nested expanders appears to work.
3. Start the app (without debugging).
4. The app crashes when clicking the expander.

## Expected behavior

The app should behave identically when run inside and outside Visual Studio. Nested `CommunityToolkit.WinUI.Controls.SettingsExpander` controls should not cause a crash.

## Actual behavior

When a nested `CommunityToolkit.WinUI.Controls.SettingsExpander` is present, the app crashes only when run outside the Visual Studio debugger. Running under the debugger masks the crash and the app appears to run normally.

## Workarounds

- Avoid nesting `CommunityToolkit.WinUI.Controls.SettingsExpander` controls. Consider alternative layouts (for example, using `StackPanel`, `Grid`, `ItemsControl`, or a custom toggle control).
- Run the app under the Visual Studio debugger while investigating (not a permanent solution).

## Environment

- Target framework: .NET 8
- UI framework: WinUI / Windows App SDK

## Machine information (paste your values here)

Provide the machine and environment details used when reproducing the crash. Replace the example values with your actual information.

- Windows version: `Windows 10 25H2 (OS Build 26200.7623)`
- .NET runtime: `Microsoft.NET 8.0.x`
- CommunityToolkit.WinUI.Controls.SettingsControls: `8.2.251219`
- Windows App SDK version: `1.8.260101001`
- Visual Studio: `Visual Studio 2026`

## How to build and test

1. Open the solution in Visual Studio with the Windows App SDK workloads installed.
2. Build the `ExpanderIssue` project.
3. To reproduce the crash, close Visual Studio and run the produced `.exe` (or packaged app) from File Explorer.

## Reporting

If you plan to file a bug with the WinUI / Windows App SDK team, include:

- Reproduction steps (above)
- The built binary or clear instructions to build from this repo
- OS version, .NET runtime version, and Windows App SDK version used when reproducing

---

This repository is a minimal reproduction to aid debugging of a platform issue involving nested `CommunityToolkit.WinUI.Controls.SettingsExpander` controls.
