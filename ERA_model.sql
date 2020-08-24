CREATE TABLE "Automobil" (
  "id" int4 NOT NULL,
  "VIN" varchar(17) NOT NULL,
  "naziv" varchar(255) NOT NULL,
  "godina_proizvodnje" date NOT NULL,
  "min_kolicina" int2 NOT NULL,
  "kolicina_narucivanja" int2,
  "cijena" money,
  "fk_vrsta_automobila" int4,
  "fk_proizvodac" int4,
  "fk_karakteristike" int4,
  PRIMARY KEY ("id")
);

CREATE TABLE "Evidencija_Skladista" (
  "id" int4 NOT NULL,
  "evidencija_datum" timestamp(255) NOT NULL DEFAULT now(),
  "prijasnja_kolicina" int4,
  "nova_kolicina" int4 NOT NULL,
  "tip_posla" varchar(255),
  "fk_automobil" int4 NOT NULL,
  CONSTRAINT "_copy_1" PRIMARY KEY ("id")
);

CREATE TABLE "Karakteristike" (
  "id" int4 NOT NULL,
  "model" varchar(255),
  "vrsta_motora" varchar(255),
  "snaga" varchar(255),
  "boja" varchar(255),
  "obujam_motora" int2,
  "duljina_vozila" varchar(255),
  PRIMARY KEY ("id")
);

CREATE TABLE "Nabava_Automobila" (
  "id" int4 NOT NULL,
  "stanje" int4 NOT NULL,
  "stanje_na_datum" timestamp(255) NOT NULL DEFAULT now(),
  "kolicina_za_narucivanje" int2 DEFAULT 0,
  "datum_zaprimanja" timestamp(255),
  "fk_automobil" int4 NOT NULL,
  CONSTRAINT "_copy_2" PRIMARY KEY ("id")
);

CREATE TABLE "Narudzbenica" (
  "id" int4 NOT NULL,
  "datum" timestamp(255),
  "zaprimljeno" int4,
  "kolicina" varchar(255),
  "fk_nabava_automobila" int4,
  "fk_automobil" int4,
  CONSTRAINT "_copy_3" PRIMARY KEY ("id")
);

CREATE TABLE "Proizvodac" (
  "id" int4 NOT NULL,
  "naziv" varchar(255),
  "opis" varchar(255),
  PRIMARY KEY ("id")
);

CREATE TABLE "Stanje_Na_Skladistu" (
  "fk_automobil" int4 NOT NULL,
  "kolicina" varchar(255),
  "poziciju_u_skladistu" varchar(255),
  PRIMARY KEY ("fk_automobil")
);

CREATE TABLE "Vrsta_Automobila" (
  "id" int4 NOT NULL,
  "naziv" varchar(255),
  "opis" varchar(255),
  PRIMARY KEY ("id"),
  CONSTRAINT "Jedinstven_naiv" UNIQUE ("naziv")
);

ALTER TABLE "Automobil" ADD CONSTRAINT "vk_vrsta_automobila" FOREIGN KEY ("fk_vrsta_automobila") REFERENCES "Vrsta_Automobila" ("id");
ALTER TABLE "Automobil" ADD CONSTRAINT "vk_proizvodac" FOREIGN KEY ("fk_proizvodac") REFERENCES "Proizvodac" ("id");
ALTER TABLE "Automobil" ADD CONSTRAINT "vk_karakteristike" FOREIGN KEY ("fk_karakteristike") REFERENCES "Karakteristike" ("id");
ALTER TABLE "Evidencija_Skladista" ADD CONSTRAINT "vk_automobil" FOREIGN KEY ("fk_automobil") REFERENCES "Automobil" ("id");
ALTER TABLE "Nabava_Automobila" ADD CONSTRAINT "vk_automobili" FOREIGN KEY ("fk_automobil") REFERENCES "Automobil" ("id");
ALTER TABLE "Narudzbenica" ADD CONSTRAINT "vk_nabava_automobila" FOREIGN KEY ("fk_nabava_automobila") REFERENCES "Nabava_Automobila" ("id");
ALTER TABLE "Narudzbenica" ADD CONSTRAINT "vk_automobili" FOREIGN KEY ("fk_automobil") REFERENCES "Automobil" ("id");
ALTER TABLE "Stanje_Na_Skladistu" ADD CONSTRAINT "vk_automobil" FOREIGN KEY ("fk_automobil") REFERENCES "Automobil" ("id");
