# PBR Material Maker

Dieses Projekt ist ein GLTF-Packer f�r PBR-Materialien. Es erm�glicht das Drag & Drop von Texturen (JPG/PNG) auf die Oberfl�che und generiert automatisch die zugeh�rigen Maps (Normal, Occlusion, Roughness, Metallic, Emission, Alpha) sowie eine GLTF-Datei.

## Features

- Drag & Drop Unterst�tzung f�r Texturen
- Automatisches Ausf�llen von Materialnamen und zugeh�rigen Maps
- Unterst�tzung f�r verschiedene Aufl�sungen und benutzerdefinierte Gr��en
- Generierung von GLTF-Dateien inklusive aller Texturen
- Fehlende Bestandteile (Normal, Occlusion, Roughness, Metallic, Emission, Alpha) werden automatisch aus der Base Color Datei erzeugt, falls keine eigenen Texturen vorhanden sind.
- Unterst�tzt .NET 10 und C# 14.0
- WPF-Oberfl�che

## Bedienung

1. Ziehe eine Textur auf das entsprechende Feld.
2. W�hle die gew�nschte Aufl�sung.
3. Klicke auf "Save", um die Maps und die GLTF-Datei zu generieren.

## Hinweise

- Die Anwendung ben�tigt mindestens eine Base Color Textur.
- Die generierten Dateien werden im Unterordner `gltf_textures` gespeichert.

## Lizenz

Siehe [LICENSE](../LICENSE) f�r weitere Informationen.