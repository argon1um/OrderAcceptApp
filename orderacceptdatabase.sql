-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: orderacceptdatabase
-- ------------------------------------------------------
-- Server version	8.2.0

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
-- Table structure for table `requests`
--

DROP TABLE IF EXISTS `requests`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `requests` (
  `requset_id` int NOT NULL,
  `user_id` int DEFAULT NULL,
  `service_id` int DEFAULT NULL,
  `request_date` date DEFAULT NULL,
  `request_theme` varchar(45) DEFAULT NULL,
  `request_decsription` varchar(150) DEFAULT NULL,
  `response` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`requset_id`),
  KEY `userid_idx` (`user_id`),
  KEY `serviceid_idx` (`service_id`),
  CONSTRAINT `serviceid` FOREIGN KEY (`service_id`) REFERENCES `services` (`service_id`),
  CONSTRAINT `userid` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `requests`
--

LOCK TABLES `requests` WRITE;
/*!40000 ALTER TABLE `requests` DISABLE KEYS */;
INSERT INTO `requests` VALUES (1,1,1,'2019-04-20','Ошибка','Ошибки в грамматике, нужны правки','1'),(2,2,2,'2005-05-20','Отзыв','Мне понравилось быстрое и четкое реагирование поддержки на мой запрос','1'),(3,3,3,'2026-08-20','Авторизация','Проблемы с доступом к аккаунту, пользователь забыл пароль','0'),(4,1,3,'2020-02-20','Ошибка','Некорректное отображение данных после обновления','0'),(5,3,3,'2004-08-20','Авторизация','Не приходит SMS-код для подтверждения авторизации','0'),(6,1,3,'2013-03-20','Ошибка','Проблемы с загрузкой страницы после обновления','0'),(7,2,4,'2019-07-20','Отзыв','Пожелание добавить новый фильтр в отображение данных','1'),(8,3,3,'2024-08-20','Авторизация','Не работает кнопка Восстановить пароль','0'),(9,1,3,'2018-08-20','Ошибка','Не отображаются данные в таблице на странице','0'),(10,2,2,'2024-04-17','Ошибка','Ошибка в выводе данных в таблицу','2\n');
/*!40000 ALTER TABLE `requests` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `services`
--

DROP TABLE IF EXISTS `services`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `services` (
  `service_id` int NOT NULL,
  `service_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`service_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `services`
--

LOCK TABLES `services` WRITE;
/*!40000 ALTER TABLE `services` DISABLE KEYS */;
INSERT INTO `services` VALUES (1,'Лингвистика'),(2,'ФидБек'),(3,'Функционал'),(4,'Предложение');
/*!40000 ALTER TABLE `services` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subdivisions`
--

DROP TABLE IF EXISTS `subdivisions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subdivisions` (
  `subdivision_id` int NOT NULL,
  `subdivision_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`subdivision_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subdivisions`
--

LOCK TABLES `subdivisions` WRITE;
/*!40000 ALTER TABLE `subdivisions` DISABLE KEYS */;
INSERT INTO `subdivisions` VALUES (1,'Первое подр'),(2,'Второе подр');
/*!40000 ALTER TABLE `subdivisions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `user_id` int NOT NULL,
  `user_name` varchar(45) DEFAULT NULL,
  `user_surname` varchar(45) DEFAULT NULL,
  `user_patronymic` varchar(45) DEFAULT NULL,
  `user_login` varchar(45) DEFAULT NULL,
  `user_password` varchar(45) DEFAULT NULL,
  `user_subdivisionid` int DEFAULT NULL,
  PRIMARY KEY (`user_id`),
  KEY `subdiv_id_idx` (`user_subdivisionid`),
  CONSTRAINT `subdiv_id` FOREIGN KEY (`user_subdivisionid`) REFERENCES `subdivisions` (`subdivision_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Павел','Петров','Платонович','Петров1','23897412@',1),(2,'Сергей','Сидоров','Семенович','Сидоров','123',2),(3,'Илья','Иванов','Игнатович','Иванов','Ivano0v',1);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-04-18  6:20:58
