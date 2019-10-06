curl -i -X POST -H “Content-Type: application/json” -d "{ 'PlayerTypeName': 'White', 'TurnOrder': '1'}" https://texasrealtimechess.azurewebsites.net/api/playerTypes
curl -i -X POST -H “Content-Type: application/json” -d "{ 'PlayerTypeName': 'Black', 'TurnOrder': '2'}" https://texasrealtimechess.azurewebsites.net/api/playerTypes
curl -i -X POST -H “Content-Type: application/json” -d "{ 'PlayerTypeName': 'Red', 'TurnOrder': '3'}" https://texasrealtimechess.azurewebsites.net/api/playerTypes
curl -i -X POST -H “Content-Type: application/json” -d "{ 'PlayerTypeName': 'Blue', 'TurnOrder': '4'}" https://texasrealtimechess.azurewebsites.net/api/playerTypes


curl -i -X POST -H “Content-Type: application/json” https://texasrealtimechess.azurewebsites.net/api/



curl -i -X POST -H “Content-Type: application/json” -d "{}" https://texasrealtimechess.azurewebsites.net/api/ChessMatches/1/Setup
