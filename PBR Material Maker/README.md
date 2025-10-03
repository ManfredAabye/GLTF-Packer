# PBR Material Maker

Dieses Projekt ist ein GLTF-Packer für PBR-Materialien. Es ermöglicht das Drag & Drop von Texturen (JPG/PNG) auf die Oberfläche und generiert automatisch die zugehörigen Maps (Normal, Occlusion, Roughness, Metallic, Emission, Alpha) sowie eine GLTF-Datei.

## Features

- Drag & Drop Unterstützung für Texturen
- Automatisches Ausfüllen von Materialnamen und zugehörigen Maps
- Unterstützung für verschiedene Auflösungen und benutzerdefinierte Größen
- Generierung von GLTF-Dateien inklusive aller Texturen
- Fehlende Bestandteile (Normal, Occlusion, Roughness, Metallic, Emission, Alpha) werden automatisch aus der Base Color Datei erzeugt, falls keine eigenen Texturen vorhanden sind.
- Unterstützt .NET 10 und C# 14.0
- WPF-Oberfläche

## Bedienung

1. Ziehe eine Textur auf das entsprechende Feld.
2. Wähle die gewünschte Auflösung.
3. Klicke auf "Save", um die Maps und die GLTF-Datei zu generieren.

## Hinweise

- Die Anwendung benötigt mindestens eine Base Color Textur.
- Die generierten Dateien werden im Unterordner `gltf_textures` gespeichert.

## Lizenz

Siehe [LICENSE](../LICENSE) für weitere Informationen.