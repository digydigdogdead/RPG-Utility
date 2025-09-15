# An All-In-One helper app for GMs!

This WPF application is a one-stop-shop for all the little things GMs might be using multiple applications to do. The functions this has include:

- ### Dice Roller
    The dice roller has a default preset which would work for any game, but also presets for the games Wilderfeast and Household.
  ![image](https://i.imgur.com/Em6NcJo.png)
- ### Initiative Tracker
    A page where you can add all the fighters in a given scene and their initiative, and the application will track the turn order for you.
    ![image](https://i.imgur.com/fEArT7C.png)
- ### Clocks
    A page where you can create clocks, a recommended mechanic for tracking future events in many RPGs. Simply enter the number of scenes/segments, give it a title, and the program will construct a clock for you. Left click to fill in a segment, and right click to take it back.
    ![image](https://i.imgur.com/Ljg1ZIz.png)
- ### Stat Tracker
    A page you can use to track any number of miscellaneous stats. Character's initiative, HP, number of rats remaining they need to clear out before the evil baron gives the players back the magical sword he stole and has been using for leverage. Anything at all. By right clicking a stat you've made, you can colour code it for easy scanning!
  ![image](https://i.imgur.com/vxFy1eF.png)
- ### Memos
    A place to keep track of the things that you, as an adaptable and clever GM, had to come up with on the spot, so you can work them into your proper notes later. Just give a memo a name and write down as much detail as you like. You can view the full details and edit them by double clicking on a memo.
![image](https://i.imgur.com/UEDyzc7.png)
- ### Session Logs
    Keep record of your sessions, so you can always figure out which session it was that the players accidentally killed the NPC who had all the information they needed, and who was there to witness it. The session logs are compact, but you can double click any of them to see the full details and edit them.
  
    ![image](https://i.imgur.com/uWHS1lG.png)
- ### Name Generator
    Randomly generate names for people, places, and monsters. You can add memos to the memo page straight from the name you generated.
  
  ![image](https://i.imgur.com/G8Ge9rp.png)

## To Do:
- **Rehaul Save/Load**: At the moment saving is quite intrusive and requires the user to click out of an alert window. I'd like to make it smoother, and make it more obvious to users if they have unsaved changes.
- **Incoporate conditions to Initiative Tracker**: A request has been made to include player conditions in the Initiative tracker page 

### Acknowledgements:
This project makes frequent use of [Xceed's WPF Toolkit](https://github.com/xceedsoftware/wpftoolkit), specifically the Integer Up Down control, and NewtonSoft.Json for saving and loading data. The icon is a segment from official art for the podcast Dice So Nice I Said Dice Twice, illustrated by Kevin Ryan, used with permission.
