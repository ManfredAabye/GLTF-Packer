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

## Konfiguration: material.json

Die Datei `material.json` erlaubt die Anpassung der Effektstärken für die Generierung der Maps. Die Werte können wie folgt eingestellt werden:

| Parameter           | Minimalwert | Maximalwert | Beschreibung                                      |
|---------------------|-------------|-------------|---------------------------------------------------|
| NormalStrength      | 0.0         | 1.0         | Stärke der Prägung/Normalmap                      |
| RoughnessStrength   | 0.0         | 1.0         | Stärke der Rauheit                                |
| OcclusionStrength   | 0.0         | 1.0         | Stärke der Schatten/Occlusion                     |
| MetallicThreshold   | 0           | 255         | Schwellenwert für Metallisch                      |
| EmissionStrength    | 0.0         | 1.0         | Stärke der Emission                               |
| AlphaStrength       | 0.0         | 1.0         | Stärke der Transparenz/Alpha                      |

**Hinweis:** Werte außerhalb des Bereichs können zu unerwarteten Ergebnissen führen.

## Bedienung

1. Ziehe eine Textur auf das entsprechende Feld.
2. Wähle die gewünschte Auflösung.
3. Klicke auf "Save", um die Maps und die GLTF-Datei zu generieren.

## Hinweise

- Die Anwendung benötigt mindestens eine Base Color Textur.
- Die generierten Dateien werden im Unterordner `gltf_textures` gespeichert.

## Lizenz

Siehe [LICENSE](../LICENSE) für weitere Informationen.