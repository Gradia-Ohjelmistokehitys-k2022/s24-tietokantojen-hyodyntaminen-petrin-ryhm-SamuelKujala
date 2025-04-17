-- MariaDB dump 10.19  Distrib 10.4.32-MariaDB, for Win64 (AMD64)
--
-- Host: 127.0.0.1    Database: opiskelit_t2
-- ------------------------------------------------------
-- Server version	10.4.32-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `opiskelijaryhma`
--

DROP TABLE IF EXISTS `opiskelijaryhma`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `opiskelijaryhma` (
  `opiskelijaryhmä_ID` int(11) NOT NULL AUTO_INCREMENT,
  `nimi` varchar(45) NOT NULL,
  PRIMARY KEY (`opiskelijaryhmä_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `opiskelijaryhma`
--

LOCK TABLES `opiskelijaryhma` WRITE;
/*!40000 ALTER TABLE `opiskelijaryhma` DISABLE KEYS */;
INSERT INTO `opiskelijaryhma` VALUES (1,'3b'),(2,'9a'),(3,'8b');
/*!40000 ALTER TABLE `opiskelijaryhma` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `opiskelijat`
--

DROP TABLE IF EXISTS `opiskelijat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `opiskelijat` (
  `opiskelija_ID` int(11) NOT NULL AUTO_INCREMENT,
  `etunimi` varchar(45) NOT NULL,
  `sukunimi` varchar(45) NOT NULL,
  `ryhma_ID` int(11) NOT NULL,
  PRIMARY KEY (`opiskelija_ID`),
  KEY ` fk_ryhma_ID_idx` (`ryhma_ID`),
  CONSTRAINT ` fk_ryhma_ID` FOREIGN KEY (`ryhma_ID`) REFERENCES `opiskelijaryhma` (`opiskelijaryhmä_ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `opiskelijat`
--

LOCK TABLES `opiskelijat` WRITE;
/*!40000 ALTER TABLE `opiskelijat` DISABLE KEYS */;
INSERT INTO `opiskelijat` VALUES (2,'Jaakko','Jaakkola',2),(3,'Antti','Suomela',3),(4,'Jesse','Penttinen',2),(5,'Elias','Huttu',1),(6,'Petri','Matikainen',2),(7,'Eric','Perrin',3),(8,'Jere','Lassila',2),(9,'Teemu','Eronen',1),(12,'Samuel','Kujala',2),(16,'Jesse','Koirikivi',3);
/*!40000 ALTER TABLE `opiskelijat` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-04-17 13:22:52
