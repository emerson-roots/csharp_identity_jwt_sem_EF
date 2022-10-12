 ![NPM](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white) ![NPM](https://img.shields.io/badge/.NET-512BD4?style=flat&logo=dotnet&logoColor=white)   ![NPM](https://img.shields.io/badge/Swagger-85EA2D?style=flat&logo=Swagger&logoColor=white)   ![NPM](https://img.shields.io/badge/SQLite-07405E?style=flat&logo=sqlite&logoColor=white)  ![NPM](https://img.shields.io/badge/Visual_Studio-5C2D91?style=flat&logo=visual%20studio&logoColor=white)
 
 # Sobre: PoC - Identity sem Entity Framework
Um pequeno projeto ilustrando o uso das funcionalidades básicas do identity [(Microsoft.AspNetCore.Identity)](https://learn.microsoft.com/pt-br/aspnet/core/security/authentication/identity?view=aspnetcore-6.0&tabs=visual-studio) excluindo a camada na qual utiliza o Entity Framework e usando uma camada de dados personalizada;

##### 12/10/2022
implementado da camada de acesso a dados (persistência) relacionados ao usuário (UserRepository);

##### Próximos passos (não necessáriamente na ordem listada);
- implementar camada de acesso a dados  (persistência) relacionados aos perfis de acesso (Roles)
- implementar camada de retorno dos resultados do identity com base na persistência de dados dos usuários (IdentityResult)
- implementar serviço de tokens JWT
- implementar serviço de envio de e-mail de confirmação;

# 🚀 Autor
*Emerson Melo de Lima*
# ✉️ Email
emerson_sardinha@hotmail.com
