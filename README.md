# Wishlist
 
Dit project bevat een ASP.NET Core API en een MySQL-database, ingepakt in Docker-containers.
De app is gemaakt via visual studio samen met c# dotnet maui.

Om de docker te maken moet je in de map ASPNET zitten in de command line en volgende commando's ingeven:

- docker-compose build
- docker-compose up -d


<hr>

Om de app te starten kan je dit doen via de:

- de run knop in visual studio
- de shortcut van de run knop f5

(soms kan de app lastig doen bij het opstarten en dan moet je stoppen met runnen en builden (rood vierkantje boven aan in visual studio) en opniew de app runnen (en builden))

Mits er problemen zijn met het verbinden van de api moet je zien in ./WishList/Services/ApiMySQL.CS
tussen lijn 33 en 43 wordt er de url van de api ingegeven. Dit wordt automatisch aangepast afhankelijk van het apparaat waarop je werkt.

- op Windows http://localhost:8080/

- op Android http://10.0.2.2:8080/

- al het andere http://localhost:8080/
