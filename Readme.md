# File Organizer

:computer: A simple console application to organize files by their extensions
(This is my first repository on github, enjoy! :blush: )
## How to setup and run
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
6. Under "Add arguments (optional)" enter `<direcctory> --<operation>`, e.g. `C:\Users\username\Downloads --pack`
7. Under "Start in (optional)" enter installed directory, e.g. `E:\Software\installed folder`
8. Finish

## Commands
- Command structure: `FileOranizer.exe <directory> --<operation>`
- `<directory>` is the target directory to clean
- `<operation>` is the operation that the program will perform, they are:
	- `--pack` move all file types into allocated directory.
	- `--unpack` move all file within the subfolders into root directory.


## Example command
- Pack and clean file in directory `C:\Users\username\Downloads`
	- `FileOrganizer.exe C:\Users\username\Downloads --pack`
- Restore packed file
	- `FileOrganizer.exe C:\Users\username\Downloads --unpack`
## Demo use (command prompt)
![demo](pictures/Comand_Demo.gif)
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTY3Nzc5NjY4MCwtMTI3MDU5MDEyOSwxMD
g2NjQwODI1LDE2ODM3NDk3MjcsNTQ2NzU5NjUwLC05OTU4MTQ2
OTcsMTE4OTQ5NzQ4M119
-->