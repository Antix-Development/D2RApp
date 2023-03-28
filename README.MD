
<div align="justify">

# D2RApp

### About

D2RAPP IS CURRENTLY IN DEVELOPMENT AND IS NOT FULLY FUNCTIONAL. WHEN THIS BLOCK OF TEXT IS REMOVED, IT IS READY TO BE USED ;)



D2RApp is an application written in C# that enables the user to mirror MouseMove, MouseClick, and KeyPress input events from one master computer to multiple connected slave computers, where the input events are sent from the master to the slaves when the ALT key is being held down.

It might seem strange but this enables the user to be able to have two client copies of Diablo II Ressurrected running on two separate computers and be able to control both running clients with one keyboard and mouse.

Its all pretty basic but it meets my simple requirements and I thought I'd make it public just incase anyone else was looking for the same thing.

As well as being able to generate input events on slave computers, the master computer can also command slave computers to execute a script (a sequence of actions).

### Installation
D2RApp is portable so just download the latest release and unzip it somewhere.

### Use
Start Diablo II Ressurrected on your master and slave computers.

Put your Diablo II Ressurrected computers into windowed mode (`ALT` + `ENTER`) and press `WINDOWS` + `ARROWUP` to make the program fill the screen properly in windowed mode (IMHO).

Start the `Server` application on your master computer, and run the `Client` application on all slave computers.

On each slave computer enter the IP Address and Port number of the Server (which will be displayed in the Servers title bar), and click the `Connect` button.

When a slave computer connects to the server, the server will transmit the currently loaded scripts to that slave.

Once slaves are connected, you can mirror input events on all connected slave computers from the master computer when the `ALT` key is being held down.

*TIP* I hold the `SHIFT` key down when mirroring mouse clicks so that my character on my master computer does not walk off randomly when I want to click on the slave computer.

### Scripts

Editing scripts...

From the main window, click the `Edit Scripts` button to open the script editor window, then in that window..

Click `New Script` to create a new script.

Once it has been created you can edit its name, change its order in the script list, delete it, and add actions to it.

Click the `Add Action` button to add a new action to the currently selected script.

Once created you can change its execution order in the action list, delete it, and modify its various parameters.

An action can be one of four types:

#### MouseMove
Click the `MouseMove` radiobutton to change the currently selected actions type to "MouseMove".
Change the values of the `X` and `Y` textboxes to set the position on the slave computer(s) that the action will move the mouse to.

#### LeftClick
Click the `LeftClick` radiobutton to change the currently selected actions type to "LeftClick".

#### RightClick
Click the `RightClick` radiobutton to change the currently selected actions type to "RightClick".

#### KeyPress.
Click the `KeyPress` radiobutton to change the currently selected actions type to "KeyPress".
Click the `Key` button which will cause D2RApp to start waiting for your desired key to br pressed.
Press the key you want the "Keypress" action to press.
Currently the valid keys are... (a-z) (0-9) (F1-F12) (;=,-./`) ([\]')

All actions will have their execution delayed by the number of milliseconds specified in the `Delay` textbox.




Clicking the "Accept" button on the "Settings" form, the server will broadcast all scripts to all connected clients, and also save the scripts locally in D2RApp's folder.'




Really you just need to run the software and have a play with it.

I don't think it's terribly difficult to figure it out and if there is something that it does not do, then you can always add that functionality yourself.

### Notes

D2RApp was written to work with my own personal setup which is two separate Windows10 computers, each running one copy of Diablo II Ressurrected in windowed mode. Your mileage may vary wildly with other configurations.

I only have two Diablo II Ressurrected licences so D2RApp has only been tested working with one slave.

This is my first C# project since I used it whilst working towards my Computer Science degree, it's probably pretty tragic ;)

Feel free to fork this repository and make your own crazy creations, just fire me a message.. I'd love to see what other people manage to do with it.

### DISCLAIMER
Now I did a bunch of searching on the internet and coudn't find anything about using such software as this with Diablo II Ressurrected. There is some mention of using input mirroring software with World Of Warcraft, but as far as I could see, nothing directly related to Diablo II Ressurrected.

The takeaway from this is as follows...

USE THIS SOFTWARE AT YOUR OWN RISK. IF YOUR ACCOUNT(S) GETS BANNED BECAUSE BLIZZARD DEEM YOU CHEATED THEN THAT'S ON YOU, TOTALLY YOU, AND NO-ONE ELSE. DO NOT WHINGE TO ME, BECAUSE YOU HAVE BEEN ADEQUATELY WARNED.

Furthermore...

I DO NOT USE OR CONDONE THE USE OF BOTS TO AUTOMATE ITEM FARMING IN D2R (OR ANY GAME) AND THIS SOFTWARE WAS IN NO WAY DESIGNED WITH THE AIM OF ENABLING THAT. I WOULD HOPE THAT YOU DO NOT TAKE THIS SOFTWARE AND USE IT FOR SUCH THINGS.
