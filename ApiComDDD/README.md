# O que é este projeto?
Projeto de estudo sobre DDD em uma aplicação API Web com ASP NET Core.

# Como testar?

### POST de compra para cliente 1

```
{
  "clienteId": 1,
  "dataDaCompra": "2018-09-13T17:26:39.448Z",
  "ruaDeEntrega": "Rua 1",
  "cidadeDeEntrega": "Maringá",
  "estadoDeEntrega": "PR",
  "cepDeEntrega": "-",
  "listaDeProdutosDaCompra": [
    {
      "idDoProduto": 1,
      "preco": 100,
      "desconto": 20,
      "quantidade": 1
    }
  ]
}
```

Resultado esperado ao realizar o GET: `"valorTotalDaCompra": 68`, pois a regra é 15% na primeira compra para determinado cliente.

### POST de compra para cliente 2

```
{
  "clienteId": 2,
  "dataDaCompra": "2018-09-13T17:26:39.448Z",
  "ruaDeEntrega": "Rua 2",
  "cidadeDeEntrega": "Maringá",
  "estadoDeEntrega": "PR",
  "cepDeEntrega": "-",
  "listaDeProdutosDaCompra": [
    {
      "idDoProduto": 1,
      "preco": 50,
      "desconto": 10,
      "quantidade": 2
    }
  ]
}
```

Resultado esperado ao realizar o GET: `"valorTotalDaCompra": 68`, pois a regra é 15% na primeira compra para determinado cliente.

### POST de compra para cliente 1

```
{
  "clienteId": 1,
  "dataDaCompra": "2020-09-14T17:26:39.448Z",
  "ruaDeEntrega": "Rua 1",
  "cidadeDeEntrega": "Maringá",
  "estadoDeEntrega": "PR",
  "cepDeEntrega": "-",
  "listaDeProdutosDaCompra": [
    {
      "idDoProduto": 1,
      "preco": 100,
      "desconto": 20,
      "quantidade": 1
    }
  ]
}
```

Resultado esperado ao realizar o GET: `"valorTotalDaCompra": 76`, pois a regra é 5% de desconto na compra quando o cliente já fez compras há mais de um ano.

# Criado com

* Microsoft Visual Studio Community 2019
* Entity Framework Core
* Entity Framework Core In Memory
* NewtonsoftJson
* OpenAPI
* Swagger