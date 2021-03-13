# Active-Car-Warehouse

<center><strong> Temporary and Active databases Windows Forms App </strong></center>

## Opis

---

Cilj ovog projekta je kreiranje automatiziranog skladišta koje ne zahtjeve preveliku ulogu samog korisnika. Tema projekta je: "Aplikacija za vođenje statistike skladišta i planiranje zaliha (strategije upravljanja zalihama - minimalne/maksimalne količine, vremena između nabavki itd. - obavezna implementacija strategije upravljanja zalihama) - Aktivne + Temporalne baze podataka - PostgreSQL + Desktop grafičko sučelje sučelje po želji". Korištenjem aktivnih i temporalnih baza podataka korisniku sam omogućio uvid u prijašnja stanja na skladištu i promjene koje su se događale, a aktivne baze podataka služe kako bi se određene aktivnosti unutar skladišta izvršavale automatski. Na ovaj način smanjila se uloga i obveze samog korisnika prema bazi podataka, a to je glavni cilj našeg projekta, kreirati aplikaciju koja olakšava vođenje skladišta. Odlučio sam se za skladište automobila zbog interesa prema istima, također zanimalo me kako bi skladište izgledalo kada bi se automatiziralo. Za izradu projekta koristio sam alate kao što su: Microsoft Visual Studio, pgAdmin 4 i Navicat 15.

## Aplikacijska domena

---

Tema mojeg projektnog zadataka je izrada aplikacije za vođene statistike skladišta i planiranje zaliha. Izradio sam aplikaciju koja omogućuje skladištenje automobila, praćenje, promjene i dodavanje novih automobila. Kako sama mogućnost naručivanja automobila za realno skladište ne predstavlja veliku vrijednost izradio sam i statistiku koju sam grafički nastojao što više približiti korisniku. Aplikacija je izrađena uz pomoć alata \textbf{Microsoft Visual Studio} \cite{Visual_Studio}, programski jezik koji se koristio prilikom izrade je \textbf{C#{\#}}. Kako bi mogao voditi evidenciju skladišta bilo je potrebno izraditi bazu podataka na koju bi se mogao spojiti. Bazu sam izradio uz pomoć alata \textbf{pgAdmin 4} \cite{PostgreSQL} i \textbf{Navicat 15} \cite{Navicat}. Navicat mi je služio kao pomoć prilikom testiranja raznih upita, prilikom kreiranja okidača i funkcija. Baza je kreirana tako da sadrži sve bitne informacije koje bi jedno skladište automobila moglo koristiti. Informacije kao što su: model automobila, proizvođač automobila, tip goriva koje se koristi u automobilu, snaga motora i mnoge druge. Nakon što su osnovne karakteristike automobila kreirane potrebno je voditi i evidenciju samog skladišta. Vrlo je važno znati koliko se automobila trenutno nalazi na skladištu. Osim informacije o količini vozila aplikacija mora voditi brigu i o minimalnim količinama koje je potrebno održavati unutar skladišta. Kod svakog automobila postoji razina ispod koje kada se dođe kreće automatiziran proces naručivanja. Od korisnika aplikacije traži se samo da vodi evidenciju automobila na skladištu i da evidentira zaprimljenu količinu automobila koje je dobio na skladište kako se kasnije ne bi dogodilo da se u procesu naručivanja naručila jedna količina automobila, a tek nakon nekog vremena ispostavilo da ta količina nije zaprimljena. Ovaj oblik aplikacije pogodan je za prodavače rabljenih automobila ili za veću automobilsku kuću koja mora imati veće količine zaliha kako bi mogla zadovoljiti potrebe svojih kupaca.

Za realizaciju ovog projekta koristio sam aktivne i temporalne baze podataka, a domena nad kojima su implementirane su: Stanje na skladištu, Evidencija skladišta, Nabava automobila i Narudžbenica. Tako sam u potpunosti zaokružio proces naručivanja i dobio potpunu automatizaciju

## ERA model

---

<img align="center" alt="ERA"  src="https://raw.githubusercontent.com/dlanger96/Active-Car-Warehouse/master/Slike/ERA_TBP.jpg"/>
<br />
<br />
<center>ERA model</center>

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

---

<img align="center" alt="Desktop"  src="https://raw.githubusercontent.com/dlanger96/Active-Car-Warehouse/master/Slike/Tbp_projekt_KjrW4SXNnL.png"/>

<br><center>Početni izbornik</center></br>

### Spajanje na bazu

---

```csharp
 public NpgsqlConnection connection;

        public void Povezi()
        {
            string ConnectionString = "Server=localhost;Port=5432;User Id=postgres;Password = marago747;Database =test; ";
            connection = new NpgsqlConnection(ConnectionString);
            connection.Open();

        }

        public void Odspoji()
        {
            connection.Close();
        }
```

### Čitanje podataka iz baze

---

Kako je naša aplikacija povezana s bazom podataka to nam daje dodatnu mogu ́cnostda odre ̄dene informacije koje smo prije zapisali u bazu ili ́cemo zapisati u istu možemo prikazatikorisniku korištenjem upita. Za prikaz informacija najˇceš ́ce se koristi "dataGridView" (DGV) kojise dodaje na formu. Osim upita preko kojega definiramo što želimo korisniku prikazati moramose koristiti našim preuzetim paketom. Upit sam po sebi se ne ́ce izvršiti ako ga ne proslijedimoklasi "NpgsqlDataAdapter" za dohva ́canje podataka. U nastavku slijedi jedan primjer kako sepodaci iz baze mogu prikazati unutar dataGridView-a. Dodatno su urešena zaglavlja koja seprikazuju unutar DGV-a linijama: "dgvAutomobili.Columns[0].HeaderText = "ID";"

```csharp
string sql = "SELECT \"Automobil\".\"id\",\"Automobil\".\"VIN\", \"Automobil\".\"naziv\", \"Proizvodac\".\"naziv\", \"Vrsta_Automobila\".\"naziv\", \"Automobil\".\"cijena\",\"Karakteristike\".\"model\"" +
                ", \"Karakteristike\".\"vrsta_motora\", \"Karakteristike\".\"snaga\", \"Karakteristike\".\"boja\", \"Karakteristike\".\"obujam_motora\", \"Karakteristike\".\"duljina_vozila\" " +
                "FROM \"Automobil\",\"Proizvodac\",\"Vrsta_Automobila\",\"Karakteristike\" WHERE \"Automobil\".\"fk_proizvodac\"=\"Proizvodac\".\"id\" AND \"Automobil\".\"fk_vrsta_automobila\" = " +
                "\"Vrsta_Automobila\".\"id\" AND \"Automobil\".\"fk_karakteristike\" = \"Karakteristike\".\"id\" AND \"Automobil\".\"naziv\" LIKE '%"+ txtPretrazivanjeNaziv.Text + "%' ORDER BY 1 ;";

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, baza.connection);
            DataSet automobiliDs = new DataSet();
            dataAdapter.Fill(automobiliDs);
            dgvAutomobili.DataSource = automobiliDs.Tables[0];
            dgvAutomobili.Columns[0].HeaderText = "ID";
            dgvAutomobili.Columns[1].HeaderText = "VIN";
            dgvAutomobili.Columns[2].HeaderText = "Naziv automobila";
            dgvAutomobili.Columns[3].HeaderText = "Proizvođač automobila";
            dgvAutomobili.Columns[4].HeaderText = "Vrsta automobila";
            dgvAutomobili.Columns[5].HeaderText = "Cijena u $";
            dgvAutomobili.Columns[6].HeaderText = "Model";
            dgvAutomobili.Columns[7].HeaderText = "Gorivo";
            dgvAutomobili.Columns[8].HeaderText = "Snaga u KW";
            dgvAutomobili.Columns[9].HeaderText = "Boja";
            dgvAutomobili.Columns[10].HeaderText = "Obujam motora CCM";
            dgvAutomobili.Columns[11].HeaderText = "Duljina vozila u m";
```

### Zapisivanje u bazu i ažuriranje

---

Proces zapisivanja u bazu i ažuriranja nešto je drugačiji od procesa čitanja. Ovdje moramo posegnuti za novom klasom, a to je "NpgsqlComand" koja nam omogućuje zapisivanje u bazu. Nakon što se zapisivanje izvršilo potrebno je osvježiti "dataGridView" kako bi se prikazale nove promjene.

```csharp
 pov.Povezi();
                string sql = "INSERT INTO \"Automobil\" VALUES (DEFAULT ,'" + txtVIN.Text.ToString() + "' ,'" + txtNazivAutomobila.Text.ToString() + "', '" + dtpGodina.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', " + int.Parse(txtMinKol.Text.ToString()) + "," +
                    "" + int.Parse(txtKolNarucivanja.Text.ToString()) + ", CAST('" + txtCijena.Text.ToString() + "' AS money), " + int.Parse(txtVrsteAutomobilaId.Text.ToString()) + ", " + int.Parse(txtProizvodacId.Text.ToString()) + ", " + int.Parse(txtKarakteristikeId.Text.ToString()) + "); ";
                NpgsqlCommand command = new NpgsqlCommand(sql, pov.connection);
                command.ExecuteNonQuery();
                pov.Odspoji();
```

<center> Zapisivanje </center>

```csharp
 baza.Povezi();
                    string sql = "UPDATE \"Stanje_Na_Skladistu\" SET \"kolicina\" = " + kolicina + ", \"poziciju_u_skladistu\" = '" + poz + "' WHERE \"fk_automobil\" = " + kljuc + ";";
                    NpgsqlCommand command = new NpgsqlCommand(sql, baza.connection);
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "UPOZORENJE!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    Osvjezi(baza.connection);
                    Osvjezi_Evidenciju(baza.connection);
                baza.Odspoji();
```

<center> Ažuriranje </center>
<br></br>

# Automatizacija

Kako bi se proces automatizacije mogao postići potrebno je implementirati aktivne baze podataka. Ovdje veliki naglasak dajemo na okidače koji su implementirani nad određenim tablicama. Okidači se pokreću nakon što se nad nekom tablicom izvrši upit tipa "Insert" ili "Update". Tako dobivamo jednu cjelinu gdje se od korisnika traži samo da ukoliko je potrebno unese nove automobile na skladište, ažurira stanje na skladištu nakon što su određeni automobili otpremljeni i da evidentira koliku količinu automobila je zaprimio temeljem narudžbenice.
<br></br>

### Dodavanje novog automobila na skladište

---

Korisniku je omogućeno da ukoliko dobije novi automobil, tj. novi model automobila isti može dodati u samu bazu. Prilikom unosa potrebno je da korisnik popunio sve bitne informacije kako bi unos bio valjan. Nakon što je korisnik unio podatke iste informacije se automatski prosljeđuju na skladište unutar kojega se zapisuje stanje automobila.

```sql
CREATE FUNCTION public.dodaj_auto_na_sk() RETURNS trigger
    LANGUAGE plpgsql
    AS $$

BEGIN

INSERT INTO "Stanje_Na_Skladistu"(fk_automobil,kolicina,poziciju_u_skladistu)

VALUES(NEW.id,NEW.min_kolicina,'Novi parking');

RETURN NEW;

END;
```

<center> Okidač za dodavanje novog automobila na skladište </center>
<br></br>

### Vođenje evidencije skladišta

---

Kako bi se svaka promjena koja se dogodila na skladištu mogla evidentirati potrebno je bilo kreirati okidač koji bilježi svaku promjenu na skladištu. Nakon što se izvrši "Insert" na tablici Stanje_Na_Skladistu ta promjena se evidentira i bilježi unutar tablice Evidencija_Na_Skladistu.

```sql
CREATE FUNCTION public.unesi_novi_auto_na_skladiste() RETURNS trigger
    LANGUAGE plpgsql
    AS $$BEGIN
INSERT INTO public."Evidencija_Skladista"(fk_automobil,nova_kolicina,tip_posla) VALUES(NEW.
fk_automobil,NEW.kolicina,'Nova kolicina automobila');
RETURN NEW;
END;
```

<center> Okidač za vođenje evidencije skladišta </center>
<br>

Osim što se automobil može dodati na skladište, tj. njegovo stanje u skladištu se može povećati ili smanjiti. Okidač se aktivira kada se izvrši "Update" nad stanjem skladišta. Pokuša li korisnik unijeti količinu koja je negativna odmah dobiva upozorenje. Ako je nova količina veća od prijašnje evidentira se da je došlo do porasta količine automobila, ako je nova količina manja od prijašnje evidentira se da je došlo do smanjenja broja automobila. Dodatno je implementirano ako se dogodi da određena količina padne strogo ispod minimalne količine automobila kreće proces naručivanja nove količine automobila koja je definirana kao količina naručivanja koja je zasebna za svaki automobil.

```sql
CREATE FUNCTION public.vodi_evidenciju() RETURNS trigger
    LANGUAGE plpgsql
    AS $$DECLARE
min_kol INTEGER;
kol_nar INTEGER;
pomocna_var INTEGER;
naruci INTEGER;
id_dobave_robe INTEGER;
BEGIN
IF NEW.kolicina<0 THEN
RAISE EXCEPTION 'Kolicina ne može biti negativna';
ELSE
IF(NEW.kolicina>OLD.kolicina) THEN
INSERT INTO "Evidencija_Skladista"(fk_automobil,prijasnja_kolicina,nova_kolicina,
tip_posla) VALUES(OLD.fk_automobil,OLD.kolicina,NEW.kolicina,'Dodana je nova kolicina automobila na skladiste');
ELSE
INSERT INTO "Evidencija_Skladista"(fk_automobil,prijasnja_kolicina,nova_kolicina,
tip_posla) VALUES(OLD.fk_automobil,OLD.kolicina,NEW.kolicina,'Oduzeta je kolicina automobila sa skladista');
END IF;
SELECT a.min_kolicina INTO min_kol
FROM "Automobil" a
JOIN "Stanje_Na_Skladistu" sns ON a.id=sns.fk_automobil
WHERE sns.fk_automobil=OLD.fk_automobil;

SELECT a.kolicina_narucivanja INTO kol_nar
FROM "Automobil" a
JOIN "Stanje_Na_Skladistu" sns ON a.id=sns.fk_automobil
WHERE sns.fk_automobil=OLD.fk_automobil;
pomocna_var=NEW.kolicina;
naruci=0;
LOOP
IF pomocna_var>=min_kol THEN
EXIT;
ELSE
pomocna_var=pomocna_var+kol_nar;
naruci=naruci+kol_nar;
END IF;
END LOOP;
SELECT id INTO id_dobave_robe
FROM "Nabava_Automobila"
WHERE fk_automobil=OLD.fk_automobil
AND datum_zaprimanja IS NULL;
IF (naruci>0 AND id_dobave_robe IS NULL ) THEN
INSERT INTO "Nabava_Automobila"(fk_automobil,stanje,kolicina_za_narucivanje)
VALUES(OLD.fk_automobil,NEW.kolicina,naruci);
END IF;
END IF;
RETURN NEW;
END;
```

<center> Okidač za evidenciju promjene stanja na skladištu i minimalnih količina </center>
<br>

### Proces naručivanja automobila

---

Kao što smo u prethodnom primjeru vidjeli ako određena količina automobila padne ispod minimalne količine automatski se pokreće proces nabave novih automobila. Prvo se popunjava tablica Nabava_Automobila, unutar koje se unosi količina koja se naručuje. Bilježi se stanje na datum kada je započet proces naručivanja. Podaci se zatim proslijeđuju prema narudžbenici i od korisnika se traži da sam evidentira datum kada je zaprimio i da definira količinu automobila koju je zaprimio. Nakon što je korisnik izvršio "Update" nad tablicom narudžbenica podaci o zaprimanju se unose u tablicu Nabava_Automobila i time se završava proces nabave. Sve izvršene promjene se evidentiraju na skladištu i ulaze u tablicu evidencije.

```sql
CREATE FUNCTION public.kreiranje_narudzbe() RETURNS trigger
    LANGUAGE plpgsql
    AS $$BEGIN

INSERT INTO public."Narudzbenica"(fk_nabava_automobila,kolicina,fk_automobil)

VALUES(NEW.id,NEW.kolicina_za_narucivanje,NEW.fk_automobil);

RETURN NEW;

END;
```

<center> Okidač za kreiranje narudžbe </center>
<br>

```sql
CREATE FUNCTION public.azuriranje_nabave_automobila() RETURNS trigger
    LANGUAGE plpgsql
    AS $$DECLARE
id_auto INTEGER;
BEGIN
UPDATE "Nabava_Automobila" SET datum_zaprimanja=NOW() WHERE id=OLD.fk_nabava_automobila;
SELECT fk_automobil INTO id_auto FROM "Nabava_Automobila" WHERE id=OLD.fk_nabava_automobila;
UPDATE "Stanje_Na_Skladistu" SET kolicina = kolicina+CAST(OLD.kolicina AS INTEGER) WHERE fk_automobil=id_auto;
RETURN NEW;
END;
```

<center> Okidač za ažuriranje Nabave_Automobila </center>
<br>
Ovakvim pristupom smo upotpunosti automatizirali bazu podataka što je bio jedan od glavnih ciljeva ovog projekta. Jednostavnost korištenja i smanjenje količine podataka o kojima se korisnik mora brinuti ili voditi evidenciju uvelike olakšava korištenje aplikacije. Kroz ova poglavlja upotpunosti smo pregledali kreiranu bazu i zaokružili cijeli proces rada skladišta, od samog dodavanja automobila na skladište, do nabave novog automobila, evidentiranja i zaprimanja istog na skladište.
<br></br>

# Zaključak

Korištenjem temporalnih i aktivnih baza podataka uvelike smo korisniku olakšali rad. Cilj nam je bio kreirati skladište koje će biti autonomno, od korisnika tražimo minimalni unos podataka kako bi skladište funkcioniralo. Želimo korisniku pružiti statističke podatke na temelju kojih se onda mogu korigirati određeni elementi naručivanja automobila ili upravljanja skladištem. Korištenje aplikacije mora biti intuitivno. Kreiranjem Glavnog izbornika korisnik može odmah odabrati i doći do formi koje su mu potrebne, kako su sve forme sortirane korisniku je lakše pronaći formu koja mu treba. Unos podataka mora biti brz i jednostavan. Zbog toga sam se odlučio na izbor DGV-a i combobox-a preko kojih korisnik samo odabire informacije o automobilu koje mu trebaju. Valjanost unosa se provjerava i ako se dogodi da korisnik unese neke netočne informacije aplikacija ga na to upozori. Unos u bazu je sveden na minimum, a sve zahvaljujući aktivnim bazama koje informacije odmah pohranjuju u predviđene tablice koristeći okidače. Temporalne baze su iskorištene kako bi korisniku pružile uvid u stanje skladišta i sve promjene koje su se radile nad njime u određenom vremenskom razdoblju.

Rad na projektu mi je bio jako zabavan, naučio sam dosta novih stvari, nekih stvari sam se morao i podsjetiti. Alati koje sam koristio nisu bili previše zahtjevni za snalaženje, ali mislim da što se tiče njihovih punih mogućnosti tek sam zagrebao površinu. Mislim da je alat Navicat pun pogodak kada govorimo o radu na bazama. Grafičko sučelje je vrlo jednostavno, a ima mogućnosti spajanja na sve poznate baze podataka. Nažalost za kvalitetan program treba izdvojiti i određenu količinu novca, ali mislim da se u konačnici takva investicija isplati.
