# SaaSVet — Sistema de Consultas Veterinárias

Sistema completo de gerenciamento de consultas veterinárias, desenvolvido como trabalho final da disciplina de Arquitetura de Software e Desenvolvimento Full-Stack (UNIMAR).

## Tecnologias

**Backend**
- .NET 8 / ASP.NET Core
- Entity Framework Core (MySQL)
- Arquitetura DDD com Bounded Contexts

**Frontend**
- Next.js
- React com TypeScript

---

## Arquitetura

O sistema é organizado em dois Bounded Contexts:

**Register** — responsável pelo cadastro de donos e pets.
- Entidades: `PetOwner`, `Pet`
- Use Cases: `NewOwnerUseCase`, `NewPetUseCase`, `DeletePetUseCase`, `ShowOwnedPetsUseCase`, `ShowOwnedPetsUseCase`, `ShowOwnersUseCase`

**Appointment** — responsável pelo agendamento e gerenciamento de consultas.
- Entidades: `Appointment`
- Use Cases: `CreateAppointmentUseCase`, `CancelAppointmentUseCase`, `ViewPetAppointmentsUseCase`

Ambos os contextos compartilham um único banco de dados (`VetDbContext`), mantendo separação conceitual via camadas de domínio, aplicação e repositórios independentes.

### Camadas por contexto

```
Controller → UseCase → Domain → Repository → DbContext
```

---

## Regras de Negócio

- **CPF único:** não é permitido cadastrar dois donos com o mesmo CPF. Validado via índice único no banco e verificação no `NewOwnerUseCase`.
- **Conflito de horário:** não é permitido agendar uma consulta para um pet dentro de uma janela de 1 hora a partir do horário de outra consulta já existente.
- **Exclusão de pet:** não é permitido deletar um pet que possui consultas futuras agendadas. A exclusão é um soft delete — o registro é mantido no banco com `IsDeleted = true`.
- **Consulta no passado:** não é permitido agendar uma consulta com data anterior ao momento atual. Validado no construtor da entidade `Appointment`.

> **Decisões de escopo:** O conflito de horário é verificado por pet, não por veterinário, pois o sistema não contempla cadastro de veterinários. A janela de 1 hora foi definida como razoável para o contexto de consultas veterinárias.

---

## Como Rodar

### Pré-requisitos

- .NET 8 SDK
- Node.js
- MySQL rodando localmente

### Backend

```bash
# Na raiz do projeto backend
cd SaaSVet

# Configurar connection string em appsettings.json
# "DefaultConnection": "server=localhost;database=saasvet;user=root;password=sua_senha"

# Aplicar migrations
dotnet ef database update

# Rodar
dotnet run
```

A API estará disponível em `http://localhost:5248`.  
Swagger disponível em `http://localhost:5248/swagger`.

### Frontend

```bash
# Na raiz do projeto frontend
cd saasvet-frontend

npm install
npm run dev
```

O frontend estará disponível em `http://localhost:3000`.

---

## Endpoints Principais

### Register

| Método | Rota                                     | Descrição                 |
|--------|------------------------------------------|---------------------------|
| POST   | `/api/Owner/add`                         | Cadastrar dono            |
| GET    | `/api/Owner/list`                        | Listar donos              |
| POST   | `/api/Pet/add`                           | Cadastrar pet             |
| GET    | `/api/Pet/pet/all/{ownerId}`             | Listar pets de um dono    |
| DELETE | `/api/Pet/remove`                        | Deletar pet (soft delete) |

### Appointment

| Método | Rota | Descrição                 |
|--------|------|---------------------------|
| POST   | `api/Appointment/create`                 | Agenda consulta           |
| GET    | `api/Appointment/get/{petId}`            | Busca consultas de um pet |
| POST   | `api/Appointment/cancel/{AppointmentId}` | Cancela consulta          |

---

## Estrutura do Projeto

```
SaaSVet/
├── Common/
│   ├── Entities/
│   │   └── EntityBase.cs
│   └── Persistance/
│       └── VetDbContext.cs
└── Contexts/
    ├── Register/
    │   ├── Application/
    │   ├── Domain/
    │   ├── Infrastructure/
    │   └── Presentation/
    └── Appointment/
        ├── Application/
        ├── Domain/
        ├── Infrastructure/
        └── Presentation/
```

---

## Grupo
Gabriel Fernando, Thiago Siqueira
Trabalho desenvolvido para a disciplina de Arquitetura de Software e Desenvolvimento Full-Stack — UNIMAR.  
Professor: William Castro.
