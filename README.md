# A3

Para rodar toda a infraestrutura do projeto, garanta que o [Docker](https://www.docker.com/products/docker-desktop/) esteja instalado e rodando, e execute na raíz do projeto:    
``
docker compose -f docker-compose.yml up -d
``

Para persistir as alterações dos projetos no Docker, faça o rebuild nas imagens do **Flask**, **.NET** ou do **postgres**.
