# Active-Car-Warehouse
Temporary and Active databases Windows Forms App


## Opis
Cilj ovog projekta je kreiranje automatiziranog skladišta koje ne zahtjeve preveliku ulogu samog korisnika. Tema projekta je: "Aplikacija za vođenje statistike skladišta i planiranje zaliha (strategije upravljanja zalihama - minimalne/maksimalne količine, vremena između nabavki itd. - obavezna implementacija strategije upravljanja zalihama) - Aktivne + Temporalne baze podataka - PostgreSQL + Desktop grafičko sučelje sučelje po želji". Korištenjem aktivnih i temporalnih baza podataka korisniku sam omogućio uvid u prijašnja stanja na skladištu i promjene koje su se događale, a aktivne baze podataka služe kako bi se određene aktivnosti unutar skladišta izvršavale automatski. Na ovaj način smanjila se uloga i obveze samog korisnika prema bazi podataka, a to je glavni cilj našeg projekta, kreirati aplikaciju koja olakšava vođenje skladišta. Odlučio sam se za skladište automobila zbog interesa prema istima, također zanimalo me kako bi skladište izgledalo kada bi se automatiziralo. Za izradu projekta koristio sam alate kao što su: Microsoft Visual Studio, pgAdmin 4 i Navicat 15. 

## Aplikacijska domena

Tema mojeg projektnog zadataka je izrada aplikacije za vođene statistike skladišta i planiranje zaliha. Izradio sam aplikaciju koja omogućuje skladištenje automobila, praćenje, promjene i dodavanje novih automobila. Kako sama mogućnost naručivanja automobila za realno skladište ne predstavlja veliku vrijednost izradio sam i statistiku koju sam grafički nastojao što više približiti korisniku. Aplikacija je izrađena uz pomoć alata \textbf{Microsoft Visual Studio} \cite{Visual_Studio}, programski jezik koji se koristio prilikom izrade je \textbf{C#{\#}}. Kako bi mogao voditi evidenciju skladišta bilo je potrebno izraditi bazu podataka na koju bi se mogao spojiti. Bazu sam izradio uz pomoć alata \textbf{pgAdmin 4} \cite{PostgreSQL} i \textbf{Navicat 15} \cite{Navicat}. Navicat mi je služio kao pomoć prilikom testiranja raznih upita, prilikom kreiranja okidača i funkcija. Baza je kreirana tako da sadrži sve bitne informacije koje bi jedno skladište automobila moglo koristiti. Informacije kao što su: model automobila, proizvođač automobila, tip goriva koje se koristi u automobilu, snaga motora i mnoge druge. Nakon što su osnovne karakteristike automobila kreirane potrebno je voditi i evidenciju samog skladišta. Vrlo je važno znati koliko se automobila trenutno nalazi na skladištu. Osim informacije o količini vozila aplikacija mora voditi brigu i o minimalnim količinama koje je potrebno održavati unutar skladišta. Kod svakog automobila postoji razina ispod koje kada se dođe kreće automatiziran proces naručivanja. Od korisnika aplikacije traži se samo da vodi evidenciju automobila na skladištu i da evidentira zaprimljenu količinu automobila koje je dobio na skladište kako se kasnije ne bi dogodilo da se u procesu naručivanja naručila jedna količina automobila, a tek nakon nekog vremena ispostavilo da ta količina nije zaprimljena. Ovaj oblik aplikacije pogodan je za prodavače rabljenih automobila ili za veću automobilsku kuću koja mora imati veće količine zaliha kako bi mogla zadovoljiti potrebe svojih kupaca.

Za realizaciju ovog projekta koristio sam aktivne i temporalne baze podataka, a domena nad kojima su implementirane su: Stanje na skladištu, Evidencija skladišta, Nabava automobila i Narudžbenica. Tako sam u potpunosti zaokružio proces naručivanja i dobio potpunu automatizaciju

## ERA model

<img align="center" alt="ERA"  src="https://raw.githubusercontent.com/dlanger96/Active-Car-Warehouse/master/Slike/ERA_TBP.jpg"/>

<br />
<br/>


- **Automobil** - središnja je tablica modela i sadrži sve informacije o automobilima koji se nalaze na skladištu. Tablica Automobil sadrži jedinstveni "id" automobila prema kojemu ga i identificiramo unutar skladišta. Dodatno su definirane informacije kao što su VIN, Naziv, Godina proizvodnje i nekima možda i najbitniji aspekt, a to je cijena. Osim informacija koje jedinstveno definiraju automobil moramo i definirati elemente koji će se odnositi na skladište i vođenje istoga. Za skladište neophodne su informacije o minimalnim količinama i količini naručivanja. Minimalne količine nam predstavljaju vrijednost ispod koje je potrebno naručiti vozila, a količina naručivanja definira koliko ustvari moramo naručiti.
- **Proizvođač** - Automobile možemo dodatno razlikovati po proizvođačima. Svaki proizvođač ima određenu reputaciju i uz njegov naziv veže se određena razina pouzdanosti u marku ili određena doza skepticizma prema marci.
- **Vrsta automobila** - Kako je prošlo jako puno godina od izuma prvog automobila tako se i je i sama količina različitih vrsta automobila povećavala. Danas na tržištu postoji nebrojeno puno vrsta, a neke od najprodavanijih u zadnje vrijeme su SUV automobili. Nešto viši i robusniji od standardnih vozila samim korisnicima nude osjećaj sigurnosti. Neke od ostalih vrsta koje možemo pronaći na skladištu su: limuzine, karavani, kompakti, terenci i mnogi drugi.
- **Karakteristike** - Kako je svaki automobil jedinstveno definiran svojim id-jem tako se mu i jedinstvene karakteristike koje ga definiraju. Model, vrsta motora, snaga, boja, obujam motora i duljina vozila jedne su od glavnih karakteristika pomoću kojih možemo razlikovati više modela i uspoređivati ih prilikom kupnje ili prodaje. 
- **Stanje na skladištu** - Svaki automobil je na skladište povezan pomoću svojeg id-a, sadrži jedinstvenu količinu na skladištu i poziciju u skladištu. Pozicija u skladištu implementirana je kako bi se zaposlenici mogli što bolje snalaziti prilikom pronalaska određenog automobila. Ovdje možemo dodavati ili smanjivati količinu koju imamo na skladištu.
- **Evidencija skladišta** - Evidencija je ovdje kako bi se moglo detaljno vidjeti kada i za koliko se dogodila promjena na skladištu. Jesu li se dodali ili oduzeli određeni automobili. Koliko je stanje bilo prije promjene i koliko je stanje nakon promjene. 
- **Nabava automobila** - Padne li stanje automobila ispod minimalne količine odmah se započinje proces nabave automobila. Bilježi se stanje na skladištu i uz to stanje definira se datum, vidimo i količinu koja se treba naručiti. Datum zaprimanja se neće upisati sve dok osoba unutar narudžbenice ne unese koliko je automobila zaprimila i kada.
- **Narudžbenica** - Sadrži naziv automobila koji je naručen, korisnik definira koliko je automobila zaprimio, a u stupcu do piše kolika je količina naručena. Vidimo i ključeve prema automobilu i nabavi automobila. 

## Izgled desktop aplikacije

<img align="center" alt="Desktop"  src="https://raw.githubusercontent.com/dlanger96/Active-Car-Warehouse/master/Slike/Tbp_projekt_KjrW4SXNnL.png"/>


