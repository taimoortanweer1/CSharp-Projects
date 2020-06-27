/*--------------------------------------------------------------------------*/
/*  HAPPINESS.JS							    */
/*    Routines to calculate libMIT happiness scores			    */
/* 									    */
/*- Modification History: --------------------------------------------------*/
/*  When:	Who:			Comments:			    */
/* 									    */
/*  03-Feb-13	Christopher G. Healey	Converted from ANEW.JS		    */
/*--------------------------------------------------------------------------*/

//  Module global variables

//  Happiness description structure:
//  - key, full term
//  - dict, dictionary
//  - word, full term
//  - stem, stemmed term
//  - avg, happiness average
//  - std, happiness standard deviation
//
//  Happiness terms are not stemmed, because the original dataset was
//  specifically designed not to conflate terms


  
  
  
  
  
  
  
  
  
  
  "demons": {
    dict: "happiness", word: "demons", stem: "demon", anew: "demon",
    avg: [ 6.76, 2.64 ], std: [ 2.68, 2.07 ], fq: 50 
  },
  "guilty": {
    dict: "happiness", word: "guilty", stem: "guilti", anew: "guilty",
    avg: [ 6.04, 2.64 ], std: [ 2.76, 1.59 ], fq: 50 
  },
  "sin": {
    dict: "happiness", word: "sin", stem: "sin", anew: "sinful",
    avg: [ 6.29, 2.64 ], std: [ 2.43, 1.70 ], fq: 50 
  },
  "heartaches": {
    dict: "happiness", word: "heartaches", stem: "heartach", anew: "grief",
    avg: [ 4.78, 2.63 ], std: [ 2.84, 2.02 ], fq: 50 
  },
  "beaten": {
    dict: "happiness", word: "beaten", stem: "beaten", anew: "crushed",
    avg: [ 5.52, 2.62 ], std: [ 2.87, 1.59 ], fq: 50 
  },
  "lies": {
    dict: "happiness", word: "lies", stem: "lie", anew: "lie",
    avg: [ 5.96, 2.62 ], std: [ 2.63, 1.38 ], fq: 50 
  },
  "nasty": {
    dict: "happiness", word: "nasty", stem: "nasti", anew: "nasty",
    avg: [ 4.89, 2.62 ], std: [ 2.50, 1.23 ], fq: 50 
  },
  "retarded": {
    dict: "happiness", word: "retarded", stem: "retard", anew: "slow",
    avg: [ 3.39, 2.62 ], std: [ 2.22, 1.54 ], fq: 50 
  },
  "rude": {
    dict: "happiness", word: "rude", stem: "rude", anew: "rude",
    avg: [ 6.31, 2.62 ], std: [ 2.47, 1.64 ], fq: 50 
  },
  "threatened": {
    dict: "happiness", word: "threatened", stem: "threaten", anew: "menace",
    avg: [ 5.52, 2.62 ], std: [ 2.45, 1.47 ], fq: 50 
  },
  "violated": {
    dict: "happiness", word: "violated", stem: "violat", anew: "outrage",
    avg: [ 6.83, 2.62 ], std: [ 2.26, 1.38 ], fq: 50 
  },
  "abortion": {
    dict: "happiness", word: "abortion", stem: "abort", anew: "abortion",
    avg: [ 5.39, 2.60 ], std: [ 2.80, 1.53 ], fq: 50 
  },
  "brutal": {
    dict: "happiness", word: "brutal", stem: "brutal", anew: "brutal",
    avg: [ 6.60, 2.60 ], std: [ 2.36, 2.08 ], fq: 50 
  },
  "crash": {
    dict: "happiness", word: "crash", stem: "crash", anew: "crash",
    avg: [ 6.95, 2.60 ], std: [ 2.44, 1.37 ], fq: 50 
  },
  "error": {
    dict: "happiness", word: "error", stem: "error", anew: "fault",
    avg: [ 4.07, 2.60 ], std: [ 1.69, 0.81 ], fq: 50 
  },
  "lie": {
    dict: "happiness", word: "lie", stem: "lie", anew: "lie",
    avg: [ 5.96, 2.60 ], std: [ 2.63, 1.62 ], fq: 50 
  },
  "mad": {
    dict: "happiness", word: "mad", stem: "mad", anew: "mad",
    avg: [ 6.76, 2.60 ], std: [ 2.26, 1.32 ], fq: 50 
  },
  "selfish": {
    dict: "happiness", word: "selfish", stem: "selfish", anew: "selfish",
    avg: [ 5.50, 2.60 ], std: [ 2.62, 1.05 ], fq: 50 
  },
  "worries": {
    dict: "happiness", word: "worries", stem: "worri", anew: "headache",
    avg: [ 5.07, 2.60 ], std: [ 2.74, 1.32 ], fq: 50 
  },
  "infections": {
    dict: "happiness", word: "infections", stem: "infect", anew: "infection",
    avg: [ 5.03, 2.59 ], std: [ 2.77, 1.91 ], fq: 50 
  },
  "annoyed": {
    dict: "happiness", word: "annoyed", stem: "annoy", anew: "annoy",
    avg: [ 6.49, 2.58 ], std: [ 2.17, 1.64 ], fq: 50 
  },
  "blind": {
    dict: "happiness", word: "blind", stem: "blind", anew: "blind",
    avg: [ 4.39, 2.58 ], std: [ 2.36, 1.23 ], fq: 50 
  },
  "cheated": {
    dict: "happiness", word: "cheated", stem: "cheat", anew: "betray",
    avg: [ 7.24, 2.58 ], std: [ 2.06, 1.59 ], fq: 50 
  },
  "damage": {
    dict: "happiness", word: "damage", stem: "damag", anew: "damage",
    avg: [ 5.57, 2.58 ], std: [ 2.26, 1.50 ], fq: 50 
  },
  "disgusting": {
    dict: "happiness", word: "disgusting", stem: "disgust", anew: "disgusted",
    avg: [ 5.42, 2.58 ], std: [ 2.59, 1.47 ], fq: 50 
  },
  "guilt": {
    dict: "happiness", word: "guilt", stem: "guilt", anew: "guilty",
    avg: [ 6.04, 2.58 ], std: [ 2.76, 1.46 ], fq: 50 
  },
  "lying": {
    dict: "happiness", word: "lying", stem: "lie", anew: "lie",
    avg: [ 5.96, 2.58 ], std: [ 2.63, 1.70 ], fq: 50 
  },
  "rotten": {
    dict: "happiness", word: "rotten", stem: "rotten", anew: "rotten",
    avg: [ 4.53, 2.58 ], std: [ 2.38, 1.60 ], fq: 50 
  },
  "scared": {
    dict: "happiness", word: "scared", stem: "scare", anew: "scared",
    avg: [ 6.82, 2.58 ], std: [ 2.03, 1.43 ], fq: 50 
  },
  "shitty": {
    dict: "happiness", word: "shitty", stem: "shitti", anew: "stink",
    avg: [ 4.26, 2.58 ], std: [ 2.10, 1.57 ], fq: 50 
  },
  "starving": {
    dict: "happiness", word: "starving", stem: "starv", anew: "starving",
    avg: [ 5.61, 2.58 ], std: [ 2.53, 1.47 ], fq: 50 
  },
  "stroke": {
    dict: "happiness", word: "stroke", stem: "stroke", anew: "accident",
    avg: [ 6.26, 2.58 ], std: [ 2.87, 1.60 ], fq: 50 
  },
  "betrayed": {
    dict: "happiness", word: "betrayed", stem: "betray", anew: "betray",
    avg: [ 7.24, 2.57 ], std: [ 2.06, 1.83 ], fq: 50 
  },
  "nightmares": {
    dict: "happiness", word: "nightmares", stem: "nightmar", anew: "nightmare",
    avg: [ 7.59, 2.56 ], std: [ 2.23, 1.65 ], fq: 50 
  },
  "assault": {
    dict: "happiness", word: "assault", stem: "assault", anew: "assault",
    avg: [ 7.51, 2.56 ], std: [ 2.28, 1.66 ], fq: 50 
  },
  "beating": {
    dict: "happiness", word: "beating", stem: "beat", anew: "crushed",
    avg: [ 5.52, 2.56 ], std: [ 2.87, 1.90 ], fq: 50 
  },
  "grave": {
    dict: "happiness", word: "grave", stem: "grave", anew: "solemn",
    avg: [ 3.56, 2.56 ], std: [ 1.95, 1.85 ], fq: 50 
  },
  "loss": {
    dict: "happiness", word: "loss", stem: "loss", anew: "red",
    avg: [ 5.29, 2.56 ], std: [ 2.04, 1.50 ], fq: 50 
  },
  "rage": {
    dict: "happiness", word: "rage", stem: "rage", anew: "rage",
    avg: [ 8.17, 2.56 ], std: [ 1.40, 1.51 ], fq: 50 
  },
  "upset": {
    dict: "happiness", word: "upset", stem: "upset", anew: "upset",
    avg: [ 5.86, 2.56 ], std: [ 2.40, 1.43 ], fq: 50 
  },
  "corpse": {
    dict: "happiness", word: "corpse", stem: "corps", anew: "corpse",
    avg: [ 4.74, 2.55 ], std: [ 2.94, 1.96 ], fq: 50 
  },
  "abandoned": {
    dict: "happiness", word: "abandoned", stem: "abandon", anew: "vacation",
    avg: [ 5.64, 2.54 ], std: [ 2.99, 1.37 ], fq: 50 
  },
  "broke": {
    dict: "happiness", word: "broke", stem: "broke", anew: "bankrupt",
    avg: [ 6.21, 2.54 ], std: [ 2.79, 1.28 ], fq: 50 
  },
  "harm": {
    dict: "happiness", word: "harm", stem: "harm", anew: "injury",
    avg: [ 5.69, 2.54 ], std: [ 2.06, 1.45 ], fq: 50 
  },
  "hurricane": {
    dict: "happiness", word: "hurricane", stem: "hurrican", anew: "hurricane",
    avg: [ 6.83, 2.54 ], std: [ 2.06, 1.57 ], fq: 50 
  },
  "miserable": {
    dict: "happiness", word: "miserable", stem: "miser", anew: "pity",
    avg: [ 3.72, 2.54 ], std: [ 2.02, 1.67 ], fq: 50 
  },
  "pissed": {
    dict: "happiness", word: "pissed", stem: "piss", anew: "irritate",
    avg: [ 5.76, 2.54 ], std: [ 2.15, 1.33 ], fq: 50 
  },
  "ruined": {
    dict: "happiness", word: "ruined", stem: "ruin", anew: "bankrupt",
    avg: [ 6.21, 2.54 ], std: [ 2.79, 1.62 ], fq: 50 
  },
  "tumor": {
    dict: "happiness", word: "tumor", stem: "tumor", anew: "tumor",
    avg: [ 6.51, 2.53 ], std: [ 2.85, 2.00 ], fq: 50 
  },
  "attacked": {
    dict: "happiness", word: "attacked", stem: "attack", anew: "aggressive",
    avg: [ 5.83, 2.52 ], std: [ 2.33, 1.55 ], fq: 50 
  },
  "bastard": {
    dict: "happiness", word: "bastard", stem: "bastard", anew: "bastard",
    avg: [ 6.07, 2.52 ], std: [ 2.15, 1.30 ], fq: 50 
  },
  "destroy": {
    dict: "happiness", word: "destroy", stem: "destroy", anew: "destroy",
    avg: [ 6.83, 2.52 ], std: [ 2.38, 1.81 ], fq: 50 
  },
  "failing": {
    dict: "happiness", word: "failing", stem: "fail", anew: "bomb",
    avg: [ 7.15, 2.52 ], std: [ 2.40, 1.27 ], fq: 50 
  },
  "shooting": {
    dict: "happiness", word: "shooting", stem: "shoot", anew: "hit",
    avg: [ 5.73, 2.52 ], std: [ 2.09, 1.74 ], fq: 50 
  },
  "useless": {
    dict: "happiness", word: "useless", stem: "useless", anew: "useless",
    avg: [ 4.87, 2.52 ], std: [ 2.58, 1.42 ], fq: 50 
  },
  "motherfuckers": {
    dict: "happiness", word: "motherfuckers", stem: "motherfuck", anew: "bastard",
    avg: [ 6.07, 2.51 ], std: [ 2.15, 2.47 ], fq: 50 
  },
  "betray": {
    dict: "happiness", word: "betray", stem: "betray", anew: "betray",
    avg: [ 7.24, 2.50 ], std: [ 2.06, 1.63 ], fq: 50 
  },
  "shit": {
    dict: "happiness", word: "shit", stem: "shit", anew: "dump",
    avg: [ 4.12, 2.50 ], std: [ 2.36, 1.52 ], fq: 50 
  },
  "shot": {
    dict: "happiness", word: "shot", stem: "shot", anew: "hit",
    avg: [ 5.73, 2.50 ], std: [ 2.09, 1.66 ], fq: 50 
  },
  "crisis": {
    dict: "happiness", word: "crisis", stem: "crisi", anew: "crisis",
    avg: [ 5.44, 2.48 ], std: [ 3.07, 1.67 ], fq: 50 
  },
  "damaged": {
    dict: "happiness", word: "damaged", stem: "damag", anew: "damage",
    avg: [ 5.57, 2.48 ], std: [ 2.26, 1.03 ], fq: 50 
  },
  "recession": {
    dict: "happiness", word: "recession", stem: "recess", anew: "corner",
    avg: [ 3.91, 2.48 ], std: [ 1.92, 1.50 ], fq: 50 
  },
  "slap": {
    dict: "happiness", word: "slap", stem: "slap", anew: "slap",
    avg: [ 6.46, 2.48 ], std: [ 2.58, 1.53 ], fq: 50 
  },
  "attacks": {
    dict: "happiness", word: "attacks", stem: "attack", anew: "fire",
    avg: [ 7.17, 2.46 ], std: [ 2.06, 1.46 ], fq: 50 
  },
  "crashed": {
    dict: "happiness", word: "crashed", stem: "crash", anew: "crash",
    avg: [ 6.95, 2.46 ], std: [ 2.44, 1.40 ], fq: 50 
  },
  "losses": {
    dict: "happiness", word: "losses", stem: "loss", anew: "red",
    avg: [ 5.29, 2.46 ], std: [ 2.04, 1.45 ], fq: 50 
  },
  "panic": {
    dict: "happiness", word: "panic", stem: "panic", anew: "panic",
    avg: [ 7.02, 2.46 ], std: [ 2.02, 1.34 ], fq: 50 
  },
  "burial": {
    dict: "happiness", word: "burial", stem: "burial", anew: "burial",
    avg: [ 5.08, 2.44 ], std: [ 2.40, 1.92 ], fq: 50 
  },
  "cheat": {
    dict: "happiness", word: "cheat", stem: "cheat", anew: "betray",
    avg: [ 7.24, 2.44 ], std: [ 2.06, 1.23 ], fq: 50 
  },
  "dangerous": {
    dict: "happiness", word: "dangerous", stem: "danger", anew: "danger",
    avg: [ 7.32, 2.44 ], std: [ 2.07, 1.46 ], fq: 50 
  },
  "drowning": {
    dict: "happiness", word: "drowning", stem: "drown", anew: "drown",
    avg: [ 6.57, 2.44 ], std: [ 2.33, 1.59 ], fq: 50 
  },
  "hating": {
    dict: "happiness", word: "hating", stem: "hate", anew: "hate",
    avg: [ 6.95, 2.44 ], std: [ 2.56, 1.45 ], fq: 50 
  },
  "prisoners": {
    dict: "happiness", word: "prisoners", stem: "prison", anew: "prison",
    avg: [ 5.70, 2.44 ], std: [ 2.56, 1.46 ], fq: 50 
  },
  "arrest": {
    dict: "happiness", word: "arrest", stem: "arrest", anew: "pinch",
    avg: [ 4.59, 2.42 ], std: [ 2.10, 1.49 ], fq: 50 
  },
  "attack": {
    dict: "happiness", word: "attack", stem: "attack", anew: "fire",
    avg: [ 7.17, 2.42 ], std: [ 2.06, 1.43 ], fq: 50 
  },
  "flood": {
    dict: "happiness", word: "flood", stem: "flood", anew: "flood",
    avg: [ 6.00, 2.42 ], std: [ 2.02, 1.37 ], fq: 50 
  },
  "ill": {
    dict: "happiness", word: "ill", stem: "ill", anew: "illness",
    avg: [ 4.71, 2.42 ], std: [ 2.24, 1.23 ], fq: 50 
  },
  "killer": {
    dict: "happiness", word: "killer", stem: "killer", anew: "killer",
    avg: [ 7.86, 2.42 ], std: [ 1.89, 1.93 ], fq: 50 
  },
  "negative": {
    dict: "happiness", word: "negative", stem: "neg", anew: "damage",
    avg: [ 5.57, 2.42 ], std: [ 2.26, 1.05 ], fq: 50 
  },
  "worried": {
    dict: "happiness", word: "worried", stem: "worri", anew: "disturb",
    avg: [ 5.80, 2.42 ], std: [ 2.39, 1.18 ], fq: 50 
  },
  "wounded": {
    dict: "happiness", word: "wounded", stem: "wound", anew: "wounds",
    avg: [ 5.82, 2.42 ], std: [ 2.01, 1.55 ], fq: 50 
  },
  "slaughter": {
    dict: "happiness", word: "slaughter", stem: "slaughter", anew: "slaughter",
    avg: [ 6.77, 2.41 ], std: [ 2.42, 1.84 ], fq: 50 
  },
  "asshole": {
    dict: "happiness", word: "asshole", stem: "asshol", anew: "bastard",
    avg: [ 6.07, 2.40 ], std: [ 2.15, 1.60 ], fq: 50 
  },
  "weapons": {
    dict: "happiness", word: "weapons", stem: "weapon", anew: "weapon",
    avg: [ 6.03, 2.40 ], std: [ 1.89, 1.69 ], fq: 50 
  },
  "sad": {
    dict: "happiness", word: "sad", stem: "sad", anew: "sad",
    avg: [ 4.13, 2.38 ], std: [ 2.38, 1.61 ], fq: 50 
  },
  "victim": {
    dict: "happiness", word: "victim", stem: "victim", anew: "victim",
    avg: [ 6.06, 2.38 ], std: [ 2.32, 1.41 ], fq: 50 
  },
  "hurting": {
    dict: "happiness", word: "hurting", stem: "hurt", anew: "hurt",
    avg: [ 5.85, 2.36 ], std: [ 2.49, 1.12 ], fq: 50 
  },
  "threat": {
    dict: "happiness", word: "threat", stem: "threat", anew: "menace",
    avg: [ 5.52, 2.36 ], std: [ 2.45, 1.31 ], fq: 50 
  },
  "frustration": {
    dict: "happiness", word: "frustration", stem: "frustrat", anew: "frustrated",
    avg: [ 5.61, 2.34 ], std: [ 2.76, 1.19 ], fq: 50 
  },
  "hate": {
    dict: "happiness", word: "hate", stem: "hate", anew: "hate",
    avg: [ 6.95, 2.34 ], std: [ 2.56, 1.88 ], fq: 50 
  },
  "grief": {
    dict: "happiness", word: "grief", stem: "grief", anew: "grief",
    avg: [ 4.78, 2.33 ], std: [ 2.84, 1.78 ], fq: 50 
  },
  "accident": {
    dict: "happiness", word: "accident", stem: "accid", anew: "accident",
    avg: [ 6.26, 2.32 ], std: [ 2.87, 1.52 ], fq: 50 
  },
  "angry": {
    dict: "happiness", word: "angry", stem: "angri", anew: "angry",
    avg: [ 7.17, 2.32 ], std: [ 2.07, 1.24 ], fq: 50 
  },
  "fear": {
    dict: "happiness", word: "fear", stem: "fear", anew: "fearful",
    avg: [ 6.33, 2.32 ], std: [ 2.28, 1.30 ], fq: 50 
  },
  "nightmare": {
    dict: "happiness", word: "nightmare", stem: "nightmar", anew: "nightmare",
    avg: [ 7.59, 2.32 ], std: [ 2.23, 1.87 ], fq: 50 
  },
  "poor": {
    dict: "happiness", word: "poor", stem: "poor", anew: "pity",
    avg: [ 3.72, 2.32 ], std: [ 2.02, 1.28 ], fq: 50 
  },
  "victims": {
    dict: "happiness", word: "victims", stem: "victim", anew: "victim",
    avg: [ 6.06, 2.32 ], std: [ 2.32, 1.50 ], fq: 50 
  },
  "anger": {
    dict: "happiness", word: "anger", stem: "anger", anew: "anger",
    avg: [ 7.63, 2.30 ], std: [ 1.91, 1.42 ], fq: 50 
  },
  "fired": {
    dict: "happiness", word: "fired", stem: "fire", anew: "fire",
    avg: [ 7.17, 2.30 ], std: [ 2.06, 1.57 ], fq: 50 
  },
  "fraud": {
    dict: "happiness", word: "fraud", stem: "fraud", anew: "fraud",
    avg: [ 5.75, 2.30 ], std: [ 2.45, 1.18 ], fq: 50 
  },
  "thieves": {
    dict: "happiness", word: "thieves", stem: "thiev", anew: "thief",
    avg: [ 6.89, 2.29 ], std: [ 2.13, 1.31 ], fq: 50 
  },
  "heartache": {
    dict: "happiness", word: "heartache", stem: "heartach", anew: "grief",
    avg: [ 4.78, 2.28 ], std: [ 2.84, 1.50 ], fq: 50 
  },
  "cheating": {
    dict: "happiness", word: "cheating", stem: "cheat", anew: "foul",
    avg: [ 4.93, 2.26 ], std: [ 2.23, 1.19 ], fq: 50 
  },
  "destruction": {
    dict: "happiness", word: "destruction", stem: "destruct", anew: "destruction",
    avg: [ 5.82, 2.26 ], std: [ 2.71, 1.51 ], fq: 50 
  },
  "disappointed": {
    dict: "happiness", word: "disappointed", stem: "disappoint", anew: "disappoint",
    avg: [ 4.92, 2.26 ], std: [ 2.64, 1.03 ], fq: 50 
  },
  "bombing": {
    dict: "happiness", word: "bombing", stem: "bomb", anew: "bomb",
    avg: [ 7.15, 2.24 ], std: [ 2.40, 1.48 ], fq: 50 
  },
  "devil": {
    dict: "happiness", word: "devil", stem: "devil", anew: "devil",
    avg: [ 6.07, 2.24 ], std: [ 2.61, 1.55 ], fq: 50 
  },
  "horrible": {
    dict: "happiness", word: "horrible", stem: "horribl", anew: "ugly",
    avg: [ 5.38, 2.24 ], std: [ 2.23, 1.48 ], fq: 50 
  },
  "suffered": {
    dict: "happiness", word: "suffered", stem: "suffer", anew: "ache",
    avg: [ 5.00, 2.24 ], std: [ 2.45, 1.60 ], fq: 50 
  },
  "hatred": {
    dict: "happiness", word: "hatred", stem: "hatr", anew: "hatred",
    avg: [ 6.66, 2.22 ], std: [ 2.56, 1.86 ], fq: 50 
  },
  "hell": {
    dict: "happiness", word: "hell", stem: "hell", anew: "hell",
    avg: [ 5.38, 2.22 ], std: [ 2.62, 1.47 ], fq: 50 
  },
  "injured": {
    dict: "happiness", word: "injured", stem: "injur", anew: "wounds",
    avg: [ 5.82, 2.22 ], std: [ 2.01, 1.11 ], fq: 50 
  },
  "suffering": {
    dict: "happiness", word: "suffering", stem: "suffer", anew: "distressed",
    avg: [ 6.40, 2.22 ], std: [ 2.38, 1.71 ], fq: 50 
  },
  "cried": {
    dict: "happiness", word: "cried", stem: "cri", anew: "scream",
    avg: [ 7.04, 2.20 ], std: [ 1.96, 1.29 ], fq: 50 
  },
  "crime": {
    dict: "happiness", word: "crime", stem: "crime", anew: "crime",
    avg: [ 5.41, 2.20 ], std: [ 2.69, 1.26 ], fq: 50 
  },
  "loser": {
    dict: "happiness", word: "loser", stem: "loser", anew: "loser",
    avg: [ 4.95, 2.20 ], std: [ 2.57, 1.11 ], fq: 50 
  },
  "depressed": {
    dict: "happiness", word: "depressed", stem: "depress", anew: "depression",
    avg: [ 4.54, 2.18 ], std: [ 3.19, 1.79 ], fq: 50 
  },
  "divorce": {
    dict: "happiness", word: "divorce", stem: "divorc", anew: "divorce",
    avg: [ 6.33, 2.18 ], std: [ 2.71, 1.32 ], fq: 50 
  },
  "hurt": {
    dict: "happiness", word: "hurt", stem: "hurt", anew: "hurt",
    avg: [ 5.85, 2.18 ], std: [ 2.49, 1.37 ], fq: 50 
  },
  "agony": {
    dict: "happiness", word: "agony", stem: "agoni", anew: "agony",
    avg: [ 6.06, 2.16 ], std: [ 2.67, 1.88 ], fq: 50 
  },
  "drowned": {
    dict: "happiness", word: "drowned", stem: "drown", anew: "drown",
    avg: [ 6.57, 2.16 ], std: [ 2.33, 1.60 ], fq: 50 
  },
  "pollution": {
    dict: "happiness", word: "pollution", stem: "pollut", anew: "pollute",
    avg: [ 6.08, 2.16 ], std: [ 2.42, 1.18 ], fq: 50 
  },
  "corruption": {
    dict: "happiness", word: "corruption", stem: "corrupt", anew: "corrupt",
    avg: [ 4.67, 2.14 ], std: [ 2.35, 1.31 ], fq: 50 
  },
  "crimes": {
    dict: "happiness", word: "crimes", stem: "crime", anew: "crime",
    avg: [ 5.41, 2.14 ], std: [ 2.69, 1.37 ], fq: 50 
  },
  "hated": {
    dict: "happiness", word: "hated", stem: "hate", anew: "hate",
    avg: [ 6.95, 2.14 ], std: [ 2.56, 1.29 ], fq: 50 
  },
  "hurts": {
    dict: "happiness", word: "hurts", stem: "hurt", anew: "hurt",
    avg: [ 5.85, 2.14 ], std: [ 2.49, 1.20 ], fq: 50 
  },
  "painful": {
    dict: "happiness", word: "painful", stem: "pain", anew: "pain",
    avg: [ 6.50, 2.12 ], std: [ 2.49, 1.45 ], fq: 50 
  },
  "sorrow": {
    dict: "happiness", word: "sorrow", stem: "sorrow", anew: "regretful",
    avg: [ 5.74, 2.12 ], std: [ 2.32, 1.56 ], fq: 50 
  },
  "unhappy": {
    dict: "happiness", word: "unhappy", stem: "unhappi", anew: "unhappy",
    avg: [ 4.18, 2.12 ], std: [ 2.50, 1.36 ], fq: 50 
  },
  "heartbreak": {
    dict: "happiness", word: "heartbreak", stem: "heartbreak", anew: "grief",
    avg: [ 4.78, 2.11 ], std: [ 2.84, 1.31 ], fq: 50 
  },
  "dying": {
    dict: "happiness", word: "dying", stem: "die", anew: "death",
    avg: [ 4.59, 2.10 ], std: [ 3.07, 1.47 ], fq: 50 
  },
  "funeral": {
    dict: "happiness", word: "funeral", stem: "funer", anew: "funeral",
    avg: [ 4.94, 2.10 ], std: [ 3.21, 1.56 ], fq: 50 
  },
  "pain": {
    dict: "happiness", word: "pain", stem: "pain", anew: "pain",
    avg: [ 6.50, 2.10 ], std: [ 2.49, 1.28 ], fq: 50 
  },
  "worst": {
    dict: "happiness", word: "worst", stem: "worst", anew: "regretful",
    avg: [ 5.74, 2.10 ], std: [ 2.32, 1.34 ], fq: 50 
  },
  "rejected": {
    dict: "happiness", word: "rejected", stem: "reject", anew: "rejected",
    avg: [ 6.37, 2.08 ], std: [ 2.56, 1.12 ], fq: 50 
  },
  "suffer": {
    dict: "happiness", word: "suffer", stem: "suffer", anew: "ache",
    avg: [ 5.00, 2.08 ], std: [ 2.45, 1.38 ], fq: 50 
  },
  "bankruptcy": {
    dict: "happiness", word: "bankruptcy", stem: "bankruptci", anew: "failure",
    avg: [ 4.95, 2.06 ], std: [ 2.81, 1.60 ], fq: 50 
  },
  "fails": {
    dict: "happiness", word: "fails", stem: "fail", anew: "bomb",
    avg: [ 7.15, 2.06 ], std: [ 2.40, 1.20 ], fq: 50 
  },
  "failure": {
    dict: "happiness", word: "failure", stem: "failur", anew: "failure",
    avg: [ 4.95, 2.06 ], std: [ 2.81, 1.22 ], fq: 50 
  },
  "hates": {
    dict: "happiness", word: "hates", stem: "hate", anew: "hate",
    avg: [ 6.95, 2.06 ], std: [ 2.56, 1.33 ], fq: 50 
  },
  "prison": {
    dict: "happiness", word: "prison", stem: "prison", anew: "prison",
    avg: [ 5.70, 2.06 ], std: [ 2.56, 1.48 ], fq: 50 
  },
  "slave": {
    dict: "happiness", word: "slave", stem: "slave", anew: "slave",
    avg: [ 6.21, 2.06 ], std: [ 2.93, 1.46 ], fq: 50 
  },
  "slaves": {
    dict: "happiness", word: "slaves", stem: "slave", anew: "slave",
    avg: [ 6.21, 2.06 ], std: [ 2.93, 1.37 ], fq: 50 
  },
  "tragedy": {
    dict: "happiness", word: "tragedy", stem: "tragedi", anew: "tragedy",
    avg: [ 6.24, 2.06 ], std: [ 2.64, 1.38 ], fq: 50 
  },
  "violent": {
    dict: "happiness", word: "violent", stem: "violent", anew: "violent",
    avg: [ 6.89, 2.06 ], std: [ 2.47, 1.35 ], fq: 50 
  },
  "crying": {
    dict: "happiness", word: "crying", stem: "cri", anew: "scream",
    avg: [ 7.04, 2.04 ], std: [ 1.96, 1.24 ], fq: 50 
  },
  "destroyed": {
    dict: "happiness", word: "destroyed", stem: "destroy", anew: "destroy",
    avg: [ 6.83, 2.04 ], std: [ 2.38, 1.34 ], fq: 50 
  },
  "injury": {
    dict: "happiness", word: "injury", stem: "injuri", anew: "injury",
    avg: [ 5.69, 2.04 ], std: [ 2.06, 1.24 ], fq: 50 
  },
  "rejection": {
    dict: "happiness", word: "rejection", stem: "reject", anew: "rejected",
    avg: [ 6.37, 2.02 ], std: [ 2.56, 1.33 ], fq: 50 
  },
  "motherfucker": {
    dict: "happiness", word: "motherfucker", stem: "motherfuck", anew: "bastard",
    avg: [ 6.07, 2.02 ], std: [ 2.15, 1.66 ], fq: 50 
  },
  "sick": {
    dict: "happiness", word: "sick", stem: "sick", anew: "sickness",
    avg: [ 5.61, 2.02 ], std: [ 2.67, 1.08 ], fq: 50 
  },
  "dead": {
    dict: "happiness", word: "dead", stem: "dead", anew: "dead",
    avg: [ 5.73, 2.00 ], std: [ 2.73, 1.32 ], fq: 50 
  },
  "illness": {
    dict: "happiness", word: "illness", stem: "ill", anew: "illness",
    avg: [ 4.71, 2.00 ], std: [ 2.24, 1.18 ], fq: 50 
  },
  "killers": {
    dict: "happiness", word: "killers", stem: "killer", anew: "killer",
    avg: [ 7.86, 2.00 ], std: [ 1.89, 1.53 ], fq: 50 
  },
  "punishment": {
    dict: "happiness", word: "punishment", stem: "punish", anew: "punishment",
    avg: [ 5.93, 2.00 ], std: [ 2.40, 1.34 ], fq: 50 
  },
  "criminal": {
    dict: "happiness", word: "criminal", stem: "crimin", anew: "criminal",
    avg: [ 4.79, 1.98 ], std: [ 2.51, 1.27 ], fq: 50 
  },
  "depression": {
    dict: "happiness", word: "depression", stem: "depress", anew: "depression",
    avg: [ 4.54, 1.98 ], std: [ 3.19, 1.56 ], fq: 50 
  },
  "headache": {
    dict: "happiness", word: "headache", stem: "headach", anew: "headache",
    avg: [ 5.07, 1.98 ], std: [ 2.74, 1.12 ], fq: 50 
  },
  "poverty": {
    dict: "happiness", word: "poverty", stem: "poverti", anew: "poverty",
    avg: [ 4.87, 1.98 ], std: [ 2.66, 1.12 ], fq: 50 
  },
  "tumors": {
    dict: "happiness", word: "tumors", stem: "tumor", anew: "tumor",
    avg: [ 6.51, 1.98 ], std: [ 2.85, 1.35 ], fq: 50 
  },
  "bomb": {
    dict: "happiness", word: "bomb", stem: "bomb", anew: "bomb",
    avg: [ 7.15, 1.96 ], std: [ 2.40, 1.28 ], fq: 50 
  },
  "disaster": {
    dict: "happiness", word: "disaster", stem: "disast", anew: "disaster",
    avg: [ 6.33, 1.96 ], std: [ 2.70, 1.43 ], fq: 50 
  },
  "fail": {
    dict: "happiness", word: "fail", stem: "fail", anew: "bomb",
    avg: [ 7.15, 1.96 ], std: [ 2.40, 1.03 ], fq: 50 
  },
  "poison": {
    dict: "happiness", word: "poison", stem: "poison", anew: "poison",
    avg: [ 6.05, 1.94 ], std: [ 2.82, 1.15 ], fq: 50 
  },
  "depressing": {
    dict: "happiness", word: "depressing", stem: "depress", anew: "depression",
    avg: [ 4.54, 1.90 ], std: [ 3.19, 1.22 ], fq: 50 
  },
  "evil": {
    dict: "happiness", word: "evil", stem: "evil", anew: "evil",
    avg: [ 6.39, 1.90 ], std: [ 2.44, 1.28 ], fq: 50 
  },
  "wars": {
    dict: "happiness", word: "wars", stem: "war", anew: "war",
    avg: [ 7.49, 1.90 ], std: [ 2.16, 1.33 ], fq: 50 
  },
  "abuse": {
    dict: "happiness", word: "abuse", stem: "abus", anew: "abuse",
    avg: [ 6.83, 1.88 ], std: [ 2.70, 1.24 ], fq: 50 
  },
  "sadness": {
    dict: "happiness", word: "sadness", stem: "sad", anew: "sad",
    avg: [ 4.13, 1.88 ], std: [ 2.38, 1.19 ], fq: 50 
  },
  "cruel": {
    dict: "happiness", word: "cruel", stem: "cruel", anew: "cruel",
    avg: [ 5.68, 1.84 ], std: [ 2.65, 1.15 ], fq: 50 
  },
  "cry": {
    dict: "happiness", word: "cry", stem: "cri", anew: "scream",
    avg: [ 7.04, 1.84 ], std: [ 1.96, 1.28 ], fq: 50 
  },
  "failed": {
    dict: "happiness", word: "failed", stem: "fail", anew: "bomb",
    avg: [ 7.15, 1.84 ], std: [ 2.40, 1.00 ], fq: 50 
  },
  "sickness": {
    dict: "happiness", word: "sickness", stem: "sick", anew: "sickness",
    avg: [ 5.61, 1.84 ], std: [ 2.67, 1.18 ], fq: 50 
  },
  "abused": {
    dict: "happiness", word: "abused", stem: "abus", anew: "abuse",
    avg: [ 6.83, 1.83 ], std: [ 2.70, 1.31 ], fq: 50 
  },
  "tortured": {
    dict: "happiness", word: "tortured", stem: "tortur", anew: "torture",
    avg: [ 6.10, 1.82 ], std: [ 2.77, 1.42 ], fq: 50 
  },
  "fatal": {
    dict: "happiness", word: "fatal", stem: "fatal", anew: "black",
    avg: [ 4.61, 1.80 ], std: [ 2.24, 1.53 ], fq: 50 
  },
  "killings": {
    dict: "happiness", word: "killings", stem: "kill", anew: "defeated",
    avg: [ 5.09, 1.80 ], std: [ 3.00, 1.54 ], fq: 50 
  },
  "murdered": {
    dict: "happiness", word: "murdered", stem: "murder", anew: "murderer",
    avg: [ 7.47, 1.80 ], std: [ 2.18, 1.63 ], fq: 50 
  },
  "war": {
    dict: "happiness", word: "war", stem: "war", anew: "war",
    avg: [ 7.49, 1.80 ], std: [ 2.16, 1.41 ], fq: 50 
  },
  "kills": {
    dict: "happiness", word: "kills", stem: "kill", anew: "defeated",
    avg: [ 5.09, 1.78 ], std: [ 3.00, 1.23 ], fq: 50 
  },
  "jail": {
    dict: "happiness", word: "jail", stem: "jail", anew: "jail",
    avg: [ 5.49, 1.76 ], std: [ 2.67, 1.02 ], fq: 50 
  },
  "terror": {
    dict: "happiness", word: "terror", stem: "terror", anew: "panic",
    avg: [ 7.02, 1.76 ], std: [ 2.02, 1.00 ], fq: 50 
  },
  "killing": {
    dict: "happiness", word: "killing", stem: "kill", anew: "defeated",
    avg: [ 5.09, 1.70 ], std: [ 3.00, 1.36 ], fq: 50 
  },
  "deaths": {
    dict: "happiness", word: "deaths", stem: "death", anew: "death",
    avg: [ 4.59, 1.64 ], std: [ 3.07, 1.14 ], fq: 50 
  },
  "raped": {
    dict: "happiness", word: "raped", stem: "rape", anew: "rape",
    avg: [ 6.81, 1.64 ], std: [ 3.17, 1.43 ], fq: 50 
  },
  "torture": {
    dict: "happiness", word: "torture", stem: "tortur", anew: "torture",
    avg: [ 6.10, 1.58 ], std: [ 2.77, 1.05 ], fq: 50 
  },
  "kill": {
    dict: "happiness", word: "kill", stem: "kill", anew: "defeated",
    avg: [ 5.09, 1.56 ], std: [ 3.00, 1.05 ], fq: 50 
  },
  "killed": {
    dict: "happiness", word: "killed", stem: "kill", anew: "defeated",
    avg: [ 5.09, 1.56 ], std: [ 3.00, 1.23 ], fq: 50 
  },
  "cancer": {
    dict: "happiness", word: "cancer", stem: "cancer", anew: "cancer",
    avg: [ 6.42, 1.54 ], std: [ 2.83, 1.07 ], fq: 50 
  },
  "death": {
    dict: "happiness", word: "death", stem: "death", anew: "death",
    avg: [ 4.59, 1.54 ], std: [ 3.07, 1.28 ], fq: 50 
  },
  "murder": {
    dict: "happiness", word: "murder", stem: "murder", anew: "murderer",
    avg: [ 7.47, 1.48 ], std: [ 2.18, 1.01 ], fq: 50 
  },
  "rape": {
    dict: "happiness", word: "rape", stem: "rape", anew: "rape",
    avg: [ 6.81, 1.44 ], std: [ 3.17, 0.79 ], fq: 50 
  },
  "suicide": {
    dict: "happiness", word: "suicide", stem: "suicid", anew: "suicide",
    avg: [ 5.73, 1.30 ], std: [ 3.14, 0.84 ], fq: 50 
  },
  "terrorist": {
    dict: "happiness", word: "terrorist", stem: "terrorist", anew: "terrorist",
    avg: [ 7.27, 1.30 ], std: [ 2.38, 0.91 ], fq: 50 
  }
};


function happiness_extend( term, avg, std )

  //  Extend the Happiness dictionary with the given term
  //
  //  term:  Term to add
  //  avg:   Happiness average
  //  std:   Happiness standard deviation
{
  term = term.toLowerCase();

  //  Warning if we're replacing terms rather than adding them

  if ( happiness_term.hasOwnProperty( term ) ) {
    console.log( "happiness_extend(), replacing term " + term );
  }

  happy_term[ term ]= { avg: avg, std: std };
}					// End routine happiness_extend_term


function happiness_find_word( w )

  //  Return the word in the happiness dictionary, or -1 if no such word
  //
  //  w:  Word to search
{
  if ( w.length == 0 ) {		// Empty term?
    return -1;
  }

  if ( happy_term.hasOwnProperty( w ) ) {
    return happy_term[ w ];
  }

  return -1;
}					// End routine happiness_find_word
