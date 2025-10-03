# DOTNET 10.0 Version von GLTF Packer (Fork von Captain Ai)

Visual Studio 2026 – Windows 11 – .NET 10.0

Diese Version erstellt automatisch nicht vorhandene PBR-Bestandteile (BaseColor, Normal, Occlusion, Roughness, Metallic, Emission, Alpha) und speichert sie im Zielverzeichnis. Die Normalmap wird aus der Albedo berechnet und erhält eine leichte Prägung (Standard: 5 %).

## Features

- Automatische Erzeugung fehlender PBR-Texturen (weiß/schwarz oder generiert)
- Normalmap-Generierung aus Albedo mit Prägung
- Unterstützung für Drag & Drop von Texturen
- Anpassbare Auflösung für alle Maps
- GLTF-Export mit allen relevanten Textur-Referenzen
- Kompatibel mit Windows 11 und Visual Studio 2026 (.NET 10.0)

## Installation

1. Projekt mit Visual Studio 2026 öffnen.
2. Abhängigkeiten installieren (NuGet: Newtonsoft.Json).
3. Anwendung kompilieren und starten.

## Verwendung

1. Ziehe die gewünschte Albedo-Textur per Drag & Drop in das Fenster.
2. Weitere Maps werden automatisch erkannt oder generiert.
3. Wähle die gewünschte Auflösung.
4. Klicke auf „Save“, um die GLTF-Datei und alle Texturen zu exportieren.

## Disclaimer

GLTF Packer steht in keiner Verbindung zu KhronosGroup, glTF, Linden Lab, SecondLife oder OpenSim. Es handelt sich um Drittanbieter-Software.

## Lizenz

Siehe LICENSE-Datei im Repository.
