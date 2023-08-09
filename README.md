# Projeto corretora de seguros

### Sistema desenvolvido para projeto 3° ADS - Fatec - Taquaritinga

Este sistema foi desenvolvido com objetivo de auxiliar a gestão de uma corretora de seguros da cidade de Matão - SP. 
O sistema é de uso interno, sendo possível cadastrar clientes e os planos que estão contratando com a seguradora.
## Instalação

### Bibliotecas necessárias
* Microsoft.EntityFramework.core
* Microsoft.EntityFramework.core.tools
* Microsoft.EntityFramework.core.SQLServer ou Microsoft.EntityFramework.core.< DB que estiver utilizando >

### Conexão com DataBase

String de conexão com banco de dados na Program.cs
```bash
Server="SeuServidor/LocalHost";Database=NomeDatabase;Trusted_Connection=True
```
String de conexão do SQL server, em caso de utilizar outro DB, pesquisar por < database > connection string

### Adicionar migração para criar tabelas no banco de dados

Abrir package manager console e executar o comando
```bash
add-migration < nome da migration > 
```
Após isso, executar
```bash
update-database
```

Desta forma o sistema ja estará disponivel para uso. 

 * Executar com IIS express em caso de erro de privacidade.

