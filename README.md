# Password Manager - Back-End

## Description
Ce projet est une API REST en .NET 8 permettant de stocker et gérer des mots de passe de manière sécurisée. L'API utilise une base de données SQL Server et implémente un chiffrement AES et RSA pour sécuriser les mots de passe.

## Prérequis
- .NET 8 SDK
- SQL Server
- Un outil de gestion de bases de données (SSMS, Azure Data Studio, etc.)

## Installation

1. Cloner le dépôt Git :
   ```sh
   git clone <URL_DU_REPO>
   cd PasswordManager-Back
   ```

2. Configurer la base de données :
   - Modifier `appsettings.json` pour définir la connexion SQL Server :
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=.\\SQLExpress;Database=PasswordManagerDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
     }
     ```
   - Appliquer les migrations :
     ```sh
     dotnet ef database update
     ```

3. Exécuter l'API :
   ```sh
   dotnet run
   ```

## Endpoints principaux
- `POST /passwords` : Ajouter un mot de passe avec chiffrement
- `GET /passwords/{id}` : Récupérer un mot de passe (déchiffré)
- `GET /applications` : Obtenir la liste des applications
- `POST /applications` : Ajouter une nouvelle application

## Sécurité
L'API utilise une clé d'API pour sécuriser les requêtes. Ajoutez votre clé dans les en-têtes HTTP :
```sh
curl -H "X-Api-Key: MyMegaSupraSuperSecretApiKey123!" http://localhost:5000/passwords
```

## Documentation API
L'API est documentée avec Swagger. Une fois lancée, accédez à :
```
http://localhost:5000/swagger
```

