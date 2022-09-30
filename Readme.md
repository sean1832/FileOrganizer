# File Organizer

:computer: A simple console application to organize files by their extensions
(This is my first repository on github, enjoy! :blush: )
## How to use
1. [**Download all files for application**](https://github.com/sean1832/Organizer/tree/master/FileOrganizer/deploy)
2. **Extract** files into local directory

### Command Prompt

1. Open **cmd** in **installed directory**
2. Initiate application `FileOrganizer.exe`
3. Enter directory path to clean (eg. `C:\path..."` )
4. Enter operation `--pack` or `--unpack`

### Task Scheduler
1. Open task scheduler
2. Create a basic task
3. Set desier trigger time
4. Under Action, select "Start a Program"
5. Click "Browse" and navigate to local installed directory. Select "FileOrganizer.exe".
6. under "Add arguments"
## Example command
- Pack and clean file in directory `C:\Users\username\Downloads`
	- `FileOrganizer.exe C:\Users\username\Downloads --pack`
- Restore packed file
	- `FileOrganizer.exe C:\Users\username\Downloads --unpack`
## Demo use (command prompt)
![demo](pictures/Comand_Demo.gif)
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTE0OTk3ODc4NDcsLTEyNzA1OTAxMjksMT
A4NjY0MDgyNSwxNjgzNzQ5NzI3LDU0Njc1OTY1MCwtOTk1ODE0
Njk3LDExODk0OTc0ODNdfQ==
-->