# Vendinha

Sistema desktop desenvolvido em C# utilizando Windows Forms e SQLite para controle de clientes e dívidas.


## Funcionalidades

- CRUD de Clientes
- CRUD de Dívidas
- Busca por nome
- Paginação
- Ordenação por maior dívida
- Validação de CPF
- Validação de E-mail
- Controle de pagamento


## Tecnologias

- .NET 10 SDK
- Windows Forms
- SQLite
- C#
- ADO.NET



## Como executar

1. Clone o repositório

```bash
git clone URL_DO_SEU_REPOSITORIO  // colocar git
```

2. Abra o projeto no Visual Studio 2022

3. Execute o projeto



## Banco de dados

O banco SQLite é criado automaticamente na primeira execução do sistema.



## Requisitos

- Visual Studio 2022
- .NET 8 SDK (fizemos no .NET 10 SDK, mas é compatível com o .NET 8)



## Funcionalidades implementadas

### Clientes
- Cadastro
- Edição
- Exclusão
- Busca por nome
- Paginação
- Ordenação por maior dívida

### Dívidas
- Cadastro de dívidas
- Controle de pagamento
- Listagem de dívidas por cliente

---

## Regras de negócio

- Apenas um cliente por CPF
- Apenas uma dívida pendente por cliente
- CPF validado
- E-mail validado

---

## Autor

Projeto desenvolvido para atividade acadêmica utilizando C# e Windows Forms.