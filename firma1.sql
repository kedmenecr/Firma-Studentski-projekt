/*
SQLyog Community v8.61 
MySQL - 5.7.18-log : Database - firma1
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`firma1` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `firma1`;

/*Table structure for table `admin` */

DROP TABLE IF EXISTS `admin`;

CREATE TABLE `admin` (
  `id_admin` int(11) NOT NULL AUTO_INCREMENT,
  `ime` varchar(20) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `prezime` varchar(20) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `adresa` varchar(100) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `mobitel` varchar(15) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `lozinka` varchar(20) COLLATE cp1250_croatian_ci DEFAULT NULL,
  PRIMARY KEY (`id_admin`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=cp1250 COLLATE=cp1250_croatian_ci CHECKSUM=1;

/*Data for the table `admin` */

insert  into `admin`(`id_admin`,`ime`,`prezime`,`adresa`,`mobitel`,`lozinka`) values (1,'as',NULL,NULL,NULL,NULL);

/*Table structure for table `artikli` */

DROP TABLE IF EXISTS `artikli`;

CREATE TABLE `artikli` (
  `id_artikla` int(11) NOT NULL AUTO_INCREMENT,
  `ime_artikla` varchar(255) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `opis` varchar(255) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `cijena` decimal(7,2) DEFAULT NULL,
  `porez` int(11) NOT NULL,
  PRIMARY KEY (`id_artikla`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=cp1250 COLLATE=cp1250_croatian_ci;

/*Data for the table `artikli` */

insert  into `artikli`(`id_artikla`,`ime_artikla`,`opis`,`cijena`,`porez`) values (1,'MicroSD 128GB SONY Memorijska kartica','Sony microSD SONY SR10UYA s SD adapterom, kapaciteta 128 GB','729.00',25),(2,'SD 32GB KINGSTON ','Velike brzine za HD video. Kingston SDHC/SDXC Class 10 UHS-I je napravljena da bude brza, s smanjenom brzinom između ponovljenog zapisa čineći ju idealnom a full HD i 3D video.','729.00',25),(3,'Ovo','Ono','22.20',25);

/*Table structure for table `fraktura` */

DROP TABLE IF EXISTS `fraktura`;

CREATE TABLE `fraktura` (
  `id_racun` int(11) NOT NULL AUTO_INCREMENT,
  `ime_artikla` varchar(45) NOT NULL,
  `id_proizvod` int(11) NOT NULL,
  `cijena` decimal(7,2) NOT NULL,
  `porez` int(11) NOT NULL,
  `ukupna_cijena` decimal(7,2) NOT NULL,
  `ukupna_kolicina` int(11) NOT NULL,
  PRIMARY KEY (`id_racun`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

/*Data for the table `fraktura` */

insert  into `fraktura`(`id_racun`,`ime_artikla`,`id_proizvod`,`cijena`,`porez`,`ukupna_cijena`,`ukupna_kolicina`) values (3,'Alo',556,'22.00',0,'0.00',0),(4,'Alo',556,'22.00',0,'0.00',0),(5,'Vino',555655,'48.00',0,'0.00',0);

/*Table structure for table `poslovni_partner` */

DROP TABLE IF EXISTS `poslovni_partner`;

CREATE TABLE `poslovni_partner` (
  `id_poslovni_partner` int(11) NOT NULL AUTO_INCREMENT,
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=cp1250 COLLATE=cp1250_croatian_ci CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `poslovni_partner` */

insert  into `poslovni_partner`(`id_poslovni_partner`,`naziv`,`adresa`,`oib`,`telefon`,`email`,`oznaka_banke`,`SWIFT_broj_banke`,`podaci_o_osnivanju`,`naziv_odgovorne_osobe`) values (1,'Robi','dmdmkawd',236515616,'16526','rexerd96@gmail.com','daiok','5253','00203','naziv'),(2,'Robi12','dmdmkawd',236515616,'16526','rexerd96@gmail.com','daiok','5253','00203','naziv');

/*Table structure for table `racun` */

DROP TABLE IF EXISTS `racun`;

CREATE TABLE `racun` (
  `id_racun` int(11) NOT NULL AUTO_INCREMENT,
  `id_artikla` int(11) DEFAULT NULL,
  `id_poslovni_partner` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_racun`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8;

/*Data for the table `racun` */

insert  into `racun`(`id_racun`,`id_artikla`,`id_poslovni_partner`) values (38,1,1),(39,2,1),(40,3,2),(41,1,1);

/*Table structure for table `tipovi_placanja` */

DROP TABLE IF EXISTS `tipovi_placanja`;

CREATE TABLE `tipovi_placanja` (
  `id_tipovi_placanja` int(11) NOT NULL AUTO_INCREMENT,
  `tip_placanja` varchar(255) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `opis` varchar(255) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `komentar` varchar(255) COLLATE cp1250_croatian_ci DEFAULT NULL,
  PRIMARY KEY (`id_tipovi_placanja`)
) ENGINE=InnoDB DEFAULT CHARSET=cp1250 COLLATE=cp1250_croatian_ci CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `tipovi_placanja` */

/*Table structure for table `zaposlenik` */

DROP TABLE IF EXISTS `zaposlenik`;

CREATE TABLE `zaposlenik` (
  `id_zaposlenik` int(11) NOT NULL AUTO_INCREMENT,
  `ime` varchar(20) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `prezime` varchar(20) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `adresa` varchar(100) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `mobitel` varchar(15) COLLATE cp1250_croatian_ci DEFAULT NULL,
  `lozinka` varchar(20) COLLATE cp1250_croatian_ci DEFAULT NULL,
  PRIMARY KEY (`id_zaposlenik`)
) ENGINE=InnoDB AUTO_INCREMENT=654322 DEFAULT CHARSET=cp1250 COLLATE=cp1250_croatian_ci CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `zaposlenik` */

insert  into `zaposlenik`(`id_zaposlenik`,`ime`,`prezime`,`adresa`,`mobitel`,`lozinka`) values (654321,'Mihael','Perić','Ilica 2 , Zagreb, 10000','+384981455670','mihael');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
