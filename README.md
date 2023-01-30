# About
Single-player Text RPG implemented with as many relevant known mechanics as possible.

# Project Properties
- Built on .NET Framework 4.7.2
- Local MySQL Server Database hosted with MAMP

# Database Properties
- User database (player_id, username, password, email)
  - playerid (primary key, auto_increment)
  - username (unique)
  - password
  - email (unique)

# Current Features
- New User Registration Form
  - SHA256 Password Encryption
  - Checks for unique username/email.
  - Checks for correctly typed password/email.
- Login
  - Username/Password Login

# Main UI
![Main UI](https://github.com/tojohnny/BasicRPG/blob/master/gui/main_02.png?raw=true)

# New User Registration
![New User Registration UI](https://github.com/tojohnny/BasicRPG/blob/master/gui/user_registration_03.png?raw=true)

# Login
![Login UI](https://github.com/tojohnny/BasicRPG/blob/master/gui/user_login_01.png?raw=true)

# TODO/Future Features
List will update as progress moves forward, sometimes too many wants will lead to nothing at all.
List in no particular order.
- [x] ~~Unique e-mail validation.~~ (Refactored registration form, and added unique constraint to username/email table.)
- [ ] Login will populate account data, and character information data.
- [ ] Character creation (stored with each unique user).
- [ ] Add more character data.
- [ ] Add UML diagram to README.
