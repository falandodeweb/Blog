# SQL Manager 2007 for MySQL 4.3.4.1
# ---------------------------------------
# Host     : 177.12.174.24
# Port     : 3306
# Database : falandodeweb


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

SET FOREIGN_KEY_CHECKS=0;

CREATE DATABASE `falandodeweb`
    CHARACTER SET 'latin1'
    COLLATE 'latin1_swedish_ci';

USE `falandodeweb`;

#
# Structure for the `Categoria` table : 
#

CREATE TABLE `Categoria` (
  `Codigo` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `DataCadastro` DATETIME NOT NULL,
  `Titulo` VARCHAR(100) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`Codigo`),
  UNIQUE KEY `Codigo` (`Codigo`)
)ENGINE=InnoDB
AUTO_INCREMENT=6 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci';

#
# Structure for the `Usuario` table : 
#

CREATE TABLE `Usuario` (
  `Codigo` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `DataCadastro` DATETIME NOT NULL,
  `Nome` VARCHAR(50) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `Email` VARCHAR(50) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `Senha` VARCHAR(100) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `Ativo` TINYINT(1) NOT NULL,
  `Master` TINYINT(1) NOT NULL,
  PRIMARY KEY (`Codigo`),
  UNIQUE KEY `Codigo` (`Codigo`)
)ENGINE=InnoDB
AUTO_INCREMENT=14 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci';

#
# Structure for the `Post` table : 
#

CREATE TABLE `Post` (
  `Codigo` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `Categoria` INTEGER(11) NOT NULL,
  `Usuario` INTEGER(11) NOT NULL,
  `DataCadastro` DATETIME NOT NULL,
  `DataPublicacao` DATETIME NOT NULL,
  `Titulo` VARCHAR(100) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `Subtitulo` VARCHAR(300) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `Previa` TEXT COLLATE latin1_swedish_ci NOT NULL,
  `Texto` TEXT COLLATE latin1_swedish_ci NOT NULL,
  `Tag` VARCHAR(300) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `Fonte` VARCHAR(200) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `Aprovado` TINYINT(1) NOT NULL,
  PRIMARY KEY (`Codigo`),
  UNIQUE KEY `Codigo` (`Codigo`),
  KEY `Categoria` (`Categoria`),
  KEY `Usuario` (`Usuario`),
  KEY `Categoria_DataPublicacao_Aprovado` (`Categoria`, `DataPublicacao`, `Aprovado`),
  KEY `DataPublicacao_Aprovado` (`DataPublicacao`, `Aprovado`),
  KEY `Usuario_DataPublicacao_Aprovado` (`Usuario`, `DataPublicacao`, `Aprovado`),
  CONSTRAINT `Post_Categoria` FOREIGN KEY (`Categoria`) REFERENCES `Categoria` (`Codigo`),
  CONSTRAINT `Post_Usuario` FOREIGN KEY (`Usuario`) REFERENCES `Usuario` (`Codigo`)
)ENGINE=InnoDB
AUTO_INCREMENT=17 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci';

#
# Structure for the `Anexo` table : 
#

CREATE TABLE `Anexo` (
  `Codigo` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `Post` INTEGER(11) NOT NULL,
  `Titulo` VARCHAR(50) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `Link` VARCHAR(200) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`Codigo`),
  UNIQUE KEY `Codigo` (`Codigo`),
  KEY `Post` (`Post`),
  CONSTRAINT `Anexo_Post` FOREIGN KEY (`Post`) REFERENCES `Post` (`Codigo`)
)ENGINE=InnoDB
AUTO_INCREMENT=2 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci';

#
# Structure for the `Contato` table : 
#

CREATE TABLE `Contato` (
  `Codigo` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `Tipo` INTEGER(11) NOT NULL,
  `DataCadastro` DATETIME NOT NULL,
  `Nome` VARCHAR(100) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `Email` VARCHAR(100) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `Telefone` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `Mensagem` VARCHAR(500) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `Enviado` TINYINT(1) NOT NULL,
  PRIMARY KEY (`Codigo`),
  UNIQUE KEY `Codigo` (`Codigo`)
)ENGINE=InnoDB
AUTO_INCREMENT=2350 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci';

#
# Structure for the `Erro` table : 
#

CREATE TABLE `Erro` (
  `Codigo` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `DataCadastro` DATETIME NOT NULL,
  `Mensagem` VARCHAR(500) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `InnerException` VARCHAR(500) COLLATE latin1_swedish_ci DEFAULT '',
  `Navegador` VARCHAR(50) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `URL` VARCHAR(300) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `IP` VARCHAR(30) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`Codigo`),
  UNIQUE KEY `Codigo` (`Codigo`)
)ENGINE=InnoDB
AUTO_INCREMENT=36 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci';

#
# Structure for the `Log` table : 
#

CREATE TABLE `Log` (
  `Codigo` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `Usuario` INTEGER(11) NOT NULL,
  `DataCadastro` DATETIME NOT NULL,
  `Acao` VARCHAR(200) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`Codigo`),
  UNIQUE KEY `Codigo` (`Codigo`),
  KEY `Usuario` (`Usuario`),
  CONSTRAINT `Usuario_Log` FOREIGN KEY (`Usuario`) REFERENCES `Usuario` (`Codigo`)
)ENGINE=InnoDB
AUTO_INCREMENT=34 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci';

#
# Structure for the `Texto` table : 
#

CREATE TABLE `Texto` (
  `Codigo` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `Titulo` VARCHAR(50) COLLATE latin1_swedish_ci NOT NULL DEFAULT '',
  `Conteudo` TEXT COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY (`Codigo`),
  UNIQUE KEY `Codigo` (`Codigo`)
)ENGINE=InnoDB
AUTO_INCREMENT=5 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci';



/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;