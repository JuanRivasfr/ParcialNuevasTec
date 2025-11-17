# 🎮 GUÍA COMPLETA: CONFIGURAR CODE FIGHTERS - BUG WARS EN UNITY

## 📋 ÍNDICE
1. [Preparación Inicial](#1-preparación-inicial)
2. [Configurar MainMenu](#2-configurar-mainmenu)
3. [Configurar IntroNarrativa](#3-configurar-intronarrativa)
4. [Configurar CiberDojo](#4-configurar-ciberdojo)
5. [Configurar TrainingProtocol](#5-configurar-trainingprotocol)
6. [Configurar BattleScene](#6-configurar-battlescene)
7. [Configurar VictoryScreen](#7-configurar-victoryscreen)
8. [Configurar GameOverScreen](#8-configurar-gameoverscreen)
9. [Configurar Settings](#9-configurar-settings)
10. [Configurar SceneRouter](#10-configurar-scenerouter)
11. [Crear ScriptableObjects](#11-crear-scriptableobjects)

---

## 1. PREPARACIÓN INICIAL

### Paso 1.1: Abrir Unity y verificar escenas
1. Abre Unity Editor
2. En el **Project Window** (abajo), ve a `Assets/Scenes/`
3. Verifica que existan estas escenas:
   - MainMenu
   - IntroNarrativa
   - CiberDojo
   - TrainingProtocol
   - BattleScene
   - VictoryScreen
   - GameOverScreen
   - Settings

### Paso 1.2: Configurar Build Settings
1. Ve a **File > Build Settings**
2. Arrastra todas las escenas desde `Assets/Scenes/` a la lista de "Scenes In Build"
3. Asegúrate de que **MainMenu** esté en el índice 0 (arrastra para reordenar)
4. Cierra Build Settings

---

## 2. CONFIGURAR MAINMENU

### Paso 2.1: Abrir la escena MainMenu
1. Doble clic en `Assets/Scenes/MainMenu.unity/MainMenu.unity` (o la ruta donde esté)

### Paso 2.2: Crear el Canvas (si no existe)
1. Click derecho en la **Hierarchy** (panel izquierdo)
2. **UI > Canvas**
3. Se creará automáticamente un **EventSystem** también

### Paso 2.3: Configurar MainMenuInitializer
1. Click derecho en **Hierarchy**
2. **Create Empty** → Renómbralo a "MainMenuInitializer"
3. En el **Inspector** (panel derecho), click en **Add Component**
4. Busca y agrega: **MainMenuInitializer**
5. En el componente:
   - ✅ Marca "Auto Setup On Start"
   - ✅ Marca "Setup Complete" (después de la primera ejecución)

### Paso 2.4: Configurar MainMenuController (alternativa manual)
Si prefieres configurar manualmente:

1. Click derecho en **Hierarchy** → **Create Empty** → "MainMenuController"
2. **Add Component** → **MainMenuController**
3. Crea los botones manualmente:
   - Click derecho en **Canvas** → **UI > Button - TextMeshPro**
   - Renómbralo a "Button_Iniciar"
   - Duplica este botón 5 veces para: Continuar, Historia, Tutorial, Configuración, Salir
4. Arrastra cada botón al campo correspondiente en **MainMenuController**

### Paso 2.5: Probar MainMenu
1. Click en el botón **Play** ▶️ (arriba del editor)
2. Deberías ver el menú con fondo azul y botones neon
3. Click **Stop** ⏹️

---

## 3. CONFIGURAR INTRONARRATIVA

### Paso 3.1: Abrir escena IntroNarrativa
1. Doble clic en la escena `IntroNarrativa`

### Paso 3.2: Crear Canvas y Panel de Diálogo
1. **Hierarchy** → Click derecho → **UI > Canvas**
2. Click derecho en **Canvas** → **UI > Panel** → Renómbralo a "DialoguePanel"
3. Configura el Panel:
   - **Anchor Presets**: Presiona **Alt + Shift** y click en "stretch-stretch" (esquinas)
   - **Position**: X:0, Y:0
   - **Width**: 1920, **Height**: 400
   - **Color**: Negro semi-transparente (R:0, G:0, B:0, A:200)

### Paso 3.3: Crear Borde Neon Azul
1. Click derecho en **DialoguePanel** → **UI > Image**
2. Renómbralo a "Border"
3. En el **Inspector**:
   - **Image Type**: Simple
   - **Color**: Azul neon (R:0, G:200, B:255, A:255)
   - **Rect Transform**: 
     - **Anchor Presets**: Stretch-Stretch
     - **Left/Right/Top/Bottom**: 2 (para crear un borde de 2px)

### Paso 3.4: Crear Avatar
1. Click derecho en **DialoguePanel** → **UI > Image** → "Avatar"
2. **Rect Transform**:
   - **Anchor**: Bottom-Left
   - **Position**: X:50, Y:50
   - **Width**: 100, **Height**: 100
3. Más adelante asignarás el sprite del avatar

### Paso 3.5: Crear Texto del Hablante
1. Click derecho en **DialoguePanel** → **UI > Text - TextMeshPro**
2. Renómbralo a "SpeakerName"
3. **Rect Transform**:
   - **Anchor**: Top-Left
   - **Position**: X:150, Y:-20
   - **Width**: 500, **Height**: 40
4. **TextMeshProUGUI**:
   - **Text**: "> NARRATOR"
   - **Font Size**: 24
   - **Color**: Blanco
   - **Alignment**: Left

### Paso 3.6: Crear Texto del Diálogo
1. Click derecho en **DialoguePanel** → **UI > Text - TextMeshPro** → "DialogueText"
2. **Rect Transform**:
   - **Anchor**: Stretch-Stretch
   - **Left**: 150, **Right**: 50, **Top**: 50, **Bottom**: 80
3. **TextMeshProUGUI**:
   - **Text**: "Texto del diálogo aparecerá aquí..."
   - **Font Size**: 20
   - **Color**: Blanco
   - **Alignment**: Left-Top
   - **Wrapping**: Enabled

### Paso 3.7: Crear Botón NEXT
1. Click derecho en **DialoguePanel** → **UI > Button - TextMeshPro** → "NextButton"
2. **Rect Transform**:
   - **Anchor**: Bottom-Right
   - **Position**: X:-50, Y:30
   - **Width**: 150, **Height**: 40
3. En el hijo "Text (TMP)":
   - **Text**: "NEXT >"
   - **Font Size**: 20
   - **Color**: Blanco

### Paso 3.8: Crear Barra de Progreso
1. Click derecho en **DialoguePanel** → **UI > Image** → "ProgressBarBackground"
2. **Rect Transform**:
   - **Anchor**: Bottom-Left
   - **Position**: X:150, Y:10
   - **Width**: 300, **Height**: 5
3. **Color**: Gris oscuro
4. Click derecho en **ProgressBarBackground** → **UI > Image** → "ProgressBarFill"
5. **Image Type**: Filled
6. **Fill Method**: Horizontal
7. **Color**: Azul neon

### Paso 3.9: Crear Texto de Progreso
1. Click derecho en **DialoguePanel** → **UI > Text - TextMeshPro** → "ProgressText"
2. **Rect Transform**: Sobre la barra de progreso
3. **Text**: "1/5"

### Paso 3.10: Configurar DialogueSystem
1. Click derecho en **Hierarchy** → **Create Empty** → "DialogueSystem"
2. **Add Component** → **DialogueSystem**
3. Arrastra los elementos al componente:
   - **Dialogue Panel**: DialoguePanel
   - **Avatar Image**: Avatar
   - **Speaker Name Text**: SpeakerName
   - **Dialogue Text**: DialogueText
   - **Next Button**: NextButton
   - **Progress Bar**: ProgressBarFill
   - **Progress Text**: ProgressText

### Paso 3.11: Configurar IntroNarrativaInitializer
1. Click derecho en **Hierarchy** → **Create Empty** → "IntroNarrativaInitializer"
2. **Add Component** → **IntroNarrativaInitializer**
3. Más adelante asignarás el DialogueSequence aquí

---

## 4. CONFIGURAR CIBERDOJO

### Paso 4.1: Abrir escena CiberDojo

### Paso 4.2: Crear Canvas
1. **UI > Canvas**

### Paso 4.3: Crear Fondo
1. Click derecho en **Canvas** → **UI > Image** → "Background"
2. **Anchor Presets**: Stretch-Stretch
3. **Color**: Azul oscuro (R:0, G:20, B:40)
4. (Opcional: Agregar sprite de mundo)

### Paso 4.4: Crear Título
1. Click derecho en **Canvas** → **UI > Text - TextMeshPro** → "Title"
2. **Text**: "CIBERDOJO"
3. **Font Size**: 60
4. **Position**: Top-Center

### Paso 4.5: Crear Contenedor de Nodos
1. Click derecho en **Canvas** → **UI > Panel** → "LevelNodesContainer"
2. **Anchor Presets**: Stretch-Stretch
3. **Add Component** → **Grid Layout Group** (para organizar nodos)
4. **Cell Size**: X:100, Y:100
5. **Spacing**: X:50, Y:50

### Paso 4.6: Crear Prefab de Nodo de Nivel
1. Click derecho en **LevelNodesContainer** → **UI > Button - TextMeshPro** → "LevelNode"
2. **Rect Transform**: Width:100, Height:100
3. **Add Component** → **LevelNodeUI**
4. Crear hijos:
   - **UI > Image** → "NodeIcon" (icono del nivel)
   - **UI > Image** → "LockIcon" (candado, visible cuando está bloqueado)
   - **UI > Image** → "CheckmarkIcon" (check, visible cuando está completado)
   - **UI > Text - TextMeshPro** → "LevelNameText" (nombre del nivel)
5. Arrastra estos elementos a **LevelNodeUI**
6. Arrastra **LevelNode** desde Hierarchy a `Assets/Prefabs/UI/` para crear el prefab
7. Elimina el nodo de la escena (ya tienes el prefab)

### Paso 4.7: Crear Panel de Información
1. Click derecho en **Canvas** → **UI > Panel** → "InfoPanel"
2. **Anchor**: Bottom-Center
3. **Position**: Y:50
4. **Width**: 400, **Height**: 100
5. Crear textos hijos:
   - "MissionsCompletedText" → "Misiones Completadas: 0/5"
   - "TotalXPText" → "XP Total: 0"

### Paso 4.8: Crear Botones
1. **UI > Button - TextMeshPro** → "BackToMenuButton"
   - **Text**: "VOLVER AL MENÚ"
2. **UI > Button - TextMeshPro** → "TutorialButton"
   - **Text**: "TUTORIAL DE HABILIDADES"

### Paso 4.9: Configurar DojoManager
1. Click derecho en **Hierarchy** → **Create Empty** → "DojoManager"
2. **Add Component** → **DojoManager**
3. Arrastra elementos:
   - **Level Nodes Container**: LevelNodesContainer
   - **Level Node Prefab**: El prefab que creaste
   - **Back To Menu Button**: BackToMenuButton
   - **Tutorial Button**: TutorialButton
   - **Missions Completed Text**: MissionsCompletedText
   - **Total XP Text**: TotalXPText
4. Más adelante asignarás el array de **All Levels**

---

## 5. CONFIGURAR TRAININGPROTOCOL

### Paso 5.1: Abrir escena TrainingProtocol

### Paso 5.2: Crear Canvas y Título
1. **UI > Canvas**
2. **UI > Text - TextMeshPro** → "Title"
   - **Text**: "TRAINING PROTOCOL"
   - **Font Size**: 50

### Paso 5.3: Crear Contenedor de Tarjetas de Habilidades
1. **UI > Panel** → "SkillCardsContainer"
2. **Add Component** → **Horizontal Layout Group**
3. **Spacing**: 20
4. **Child Alignment**: Middle Center

### Paso 5.4: Crear Prefab de Tarjeta de Habilidad
1. **UI > Panel** → "SkillCard"
2. **Width**: 250, **Height**: 300
3. **Add Component** → **SkillCardUI**
4. Crear hijos:
   - **UI > Image** → "SkillIcon"
   - **UI > Text - TextMeshPro** → "SkillNameText"
   - **UI > Text - TextMeshPro** → "DescriptionText"
   - **UI > Text - TextMeshPro** → "PowerLevelText"
   - **UI > Button - TextMeshPro** → "ViewDetailsButton"
5. Arrastra estos elementos a **SkillCardUI**
6. Crea el prefab en `Assets/Prefabs/UI/SkillCard.prefab`

### Paso 5.5: Crear Botones
1. **UI > Button - TextMeshPro** → "StartBattleButton"
   - **Text**: "START BATTLE"
2. **UI > Button - TextMeshPro** → "BackButton"
   - **Text**: "BACK"

### Paso 5.6: Configurar TrainingProtocolManager
1. **Create Empty** → "TrainingProtocolManager"
2. **Add Component** → **TrainingProtocolManager**
3. Arrastra:
   - **Skill Cards Container**: SkillCardsContainer
   - **Skill Card Prefab**: El prefab de SkillCard
   - **Start Battle Button**: StartBattleButton
   - **Back Button**: BackButton
4. Más adelante asignarás el array de **Available Skills**

---

## 6. CONFIGURAR BATTLESCENE

### Paso 6.1: Abrir escena BattleScene

### Paso 6.2: Crear Canvas

### Paso 6.3: Crear HUD Superior (Barras de Vida)
1. **UI > Panel** → "TopHUD"
2. **Anchor**: Top-Stretch
3. **Height**: 100
4. Crear dos paneles hijos:
   - "PlayerHealthPanel" (izquierda)
   - "EnemyHealthPanel" (derecha)
5. En cada panel:
   - **UI > Text - TextMeshPro** → "NameText"
   - **UI > Image** → "HealthBarBackground"
   - **UI > Image** → "HealthBarFill" (Fill Method: Horizontal)
   - **UI > Text - TextMeshPro** → "HealthText"
6. **Add Component** → **HealthBar** a cada panel
7. Arrastra los elementos a cada **HealthBar**

### Paso 6.4: Crear Personajes (Placeholders)
1. Click derecho en **Hierarchy** (fuera del Canvas) → **Create Empty** → "Player"
2. **Add Component** → **Player**
3. Configura stats en el Inspector
4. Repite para "Enemy" con componente **Enemy**

### Paso 6.5: Crear Panel de Preguntas (Inferior)
1. **UI > Panel** → "QuestionPanel"
2. **Anchor**: Bottom-Stretch
3. **Height**: 300
4. Crear:
   - **UI > Text - TextMeshPro** → "QuestionText"
   - **UI > Button - TextMeshPro** → "AnswerButton1"
   - **UI > Button - TextMeshPro** → "AnswerButton2"
   - **UI > Button - TextMeshPro** → "AnswerButton3"
5. Organiza los botones verticalmente

### Paso 6.6: Crear Barra de Energía
1. **UI > Image** → "EnergyBarBackground"
2. **UI > Image** → "EnergyBarFill" (Fill Method: Horizontal)
3. **UI > Text - TextMeshPro** → "EnergyText"

### Paso 6.7: Configurar BattleManager
1. **Create Empty** → "BattleManager"
2. **Add Component** → **BattleManager**
3. **Add Component** → **TurnSystem**
4. Arrastra todas las referencias:
   - **Player**: Player
   - **Enemy**: Enemy
   - **Player Health Bar**: PlayerHealthPanel
   - **Enemy Health Bar**: EnemyHealthPanel
   - **Question System**: (crear GameObject con QuestionSystem)
   - **Turn System**: El mismo BattleManager
   - **Energy Bar**: EnergyBarFill
   - **Energy Text**: EnergyText

### Paso 6.8: Configurar QuestionSystem
1. **Create Empty** → "QuestionSystem"
2. **Add Component** → **QuestionSystem**
3. Arrastra:
   - **Question Text**: QuestionText
   - **Answer Buttons**: Los 3 botones
   - **Answer Texts**: Los textos de los botones
4. Más adelante asignarás el array de **Questions**

---

## 7. CONFIGURAR VICTORYSCREEN

### Paso 7.1: Abrir escena VictoryScreen

### Paso 7.2: Crear Canvas y Fondo
1. **UI > Canvas**
2. **UI > Image** → "Background"
   - **Color**: Azul suave con puntos (o sprite)

### Paso 7.3: Crear Título
1. **UI > Text - TextMeshPro** → "TitleText"
   - **Text**: "¡VICTORIA!"
   - **Font Size**: 72

### Paso 7.4: Crear Panel de Estadísticas
1. **UI > Panel** → "StatsPanel"
2. Crear textos hijos:
   - "TimeText" → "Tiempo: 00:00"
   - "CorrectAnswersText" → "Respuestas Correctas: 0"
   - "XPGainedText" → "XP Ganada: +0"
   - "LevelReachedText" → "Nivel: 1"

### Paso 7.5: Crear Botones
1. **UI > Button - TextMeshPro** → "BackToDojoButton"
2. **UI > Button - TextMeshPro** → "RepeatBattleButton"
3. **UI > Button - TextMeshPro** → "ContinueStoryButton"

### Paso 7.6: Configurar VictoryScreen
1. **Create Empty** → "VictoryScreen"
2. **Add Component** → **VictoryScreen**
3. Arrastra todos los elementos

---

## 8. CONFIGURAR GAMEOVERSCREEN

### Paso 8.1: Similar a VictoryScreen pero:
- Fondo rojo oscuro
- Título: "YOU WERE DEBUGGED!"
- Panel de errores en lugar de estadísticas
- Solo 2 botones: Retry y GoToDojo

---

## 9. CONFIGURAR SETTINGS

### Paso 9.1: Abrir escena Settings

### Paso 9.2: Crear Canvas y Título
1. **UI > Canvas**
2. **UI > Text - TextMeshPro** → "Title" → "CONFIGURACIÓN"

### Paso 9.3: Crear Sliders de Audio
1. **UI > Slider** → "MasterVolumeSlider"
   - **Label**: "Volumen General"
2. **UI > Slider** → "MusicVolumeSlider"
   - **Label**: "Volumen Música"
3. **UI > Slider** → "EffectsVolumeSlider"
   - **Label**: "Volumen Efectos"

### Paso 9.4: Crear Campo de Nombre
1. **UI > Input Field - TextMeshPro** → "PlayerNameInput"
   - **Placeholder**: "Nombre del jugador"

### Paso 9.5: Crear Dropdown de Idioma
1. **UI > Dropdown - TextMeshPro** → "LanguageDropdown"
2. En **Dropdown**, agrega opciones: Español, English, etc.

### Paso 9.6: Crear Toggle de Accesibilidad
1. **UI > Toggle** → "AccessibilityModeToggle"
   - **Label**: "Modo Accesibilidad"

### Paso 9.7: Crear Botones
1. **UI > Button - TextMeshPro** → "SaveButton" → "GUARDAR"
2. **UI > Button - TextMeshPro** → "BackButton" → "VOLVER"

### Paso 9.8: Configurar SettingsManager
1. **Create Empty** → "SettingsManager"
2. **Add Component** → **SettingsManager**
3. Arrastra todos los elementos

---

## 10. CONFIGURAR SCENEROUTER

### Paso 10.1: Crear GameObject Persistente
1. En **cualquier escena** (recomiendo MainMenu):
2. **Create Empty** → "SceneRouter"
3. **Add Component** → **SceneRouter**
4. En el Inspector, marca **Dont Destroy On Load** (esto ya está en el código)

### Paso 10.2: Verificar Nombres de Escenas
1. En **SceneRouter**, verifica que los nombres coincidan:
   - Main Menu Scene: "MainMenu"
   - Intro Narrativa Scene: "IntroNarrativa"
   - etc.

---

## 11. CREAR SCRIPTABLEOBJECTS

### Paso 11.1: Crear DialogueSequence
1. En **Project Window**, click derecho en `Assets/`
2. **Create > Code Fighters > Dialogue Sequence**
3. Renómbralo a "InitialNarrative"
4. En el Inspector:
   - **Dialogue Lines**: Click en el **+** para agregar líneas
   - Para cada línea:
     - **Speaker Name**: "NARRATOR", "SYSTEM", "ZEVEN"
     - **Speaker Type**: Selecciona el tipo
     - **Dialogue Text**: Escribe el texto
     - **Auto Advance Delay**: 0 (manual) o segundos para auto

### Paso 11.2: Crear LevelData
1. **Create > Code Fighters > Level Data**
2. Crea uno por cada nivel (Level1, Level2, etc.)
3. Configura:
   - **Level Name**: "Nivel 1"
   - **Level Description**: Descripción
   - **Level ID**: 0, 1, 2, etc.
   - **Required XP**: XP necesaria para desbloquear
   - **Reward XP**: XP que da al completar
   - **Level Icon**: Sprite del icono
   - **Scene To Load**: "BattleScene"

### Paso 11.3: Crear SkillDefinition
1. **Create > Code Fighters > Skill Definition**
2. Crea: PrintAttack, LoopKick, FilterCutter, ElseCounter
3. Configura:
   - **Skill Name**: "Print Attack"
   - **Description**: Descripción de la habilidad
   - **Power Level**: 1-10
   - **Energy Cost**: Costo de energía
   - **Skill Icon**: Sprite del icono
   - **Skill Type**: Selecciona el tipo

### Paso 11.4: Asignar ScriptableObjects
1. **IntroNarrativaInitializer**: Arrastra "InitialNarrative" a **Initial Narrative**
2. **DojoManager**: Arrastra todos los LevelData a **All Levels**
3. **TrainingProtocolManager**: Arrastra todos los SkillDefinition a **Available Skills**
4. **QuestionSystem**: En el Inspector, agrega preguntas al array **Questions**

---

## ✅ CHECKLIST FINAL

- [ ] Todas las escenas tienen Canvas
- [ ] MainMenu tiene MainMenuInitializer o está configurado manualmente
- [ ] IntroNarrativa tiene DialogueSystem configurado
- [ ] CiberDojo tiene DojoManager con niveles asignados
- [ ] TrainingProtocol tiene TrainingProtocolManager con habilidades
- [ ] BattleScene tiene BattleManager y QuestionSystem
- [ ] VictoryScreen y GameOverScreen están configurados
- [ ] Settings tiene SettingsManager
- [ ] SceneRouter existe y está configurado
- [ ] Todos los ScriptableObjects están creados y asignados
- [ ] Build Settings tiene todas las escenas

---

## 🎯 PRUEBA EL JUEGO

1. Abre la escena **MainMenu**
2. Click **Play** ▶️
3. Prueba cada botón y verifica que las transiciones funcionen
4. Si algo no funciona, revisa la **Console** (Window > General > Console) para ver errores

---

## 🆘 SOLUCIÓN DE PROBLEMAS

### Error: "SceneRouter.Instance is null"
- Asegúrate de que existe un GameObject "SceneRouter" con el componente en alguna escena

### Error: "Missing reference"
- Verifica que todos los campos en los componentes estén asignados (no deben estar vacíos)

### Los botones no funcionan
- Verifica que el EventSystem existe en la escena
- Verifica que los botones tienen el componente Button

### Las escenas no cargan
- Verifica los nombres en SceneRouter coinciden con los nombres reales de las escenas
- Verifica que las escenas están en Build Settings

---

¡Éxito! Tu juego debería estar completamente funcional. 🎮✨

