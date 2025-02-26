# Password Manager - Front-End

## Description
Cette application Angular permet aux utilisateurs de gérer leurs mots de passe en toute sécurité. Elle communique avec une API .NET pour stocker et récupérer les mots de passe chiffrés.

## Prérequis
- Node.js (v16 ou plus récent)
- Angular CLI

## Installation

1. Cloner le dépôt Git :
   ```sh
   git clone <URL_DU_REPO>
   cd PasswordManager-Front
   ```

2. Installer les dépendances :
   ```sh
   npm install
   ```

3. Configurer l'URL de l'API :
   - Modifier `src/environments/environment.ts` :
     ```ts
     export const environment = {
       production: false,
       apiUrl: 'http://localhost:5000/api'
     };
     ```

4. Démarrer l'application :
   ```sh
   ng serve
   ```
   L'application sera accessible sur `http://localhost:4200/`.

## Fonctionnalités
- Affichage des applications disponibles
- Ajout de mots de passe sécurisés
- Afficahge des mots de passe sécurisés

