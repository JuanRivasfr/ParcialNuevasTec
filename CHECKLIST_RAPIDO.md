# ✅ CHECKLIST RÁPIDO - CODE FIGHTERS BUG WARS

## 🚀 INICIO RÁPIDO (5 minutos)

### 1. Verificar que todo existe
- [ ] Abre Unity
- [ ] Ve a `Assets/Scenes/` - ¿Ves las 8 escenas?
- [ ] Ve a `Assets/Scripts/` - ¿Ves todas las carpetas de scripts?

### 2. Configurar Build Settings
- [ ] **File > Build Settings**
- [ ] Arrastra TODAS las escenas a "Scenes In Build"
- [ ] MainMenu debe estar en posición 0

---

## 📝 CONFIGURACIÓN POR ESCENA (Sigue el orden)

### 🏠 MAINMENU (Escena Principal)
- [ ] Abre la escena MainMenu
- [ ] Click derecho en Hierarchy → **UI > Canvas**
- [ ] Click derecho en Hierarchy → **Create Empty** → "MainMenuInitializer"
- [ ] Selecciona MainMenuInitializer → **Add Component** → Busca "MainMenuInitializer"
- [ ] ✅ Marca "Auto Setup On Start"
- [ ] Click **Play** ▶️ - ¿Aparece el menú? → ✅ Listo

### 📖 INTRONARRATIVA (Diálogos)
- [ ] Abre IntroNarrativa
- [ ] **UI > Canvas**
- [ ] **UI > Panel** → Renombra a "DialoguePanel"
- [ ] En DialoguePanel, crea:
  - [ ] **UI > Image** → "Avatar" (izquierda)
  - [ ] **UI > Text - TextMeshPro** → "SpeakerName" (arriba)
  - [ ] **UI > Text - TextMeshPro** → "DialogueText" (centro)
  - [ ] **UI > Button - TextMeshPro** → "NextButton" (abajo derecha)
  - [ ] **UI > Image** → "ProgressBarFill" (abajo)
  - [ ] **UI > Text - TextMeshPro** → "ProgressText"
- [ ] **Create Empty** → "DialogueSystem" → **Add Component** → "DialogueSystem"
- [ ] Arrastra TODOS los elementos al componente DialogueSystem
- [ ] **Create Empty** → "IntroNarrativaInitializer" → **Add Component** → "IntroNarrativaInitializer"

### 🗺️ CIBERDOJO (Mapa de Niveles)
- [ ] Abre CiberDojo
- [ ] **UI > Canvas**
- [ ] **UI > Text - TextMeshPro** → "Title" → Text: "CIBERDOJO"
- [ ] **UI > Panel** → "LevelNodesContainer"
- [ ] **UI > Button - TextMeshPro** → "LevelNode" (prefab)
  - [ ] Agrega componente **LevelNodeUI**
  - [ ] Crea hijos: Icon, LockIcon, CheckmarkIcon, LevelNameText
  - [ ] Arrastra a `Assets/Prefabs/UI/LevelNode.prefab`
- [ ] **UI > Button** → "BackToMenuButton" → Text: "VOLVER AL MENÚ"
- [ ] **UI > Button** → "TutorialButton" → Text: "TUTORIAL"
- [ ] **UI > Text - TextMeshPro** → "MissionsCompletedText"
- [ ] **UI > Text - TextMeshPro** → "TotalXPText"
- [ ] **Create Empty** → "DojoManager" → **Add Component** → "DojoManager"
- [ ] Arrastra TODOS los elementos a DojoManager

### 🎓 TRAININGPROTOCOL (Tutorial)
- [ ] Abre TrainingProtocol
- [ ] **UI > Canvas**
- [ ] **UI > Text - TextMeshPro** → "Title" → "TRAINING PROTOCOL"
- [ ] **UI > Panel** → "SkillCardsContainer"
- [ ] **UI > Panel** → "SkillCard" (prefab)
  - [ ] Agrega componente **SkillCardUI**
  - [ ] Crea hijos: SkillIcon, SkillNameText, DescriptionText, PowerLevelText, ViewDetailsButton
  - [ ] Arrastra a `Assets/Prefabs/UI/SkillCard.prefab`
- [ ] **UI > Button** → "StartBattleButton" → "START BATTLE"
- [ ] **UI > Button** → "BackButton" → "BACK"
- [ ] **Create Empty** → "TrainingProtocolManager" → **Add Component** → "TrainingProtocolManager"
- [ ] Arrastra elementos al componente

### ⚔️ BATTLESCENE (Combate)
- [ ] Abre BattleScene
- [ ] **UI > Canvas**
- [ ] **UI > Panel** → "TopHUD"
  - [ ] Crea "PlayerHealthPanel" (izquierda) con **HealthBar**
  - [ ] Crea "EnemyHealthPanel" (derecha) con **HealthBar**
- [ ] **Create Empty** → "Player" → **Add Component** → "Player"
- [ ] **Create Empty** → "Enemy" → **Add Component** → "Enemy"
- [ ] **UI > Panel** → "QuestionPanel" (abajo)
  - [ ] **UI > Text - TextMeshPro** → "QuestionText"
  - [ ] **UI > Button** → "AnswerButton1", "AnswerButton2", "AnswerButton3"
- [ ] **UI > Image** → "EnergyBarFill"
- [ ] **UI > Text - TextMeshPro** → "EnergyText"
- [ ] **Create Empty** → "BattleManager" → **Add Component** → "BattleManager" + "TurnSystem"
- [ ] **Create Empty** → "QuestionSystem" → **Add Component** → "QuestionSystem"
- [ ] Arrastra TODOS los elementos a BattleManager y QuestionSystem

### 🏆 VICTORYSCREEN
- [ ] Abre VictoryScreen
- [ ] **UI > Canvas**
- [ ] **UI > Text - TextMeshPro** → "TitleText" → "¡VICTORIA!"
- [ ] **UI > Panel** → "StatsPanel"
  - [ ] Crea textos: TimeText, CorrectAnswersText, XPGainedText, LevelReachedText
- [ ] **UI > Button** → "BackToDojoButton", "RepeatBattleButton", "ContinueStoryButton"
- [ ] **Create Empty** → "VictoryScreen" → **Add Component** → "VictoryScreen"
- [ ] Arrastra elementos

### 💀 GAMEOVERSCREEN
- [ ] Similar a VictoryScreen pero:
- [ ] Fondo rojo
- [ ] Título: "YOU WERE DEBUGGED!"
- [ ] Panel de errores: ErrorTypeText, ErrorLineText, ErrorMessageText, FinalScoreText
- [ ] Solo 2 botones: RetryButton, GoToDojoButton
- [ ] **Create Empty** → "GameOverScreen" → **Add Component** → "GameOverScreen"

### ⚙️ SETTINGS
- [ ] Abre Settings
- [ ] **UI > Canvas**
- [ ] **UI > Text - TextMeshPro** → "Title" → "CONFIGURACIÓN"
- [ ] **UI > Slider** → "MasterVolumeSlider", "MusicVolumeSlider", "EffectsVolumeSlider"
- [ ] **UI > Input Field - TextMeshPro** → "PlayerNameInput"
- [ ] **UI > Dropdown - TextMeshPro** → "LanguageDropdown"
- [ ] **UI > Toggle** → "AccessibilityModeToggle"
- [ ] **UI > Button** → "SaveButton", "BackButton"
- [ ] **Create Empty** → "SettingsManager" → **Add Component** → "SettingsManager"
- [ ] Arrastra elementos

---

## 🔗 CONFIGURAR SCENEROUTER (IMPORTANTE)

- [ ] En **cualquier escena** (recomiendo MainMenu):
- [ ] **Create Empty** → "SceneRouter"
- [ ] **Add Component** → "SceneRouter"
- [ ] Verifica que los nombres de escenas coincidan

---

## 📦 CREAR SCRIPTABLEOBJECTS

### DialogueSequence
- [ ] Click derecho en `Assets/` → **Create > Code Fighters > Dialogue Sequence**
- [ ] Renombra a "InitialNarrative"
- [ ] Agrega líneas de diálogo (click en **+**)
- [ ] Asigna a **IntroNarrativaInitializer** → Initial Narrative

### LevelData (Crea varios)
- [ ] **Create > Code Fighters > Level Data**
- [ ] Crea: Level1, Level2, Level3, etc.
- [ ] Configura: Name, ID, Required XP, Reward XP
- [ ] Asigna a **DojoManager** → All Levels (array)

### SkillDefinition (Crea 4)
- [ ] **Create > Code Fighters > Skill Definition**
- [ ] Crea: PrintAttack, LoopKick, FilterCutter, ElseCounter
- [ ] Configura cada uno
- [ ] Asigna a **TrainingProtocolManager** → Available Skills

### Questions (En QuestionSystem)
- [ ] Selecciona el GameObject "QuestionSystem" en BattleScene
- [ ] En el Inspector, en **Questions** array, click **+**
- [ ] Agrega preguntas con respuestas y respuestas correctas

---

## 🎯 PRUEBA FINAL

- [ ] Abre MainMenu
- [ ] Click **Play** ▶️
- [ ] Prueba cada botón:
  - [ ] Iniciar → ¿Va a IntroNarrativa?
  - [ ] Continuar → ¿Va a CiberDojo?
  - [ ] Historia → ¿Va a IntroNarrativa?
  - [ ] Tutorial → ¿Va a TrainingProtocol?
  - [ ] Configuración → ¿Va a Settings?
  - [ ] Salir → ¿Cierra el juego?

---

## 🆘 SI ALGO NO FUNCIONA

1. **Revisa la Console**: Window > General > Console
2. **Verifica referencias**: Todos los campos deben estar asignados (no vacíos)
3. **Verifica nombres**: Los nombres de escenas en SceneRouter deben coincidir exactamente
4. **Verifica Build Settings**: Todas las escenas deben estar agregadas

---

## 📚 DOCUMENTACIÓN COMPLETA

Para instrucciones detalladas, lee: **GUIA_CONFIGURACION_UNITY.md**

---

¡Éxito! 🎮✨

