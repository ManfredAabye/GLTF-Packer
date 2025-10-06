# PBR Material Maker - GLTF-Packer

Der **PBR Material Maker** ist ein einfach zu bedienendes Tool, um aus Texturen automatisch GLTF-Dateien für PBR-Materialien zu erstellen. Die Anwendung ist für Einsteiger geeignet und bietet eine intuitive Oberfläche mit Drag & Drop Unterstützung.

---

## Was ist PBR?

**PBR** steht für *Physically Based Rendering*. Dabei werden Materialien so beschrieben, dass sie möglichst realistisch im 3D-Rendering aussehen. Typische Texturarten sind:
- **Base Color** (Grundfarbe)
- **Normal** (Oberflächenstruktur)
- **Occlusion** (Schatten)
- **Roughness** (Rauheit)
- **Metallic** (Metallanteil)
- **Emission** (Selbstleuchten)
- **Alpha** (Transparenz)

---

## Funktionen im Überblick

### 1. Drag & Drop von Texturen
- Ziehe JPG- oder PNG-Dateien direkt auf die jeweiligen Felder (z.B. Base Color, Normal, etc.).
- Die Anwendung erkennt viele gängige Namensmuster aus Engines wie Unreal, Unity, Godot, O3DE, CryEngine, Stride, Flax, Snowdrop und mehr.

### 2. Automatisches Ausfüllen
- Wird eine Base Color Textur eingefügt, werden passende Texturen für Normal, Occlusion, Roughness, Metallic, Emission und Alpha automatisch gesucht und zugeordnet.
- Fehlen einzelne Maps, werden sie aus der Base Color generiert.

### 3. Auflösung wählen
- Wähle eine Zielauflösung für die Texturen (z.B. 2048x2048, 1024x1024, ... oder eigene Werte).
- Die Texturen werden beim Speichern auf die gewählte Größe skaliert.

### 4. GLTF-Datei erzeugen
- Mit einem Klick auf **Save** werden alle Texturen und die GLTF-Datei im Unterordner `gltf_textures` gespeichert.
- Die GLTF-Datei enthält Verweise auf alle erzeugten Texturen.

### 5. Material Presets
- Über die Materialauswahl können vordefinierte Einstellungen für verschiedene Materialien geladen werden.
- Die Werte für Normal, Roughness, Occlusion, Metallic, Emission und Alpha werden automatisch angepasst.

### 6. Konfiguration über material.json
- Die Datei `material.json` erlaubt die Anpassung der Effektstärken und Presets.
- Beispiel für die wichtigsten Parameter:

| Parameter           | Typ      | Bereich      | Beschreibung                                      |
|---------------------|----------|-------------|---------------------------------------------------|
| NormalStrength      | float    | 0.0 - 1.0   | Stärke der Prägung/Normalmap                      |
| RoughnessStrength   | float    | 0.0 - 1.0   | Stärke der Rauheit                                |
| OcclusionStrength   | float    | 0.0 - 1.0   | Stärke der Schatten/Occlusion                     |
| MetallicThreshold   | int      | 0 - 255     | Schwellenwert für Metallisch                      |
| EmissionStrength    | float    | 0.0 - 1.0   | Stärke der Emission                               |
| AlphaStrength       | float    | 0.0 - 1.0   | Stärke der Transparenz/Alpha                      |
| BaseColorTint       | float[3] | 0.0 - 1.0   | Farb-Tint für die Grundfarbe                      |
| NormalMapType       | string   | "sobel"/... | Typ der Normalmap-Generierung                     |
| RoughnessInvert     | bool     | true/false  | Rauheit invertieren                               |
| MetallicIntensity   | float    | 0.0 - 1.0   | Intensität des Metall-Effekts                     |
| EmissionColor       | float[3] | 0.0 - 1.0   | Farbe für Emission                                |
| AlphaMode           | string   | "opaque"/...| Modus für Transparenz                             |

---

## Schritt-für-Schritt Anleitung

1. **Textur einfügen:** Ziehe eine Textur (z.B. Base Color) auf das entsprechende Feld.
2. **Materialname:** Der Name wird automatisch aus dem Dateinamen vorgeschlagen, kann aber angepasst werden.
3. **Material Preset wählen:** Optional ein Preset auswählen, um die Einstellungen zu übernehmen.
4. **Auflösung wählen:** Die gewünschte Zielgröße für die Texturen auswählen.
5. **Speichern:** Klicke auf **Save**, um alle Maps und die GLTF-Datei zu generieren.

---

## Unterstützte Textur-Endungen

Das Tool erkennt automatisch viele gängige Endungen, z.B.:
- **Normal:** `_normal`, `_nrm`, `_normal-ogl`, `_Normals`, `_normalmap`, ...
- **Metallic:** `_metallic`, `_metal`, `_metalTex`, ...
- **Height/Displacement:** `_height`, `_disp`, `_bump`, ...
- **Occlusion/AO:** `_occlusion`, `_ao`, `_ambientocclusion`, ...
- **Roughness:** `_roughness`, `_rough`, ...
- **Emission:** `_emission`, `_emissive`, `_glow`, ...
- **Alpha/Mask:** `_alpha`, `_opacity`, `_mask`, ...

---

## Hinweise für Einsteiger

- **Mindestens eine Base Color Textur ist erforderlich.**
- Fehlende Maps werden automatisch aus der Base Color berechnet.
- Die generierten Dateien findest du im Unterordner `gltf_textures`.
- Die Anwendung ist für Windows (.NET 10, C# 14.0, WPF) entwickelt.

---

## Lizenz

Siehe [LICENSE](../LICENSE) für weitere Informationen.

---

## Hilfe & Support

Bei Fragen oder Problemen kannst du ein Issue auf GitHub eröffnen oder die Dokumentation im Repository lesen.

