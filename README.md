# An All-In-One helper app for GMs!

This WPF application is a one-stop-shop for all the little things GMs might be using multiple applications to do. The functions this has include:

- ### Dice Roller
    The dice roller has a default preset which would work for any game, but also a preset specifically made for use with the game Wilderfeast.
- ### Clocks
    A page where you can create clocks, a recommended mechanic for tracking future events in many RPGs. Simply enter the number of scenes/segments, give it a title, and the program will construct a clock for you. Left click to fill in a segment, and right click to take it back.
- ### Stat Tracker
    A page you can use to track any number of miscellaneous stats. Character's initiative, HP, number of rats remaining they need to clear out before the evil baron gives the players back the magical sword he stole and has been using for leverage. Anything at all.
- ### Memos
    A place to keep track of the things that you, as an adaptable and clever GM, had to come up with on the spot, so you can work them into your proper notes later. Just give a memo a name and write down as much detail as you like and this page will keep a record. You can edit memos after you've made them.
- ### Session Logs
    Keep record of your sessions, so you can always figure out which session it was that the players accidentally killed the NPC who had all the information they needed, and who was there to witness it, so you can give them a new arc where you give *them* that information and make it seem like it was what you planned to do all along. The session logs are compact, but you can double click any of them to see the full details, or edit them.

## To-Do:
- **Initiative Tracker**: A common tool GMs need is a page to keep track of who's turn it is. Most of the games *I* play don't require this, so I didn't think to include one, but it would be useful to almost everyone else.
- **Modularise Tabs**: If more tabs are added, a tab where you can decide *which* of the available pages you want visible could be useful. Most people might decide they have no need for the clocks page.
- **Improve Clocks**: In the most recent release, Clocks do not save with their progression, so upon loading they will have the correct name and number of segments, but segments won't be filled in. This needs to be fixed.
- **Name Generator**: Many GMs have a list of random NPC names ready to go. This program could benefit from a tab that generates people names, monster names, place names, etc.

### Acknowledgements:
This project makes frequent use of [Xceed's WPF Toolkit](https://github.com/xceedsoftware/wpftoolkit), specifically the Integer Up Down control, and NewtonSoft.Json for saving and loading data.

### Known Issues:
- In the current release, the Clock control does not correctly decrement filled segments when double clicked. This issue has been fixed and will be eliminated in the next release.
