						   ____            _      ____  ____   ____ 
						  | __ )  __ _ ___(_) ___|  _ \|  _ \ / ___|
						  |  _ \ / _` / __| |/ __| |_) | |_) | |  _ 
						  | |_) | (_| \__ \ | (__|  _ <|  __/| |_| |
						  |____/ \__,_|___/_|\___|_| \_\_|    \____|
<div align="center">

![GitHub contributors](https://img.shields.io/github/contributors/tojohnny/BasicRPG?logo=GitHub&style=for-the-badge) ![GitHub last commit](https://img.shields.io/github/last-commit/tojohnny/BasicRPG?logo=GitHub&style=for-the-badge) ![GitHub commit activity](https://img.shields.io/github/commit-activity/m/tojohnny/BasicRPG?logo=GitHub&style=for-the-badge) ![GitHub](https://img.shields.io/github/license/tojohnny/BasicRPG?style=for-the-badge)

# About The Project
Single-player Text RPG implemented with as many relevant known RPG mechanics as possible.

![Main UI](https://github.com/tojohnny/BasicRPG/blob/master/gui/main_02.png?raw=true)

# Description
- Built on .NET Framework 4.7.2
- Local MySQL Server Database hosted with MAMP

<p align="right">(<a href="#readme-top">back to top</a>)</p>

# Database Properties
- User database (player_id, username, password, email)
  - playerid (primary key, auto_increment)
  - username (unique)
  - password
  - email (unique)
  - 
<p align="right">(<a href="#readme-top">back to top</a>)</p>

# Features
- New User Registration Form
	- Username
	- Password/Re-enter Password
		- Stored as SHA256 Encrypted string.
	- E-mail/Re-enter Email
- Login Form
	- Username
	- Password

<p align="right">(<a href="#readme-top">back to top</a>)</p>

# Database UML Diagram
![UML Diagram](https://github.com/tojohnny/BasicRPG/blob/master/gui/uml_diagram_02.png?raw=true)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

# TODO (Roadmap)
List will update as progress moves forward, sometimes too many wants will lead to nothing at all.
List in no particular order.
- [x] New User Registration Form
- [x] Login Form
- [ ] Populate with account data and character data after login.
- [ ] Character creation.
- [ ] Add class data.
- [ ] Add character inventory/inventory history.
- [ ] Add items.
- [ ] Add User Account History.
- [ ] Add Character History.
- [x] Add UML diagram to README.
- [x] Re-design README.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

# License
Distributed under GNU Affero General Public License v3.0. Please see `licence.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>
