# Runbot
Este projeto foi realizado como Trabalho Interdisciplinar 1 no curso de Jogos Digitais da PUC Minas.
Foi criado um Bullet Hell com temática futurista para PC. Nele, tive contato com todos os processos de criar um jogo, contemplando a criação do GDD, criação dos assets, códigos e cenários.

## Prévia
https://github.com/Gu1san/Runbot/assets/69217564/17af9f75-8aac-4a5f-8f98-fce8e0872867

## Design Patterns
### Singleton
A classe GameController gerencia dados globais do jogo, como vida do player, moedas e arma equipada. Por conta da função central dessa classe, ela pode ser acessada globalmente.

### Object Pool
Por se tratar de um shooter, é esperado que hajam muitos projéteis ao mesmo tempo na tela. Por esse motivo, decidi implementar o Object Pool usando a biblioteca UnityEngine.Pool

