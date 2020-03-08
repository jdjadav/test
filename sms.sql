/*
SQLyog Community v13.1.5  (64 bit)
MySQL - 8.0.19 : Database - sms
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`sms` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `sms`;

/*Table structure for table `customer` */

DROP TABLE IF EXISTS `customer`;

CREATE TABLE `customer` (
  `CID` int NOT NULL,
  `Name` varchar(30) NOT NULL,
  `Email` varchar(30) DEFAULT NULL,
  `Contact` int DEFAULT NULL,
  `Address` text,
  PRIMARY KEY (`CID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `customer` */

/*Table structure for table `items` */

DROP TABLE IF EXISTS `items`;

CREATE TABLE `items` (
  `IID` int NOT NULL,
  `Product` int DEFAULT NULL,
  `Order` int DEFAULT NULL,
  PRIMARY KEY (`IID`),
  KEY `Product` (`Product`),
  KEY `Order` (`Order`),
  CONSTRAINT `items_ibfk_3` FOREIGN KEY (`Product`) REFERENCES `product` (`Pid`),
  CONSTRAINT `items_ibfk_4` FOREIGN KEY (`Order`) REFERENCES `order` (`Oid`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `items` */

/*Table structure for table `order` */

DROP TABLE IF EXISTS `order`;

CREATE TABLE `order` (
  `Oid` int NOT NULL,
  `Product` int DEFAULT NULL,
  `Customer` int DEFAULT NULL,
  `Items` int DEFAULT NULL,
  `Amount` double DEFAULT NULL,
  `Discount` double DEFAULT NULL,
  `Additional` double DEFAULT NULL,
  PRIMARY KEY (`Oid`),
  KEY `Product` (`Product`),
  KEY `Customer` (`Customer`),
  KEY `Items` (`Items`),
  CONSTRAINT `order_ibfk_4` FOREIGN KEY (`Product`) REFERENCES `product` (`Pid`) ON DELETE SET NULL ON UPDATE SET NULL,
  CONSTRAINT `order_ibfk_5` FOREIGN KEY (`Customer`) REFERENCES `customer` (`CID`) ON DELETE SET NULL ON UPDATE SET NULL,
  CONSTRAINT `order_ibfk_6` FOREIGN KEY (`Items`) REFERENCES `items` (`IID`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `order` */

/*Table structure for table `product` */

DROP TABLE IF EXISTS `product`;

CREATE TABLE `product` (
  `Pid` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(30) NOT NULL,
  `UPC` varchar(30) NOT NULL,
  `Category` int DEFAULT NULL,
  `Brand` int DEFAULT NULL,
  `Type` int NOT NULL,
  `When` datetime NOT NULL,
  `Price` int DEFAULT NULL,
  `Qty` double DEFAULT NULL,
  PRIMARY KEY (`Pid`),
  KEY `Category` (`Category`),
  KEY `Brand` (`Brand`),
  KEY `Type` (`Type`),
  CONSTRAINT `product_ibfk_1` FOREIGN KEY (`Category`) REFERENCES `productcategory` (`CID`),
  CONSTRAINT `product_ibfk_2` FOREIGN KEY (`Brand`) REFERENCES `productbrand` (`Bid`),
  CONSTRAINT `product_ibfk_3` FOREIGN KEY (`Type`) REFERENCES `producttype` (`Tid`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `product` */

insert  into `product`(`Pid`,`Name`,`UPC`,`Category`,`Brand`,`Type`,`When`,`Price`,`Qty`) values 
(6,'pz','123',1,1,1,'0001-01-01 00:00:00',NULL,NULL),
(7,'phh','123',1,1,1,'0001-01-01 00:00:00',NULL,NULL),
(8,'pz','123',1,1,1,'0001-01-01 00:00:00',NULL,NULL),
(9,'P1','987654212',1,1,1,'0001-01-01 00:00:00',NULL,NULL),
(11,'Dove','987654',1,1,1,'0001-01-01 00:00:00',NULL,NULL),
(12,'asd','987',1,1,1,'0001-01-01 00:00:00',NULL,NULL),
(13,'jjhjh','556',1,1,1,'0001-01-01 00:00:00',NULL,NULL),
(14,'jjhjh545','556',1,1,1,'0001-01-01 00:00:00',NULL,NULL);

/*Table structure for table `productbrand` */

DROP TABLE IF EXISTS `productbrand`;

CREATE TABLE `productbrand` (
  `Bid` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(30) NOT NULL,
  `When` datetime NOT NULL,
  PRIMARY KEY (`Bid`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `productbrand` */

insert  into `productbrand`(`Bid`,`Name`,`When`) values 
(1,'brand1','2020-03-01 17:58:48');

/*Table structure for table `productcategory` */

DROP TABLE IF EXISTS `productcategory`;

CREATE TABLE `productcategory` (
  `CID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(30) NOT NULL,
  `WhenAdded` datetime NOT NULL,
  PRIMARY KEY (`CID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `productcategory` */

insert  into `productcategory`(`CID`,`Name`,`WhenAdded`) values 
(1,'Category1','2020-03-01 17:59:19');

/*Table structure for table `producttype` */

DROP TABLE IF EXISTS `producttype`;

CREATE TABLE `producttype` (
  `Tid` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(30) NOT NULL,
  PRIMARY KEY (`Tid`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `producttype` */

insert  into `producttype`(`Tid`,`Name`) values 
(1,'type1');

/*Table structure for table `role` */

DROP TABLE IF EXISTS `role`;

CREATE TABLE `role` (
  `rid` int NOT NULL AUTO_INCREMENT,
  `name` varchar(20) NOT NULL,
  `Inventory` bit(1) DEFAULT b'0',
  `Order` bit(1) DEFAULT b'0',
  `Expense` bit(1) DEFAULT b'0',
  `user` bit(1) DEFAULT b'0',
  PRIMARY KEY (`rid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `role` */

/*Table structure for table `stock` */

DROP TABLE IF EXISTS `stock`;

CREATE TABLE `stock` (
  `StkID` int NOT NULL AUTO_INCREMENT,
  `Qty` double NOT NULL,
  `UOM` varchar(5) DEFAULT NULL,
  `Price` int NOT NULL,
  `Product` int DEFAULT NULL,
  PRIMARY KEY (`StkID`),
  KEY `Product` (`Product`),
  CONSTRAINT `stock_ibfk_1` FOREIGN KEY (`Product`) REFERENCES `product` (`Pid`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `stock` */

insert  into `stock`(`StkID`,`Qty`,`UOM`,`Price`,`Product`) values 
(1,5,'ml',1,8),
(2,5,NULL,15,9),
(3,5,NULL,0,NULL),
(4,5,NULL,0,11),
(5,5,NULL,0,12),
(6,5,NULL,5,13),
(7,5,NULL,5,14);

/*Table structure for table `store` */

DROP TABLE IF EXISTS `store`;

CREATE TABLE `store` (
  `Sid` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Sid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `store` */

/*Table structure for table `users` */

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `UID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `User Name` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Password` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Mac` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Role` int NOT NULL,
  `Adress` text,
  `Email` varchar(35) DEFAULT NULL,
  `IsActive` bit(1) DEFAULT b'0',
  `Contact` int DEFAULT NULL,
  PRIMARY KEY (`UID`),
  KEY `user_role` (`Role`),
  CONSTRAINT `user_role` FOREIGN KEY (`Role`) REFERENCES `role` (`rid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `users` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
