# Mages

Dawid Nadzieja © 2023

<p align="center">
<img src="https://github.com/daveekh/Mages/assets/33668566/3b58c7f0-ca45-4f37-933f-21ba497d44f8" width=75% height=75% />
</p>

"Mages" is a singleplayer game in which you fight versus an old wizard in a turn-based system. It's made for my bachelor thesis that focuses mostly on AI based on fuzzy logic. 

<p align="center">
<img src="https://github.com/daveekh/Mages/assets/33668566/60e14f66-56f2-46a4-94bc-61ef068a66c8" width=75% height=75% />
</p>

The game itself has a gameplay screen, bottom UI that has four possible spells to use & move keys and right UI that has HP & mana bars, current turn display and also console that registers every move. Every spell has different range, mana cost and damage. Enemy AI has two states - patrolling and attacking. In patrolling state, it moves randomly in one of the four directions. In attacking state, it takes into account two variables - own mana bar and player's HP bar and then calculates possibilities of every spell. If chosen spell isn't possible to cast because of the range, AI moves into player's direction to reduce the distance. The game ends when one of the character ends up with 0 HP. My bachelor thesis with details is available to download in this repo, but it's written in polish language. 



## How to play?

In the Releases folder there are .zip archives for Linux and Windows version. Simply download it and open the .exe or .x86_64 file. No installation required. 
