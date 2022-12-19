-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           8.0.28 - MySQL Community Server - GPL
-- OS do Servidor:               Win64
-- HeidiSQL Versão:              12.0.0.6468
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Copiando estrutura do banco de dados para locadora
CREATE DATABASE IF NOT EXISTS `locadora` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `locadora`;

-- Copiando estrutura para tabela locadora.cliente
CREATE TABLE IF NOT EXISTS `cliente` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CPF` varchar(14) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Nome` longtext,
  `Telefone` varchar(14) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `RegAtivo` varchar(1) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela locadora.cliente: ~0 rows (aproximadamente)
INSERT INTO `cliente` (`Id`, `CPF`, `Nome`, `Telefone`, `RegAtivo`) VALUES
	(1, '111.122.222-22', 'Beltrano', '(91)91111-1111', 'S'),
	(2, '111.112.222-22', 'Beltrano', '(91)91111-1111', 'N'),
	(3, '111.111.222-22', 'Beltrano', '(91)91111-1111', 'S'),
	(4, '111.111.122-22', 'Beltrano', '(91)91111-1111', 'S'),
	(5, '111.111.112-22', 'Beltrano', '(91)91111-1111', 'S');

-- Copiando estrutura para tabela locadora.filme
CREATE TABLE IF NOT EXISTS `filme` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Titulo` longtext,
  `Categoria` longtext,
  `RegAtivo` varchar(1) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Disponivel` varchar(1) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela locadora.filme: ~0 rows (aproximadamente)
INSERT INTO `filme` (`Id`, `Titulo`, `Categoria`, `RegAtivo`, `Disponivel`) VALUES
	(1, 'Filme 1', 'aventura', 'S', 'N'),
	(2, 'Filme 4', 'Ação', 'S', 'N'),
	(3, 'Filme 5', 'Ação', 'S', 'N');

-- Copiando estrutura para tabela locadora.locacao
CREATE TABLE IF NOT EXISTS `locacao` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `DataLocacao` datetime NOT NULL,
  `DataDevolucao` datetime NOT NULL,
  `DataDevolvido` datetime DEFAULT NULL,
  `ClienteId` int NOT NULL,
  `FilmeId` int NOT NULL,
  `RegAtivo` varchar(1) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `StatusLocacao` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ClienteId` (`ClienteId` DESC) USING BTREE,
  KEY `IX_FilmeId` (`FilmeId` DESC) USING BTREE,
  KEY `FK_Locacao_Cliente_ClienteId` (`ClienteId`),
  KEY `FK_Locacao_Filme_FilmeId` (`FilmeId`),
  CONSTRAINT `FK_Locacao_Cliente_ClienteId` FOREIGN KEY (`ClienteId`) REFERENCES `cliente` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_Locacao_Filme_FilmeId` FOREIGN KEY (`FilmeId`) REFERENCES `filme` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela locadora.locacao: ~0 rows (aproximadamente)
INSERT INTO `locacao` (`Id`, `DataLocacao`, `DataDevolucao`, `DataDevolvido`, `ClienteId`, `FilmeId`, `RegAtivo`, `StatusLocacao`) VALUES
	(1, '2022-12-17 00:00:00', '2022-12-18 00:00:00', '2022-12-18 14:59:02', 1, 1, 'S', 1),
	(2, '2022-12-17 00:00:00', '2022-12-18 00:00:00', '2022-12-18 15:01:53', 1, 2, 'S', 1),
	(6, '2022-12-18 00:00:00', '2022-12-20 00:00:00', '2022-12-18 13:44:24', 1, 3, 'S', 1),
	(7, '2022-12-18 00:00:00', '2022-12-20 00:00:00', '2022-12-18 15:02:29', 3, 3, 'S', 1),
	(8, '2022-12-18 00:00:00', '2022-12-20 00:00:00', NULL, 3, 3, 'S', 0),
	(9, '2022-12-18 00:00:00', '2022-12-19 00:00:00', NULL, 1, 3, 'S', 0),
	(10, '2022-12-18 00:00:00', '2022-12-19 00:00:00', NULL, 1, 2, 'S', 0),
	(11, '2022-12-18 00:00:00', '2022-12-19 00:00:00', NULL, 3, 1, 'S', 0);

-- Copiando estrutura para tabela locadora.__migrationhistory
CREATE TABLE IF NOT EXISTS `__migrationhistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ContextKey` varchar(300) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Model` longblob NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`MigrationId`,`ContextKey`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela locadora.__migrationhistory: ~1 rows (aproximadamente)
INSERT INTO `__migrationhistory` (`MigrationId`, `ContextKey`, `Model`, `ProductVersion`) VALUES
	('202212180956279_add_tabelas', 'Locadora.Migrations.Configuration', _binary 0x1f8b0800000000000400ed5a5f6fdb36107f1fb0ef20e871e8aca4dd4317d82d52271e82d5491027c5de0a46a21d6214a591941163d827dbc33ed2bec28efa4b9192253976d215455e6292f7bbe3f1ee78bcd3bf7fff337eff1852678db920119bb8c7a323d7c1cc8f02c256133791cb1fdfbaefdf7dffddf83c081f9d4fc5ba376a1d503231711fa48c4f3c4ff80f38446214129f47225aca911f851e0a22eff5d1d1cfdef1b18701c2052cc719df244c9210a73fe0e734623e8e6582e83c0a3015f938cc2c5254e7128558c4c8c713f763e4032847a36ca9eb9c5282408c05a64bd7418c45124910f2e44ee085e4115b2d621840f476136358b74454e05cf8936a79df7d1cbd56fbf02ac202ca4f848cc28180c76f72c57826f94eea754bc581eace41c572a3769daa6fe24e29c14cc2de4d5e2753cad53a4bb9a39ce495334b980f2b11279138bdbe5860be263e8c17160186a3fe5e39d384ca84e309c389e488be72ae937b4afc5ff1e636fa1db3094b28d5c5044161ae360043d73c8a31979b1bbccc85bf085cc7abd379266149a6d164fbba60f2cd6bd7b904e6e89ee2d20a341d2c64c4f12f98618e240eae919498338581533d5adc0d5ed3eb59c10cac0ebcc775e6e8f123662bf9007ef593ebccc8230e8a819cff1d23e06b40237982bb585c4621dec203fedd03935b4cf13262db18ed65333778752ac93adac667309bb15719fd565798111a0e728494e09b1b74bac12d9109dd76a8fbb1d22908b78a384107e774103bb5d99c1111478cac317d198750f6eea368884be424df9ca2d329ce9044a58233a630846f898a4116df6eac33bc8e68b257b435091ad03a9c304b0eba35b91d260dad4f057926375d804124c2384b95798e8c992ef12fd19aac52e36a56aaebdc609ace8b0712e73c72f4cfe59a198fc29b8856fe5b4c7d5e4409f7d5251e35cfdf22bec2b2bf58f985b945a87c852d523ad12a5036db244e7bec4a422d72198abf10338a56559edf3f9ed580f61dd5c0cc02cce9068c5237f3baf6e738bcc75c8bc8ca273f219ac0cf23ebac6aab3527ce098e6d6d667ad3074f85887c922aa67e11943656e779ce02a7c3e02a9728cf640e1a2231e8044e73e2fe60eda41db5b00b0db534fe3aeab16bde1357ec0c7259899d533f7b8f4d910095dabe089a09ea2370b560ae623ba2f0341570ac8449fb1e22602131a2db6537c87a5e604aac928139738663ccd4ddb3fd2cfa70d662b82d40c9c7d057977ac69e6657fdcc2d8b1e5d66618492bd985a3d0069987940fb52cdac26f7331a59ed0cfaf02deff76730b0ecc6001a09144628e5e8ec839ac18fb2e15ab81338bf19449e0a9886a3901758d61d47b84e754b9911cab2bd3a44aa982680dcf23ac8d303891a014a77302034ad19387a56a1ad6a493ccc83ecbe164ae175b92d83e8be08349cea044c47ab6f73800a72c5b72ba0214cf50854bb6ebe1e9a3494c2727a6fbcc8a54acfa82aac5e56622d4ab15e4b2d763c47710cd98b569bcd479c4556989dfeb8185eb40c330ccf170db5cb52da9213bcc3d00a1bb3c01a249d112ea47acfdc2395f74d83d05a66c781160f2bf819ae6e9f58e1770581fabf1e738c4a6a43c4cc6967b0b35085dbf4b169dbb94d9996c71145bce1693b850762c8da037f3b755ac8d4c9d381fef459955207c846fa235425481da51aed8f54bd0a75a46ad4461a7bc67158779675e8d62d5f37a25e26963bf4530cac3134f530af16bac31857511eac1d6c3e36c044abea5fcd50abe1439a481b925ec2d3b1f4f12fc6e0ca7be8292657a419c38dae95f23066572bc0d5ce469f1886a715e14c446d6a07ccec15df88994d0d7094ea75577394f6475f3b5699c6eb48adb97d3bcefe1ccea8fce870c6d433bb9d956d994b4aee65d6656457e33cd3e96e875ba94fb6c4754059602e2aed996f167fd0919a1fa5ff66c75fad9823469658c8ac5ce5be55bdfd5a53fdcb69707b4204b45f97fbd9fb0844e9b4b35330b0aeadb595d91a71ff0171ab175b410eed22d30850d2f7f0300cb349bc27d1cc227e33ec76d4812de0afc34aea5dd75d4fd56aaaee0ab48f73ecd3223da87d34a628ff5b0b69684106802cd336df35c73ec93eec3ada4f4372dfd87a7bb21bbb97b19bcdcb54ed5659f08205f871e2fe99529d3817bf7d2e095f39571c6ecf13e7c8f9eba94dcfbecc73b227b13e8c77367646d36d6d15afcd1d776f4c9565cc67ee1959e5bbdd1a143bf504da8b4b876a037c45cda5bce8fbac9d9f973496b642d18b9acacb3789ec1a72af06d0b6fe4ff614831beb5e9d6f1603073587da7b434dd003da46cab8dabb464de02fd75232145dab89f7e8a2d8ed97865dbc60cba876d05a45f6f05b1bd014b2cb11e07fda37fce0fb82ac2a08f5453fc37ecdf3ca35176c191511c090a858622417732c11a47de8944bb244be84691f0b917ee1957fee721edee3e0825d25324e246c1987f7b4f6619e0a24dbf8a79dafbacce3ab38fdd8691f5b003189ca5cafd88784d0a0947bd69013b540a808953f09d4594af534586d4aa44bab39d20694abaf0cacb7388c2980892bb6406bbc8b6c77027fc42be46f8aa2523b48f741d4d53e3e2368c55128728c8a1e7e820d07e1e3bbff004c3bb694ca320000, '6.1.3-40302');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
