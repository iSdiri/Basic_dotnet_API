# Basic .NET API

Une API RESTful simple construite avec ASP.NET Core 8 pour démontrer une structure de projet propre avec des contrôleurs, DTOs, mappers, repositories et modèles.

## Stack Technique

- .NET 8
- C#
- Entity Framework Core (InMemory)
- Swagger / OpenAPI

## Démarrage
```bash
git clone https://github.com/TON_USERNAME/Basic_dotnet_API.git
cd Basic_dotnet_API
dotnet restore
dotnet run
```

Interface Swagger disponible sur : `http://localhost:5092/swagger`

## Endpoints

### User

| Méthode | Route | Description |
|---------|-------|-------------|
| GET | /api/user | Récupérer tous les utilisateurs |
| GET | /api/user/{id} | Récupérer un utilisateur par ID |
| POST | /api/user | Créer un utilisateur |
| PUT | /api/user/{id} | Modifier un utilisateur |
| DELETE | /api/user/{id} | Supprimer un utilisateur |

### Task

| Méthode | Route | Description |
|---------|-------|-------------|
| GET | /api/task | Récupérer toutes les tâches |
| GET | /api/task/{id} | Récupérer une tâche par ID |
| POST | /api/task | Créer une tâche |
| PUT | /api/task/{id} | Modifier une tâche |
| DELETE | /api/task/{id} | Supprimer une tâche |

## À Venir

- [ ] Base de données SQL Server / PostgreSQL
- [ ] Validation des entrées (FluentValidation)
- [ ] Authentification JWT
- [ ] Pagination
- [ ] Tests unitaires