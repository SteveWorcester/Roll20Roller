# Roll20Roller

Summary: 
Roll20Roller is a quarantine friendly Dungeons and Dragons helper. It pulls character data from DnDBeyond.com and generates roll templates to be pasted into Roll20.net.

Roll20Roller does not require an API subscription to either/any service.

Current functionality: 
Select a character from the launch window or enter a character ID from DnDBeyond. The character ID is found in the URL when viewing your character.
Where to locate your Character ID: https://www.dndbeyond.com/profile/UserName/characters/>>USER ID #<<

Selenium then imports the current character data and reveals a window with rolling options. 
Do not close the command prompt that opens while importing your character! This will remain open while Roll20Roller is open, and is the selenium driver used for pulling data.

The rolling window will generate a roll template and copy it to the clipboard whenever a button is pressed. Paste into Roll20.net's chat to roll your current selection in Roll20Roller.
