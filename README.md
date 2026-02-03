# 🚀 Arcadia API

A .NET 10 GraphQL API with PostgreSQL following Clean Architecture.

## 🧱 Architecture

- **Domain**: Enterprise entities and core rules (no framework dependencies).
- **Application**: Use cases/services and interfaces.
- **Infrastructure**: EF Core, repositories, migrations, and interceptors.
- **API**: GraphQL schema, health controller, and app configuration.

## 📁 Project Structure

```
src/
  ArcadiaApi.Api/           # GraphQL + Health API
  ArcadiaApi.Application/   # Use cases & interfaces
  ArcadiaApi.Domain/        # Entities
  ArcadiaApi.Infrastructure/# EF Core + Migrations
```

## 📋 Requirements

- [SDK .NET 10](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- PostgreSQL
- Docker (optional)

## 📦 Libraries (NuGet)

- HotChocolate.AspNetCore (15.1.12)
- HotChocolate.Data.EntityFramework (15.1.12)
- Microsoft.EntityFrameworkCore (10.0.2)
- Microsoft.EntityFrameworkCore.Design (10.0.2)
- Npgsql.EntityFrameworkCore.PostgreSQL (10.0.0)
- Microsoft.AspNetCore.OpenApi (10.0.2)
- Swashbuckle.AspNetCore (10.1.0)

## ⚙️ Configuration

Clone repository:

```bash
git clone git@github.com:Aureo-Bueno/ArcadiaApi.git
```

### Run migrations

```bash
dotnet ef database update \
  --project src/ArcadiaApi.Infrastructure \
  --startup-project src/ArcadiaApi.Api
```

Add a new migration:

```bash
dotnet ef migrations add <MigrationName> \
  --project src/ArcadiaApi.Infrastructure \
  --startup-project src/ArcadiaApi.Api
```

### Run locally

```bash
dotnet run --project src/ArcadiaApi.Api
```

### Run with Docker

```bash
docker compose up --build
```

The API will be available at:

- `http://localhost:8080/graphql`
- `http://localhost:8080/swagger` (Development)
- `http://localhost:8080/health`

## ✅ Health Check

```bash
curl http://localhost:8080/health
```

Expected response:

```json
{"status":"ok"}
```

## 🔎 GraphQL Examples

### Queries

Super heroes:

```graphql
query {
  superHeroes {
    id
    name
    description
    powerLevel
  }
}
```

With filter:

```graphql
query {
  superHeroes(where: { name: { eq: "Superman" } }) {
    id
    name
    description
    powerLevel
  }
}
```

Movies:

```graphql
query {
  movies {
    id
    title
    description
    superHeroId
  }
}
```

Powers:

```graphql
query {
  powers {
    id
    superPower
    description
    superHeroId
  }
}
```

Villains:

```graphql
query {
  villains {
    id
    name
    description
    powerLevel
  }
}
```

Teams:

```graphql
query {
  teams {
    id
    name
    description
    superHeroes {
      id
      name
    }
    villains {
      id
      name
    }
  }
}
```

Combat:

```graphql
query {
  combat(
    superHeroId: "253a3137-0404-4274-a15f-bcf608ce8a71",
    villainId: "1d7b30f3-72d4-43b1-a9f9-1630f4fd63be"
  ) {
    outcome
    winnerId
    winnerName
    heroPowerLevel
    villainPowerLevel
  }
}
```

### Mutations

Add super hero:

```graphql
mutation {
  addSuperHero(
    name: "Peter Parker",
    description: "Friendly neighborhood Spider-Man",
    powerLevel: 78
  ) {
    id
    name
    description
    powerLevel
  }
}
```

Update super hero:

```graphql
mutation {
  updateSuperHero(
    id: "636a1f89-05ba-4a04-a473-87478369dc34",
    name: "Peter Parker",
    description: "Friendly neighborhood Spider-Man",
    powerLevel: 82
  ) {
    id
    name
    description
    powerLevel
  }
}
```

Add power:

```graphql
mutation {
  addPower(
    superHeroId: "253a3137-0404-4274-a15f-bcf608ce8a71",
    description: "Can lift heavy objects",
    superPower: "Super strength"
  ) {
    id
    superPower
    description
    superHeroId
  }
}
```

Update power:

```graphql
mutation {
  updatePower(
    id: "1c6c0a5d-dbb3-489d-9a9c-d851673ccbbf",
    superHeroId: "253a3137-0404-4274-a15f-bcf608ce8a71",
    description: "Updated description",
    superPower: "Updated power"
  ) {
    id
    superPower
    description
    superHeroId
  }
}
```

Add villain:

```graphql
mutation {
  addVillain(
    name: "Green Goblin",
    description: "A ruthless industrialist turned villain",
    powerLevel: 84
  ) {
    id
    name
    description
    powerLevel
  }
}
```

Update villain:

```graphql
mutation {
  updateVillain(
    id: "6e3c7e69-6c1d-4b04-9de3-3c62d0a31622",
    name: "Lex Luthor",
    description: "Updated description",
    powerLevel: 90
  ) {
    id
    name
    description
    powerLevel
  }
}
```

Add team:

```graphql
mutation {
  addTeam(
    name: "Justice League",
    description: "Earth's greatest heroes",
    superHeroIds: [
      "253a3137-0404-4274-a15f-bcf608ce8a71",
      "2968f15c-fa74-4058-b790-3feec7934faf"
    ],
    villainIds: [
      "1d7b30f3-72d4-43b1-a9f9-1630f4fd63be"
    ]
  ) {
    id
    name
  }
}
```

Update team:

```graphql
mutation {
  updateTeam(
    id: "f2c50f10-1111-4444-8888-1234567890ab",
    name: "Justice League Unlimited",
    description: "Updated description",
    superHeroIds: [
      "253a3137-0404-4274-a15f-bcf608ce8a71"
    ],
    villainIds: [
      "6e3c7e69-6c1d-4b04-9de3-3c62d0a31622"
    ]
  ) {
    id
    name
  }
}
```

Add members to a team:

```graphql
mutation {
  addTeamMembers(
    id: "f2c50f10-1111-4444-8888-1234567890ab",
    superHeroIds: [
      "2968f15c-fa74-4058-b790-3feec7934faf"
    ],
    villainIds: [
      "1d7b30f3-72d4-43b1-a9f9-1630f4fd63be"
    ]
  ) {
    id
    name
  }
}
```

Remove members from a team:

```graphql
mutation {
  removeTeamMembers(
    id: "f2c50f10-1111-4444-8888-1234567890ab",
    superHeroIds: [
      "2968f15c-fa74-4058-b790-3feec7934faf"
    ],
    villainIds: [
      "1d7b30f3-72d4-43b1-a9f9-1630f4fd63be"
    ]
  ) {
    id
    name
  }
}
```
