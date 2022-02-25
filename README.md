# The Simulation&trade;

## Installing Unity
1. Download or clone this repository <br>
    `git clone --recursive https://github.com/TAMU-Robomasters/Simulation.git`
    Be sure to note where you clone this repository.
    
2. Download [Unity Hub](https://public-cdn.cloud.unity3d.com/hub/prod/UnityHubSetup.exe) (from an App Store, Package manger, or Unity's website)
    - agree to the license thing
    - press back
    <img src="/documentation/images/activate.png" alt="where-to-click">
    
    - go to projects (should be empty)
    <img src="/documentation/images/unity_hub.png" alt="where-to-click">

    - click the "Add", find the Simulation folder you just downloaded, inside that folder go into the `unity` folder, and inside that open the `Simulation` folder
    - Then click the name of the project ("Simulation"), and there should be a black pop-up (at the bottom)
        - If Unity Hub warns you about the version number, you can go [here](https://unity3d.com/get-unity/download/archive) to install an older version of Unity.
    
    - Click install, then try opening the project again

3. Opening up the scene
    - Under the project tab
    - Select `Assets`
    - Select `Scenes`
    - Select `Arena.unity`

4. Now you should be able to see The Simulation&trade;!

## Branches (to be created)

### Localization Branch&reg;
This branch holds a simplified version of The Simulation&trade; and is used purely for Localization.
This should be bare bones and not include many special features.

~~Bugs~~ Features of the simulation should be:
- Basic arena model
- Basic robot model
- Ability to write to a .csv file
  - Depth
  - Position
  - Velocity

### Gameplay Branch&reg;
This branch holds a more realistic version of The Simulation&trade;.

~~Bugs~~ Features of the simulation should be:
- AI for the enemy robot
- Gameplay loop
- Standard Robot Model
- Accurate Arena model
