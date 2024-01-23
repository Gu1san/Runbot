# Runbot
Este projeto foi realizado como Trabalho Interdisciplinar 1 no curso de Jogos Digitais da PUC Minas.
Foi criado um Bullet Hell com temática futurista para PC. Nele, tive contato com todos os processos de criar um jogo, contemplando a criação do GDD, criação dos assets, códigos e cenários.

## Prévia
### Antes
https://github.com/Gu1san/Runbot/assets/69217564/17af9f75-8aac-4a5f-8f98-fce8e0872867

### Depois
https://github.com/Gu1san/Runbot/assets/69217564/d053fb95-f2a1-4128-836c-17da9fa9117a


## Design Patterns
### Singleton
A classe GameController gerencia dados globais do jogo, como vida do player, moedas e arma equipada. Por conta da função central dessa classe, ela pode ser acessada globalmente.

### Object Pool
Por se tratar de um shooter, é esperado que hajam muitos projéteis ao mesmo tempo na tela. Por esse motivo, decidi implementar o Object Pool usando a biblioteca UnityEngine.Pool

## VFX
Implementei alguns efeitos que fiz para a matéria de VFX usando Particle System, Shaders e VFX Graph

https://github.com/Gu1san/Runbot/assets/69217564/c95e5551-70fa-494a-8a04-e13ea8261ea0



https://github.com/Gu1san/Runbot/assets/69217564/c65e7ae2-1865-4703-a172-06d8e40088df



https://github.com/Gu1san/Runbot/assets/69217564/4c60df3a-0069-4351-b3a0-25aa65fe9e85



https://github.com/Gu1san/Runbot/assets/69217564/f390f6c1-4b6a-44a9-a9ce-90742a8ce51b

