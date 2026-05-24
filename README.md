# Convocation JA — Compléter le PDF

> Outil d'aide à la saisie pour les **Juges Arbitres FFTT**.  
> Complète automatiquement les PDFs de convocation et facilite la communication avec les clubs adverses.

---

## Sommaire

- [Présentation](#présentation)
- [Fonctionnalités](#fonctionnalités)
- [Captures d'écran](#captures-décran)
- [Prérequis & Installation](#prérequis--installation)
- [Utilisation](#utilisation)
- [Configuration](#configuration)
- [API FFTT Smartping](#api-fftt-smartping)
- [Fichiers de données](#fichiers-de-données)
- [Architecture du code](#architecture-du-code)
- [Compilation](#compilation)
- [Licence & Contact](#licence--contact)

---

## Présentation

**Convocation JA** est une application Windows qui automatise le remplissage des convocations PDF de la FFTT (Fédération Française de Tennis de Table). Elle est destinée aux Juges Arbitres officiels qui reçoivent une convocation vierge et doivent y inscrire les informations de la rencontre, calculer leurs frais et ajouter leur signature.

| Donnée | Valeur |
|--------|--------|
| Version | 1.00 |
| Plateforme | Windows (WinForms .NET 8) |
| Auteur | Patrick CHAUTARD |
| Contact | patrick.chautard@free.fr |
| Licence | Usage personnel / associatif FFTT |

---

## Fonctionnalités

### Remplissage automatique du PDF
- Sélection du PDF de convocation source
- **Lecture automatique** des informations de compétition (opposant, date, heure, adresse) par analyse du texte du PDF
- Saisie manuelle possible si la lecture automatique échoue

### Calcul des indemnités
- Indemnité fixe paramétrable
- Péages (saisie libre)
- Kilométrage avec taux paramétrable (ex. 0,30 €/km)
- **Calcul automatique du total** en temps réel

### Rapport du Juge Arbitre
- Champ libre « Accueil, ambiance »
- Champ libre « Équipements, salle… »
- Intégré dans le PDF généré

### Signature numérique
- Import d'une image de signature (PNG, JPG, BMP, GIF)
- Position et dimensions configurables dans le PDF
- Gérée via **Outils › Signature…**

### Recherche club FFTT (Smartping)
- Recherche par département (extrait automatiquement depuis l'adresse saisie)
- Filtrage par nom de club
- Affichage des coordonnées complètes : adresse, email, téléphone
- Accès direct depuis le bouton **🔍 Rechercher FFTT** ou via **Outils › Recherche club FFTT…**

### Email pré-rempli
- Modèle personnalisable (sujet + corps) avec variables de substitution :
  - `{jourCourt}` → ex. « Samedi 15/12/2026 »
  - `{jourLong}` → ex. « samedi 15 décembre 2026 »
  - `{heure}` → ex. « 16h00 »
  - `{nomArbitre}` → votre nom
- Email généré automatiquement depuis les données de la compétition et les coordonnées du club
- Édition du modèle via **Outils › Modèle d'email…**

### Mémorisation de la session
- Le dernier état du formulaire (fichier PDF, compétition, indemnités) est restauré au prochain démarrage

---

## Captures d'écran

*(à compléter)*

---

## Prérequis & Installation

### Prérequis
- **Windows 10 ou 11** (64 bits recommandé)
- **.NET 8 Runtime** — [Télécharger sur microsoft.com](https://dotnet.microsoft.com/download/dotnet/8.0)

### Installation
1. Télécharger l'archive de la dernière version dans les [Releases](../../releases)
2. Extraire dans un dossier de votre choix (ex. `C:\Outils\ConvocationJA\`)
3. Lancer `OrdreMission.exe`

Aucune installation supplémentaire n'est requise. L'application est **portable** : tous les fichiers de configuration sont créés à côté de l'EXE.

> **Remarque :** Pour la génération PDF, les PDFs complétés sont enregistrés dans le sous-dossier `PDF/` créé automatiquement.

---

## Utilisation

### Workflow type

```
1. Ouvrir l'application
2. Sélectionner le PDF de la convocation reçue  →  [Parcourir…]
       └─ Les informations de la rencontre sont lues automatiquement
3. Vérifier / compléter : Opposant, Date, Heure, Adresse
4. Saisir les indemnités : péages, kilométrage
5. Remplir le Rapport (si incident)
6. Cliquer sur  [ ▶ Générer le PDF complété ]
7. Ouvrir le PDF généré avec  [ 📂 Ouvrir PDF généré ]
```

### Menu Outils

| Élément | Rôle |
|---------|------|
| ⚙ Paramètres… | Indemnité fixe, taux km, nom arbitre, adresse de départ |
| Positions dans le PDF… | Coordonnées exactes des champs dans le PDF (réglage fin) |
| ✉ Modèle d'email… | Personnaliser le sujet et le corps de l'email |
| 🔍 Recherche club FFTT… | Rechercher les coordonnées d'un club par département |
| 🖊 Signature… | Importer ou effacer l'image de signature |

---

## Configuration

### Paramètres principaux (`Outils › ⚙ Paramètres…`)

| Paramètre | Description | Défaut |
|-----------|-------------|--------|
| Indemnité fixe | Montant forfaitaire par déplacement | 25,00 € |
| Taux kilométrique | Coût par kilomètre | 0,30 € |
| Nom de l'arbitre | Utilisé dans les emails | *(vide)* |
| Adresse de départ | Adresse personnelle (réservé pour calcul futur) | *(vide)* |

### Positions des champs PDF (`Outils › Positions dans le PDF…`)

Permet d'ajuster les coordonnées (en points PDF, origine coin bas-gauche) de chaque champ inscrit dans le PDF :
- Compétition : Opposant, Date, Heure, Adresse salle
- Tableau financier : Péages, Nombre de km, Total frais
- Rapport JA : Accueil/ambiance, Équipements
- Image de signature : X, Y, Hauteur, Largeur
- Numéro de page

> **Repères A4 :** 595 × 842 pt · Y↑ monte dans la page · X→ va vers la droite

---

## API FFTT Smartping

La recherche de clubs utilise l'API officielle **Smartping** de la FFTT.

### Obtenir des identifiants
Les identifiants API sont à demander auprès de la FFTT :
📧 **interfaces.informatiques@fftt.email**

### Saisie dans l'application
Dans la fenêtre **Recherche club FFTT** (Outils › Recherche club FFTT…) :
1. Renseigner l'**ID d'application** et le **Mot de passe**
2. Cliquer sur **Enregistrer les identifiants**

Les identifiants sont stockés dans `positions.json` à côté de l'EXE.

### Authentification
L'authentification utilise **HMAC-SHA1** sur un horodatage :
```
tm  = timestamp Unix en millisecondes
tmc = HMAC-SHA1(timestamp, MD5(password))
```

---

## Fichiers de données

Tous les fichiers sont créés automatiquement à côté de l'EXE au premier lancement ou à la première sauvegarde.

| Fichier | Contenu |
|---------|---------|
| `positions.json` | Paramètres de l'application (coordonnées PDF, taux, identifiants API…) |
| `email_template.json` | Modèle du sujet et du corps de l'email |
| `PDF/` | Dossier de sortie des PDFs générés |

> Ces fichiers peuvent être sauvegardés / copiés d'un PC à l'autre pour transférer la configuration.

---

## Architecture du code

```
OrdreMission/
├── Program.cs                  # Point d'entrée
├── Form1.cs / .Designer.cs     # Formulaire principal
│
├── AppSettings.cs              # Modèle de config → positions.json
├── EmailTemplate.cs            # Modèle d'email → email_template.json
├── PdfService.cs               # Lecture et génération PDF (iText7)
├── FfttService.cs              # Client API Smartping FFTT
│
├── ParametresForm.cs           # Dialogue Paramètres
├── PositionsForm.cs            # Dialogue Positions PDF
├── EmailTemplateForm.cs        # Dialogue Modèle d'email
├── RechercheFfttForm.cs        # Dialogue Recherche club FFTT
├── EnvoyerEmailForm.cs         # Dialogue Composer/copier l'email
└── SignatureForm.cs            # Dialogue Signature
```

### Dépendances NuGet

| Package | Version | Rôle |
|---------|---------|------|
| `itext7` | 9.6.0 | Lecture et écriture de PDFs |
| `itext7.bouncy-castle-adapter` | 9.6.0 | Cryptographie pour iText7 |

---

## Compilation

### Prérequis développement
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022+ **ou** VS Code avec extension C#

### Compiler en ligne de commande

```bash
# Restaurer les packages
dotnet restore

# Compiler en mode Debug
dotnet build

# Compiler en mode Release (EXE autonome, Windows x64)
dotnet publish -c Release -r win-x64 --self-contained false -o ./publish
```

### Générer un EXE autonome (sans .NET pré-installé)

```bash
dotnet publish -c Release -r win-x64 --self-contained true \
  -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true \
  -o ./publish-standalone
```

---

## Licence & Contact

Ce logiciel est développé à titre personnel pour faciliter le travail des Juges Arbitres de la FFTT.  
Il est distribué librement pour usage personnel et associatif dans le cadre de la FFTT.

**Auteur :** Patrick CHAUTARD  
**Email :** patrick.chautard@free.fr  
**© Copyright 2026**
