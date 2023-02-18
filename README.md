	 ____            _      ____  ____   ____ 
	| __ )  __ _ ___(_) ___|  _ \|  _ \ / ___|
	|  _ \ / _` / __| |/ __| |_) | |_) | |  _ 
	| |_) | (_| \__ \ | (__|  _ <|  __/| |_| |
	|____/ \__,_|___/_|\___|_| \_\_|    \____|
<div align="center">

![GitHub contributors](https://img.shields.io/github/contributors/tojohnny/BasicRPG?logo=GitHub&style=for-the-badge) ![GitHub last commit](https://img.shields.io/github/last-commit/tojohnny/BasicRPG?logo=GitHub&style=for-the-badge) ![GitHub commit activity](https://img.shields.io/github/commit-activity/m/tojohnny/BasicRPG?logo=GitHub&style=for-the-badge) ![GitHub](https://img.shields.io/github/license/tojohnny/BasicRPG?style=for-the-badge)

</div>

# About The Project
Single-player Text RPG implemented with as many relevant known RPG mechanics as possible.

![Main UI](https://github.com/tojohnny/BasicRPG/blob/master/gui/main_06.png?raw=true)

# Project Properties
- Built on .NET Framework 4.7.2
- Local MySQL Server Database hosted with MAMP

<p align="right">(<a href="#readme-top">back to top</a>)</p>

# Features
- New User Registration
	- Encrypted password (SHA256).
- Returning User Login
- History System (Logging)
	- User History
		- Creation
		- Last Login
	- Character History
		- Creation
		- Last Login
- Player Systems
	- Character
		- Edit Character Name
		- Delete Character
		- Multiple Characters per Account
	- Currency
- Console
	- Displays messages, actions, etc.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

# Database UML Diagram
![UML Diagram](https://github.com/tojohnny/BasicRPG/blob/master/gui/uml_diagram_02.png?raw=true)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

# TODO (Roadmap)
List will update as progress moves forward, sometimes too many wants will lead to nothing at all.
List in no particular order.
- [x] New User Registration Form
- [x] Login Form
- [x] Populate with account data and character data after login.
- [x] Character creation.
- [x] Character stats linked to character.
- [X] Add character level/exp.
- [X] Allow user to edit a selected character name.
- [X] Allow user to delete a selected character.
- [ ] Add class data.
- [ ] Add character inventory/inventory history.
- [ ] Add items.
- [x] Add currency.
- [x] Tie map to location, lights up upon entering location.
- [ ] Create commands for user interaction.
- [ ] Add enemies.
- [ ] Finish combat HP functions.
- [X] Add User Account History.
- [X] Add Character History.
- [x] Add UML diagram to README.
- [x] Re-design README.
- [x] Chatbox features.
- [ ] Chat log output at end of session.
- [ ] Runtime/Execution log during session.
- [ ] Refactor SQL queries to remove wildcards.
- [ ] Update character information window to join character level table and character table.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

# License
Distributed under GNU Affero General Public License v3.0. Please see `licence.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

# Sources
Random Name Generator - https://thestoryshack.com/

<p align="right">(<a href="#readme-top">back to top</a>)</p>
