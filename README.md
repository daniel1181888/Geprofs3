Dit is ons project voor geoprofs.

## Installatie
1. Open het project as Solution, niet als map.
2. In Visual Studio onder `Tools -> NuGet Package Manager -> Package Manager Console`
3. Update de database met deze command:
    ```
    Update-Database
    ```
4. Nu kan je de app starten.
5. Nu moet je een aantal rollen maken. Klik op het tabje 'Rollen' en maak deze 3 rollen aan: `Werknemer`, `Manager`, `Admin`
6. Nu moet je een paar test accounts maken:
    1. Klik rechtsbovenin op 'Register'.
    2. Maak een account aan.
    3. Klik op 'Click here to confirm your account'.
    
      | Username | Rol | Password |
      | -------- | --- | -------- |
      | werknemer@test.com | Werknemer | Test123! |
      | manager@test.com | Manager | Test123! |
      | admin@test.com | Admin | Test123! |
