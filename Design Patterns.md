### Tema: Vicinor - Desing Patterns
\
![vicinor-logo](https://user-images.githubusercontent.com/37186899/37522627-c259062e-2924-11e8-9f06-1c6eb6394c94.png)

## 1. Iterator - Pattern ponašanja

- Q: Kada koristimo? 

A: Ovaj pattern se koristi kada je potrebno imati uniforan način pristupa bilo kojoj kolekciji. Ako recimo želimo iz nekog razloga da primimo ArrayList, Array i HashMapu, možemo iskoristiti iterator interface pomoću kojeg ćemo najbolje omogućiti uniforan pristup, skratiti kod, napraviti bolji polimorfizam.

- Q: Kako koristimo?

A: Potrebno je napraviti interface Iterator (ne mora nužno taj naziv) i naslijediti sve naše klase iz tog interface-a, na kraju taj interface ćemo realizirati u nekoj drugoj klasi pomoću koje ćemo realizovati specifične metode tog interface-a. Naravno svaka klasa koja naslijedi Interface metodu će vraćati Interface. (ref. Java pristup)

- Q: Iskorišteno u projektu?

A: Ne.

- Q: Ako nije, gdje bi bilo dobro mjesto za njihovu upotrebu i zašto?

A: Ovo je zgodno uvijek imati implementirano ukoliko imamo rad sa više vrsta kolekcija. Pošto u našoj implementaciji imamo samo listu nije od nekog značaja. Iskorišteno bi u nekoj posebnoj klasi koja bi imala realizovan taj interface i imala recimo metodu koja će nešto sa elementima svih kolekcija..

## 2. Singleton - Kreacijski pattern

- Q: Kada koristimo? 

A: Kada je potrebno imati isključivo jednu instancu neke klase. Kada klasa sadrži nešto zajedničko za čitavu aplikaciju/dio aplikacije koji treba iskoristiti.

- Q: Kako koristimo?

A: Realizujemo klasu da ima private statičku instancu te iste klase, da ima prazan konstruktor obični, i metodu getInstance() pri čemu možemo odlučiti se za lazy singleton. Svaka instanca vraća jednu te istu instancu čime je održana validnost. Ukoliko radimo sa threadovima može se koristiti synchronized opcija (ref. Java pristup)

- Q: Iskorišteno u projektu?

A: Ne.

- Q: Ako nije, gdje bi bilo dobro mjesto za njihovu upotrebu i zašto?

A: Ne bi nigdje, jer nemamo takav specifičan tip klase sa kojom čuvamo dosta ključnih podataka vezan za aplikaciju/dio nje.

## 3. Strategy - Pattern ponašanja

- Q: Kada koristimo? 

A: Pogodan je kada postoje različiti primjenjivi algoritmi (strategije) za neki problem. Ukoliko imamo ograničeno, ali obavezano ponašanje različitih podklasa u hijerarhiji, tada je ovaj pattern zgodno iskoristiti.

- Q: Kako koristimo?

A: Prvo napravimo interface pomoću kojeg definišemo neku obaveznu metodu, zatim implementiramo sve klase aka. algoritme pri čemu implementiramo interface prvokreirani. Sada kada imamo već kreiranu hijerahiju klasa, možemo unutar glavne (base) klase realizovati instancu tog interface-a. Može staviti neki defaultni algoritam, a možemo i kasnije dinamički mijenjati. To možemo kroz naslijeđivanje novih klasa iskoristiti pogotovo.

- Q: Iskorišteno u projektu?

A: Ne.

- Q: Ako nije, gdje bi bilo dobro mjesto za njihovu upotrebu i zašto?

A: Prilikom samog prijavljivanja korisnika, znamo sigurno da imamo 3 opcije prilikom registracije koje su: registrovani korisnik, neregistrovani korisnik, guest. Na osnovu datog tipa klase tj. korisnika možemo realizovati 'set-up' nakon registracije, svaki tip korisnika ima drugačiji prikaz, samim tim možemo i drugačije podatke dobiti pomoću api request-a prema našoj bazi..

