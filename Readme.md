# Shipay Challenge - Backend API

Este repositório contém minha implementação do desafio técnico proposto pela Shipay para avaliação de habilidades em desenvolvimento backend.

O objetivo do projeto foi implementar uma **API REST** baseada no modelo de dados fornecido no desafio, permitindo operações relacionadas a usuários e papéis (roles), além de demonstrar boas práticas de arquitetura, containerização e automação de build.

---

# Arquitetura do Projeto

O projeto foi estruturado seguindo princípios de **Clean Architecture**, separando responsabilidades entre camadas.

---

```
ShipayChallange
├── ShipayChallange.Api            # Camada de apresentação (Controllers / Endpoints)
├── ShipayChallange.Application    # Regras de aplicação e casos de uso
├── ShipayChallange.Domain         # Entidades e regras de domínio
├── ShipayChallange.Infrastructure # Persistência, EF Core, banco de dados
├── docker-compose.yml             # Infraestrutura local
├── .env                           # Variáveis de ambiente
└── .github/workflows              # CI/CD com GitHub Actions
```

Essa abordagem facilita:

- separação de responsabilidades
- manutenção
- testabilidade
- escalabilidade da aplicação

---

# Tecnologias Utilizadas

- .NET 8
- ASP.NET Core
- Entity Framework Core
- SQL Server
- Docker
- Docker Compose
- GitHub Actions

---

# Funcionalidades Implementadas

Consulta SQL para listar usuário, e-mail, papel e permissões  
Consulta utilizando ORM (Entity Framework / LINQ)  
API REST para consulta de papel por ID  
API REST para criação de usuário  
Geração automática de senha quando não informada  
Containerização da aplicação  
Pipeline de build automatizado com GitHub Actions

---

# Executando o projeto localmente

## Pré-requisitos

- .NET 8 SDK
- Docker
- Docker Compose

---

# 1 - Clonar o repositório

```bash
git clone https://github.com/LucasDevolps/ShipayChallange.git

cd ShipayChallange
```
---

# 2 - Subir o banco de dados

- O projeto utiliza SQL Server via Docker.

```bash
docker-compose up -d
```

Isso criará automaticamente o container do banco.


--- 

# Variáveis de Ambiente

O projeto utiliza um arquivo `.env` para configuração de credenciais sensíveis.

Exemplo

```bash
	SA_PASSWORD=1234
```

---

# CI/CD

O projeto possui um pipeline automatizado utilizando GitHub Actions que executa:

- restore
- build
- publish da aplicação

Isso garante que o projeto compile corretamente a cada push.

---

# Autor

Lucas de Souza
Desenvolvedor Backend .NET