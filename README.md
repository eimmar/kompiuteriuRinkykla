# Kompiuterių Rinkykla


# Duomenų bazė Visual Studio aplinkoje
1. Visa informacija ir grafinė duomenų bazės sąsaja prieinama einant View -> SQL Server Object Explorer
2. Norint sukurti naują duomenų bazę atsidariusiame lange reikia pasirinkti MsSQL prisijungimą
3. Dešiniu pelės paspaudimu ant `Databases` aplankalo pridėti naują duomenų bazę.
4. Naujai sukurtoje duomenų bazėje `Tables` aplankale galima kurti lenteles, tačiau jas reikėtų kurti migracijų pagalba.

# Duomenų bazės susiejimas su ASP.NET
1. `Startup.cs` faile `ConfigureServices` metode prie `options.UseSqlServer` įrašyti duomenų bazės prisijungimo eilutę.
2. Galimai gali tekti duomenų bazės prisijungimo eilutę pridėti ir duomenų bazės konteksto klasėje `OnConfiguring` metodo
viduje. Ši klasė būna Models aplankale.
Daugiau info https://www.youtube.com/watch?v=aC_Bs3wTrcs


# Migracijų kūrimas ir paleidimas
1. Models direktorijoje sukuriamas naujas arba redaguojamas esamas modelis.
2. Visual Studio aplinkoje atsidaromas Tools -> NuGet Package Manager
3. Sukuriama migracija naudojant komandą `Add-Migration`. Pvz `Add-Migration MigracijosPavadinimas`
4. Sukurtą migraciją galima redaguoti Migrations aplankale.
5. Paleidžiamos visos migracijos naudojant komandą `Update-Database` arba `Update-Database -Migration MigracijosPavadinimas`

Daugiau info https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/
