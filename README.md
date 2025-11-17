# 🏥 CaseFinx — Sistema de Gestão de Pacientes e Histórico Clínico

O **CaseFinx** é um sistema desenvolvido em **Clean Architecture + DDD**, utilizando **.NET 8**, **MongoDB**, **Docker**, e uma arquitetura modular pensada para ser escalável, testável e fácil de manter.

O objetivo do sistema é:
- Cadastrar e gerenciar pacientes  
- Manter histórico clínico  
- Tratar duplicidade de registros  
- Facilitar integrações futuras com sistemas hospitalares  

# 🧩 Arquitetura

A estrutura segue Clean Architecture e princípios de DDD:

```
src/
  ├── CaseFinx.Api                 → Controllers, rotas, configuração
  ├── CaseFinx.Application         → Casos de uso, DTOs, Services
  ├── CaseFinx.Domain              → Entidades e regras do domínio
  └── CaseFinx.Infrastructure      → Repositórios Mongo e serviços externos
tests/                              → Testes automatizados
```

### 🔨 Tecnologias principais
- **.NET 8 Web API**
- **MongoDB**
- **Swashbuckle / Swagger**
- **Docker + Docker Compose**
- **DDD + Clean Architecture**
- **xUnit (testes)**

# 🗂 Detalhamento das Camadas

## **📌 1. CaseFinx.Api**
Responsável por:
- Endpoints REST
- Configuração do Swagger
- Injeção de dependência (DI)
- Serialização e validação de entrada
- Conexão com Application

## **📌 2. CaseFinx.Application**
Contém a lógica de aplicação:
- DTOs
- Interfaces de comunicação com o domínio
- Services (casos de uso)
- Validações simples

## **📌 3. CaseFinx.Domain**
Camada mais importante da arquitetura:
- Entidades
- Regras de negócio
- ValueObjects (em expansão)
- Interfaces do domínio

## **📌 4. CaseFinx.Infrastructure**
Implementa:
- Repositórios MongoDB
- Conexão (MongoDbContext)
- Pastas para serviços externos
- Mapeamento e persistência

# 🔗 Regras de Dependência (Clean Architecture)

```
Api → Application → Domain
Api → Infrastructure → Application → Domain
Infrastructure → Application → Domain
Domain → (não depende de ninguém)
```

Cada projeto referencia apenas o que deve.

# 🚀 Como rodar o projeto

## **1. Clone o repositório**
```bash
git clone https://github.com/laviniaptrabuco/CaseFinx.git
cd CaseFinx
```

## **2. Rodando com Docker**
Subir MongoDB e Mongo Express:
```bash
docker-compose up -d
```

Serviços disponíveis:
- MongoDB → `localhost:27017`
- Mongo Express → `http://localhost:8081`

## **3. Rodando a API**
```bash
cd src/CaseFinx.Api
dotnet run
```

API disponível em:
```
http://localhost:5000
```

Swagger:
```
http://localhost:5000/swagger
```

# 🧪 Testes Automatizados

Para rodar os testes:
```bash
dotnet test
```

A pasta **tests/** contém a estrutura de testes por camada.

# 📬 Postman Collection

O arquivo `postman_collection.json` está na raiz para facilitar testes dos endpoints.

# 📌 Decisões Técnicas

- Clean Architecture para baixo acoplamento  
- MongoDB pela modelagem flexível  
- DDD para centralizar regras de negócio  
- Uso de Services no Application para isolar casos de uso  
- Repositórios com abstração (Interfaces + Implementação)  
- Docker para ambiente previsível  