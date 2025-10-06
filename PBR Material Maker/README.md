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

## Konfiguration: material.json

Die Datei `material.json` erlaubt die Anpassung der Effektst�rken f�r die Generierung der Maps. Die Werte k�nnen wie folgt eingestellt werden:

| Parameter           | Minimalwert | Maximalwert | Beschreibung                                      |
|---------------------|-------------|-------------|---------------------------------------------------|
| NormalStrength      | 0.0         | 1.0         | St�rke der Pr�gung/Normalmap                      |
| RoughnessStrength   | 0.0         | 1.0         | St�rke der Rauheit                                |
| OcclusionStrength   | 0.0         | 1.0         | St�rke der Schatten/Occlusion                     |
| MetallicThreshold   | 0           | 255         | Schwellenwert f�r Metallisch                      |
| EmissionStrength    | 0.0         | 1.0         | St�rke der Emission                               |
| AlphaStrength       | 0.0         | 1.0         | St�rke der Transparenz/Alpha                      |

**Hinweis:** Werte au�erhalb des Bereichs k�nnen zu unerwarteten Ergebnissen f�hren.

## Bedienung

1. Ziehe eine Textur auf das entsprechende Feld.
2. W�hle die gew�nschte Aufl�sung.
3. Klicke auf "Save", um die Maps und die GLTF-Datei zu generieren.

## Hinweise

- Die Anwendung ben�tigt mindestens eine Base Color Textur.
- Die generierten Dateien werden im Unterordner `gltf_textures` gespeichert.

## Lizenz

Siehe [LICENSE](../LICENSE) f�r weitere Informationen.