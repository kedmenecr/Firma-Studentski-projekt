/*
SQLyog Community v12.09 (64 bit)
MySQL - 5.5.54-log : Database - firma
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`firma` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `firma`;

/*Table structure for table `admin` */

DROP TABLE IF EXISTS `admin`;

CREATE TABLE `admin` (
  `id_admin` int(11) NOT NULL DEFAULT '0',
  `ime` varchar(20) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `prezime` varchar(20) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `adresa` varchar(100) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `mobitel` varchar(15) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `lozinka` varchar(20) COLLATE cp1250_croatian_ci DEFAULT NULL,
  PRIMARY KEY (`id_admin`)
) ENGINE=InnoDB DEFAULT CHARSET=cp1250 COLLATE=cp1250_croatian_ci CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `admin` */

insert  into `admin`(`id_admin`,`ime`,`prezime`,`adresa`,`mobitel`,`lozinka`) values (123456,'Josip','Kolar','Masarykova ul. 2 Zagreb, 10000','+38499569846','josip');

/*Table structure for table `artikli` */

DROP TABLE IF EXISTS `artikli`;

CREATE TABLE `artikli` (
  `id_artikla` int(11) NOT NULL DEFAULT '0',
  `ime_artikla` varchar(255) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `opis` varchar(255) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `cijena` decimal(7,2) DEFAULT NULL,
  `porez` int(11) NOT NULL,
  PRIMARY KEY (`id_artikla`)
) ENGINE=InnoDB DEFAULT CHARSET=cp1250 COLLATE=cp1250_croatian_ci CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `artikli` */

insert  into `artikli`(`id_artikla`,`ime_artikla`,`opis`,`cijena`,`porez`) values (100001,' MicroSD 128GB SONY','Memorijska kartica Sony microSD SONY SR10UYA s SD adapterom, kapaciteta 128 GB, brzina čitanja je 40mb/s.','729.00',25),(100002,'SD 32GB KINGSTON','Velike brzine za HD video. Kingston SDHC/SDXC Class 10 UHS-I je napravljena da bude brza, s smanjenom brzinom između ponovljenog zapisa čineći ju idealnom a full HD i 3D video.','149.00',25),(100003,'USB memorija Verbatim 16GB','USB2.0 Mini 16GB Neon Blue V049395','69.00',25),(100004,'Baterija za laptop Sony VAIO VGPBPSC24','Baterija za Sony Vaio prijenosna računala S13 serije.','329.70',25),(100005,'Pametna sportska narukvica GARMIN Vivofit 2 Wings for life','Ustanite i pokrenite se uz vívofit 2. To je jedini uređaj za praćenje aktivnosti sa zaslonom s pozadinskim osvjetljenjem i baterijom koja traje 1 godinu.','479.40',25),(100006,'Laptop ASUS X540SA-XX435D (15.6 HD N3060 Dual do 2.48GHz 4GB 1TB DOS) sivi','Intel Celeron Dual Core-N3060, 1,60 GHz, 4 GB, 15,6\", 1366x768, SATA 1000 GB, Free DOS, Intel® HD Graphics 400, DVD±RW, 802.11b/g/n,Bluetooth 4.0,LAN, HDMI 1, USB 2.0 1, USB 3.0 1, USB 3.1 1','2225.00',25),(100007,'Fotoaparat SONY DSC-RX100',' Za izradu sjajne fotografije dijeli vas samo tri koraka: ZEISS Vario-Sonnar T* F1,8 objektiv sa širokim otvorom blende hvata veći dio prizora, EXMOR CMOS senzor s 20,2 MP učinkovito hvata svjetlo','2899.00',25),(100008,'Televizor Samsung UE40K5582 LED SMART TV (T2/S2) bijeli','Full HD SMART televizor Samsung UE40K5582 40\" da je novu razinu televizijske stvarnosti. Jednostavno dijeljenje sadržaja na televizoru putem mobilnih uređaja. ','3199.20',25),(100009,'Bežični punjač za mobitel TRUST YUDO','Bežični punjač za mobitel TRUST YUDO, puni Qi kompatibilne smartphone, LED indikator stupnja punjenja, Micro-USB kabel, touch-and-charge tehnologija.','103.20',25),(100010,'RAM memorija za PC DDR4 Corsair Dominator Platinum 8x16GB 2800MHz DDR4','RAM memorija za PC DDR4 Corsair Dominator Platinum 8x16GB 2800MHz DDR4 CL14 1.35V Intel XMP 2.0 CMD128GX4M8B2800C14','10999.00',25),(100011,'Prijenosni zvučnik Car Bus Mini Speaker (USB)','Prijenosni zvučnik u obliku busa sa FM radiom, reproducira MP3 i MP4 formate glazbe. Uživajte u svojim omiljenim naslovima sa USB memorije, SD memorijske kartice ili drugih vaših povezanih uređaja putem vanjskog audio ulaza','299.00',25),(100012,'Tablet Samsung Galaxy Tab S2 T713 8.0\" 32GB crni','Galaxy Tab S2 T713 8.0\" 32GB pruža dosad neviđenu fleksibilnost. Uređaj je izuzetno tanak i lagan.','2999.00',25),(100013,'Igraća konzola Sony PlayStation PS4 500GB Slim D Chassis + COD: Infinite Warfare','PS4 Sony Playstation 4 Slim D Chassis igraća konzola. PlayStation®4 je dizajniran iz temelja kako bi omogućili tvorcima igara da mogu u potpunosti pretočiti svoje ideje u stvarnost.','2599.00',25),(100014,'Ručni GPS uređaj GARMIN Montana 680t','Bilo da pješačite, vozite se ili plovite, novi uređaj Garmin Montana 680t napravljen je da vas odvede kamo želite ići.','4499.00',25),(100015,'Igra za PC Battlefield 1','Battlefield 1 igra za PC. Igra je smještena u WWI setup, i prati povijesne događaje. Oružje je podijeljeno u dvije grupe - lagano i teško, a moći ćemo voziti tenkove, avione, oklopna vozila, jahati na konju te čak i upravljati bojnim brodovima','299.00',25);

/*Table structure for table `poslovni_partner` */

DROP TABLE IF EXISTS `poslovni_partner`;

CREATE TABLE `poslovni_partner` (
  `id_poslovni_partner` int(11) NOT NULL DEFAULT '0',
  `naziv` varchar(255) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `adresa` varchar(255) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `oib` int(11) DEFAULT NULL,
  `telefon` varchar(255) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `email` varchar(255) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `oznaka_banke` varchar(255) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `SWIFT_broj_banke` varchar(255) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `podaci_o_osnivanju` varchar(255) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `naziv_odgovorne_osobe` varchar(255) COLLATE cp1250_croatian_ci DEFAULT NULL,
  PRIMARY KEY (`id_poslovni_partner`),
  UNIQUE KEY `id_poslovni_partner` (`id_poslovni_partner`)
) ENGINE=InnoDB DEFAULT CHARSET=cp1250 COLLATE=cp1250_croatian_ci CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `poslovni_partner` */

/*Table structure for table `tipovi_placanja` */

DROP TABLE IF EXISTS `tipovi_placanja`;

CREATE TABLE `tipovi_placanja` (
  `id_tipovi_placanja` int(11) NOT NULL DEFAULT '0',
  `tip_placanja` varchar(255) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `opis` varchar(255) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `komentar` varchar(255) COLLATE cp1250_croatian_ci DEFAULT NULL,
  PRIMARY KEY (`id_tipovi_placanja`)
) ENGINE=InnoDB DEFAULT CHARSET=cp1250 COLLATE=cp1250_croatian_ci CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `tipovi_placanja` */

/*Table structure for table `zaposlenik` */

DROP TABLE IF EXISTS `zaposlenik`;

CREATE TABLE `zaposlenik` (
  `id_zaposlenik` int(11) NOT NULL DEFAULT '0',
  `ime` varchar(20) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `prezime` varchar(20) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `adresa` varchar(100) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `mobitel` varchar(15) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `lozinka` varchar(20) COLLATE cp1250_croatian_ci DEFAULT NULL,
  PRIMARY KEY (`id_zaposlenik`)
) ENGINE=InnoDB DEFAULT CHARSET=cp1250 COLLATE=cp1250_croatian_ci CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `zaposlenik` */

insert  into `zaposlenik`(`id_zaposlenik`,`ime`,`prezime`,`adresa`,`mobitel`,`lozinka`) values (654321,'Mihael','Perić','Ilica 2 , Zagreb, 10000','+384981455670','mihael');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
