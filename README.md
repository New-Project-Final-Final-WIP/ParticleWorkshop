# Particle Workshop

A simple plugin for creating particles with color and alpha over time in [Neos VR Metaverse Engine](https://neosvr.com/).
Created by Gareth48 with some huge help from Epsilion!

## Getting Started (For Users)
1. Click this link to go to [releases](https://github.com/New-Project-Final-Final-WIP/ParticleWorkshop/releases)
1. Download the .dll
1. Navigate to your Libraries directory, usually ~\Steam\steamapps\common\NeosVR\Libraries
1. Place the dll in that folder
1. In steam, right click Neos VR and select Properties
1. In launch settings paste this line -LoadAssembly "Libraries\ParticleWorkshop.dll"
1. Once you're in game you can check if it worked by checking your friends list, if your friends appear pink you've succeeded

## What to do once you're in game
1. Open the component browser and navigate to the tab labaled "Gareth"
1. There are three new components
1. Live particle editor, which accepts and can edit a particle system in realtime (make sure the blend mode on your particle material is set to alpha if you want to see alpha changes!)
1. Random Particles, which randomly generates particles with a set amount of alpha and color transitions
1. If you use the live particle editor, once you're satisfied with your changes you can just delete the component and your changes will be saved
1. Once you've created a particle, save it to your inventory, remove the launch option addition and reboot Vanilla Neos
1. Enjoy your new particle! Feel free to use it as you please, if you do something neat with it I would love to see a picture!

## How this works
1. If it helps, think of this plugin like an inventory editor
1. Using it, we can create objects that Neos technically supports but that we have no way to generate at the moment
1. An example of color over time in the base game is the particle spray tip! It's rainbow effect is acheived in this way
1. All this plugin does is provide a GUI for you to edit those values

## Known issues
1. You cannot add duplicate color or alpha transitions
1. You can only add up to 8 unique color transitions AND 8 unique alpha transitions
1. Driving randomiterations to a large number will crash the game!
1. If the component somehow stops working, delete all instances of it, restart your game and send your logs to Gareth48
1. As a good rule of thumb, deleting the component, restarting your game and reapplying it should fix most trivial bugs
1. Once you assign a particle style to the Live Particle Editor's reference field the component it is locked on. To edit another particle system simply create another Live Particle Editor

## Contribution Guidelines
1. Please send any bugs or suggestions you have to Gareth48 in Neos, or report them via the github
1. If you would like, open an issue stating your problem or motivation and a suggested solution. 
1. Create a pull request which links to your issue.