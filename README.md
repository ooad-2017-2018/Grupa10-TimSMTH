# Grupa10 ~ Team - something

\
![gif](https://media.giphy.com/media/l41YzQX6Zf3YgT4Ri/giphy.gif)

# [Tačka 1]

### Tema: Vicinor
\
![vicinor-logo](https://user-images.githubusercontent.com/37186899/37522627-c259062e-2924-11e8-9f06-1c6eb6394c94.png)

### Članovi tima:
- Dženana Šabović
- Haris Mašović 
- Samra Salihić

## Opis teme

"Basically tinder for restaurants" - Mašović Haris

Vicinor je aplikacija koja omogućava korisniku (user-u) da na jednostavan način pronađe tom korisniku mjesto/objekat koji servira/prodaje hranu kao npr. fast food/restorani itd. pri čemu naravno se user-u taj objekat svidio.

Često korisnik dođe u situaciju da ne zna gdje jesti, te pomoću ove aplikacije ima izbor restorana/fast food-ova (generalno food places) u određenom radiusu u odnosu na trenutnu lokaciju. Korisnik može izabrati određeni restoran i/ili dodati u listu svojih omiljenih restorana ponuđene restorane od strane aplikacije ili restorane u odnosu na trenutnu lokaciju definisane određenim radiusom kojim je korisnik zadao. 

Nakon toga aplikacija daje upustva kako doći na određenu lokaciju koju je izabrao. Iz napisanih karakteristika aplikacije omogućava uklanjane dvojbe korisniku oko izbora restorana/mjesta gdje da jede (čak ukoliko nije znao šta već postoji od mjesta za jesti, ima mogućnost da vrlo brzo rješi svoju dilemu) što predstavlja glavni motiv za potražnju aplikacije.

Inače naziv vicinor (vicino - ital. znači nearby/close - blizu, a r kao restorani).

## Procesi

#### Registracija korisnika / izbor izmedju guest i aktivnog korisnika aplikacije /
Korisnik ima mogućnost da izabere tip user-a odnosno da bude obični guest i da ima osnovne funkcionalnosti aplikacije ili da bude aktivni user, da ima dodatne funkcionalnosti pored osnovnih. 
Korisnik se registruje sa osnovnim podacima o sebi, a to su:
* Ime
* Prezime
* E-mail
* Password
* Kontakt telefon

#### Kupljenje određenih restorana preko web servisa
Ovaj proces mora biti automatizovan, da kad korisnik zatraži spisak restorana/mjesta za jesti, proces mora prvo provjeriti je li lokacija ispravno uspostavljena i nakon toga mora pokupiti sva mjesta za jesti koja se nalaze u radiusu koji je definisan unaprijed od strane korisnika (možda korisnik ne želi previše hodati/putovati, samim tim ima mogućnost da bira radius).

#### Prikaz svih restorana dobivenih iz pretrage
Ovaj proces također mora biti automatizovan, i kad korisnik pokrene pretragu mora dobiti određene restorane unutar tog radiusa u odnosu na poziciju gdje se nalazi. Naravno spisak restorana će biti organizovan u listu, pri čemu korisnik može sačuvati neke restorane kao željene odnosno /wish list/-a. Element liste će sadržiti informacije o restoranu/mjesto za jesti.

#### Uputa za restoran
Nakon što korisnik izabere (ako izabere, jer ne mora nužno izabrati nijedan od ponuđenih restorana, čak možda ako i nema restorana u određenom radiusu), korisnik dobija upute preko google maps, odnosno dobija najkraći put koji mora preći da bi došao do svog restorana.

#### Proces recenzije korisnika
Korisinik (mislimo na registrovanog korisnika jer on jedini ima ovu mogučnost) će moći davati recenzije i rating-e za određene restorane. 

#### Poziv restorana
Korisnik ima mogućnost da za svaki restoran koji mu je preporučen da pozove taj restoran. Pozivanjem restorana se misli na obični telefonski poziv. Jednostavnim klikom na tu opciju mu to i omogućava.

#### Generisanje preporučenih restorana
Aplikacija ima za mogućnost da korisniku ponudi spisak restorana (generalno) koji su po nekom algoritmu generisani (npr. top tier restorani, restorani sa najboljom ocjenom, najviše posjećeni restorani preko naše aplikacije itd).

### Funkcionalnosti
* Mogućnost poziva restorana/objekta
* Mogućnost registracije
* Mogućnost uređivanje svog profila
* Mogućnost pravljenja liste želja za registrovane korisnike (lista omiljenih mjesta za jelo)
* Mogućnost ostavljanja feedbacka, recenzija
* Mogućnost korištenja aplikacije neregistrovanim korisnicima
* Mogućnost odabira radiusa
* Mogućnost izbora restorana
* Mogućnost direkcija/uputa do restorana
* Izbor iz skupa preporučenih restorana od strane aplikacije


### Akteri
- Korisnik usluga (Registrovani korisnik, neregistrovani korisnik)
- Administrator sistema 

### [Tačka 2/3] su urađene pod:
- https://github.com/ooad-2017-2018/Grupa10-TimSMTH/tree/master/UseCaseIScenarij
