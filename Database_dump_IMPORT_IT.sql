--
-- PostgreSQL database dump
--

-- Dumped from database version 12.3
-- Dumped by pg_dump version 12.3

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: azuriranje_nabave_automobila(); Type: FUNCTION; Schema: public; Owner: postgres
--

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
$$;


ALTER FUNCTION public.azuriranje_nabave_automobila() OWNER TO postgres;

--
-- Name: dodaj_auto_na_sk(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.dodaj_auto_na_sk() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
INSERT INTO "Stanje_Na_Skladistu"(fk_automobil,kolicina,poziciju_u_skladistu)
VALUES(NEW.id,NEW.min_kolicina,'Novi parking');
RETURN NEW;
END;
$$;


ALTER FUNCTION public.dodaj_auto_na_sk() OWNER TO postgres;

--
-- Name: kreiranje_narudzbe(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.kreiranje_narudzbe() RETURNS trigger
    LANGUAGE plpgsql
    AS $$BEGIN
INSERT INTO public."Narudzbenica"(fk_nabava_automobila,kolicina,fk_automobil)
VALUES(NEW.id,NEW.kolicina_za_narucivanje,NEW.fk_automobil);
RETURN NEW;
END;
$$;


ALTER FUNCTION public.kreiranje_narudzbe() OWNER TO postgres;

--
-- Name: skladiste_dodavanje(integer, smallint, character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.skladiste_dodavanje(_fk integer, _kol smallint, _poz character varying) RETURNS void
    LANGUAGE plpgsql
    AS $$
BEGIN
INSERT INTO "Stanje_Na_Skladistu" VALUES (_fk,_kol,_poz);
END
$$;


ALTER FUNCTION public.skladiste_dodavanje(_fk integer, _kol smallint, _poz character varying) OWNER TO postgres;

--
-- Name: svi_automobili(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.svi_automobili() RETURNS TABLE(automobil_id integer, vin character varying, naziv_automobila character varying, proizvodac_automobila character varying, vrsta_automobila character varying, cijena money, model character varying, gorivo character varying, snaga character varying, boja character varying, obujam_motora smallint, duljina_vozila character varying)
    LANGUAGE plpgsql
    AS $$BEGIN
	RETURN query
	SELECT a.id, a."VIN", a.naziv, p.naziv,v.naziv,a.cijena,k.model, k.vrsta_motora,k.snaga,k.boja,k.obujam_motora,k.duljina_vozila
	FROM "Automobil" a, "Proizvodac" p, "Karakteristike" k, "Vrsta_Automobila" v WHERE a.fk_proizvodac = p."id" AND a.fk_karakteristike = k."id" AND a.fk_vrsta_automobila = v."id";
END
$$;


ALTER FUNCTION public.svi_automobili() OWNER TO postgres;

--
-- Name: unesi_novi_auto_na_skladiste(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.unesi_novi_auto_na_skladiste() RETURNS trigger
    LANGUAGE plpgsql
    AS $$BEGIN
INSERT INTO public."Evidencija_Skladista"(fk_automobil,nova_kolicina,tip_posla) VALUES(NEW.
fk_automobil,NEW.kolicina,'Nova kolicina automobila');
RETURN NEW;
END;
$$;


ALTER FUNCTION public.unesi_novi_auto_na_skladiste() OWNER TO postgres;

--
-- Name: vodi_evidenciju(); Type: FUNCTION; Schema: public; Owner: postgres
--

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
$$;


ALTER FUNCTION public.vodi_evidenciju() OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Automobil; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Automobil" (
    id integer NOT NULL,
    "VIN" character varying(17) NOT NULL,
    naziv character varying(255) NOT NULL,
    godina_proizvodnje date NOT NULL,
    min_kolicina smallint NOT NULL,
    kolicina_narucivanja smallint,
    cijena numeric,
    fk_vrsta_automobila integer,
    fk_proizvodac integer,
    fk_karakteristike integer
);


ALTER TABLE public."Automobil" OWNER TO postgres;

--
-- Name: Automobil_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Automobil" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Automobil_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Evidencija_Skladista; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Evidencija_Skladista" (
    id integer NOT NULL,
    evidencija_datum timestamp(6) without time zone DEFAULT now() NOT NULL,
    prijasnja_kolicina integer,
    nova_kolicina integer NOT NULL,
    tip_posla character varying(255),
    fk_automobil integer NOT NULL
);


ALTER TABLE public."Evidencija_Skladista" OWNER TO postgres;

--
-- Name: Karakteristike; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Karakteristike" (
    id integer NOT NULL,
    model character varying(255),
    vrsta_motora character varying(255),
    snaga character varying(255),
    boja character varying(255),
    obujam_motora smallint,
    duljina_vozila character varying(255)
);


ALTER TABLE public."Karakteristike" OWNER TO postgres;

--
-- Name: Karakteristike_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Karakteristike" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Karakteristike_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Nabava_Automobila; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Nabava_Automobila" (
    id integer NOT NULL,
    stanje integer NOT NULL,
    stanje_na_datum timestamp(6) without time zone DEFAULT now() NOT NULL,
    kolicina_za_narucivanje smallint DEFAULT 0,
    datum_zaprimanja timestamp(6) without time zone,
    fk_automobil integer NOT NULL
);


ALTER TABLE public."Nabava_Automobila" OWNER TO postgres;

--
-- Name: Narudzbenica; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Narudzbenica" (
    id integer NOT NULL,
    datum timestamp(6) without time zone,
    zaprimljeno integer,
    kolicina character varying(255),
    fk_nabava_automobila integer,
    fk_automobil integer
);


ALTER TABLE public."Narudzbenica" OWNER TO postgres;

--
-- Name: Proizvodac; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Proizvodac" (
    id integer NOT NULL,
    naziv character varying(255),
    opis character varying(255)
);


ALTER TABLE public."Proizvodac" OWNER TO postgres;

--
-- Name: Proizvodac_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Proizvodac" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Proizvodac_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Stanje_Na_Skladistu; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Stanje_Na_Skladistu" (
    fk_automobil integer NOT NULL,
    kolicina smallint,
    poziciju_u_skladistu character varying(255)
);


ALTER TABLE public."Stanje_Na_Skladistu" OWNER TO postgres;

--
-- Name: Vrsta_Automobila; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Vrsta_Automobila" (
    id integer NOT NULL,
    naziv character varying(255),
    opis character varying(255)
);


ALTER TABLE public."Vrsta_Automobila" OWNER TO postgres;

--
-- Name: Vrsta_Automobila_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Vrsta_Automobila" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Vrsta_Automobila_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: evidencija_sk_pov; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.evidencija_sk_pov
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.evidencija_sk_pov OWNER TO postgres;

--
-- Name: evidencija_sk_pov; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.evidencija_sk_pov OWNED BY public."Evidencija_Skladista".id;


--
-- Name: nabava_automobila_povecanje; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.nabava_automobila_povecanje
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.nabava_automobila_povecanje OWNER TO postgres;

--
-- Name: nabava_automobila_povecanje; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.nabava_automobila_povecanje OWNED BY public."Nabava_Automobila".id;


--
-- Name: narudzbenica_povecanje; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.narudzbenica_povecanje
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.narudzbenica_povecanje OWNER TO postgres;

--
-- Name: narudzbenica_povecanje; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.narudzbenica_povecanje OWNED BY public."Narudzbenica".id;


--
-- Name: Evidencija_Skladista id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Evidencija_Skladista" ALTER COLUMN id SET DEFAULT nextval('public.evidencija_sk_pov'::regclass);


--
-- Name: Nabava_Automobila id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Nabava_Automobila" ALTER COLUMN id SET DEFAULT nextval('public.nabava_automobila_povecanje'::regclass);


--
-- Name: Narudzbenica id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Narudzbenica" ALTER COLUMN id SET DEFAULT nextval('public.narudzbenica_povecanje'::regclass);


--
-- Data for Name: Automobil; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Automobil" (id, "VIN", naziv, godina_proizvodnje, min_kolicina, kolicina_narucivanja, cijena, fk_vrsta_automobila, fk_proizvodac, fk_karakteristike) FROM stdin;
1	1s2dfg3a1w4e5e6r4	Audi RS6	2016-01-05	1	1	50000.00	3	2	2
2	dwdsadsadq32144d	BMW X5	2004-08-15	2	2	100.00	1	1	1
3	VWEF456D456DEQW	VW GOLF 8	2020-08-02	3	2	30000.00	2	4	4
4	MBSAD4864SDA468	Mercedes-Benz C250 	2015-07-16	1	3	40000.00	3	3	5
5	ASD8W4D84D86AS4	Mercedes-Benz C350	2020-08-13	1	3	20000.00	3	3	6
6	ZT5U64FG4HHGF4H	Audi A4 Avant	1994-06-16	5	4	5000.00	3	2	7
7	DWQE46QWE84EWQ	Ferrari 458 Italia	2010-06-16	1	1	150000.00	6	8	8
8	TZEQW5QWETU123Q	Ferrari 599 Fiorano	2009-06-19	1	1	130000.00	6	8	9
9	JJ678423EZIQWUE62	Jaguar XE 	2018-06-20	1	2	50000.00	2	9	13
10	ARG132138DASD213	Alfa Romeo Giulia Veloce	2017-06-20	4	2	45000.00	2	6	11
11	FF26734DHAJKS342D	Fiat Punto Grande	2012-05-26	5	5	8000.00	4	5	10
12	BMW465SADS48ASD	BMW X6m	2020-08-05	2	1	67000.00	1	1	14
13	BMW84D6ASDA84SD	BMW 118d m SPORT	2004-08-17	3	2	10000.00	2	1	15
15	VWKHJLSAD486	Volkswagen GOLF 7 GTD	2020-08-19	3	2	12000.00	4	4	16
16	VW486SDWE468	Volkswagen GOLF 6 E	2020-08-23	2	1	30000.00	4	4	17
17	VW4865sd4864	Volkswagen GOLF 7 E	2020-08-21	2	1	30000.00	4	4	12
18	VW4865sd4864	Volkswagen GOLF 7 E	2020-08-21	2	1	30000.00	4	4	12
19	VW4865sd4864	Volkswagen GOLF 7 E	2020-08-21	2	1	30000.00	4	4	12
\.


--
-- Data for Name: Evidencija_Skladista; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Evidencija_Skladista" (id, evidencija_datum, prijasnja_kolicina, nova_kolicina, tip_posla, fk_automobil) FROM stdin;
1	2020-08-15 16:18:21.670898	\N	6	Novo stanje na skladistu	1
3	2020-08-15 16:40:31.806648	\N	2	Novo stanje na skladistu	2
4	2020-08-15 16:41:10.103076	\N	3	Novo stanje na skladistu	2
5	2020-08-16 15:43:41.45349	\N	3	Novo stanje na skladistu	3
6	2020-08-16 15:56:59.506646	\N	4	Novo stanje na skladistu	4
11	2020-08-16 16:29:50.281748	6	5	\nOduzeto	1
12	2020-08-16 16:30:07.993581	5	6	\nDodano	1
13	2020-08-16 16:31:29.650682	3	5	\nDodano	3
14	2020-08-16 17:04:25.860316	6	3	\nOduzeto	1
15	2020-08-16 19:47:00.587252	3	2	\nOduzeto	1
16	2020-08-16 19:50:13.507049	2	3	\nDodano	1
17	2020-08-16 21:27:50.43632	3	1	\nOduzeto	1
19	2020-08-16 22:05:17.170525	1	2	Dodana je nova kolicina automobila na skladiste	1
23	2020-08-17 10:08:34.386145	2	7	Dodana je nova kolicina automobila na skladiste	1
24	2020-08-17 10:26:46.934723	3	2	Oduzeta je kolicina automobila sa skladista	2
25	2020-08-17 10:27:05.7485	2	1	Oduzeta je kolicina automobila sa skladista	2
26	2020-08-17 10:28:28.549052	5	2	Oduzeta je kolicina automobila sa skladista	3
27	2020-08-17 11:22:49.700652	1	3	Dodana je nova kolicina automobila na skladiste	2
28	2020-08-17 11:22:58.489933	2	4	Dodana je nova kolicina automobila na skladiste	3
29	2020-08-17 11:26:50.575053	\N	7	Nova kolicina automobila	5
30	2020-08-17 11:27:26.741666	7	0	Oduzeta je kolicina automobila sa skladista	5
31	2020-08-17 12:13:32.309169	0	3	Dodana je nova kolicina automobila na skladiste	5
32	2020-08-17 12:15:50.661871	3	1	Oduzeta je kolicina automobila sa skladista	2
33	2020-08-17 12:16:09.421301	1	3	Dodana je nova kolicina automobila na skladiste	2
34	2020-08-18 18:01:32.787991	4	2	Oduzeta je kolicina automobila sa skladista	3
35	2020-08-18 18:02:04.683475	2	4	Dodana je nova kolicina automobila na skladiste	3
36	2020-08-20 13:52:40.227332	4	3	Oduzeta je kolicina automobila sa skladista	3
37	2020-08-20 13:59:28.359604	\N	3	Nova kolicina automobila	15
38	2020-08-20 14:00:55.642226	3	1	Oduzeta je kolicina automobila sa skladista	15
39	2020-08-20 14:01:18.46578	1	3	Dodana je nova kolicina automobila na skladiste	15
40	2020-08-22 11:11:17.139488	7	5	Oduzeta je kolicina automobila sa skladista	1
41	2020-08-23 11:37:57.80973	\N	2	Nova kolicina automobila	16
42	2020-08-23 11:38:34.343879	2	5	Dodana je nova kolicina automobila na skladiste	16
43	2020-08-23 11:38:49.536175	5	1	Oduzeta je kolicina automobila sa skladista	16
44	2020-08-23 11:39:04.87258	1	2	Dodana je nova kolicina automobila na skladiste	16
45	2020-08-23 11:39:50.27238	\N	2	Nova kolicina automobila	16
46	2020-08-23 12:16:01.498069	\N	2	Nova kolicina automobila	17
47	2020-08-23 12:19:48.456631	\N	2	Nova kolicina automobila	18
48	2020-08-23 12:31:04.952038	\N	2	Nova kolicina automobila	19
\.


--
-- Data for Name: Karakteristike; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Karakteristike" (id, model, vrsta_motora, snaga, boja, obujam_motora, duljina_vozila) FROM stdin;
1	X5	Dizel	120KW	Plava	1999	5m
2	RS6	Benzin	600KW	Crna	4500	5,5m
3	330d	Dizel	150KW	Bijela	2995	4,5m
4	Golf 8	Dizel	100KW	Žuta	1995	4,8m
5	C250	Benzin	200KW	Crna	2450	5,1m
6	C350	Dizel	250KW	Crvena	3499	5,2m
7	A4 Avant	Dizel	115KW	Crna	1999	4,8m
8	458 Italita	Benzin	558KW	Crvena	4598	4,3m
9	599 Fiorano	Benzin	650KW	Žuta	3999	4,7m
10	Punto	Dizel	50KW	Bijela	1499	4,1m
11	Giulia	Benzin	189KW	Plava	2199	4,85m
12	156	Dizel	105KW	Siva	1999	4,5m
13	XE	Hibrid	250KW	Zelena	2499	4,98m
14	X6m	Benzin	213KW	Žuta	1450	5,1m
15	118d	Dizel	104KW	Crvena	1999	4,7m
16	Golf 7	Dizel	81KW	Bijela	1999	4,5m
17	Golf 6 E	Elektricni	250KW	Plava	0	4,45m
18	Passat	Dizel	150KW	Crvena	1999	4,8m
\.


--
-- Data for Name: Nabava_Automobila; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Nabava_Automobila" (id, stanje, stanje_na_datum, kolicina_za_narucivanje, datum_zaprimanja, fk_automobil) FROM stdin;
1	5	2020-08-11 09:51:24	5	2020-08-17 10:08:34.386145	1
5	1	2020-08-17 10:27:05.7485	2	2020-08-17 11:22:49.700652	2
6	2	2020-08-17 10:28:28.549052	2	2020-08-17 11:22:58.489933	3
7	0	2020-08-17 11:27:26.741666	3	2020-08-17 12:13:32.309169	5
8	1	2020-08-17 12:15:50.661871	2	2020-08-17 12:16:09.421301	2
9	2	2020-08-18 18:01:32.787991	2	2020-08-18 18:02:04.683475	3
10	1	2020-08-20 14:00:55.642226	2	2020-08-20 14:01:18.46578	15
11	1	2020-08-23 11:38:49.536175	1	2020-08-23 11:39:04.87258	16
\.


--
-- Data for Name: Narudzbenica; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Narudzbenica" (id, datum, zaprimljeno, kolicina, fk_nabava_automobila, fk_automobil) FROM stdin;
1	2020-08-11 09:57:52	4	5	1	1
2	2020-08-17 11:22:38	2	2	5	2
3	2020-08-17 11:22:50	2	2	6	3
4	2020-08-17 12:13:32	3	3	7	5
5	2020-08-17 12:16:09	2	2	8	2
6	2020-08-18 18:02:04	2	2	9	3
7	2020-08-20 14:01:18	3	2	10	15
8	2020-08-23 11:39:04	2	1	11	16
\.


--
-- Data for Name: Proizvodac; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Proizvodac" (id, naziv, opis) FROM stdin;
1	BMW	adsad
2	Audi	aksjhdsjkd
3	Mercedes	wdadw
4	Volkswagen	sfsdfdsad
5	Fiat	asdwd
6	Alfa Rome	fsdfd
7	Opel	asdfsadf
8	Ferrari	qeqwed
9	Jaguar	sdfsdf
10	Lotus	asdsad
\.


--
-- Data for Name: Stanje_Na_Skladistu; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Stanje_Na_Skladistu" (fk_automobil, kolicina, poziciju_u_skladistu) FROM stdin;
4	4	Parking
5	3	PArking 3
2	3	Parking 6
3	3	PArking 5
1	5	Parking 2
16	2	Novi
17	2	Novi parking
18	2	Novi parking
19	2	Novi parking
\.


--
-- Data for Name: Vrsta_Automobila; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Vrsta_Automobila" (id, naziv, opis) FROM stdin;
1	SUV	adsasd
2	Limuzina	sfsdfsfd
3	Karavan	gfdg
4	Kompakt	sada
5	Terenac	sdfsdf
6	Sportski	kuziuik
7	Blindiran	dsads
\.


--
-- Name: Automobil_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Automobil_id_seq"', 19, true);


--
-- Name: Karakteristike_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Karakteristike_id_seq"', 19, false);


--
-- Name: Proizvodac_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Proizvodac_id_seq"', 10, true);


--
-- Name: Vrsta_Automobila_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Vrsta_Automobila_id_seq"', 7, true);


--
-- Name: evidencija_sk_pov; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.evidencija_sk_pov', 48, true);


--
-- Name: nabava_automobila_povecanje; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.nabava_automobila_povecanje', 11, true);


--
-- Name: narudzbenica_povecanje; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.narudzbenica_povecanje', 8, true);


--
-- Name: Automobil Automobil_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Automobil"
    ADD CONSTRAINT "Automobil_pkey" PRIMARY KEY (id);


--
-- Name: Vrsta_Automobila Jedinstven_naiv; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Vrsta_Automobila"
    ADD CONSTRAINT "Jedinstven_naiv" UNIQUE (naziv);


--
-- Name: Karakteristike Karakteristike_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Karakteristike"
    ADD CONSTRAINT "Karakteristike_pkey" PRIMARY KEY (id);


--
-- Name: Proizvodac Proizvodac_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Proizvodac"
    ADD CONSTRAINT "Proizvodac_pkey" PRIMARY KEY (id);


--
-- Name: Stanje_Na_Skladistu Stanje_Na_Skladistu_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Stanje_Na_Skladistu"
    ADD CONSTRAINT "Stanje_Na_Skladistu_pkey" PRIMARY KEY (fk_automobil);


--
-- Name: Vrsta_Automobila Vrsta_Automobila_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Vrsta_Automobila"
    ADD CONSTRAINT "Vrsta_Automobila_pkey" PRIMARY KEY (id);


--
-- Name: Evidencija_Skladista _copy_1; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Evidencija_Skladista"
    ADD CONSTRAINT _copy_1 PRIMARY KEY (id);


--
-- Name: Nabava_Automobila _copy_2; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Nabava_Automobila"
    ADD CONSTRAINT _copy_2 PRIMARY KEY (id);


--
-- Name: Narudzbenica _copy_3; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Narudzbenica"
    ADD CONSTRAINT _copy_3 PRIMARY KEY (id);


--
-- Name: Narudzbenica azuriraj_skladiste_stanje; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER azuriraj_skladiste_stanje AFTER UPDATE ON public."Narudzbenica" FOR EACH ROW EXECUTE FUNCTION public.azuriranje_nabave_automobila();


--
-- Name: Automobil dodaj_atuo_na_skladiste; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER dodaj_atuo_na_skladiste AFTER INSERT ON public."Automobil" FOR EACH ROW EXECUTE FUNCTION public.dodaj_auto_na_sk();


--
-- Name: Stanje_Na_Skladistu evidentiraj_novu_robu_na_skladiste; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER evidentiraj_novu_robu_na_skladiste AFTER INSERT ON public."Stanje_Na_Skladistu" FOR EACH ROW EXECUTE FUNCTION public.unesi_novi_auto_na_skladiste();


--
-- Name: Stanje_Na_Skladistu evidentiraj_promjene; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER evidentiraj_promjene AFTER UPDATE ON public."Stanje_Na_Skladistu" FOR EACH ROW EXECUTE FUNCTION public.vodi_evidenciju();


--
-- Name: Nabava_Automobila kreiraj_narudzbu; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER kreiraj_narudzbu AFTER INSERT ON public."Nabava_Automobila" FOR EACH ROW EXECUTE FUNCTION public.kreiranje_narudzbe();


--
-- Name: Evidencija_Skladista vk_automobil; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Evidencija_Skladista"
    ADD CONSTRAINT vk_automobil FOREIGN KEY (fk_automobil) REFERENCES public."Automobil"(id);


--
-- Name: Stanje_Na_Skladistu vk_automobil; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Stanje_Na_Skladistu"
    ADD CONSTRAINT vk_automobil FOREIGN KEY (fk_automobil) REFERENCES public."Automobil"(id);


--
-- Name: Nabava_Automobila vk_automobili; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Nabava_Automobila"
    ADD CONSTRAINT vk_automobili FOREIGN KEY (fk_automobil) REFERENCES public."Automobil"(id);


--
-- Name: Narudzbenica vk_automobili; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Narudzbenica"
    ADD CONSTRAINT vk_automobili FOREIGN KEY (fk_automobil) REFERENCES public."Automobil"(id);


--
-- Name: Automobil vk_karakteristike; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Automobil"
    ADD CONSTRAINT vk_karakteristike FOREIGN KEY (fk_karakteristike) REFERENCES public."Karakteristike"(id);


--
-- Name: Narudzbenica vk_nabava_automobila; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Narudzbenica"
    ADD CONSTRAINT vk_nabava_automobila FOREIGN KEY (fk_nabava_automobila) REFERENCES public."Nabava_Automobila"(id);


--
-- Name: Automobil vk_proizvodac; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Automobil"
    ADD CONSTRAINT vk_proizvodac FOREIGN KEY (fk_proizvodac) REFERENCES public."Proizvodac"(id);


--
-- Name: Automobil vk_vrsta_automobila; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Automobil"
    ADD CONSTRAINT vk_vrsta_automobila FOREIGN KEY (fk_vrsta_automobila) REFERENCES public."Vrsta_Automobila"(id);


--
-- PostgreSQL database dump complete
--

