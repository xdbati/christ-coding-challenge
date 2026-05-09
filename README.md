# Christ Coding Challenge

The application consists out of:
- ASP.NET Backend
- Angular Frontend
- Seperate Docker containers for front and Backend

# Features

## Backend
- Fetches articles every 300 seconds from CHRIST API
- Formats and stores aggregated data locally using JSON
- Provides API endpoint for the frontend

- Stored article fields:
	- articleId		: Article ID
	- MRK			: Brand
	- MAT			: Material 1
	- MAT2			: Material 2
	- MAT3			: Material 3
	- LEG			: Alloy 1
	- LEG2			: Alloy 2
	- LEG3			: Alloy 3
	- KOLL			: Collection
	- WRG_2			: Product group
	- WHG_2			: Main Product group
	- ZIEL			: Gender
	
## Frontend
- Display article entries in table/grid view using AG Grid
- Supports changing the language of the data between the provided languages
- Displays the last time the site was refreshed and indicates when the site has not been refreshed for more than 5 minutes


# Running the application

Once Docker Desktop has been installed, the entire application can be run using *start.bat*

The frontend is accessible at: http://localhost:80

Backend API: http://localhost:8080
