-- phpMyAdmin SQL Dump
-- version 3.4.5
-- http://www.phpmyadmin.net
--
-- Хост: localhost
-- Време на генериране: 
-- Версия на сървъра: 5.5.16
-- Версия на PHP: 5.3.8

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- База данни: `supermarket`
--

-- --------------------------------------------------------

--
-- Структура на таблица `measures`
--

CREATE TABLE IF NOT EXISTS `measures` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `MeasureName` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Ссхема на данните от таблица `measures`
--

INSERT INTO `measures` (`Id`, `MeasureName`) VALUES
(1, 'liters'),
(2, 'pieces'),
(3, 'milliliters'),
(4, 'kilograms'),
(5, 'grams');

-- --------------------------------------------------------

--
-- Структура на таблица `products`
--

CREATE TABLE IF NOT EXISTS `products` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `VendorId` int(11) NOT NULL,
  `ProductName` varchar(50) NOT NULL,
  `MeasureId` int(11) NOT NULL,
  `BasePrice` double NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=51 ;

--
-- Ссхема на данните от таблица `products`
--

INSERT INTO `products` (`Id`, `VendorId`, `ProductName`, `MeasureId`, `BasePrice`) VALUES
(1, 1, 'Bolqrka', 1, 1.5),
(2, 2, 'Beer Astika', 1, 1.7),
(3, 3, 'Beer Kamenitza', 1, 1.8),
(4, 4, 'Beer Ledenika', 1, 1.85),
(5, 5, 'Beer Shumensko', 1, 1.9),
(6, 5, 'Beer Tuborg', 1, 2),
(7, 5, 'Beer Pirinsko', 1, 2.2),
(8, 6, 'Coca Cola', 1, 2.4),
(9, 6, 'Fanta', 1, 2.4),
(10, 6, 'Sprite', 1, 2.4),
(11, 7, 'Party Orange', 1, 1.3),
(12, 7, 'Party Strawberry', 1, 1.3),
(13, 7, 'Party Blueberry', 1, 1.3),
(14, 7, 'Party Blackberry', 1, 1.3),
(15, 7, 'Party Lemon', 1, 1.3),
(16, 7, 'Party Cola', 1, 1.3),
(17, 7, 'Party Apple', 1, 1.3),
(18, 10, 'Svinski vrat', 4, 5.7),
(19, 10, 'Svinski kraka', 4, 3.3),
(20, 10, 'Svinsko file', 4, 7.7),
(21, 10, 'Pileshko file', 4, 6.5),
(22, 10, 'Pileshki gurdi', 4, 5.8),
(23, 18, 'Kiselo mlqko Bor-Chvor', 3, 0.8),
(24, 18, 'Kiselo mlqko za piene Bor-Chvor', 3, 0.95),
(25, 18, 'Detsko kiselo mlqko Bor-Chvor', 3, 0.69),
(26, 18, 'Prqsno mlqko Bor-Chvor', 3, 1.19),
(27, 18, 'Sirene Bor-Chvor', 4, 3.8),
(28, 18, 'Kashkaval Bor-Chvor', 4, 4.5),
(29, 18, 'Izvara Bor-Chvor', 4, 2.99),
(30, 18, 'Smetana Bor-Chvor', 4, 4.99),
(31, 15, 'Fustuci Detelina', 2, 2),
(32, 15, 'Bireni fustuci Detelina', 2, 2),
(33, 17, 'Shamfustuk Penelopa', 5, 10),
(34, 17, 'Bademi Penelopa', 5, 10),
(35, 17, 'Leshnici Penelopa', 5, 10),
(36, 11, 'Pileshki gurdi Mes-ko', 4, 14),
(37, 11, 'Pileshki krilca Mes-ko', 4, 4),
(38, 11, 'Pileshki drobcheta Mes-ko', 4, 8),
(39, 11, 'Svinski vrat Mes-ko', 4, 15),
(40, 11, 'Svinsko pusheno file Mes-ko', 4, 16),
(41, 11, 'Nadenica Mes-ko', 4, 11),
(42, 11, 'Lukanka Mes-ko', 4, 17.5),
(43, 8, 'Qdki Deni', 2, 2.99),
(44, 9, 'Shkolad s leshnici Amore', 5, 3.99),
(45, 9, 'Shkolad s mlqko Amore', 5, 2.99),
(46, 9, 'Shkolad s parchenca qgodi Amore', 5, 3.99),
(47, 9, 'Bonboni s karamel Amore', 5, 6.99),
(48, 9, 'Bonboni s qgodi Amore', 5, 6.99),
(49, 20, 'Soleti Deq', 5, 0.3),
(50, 20, 'Kubeti Deq', 5, 0.5);

-- --------------------------------------------------------

--
-- Структура на таблица `vendors`
--

CREATE TABLE IF NOT EXISTS `vendors` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `VendorName` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=21 ;

--
-- Ссхема на данните от таблица `vendors`
--

INSERT INTO `vendors` (`Id`, `VendorName`) VALUES
(1, 'Targovishte Bottling Company Ltd.'),
(2, 'Astika Corp.'),
(3, 'Kamenitza Corp.'),
(4, 'Ledenika Corp.'),
(5, 'Shumensko Corp.'),
(6, 'Coca Cola Corp.'),
(7, 'Party Club Corp.'),
(8, 'Deni Corp.'),
(9, 'Amore Corp.'),
(10, 'Ivet EOOD'),
(11, 'Mes-ko OOD'),
(12, 'Vitabal OOD'),
(13, 'Valka ET'),
(14, 'Djela ET'),
(15, 'Detelina ET'),
(16, 'Tigar ET'),
(17, 'Penelopa OOD'),
(18, 'Bor Chvor OOD'),
(19, 'Zagora 2000 OOD'),
(20, 'Deq OOD');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
