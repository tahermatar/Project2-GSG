-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: project2_gsg
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `Id` int unsigned NOT NULL,
  `FirstName` varchar(255) NOT NULL DEFAULT '',
  `LastName` varchar(255) NOT NULL DEFAULT '',
  `Email` varchar(255) NOT NULL DEFAULT '',
  `Password` varchar(255) NOT NULL,
  `ConfirmPassword` varchar(255) NOT NULL,
  `Image` varchar(255) NOT NULL,
  `IsAdmin` tinyint NOT NULL DEFAULT '0',
  `CreatedDateUTC` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedDateUTC` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `Archived` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'taher','matar','taher@gmail.com','$2a$11$.GWZ6sJuLhFMeGFHQR5tluJ0B.MgCmf2yfWxlOsPAzLOWsHjGlBt6','$2a$11$.GWZ6sJuLhFMeGFHQR5tluJ0B.MgCmf2yfWxlOsPAzLOWsHjGlBt6','https://localhost:44309//api/v1/user/fileretrive/profilepic?filename=ProfileImages/0b7bc13e708441cfb1baac0330d82bf2Logo.png',0,'2022-10-13 21:21:05','2022-10-15 22:05:07',0),(2,'taher','youssef','taher2@gmail.com','$2a$11$hrJYXR/0f9L8EIn2fkY48ONpkMliROPwnMsiZ9j8yU5UDh.cflLvK','$2a$11$hrJYXR/0f9L8EIn2fkY48ONpkMliROPwnMsiZ9j8yU5UDh.cflLvK','',0,'2022-10-13 21:35:29','2022-10-13 21:35:29',0),(3,'Ali','Matar','test@gmail.com','$2a$11$t9qMpmNCW1zayWAdf5opvupJAhd6HEErB3lc0vMEael1NlmkXegdG','$2a$11$t9qMpmNCW1zayWAdf5opvupJAhd6HEErB3lc0vMEael1NlmkXegdG','',0,'2022-10-14 11:10:30','2022-10-14 11:10:30',0),(4,'Ola','Ahmad','test3@gmail.com','$2a$11$OaNrZfKfRgpW.18SDJESau9PnJwekqFHrxj.YOcM2lr/eZx8nHPsq','$2a$11$OaNrZfKfRgpW.18SDJESau9PnJwekqFHrxj.YOcM2lr/eZx8nHPsq','',0,'2022-10-15 03:37:27','2022-10-15 03:37:27',0);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-10-16  1:50:44
