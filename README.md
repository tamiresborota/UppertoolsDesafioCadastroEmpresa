# Plataforma integrada

Exercício feito com único propósito de ingresso no processo de seleção para oportunidade de desenvolvimento na Uppertools Tecnologia da Informação


# Justificativas

Conforme orientado pelo documento, usei as tecnologias determinadas mas por nunca ter trabalhado com .NET FrameWork, fiz algumas pesquisas e cursos rápidos para melhor desenvolver o projeto seguindo as decisões tecnológicas dessas referências.
Em relação à API da Receita optei por seguir com dados mais simples, ao invés de puxar todos os dados gerados da Api pois alguns dados ficariam ociosos. Para gerar o modelo de dados da Api da receita, a ferramenta online json2csharp foi utilizada. Ainda sobre a Api, encontrei uma biblioteca pronta (CPFCNPJ por Mauricio Junior) para validar o CNPJ, porém para fins didáticos implementei manualmente.
Todas as Api foram geradas utilizando gerador de controller do Visual Studio 2022 e modificadas para atender os requisitos do projeto. E também, o modelo de dados foi criado através das ferramentas Entity FrameWork para mapear o banco que projetei através do SQL Server Management Studio.

## Arquitetura

Utilizei o padrão MVC (Model-View-Controller). Os modelos mapeiam as entidades do banco de dados, os controladores gerenciam operações sobre esses dados, e rotas direcionam requisições aos controladores. Integrei classes auxiliares, como consulta na Receita e validação de CNPJ, para suportar funcionalidades específicas. Essa abordagem proporciona organização, facilitando a manutenção e evolução da aplicação.

## Tecnologias

Utilizei .Net FrameWork 6.0, C#, SQL Server 2022, Git, Visual Studio 2022, Swagger (Swashbuckle.AspNetCore), Newtonsoft.Json e Entity Framework.

## Dificuldades gerais
Foi a primeira vez desenvolvendo para Web, até então tinha apenas desenvolvido alguns projetos da faculdades com fins didáticos em linguagem Java.
Durante o período do teste utilizei como base alguns cursos da Alura, e diversas referências da internet, como: Youtube, documentação da Microsoft e Stack Overflow.

## Conclusão
Foi um projeto enriquecedor e desafiador, tive momentos de dificuldade em que superei e aprendi muito, que me fez ter ainda mais energia para continuar me aprimorando e estou empolgada para desbravar essa nova jornada que apenas comecei.
