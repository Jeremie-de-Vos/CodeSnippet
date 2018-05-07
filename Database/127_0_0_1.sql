-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 07, 2018 at 08:26 AM
-- Server version: 10.1.29-MariaDB
-- PHP Version: 7.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `mycodesnippet`
--
CREATE DATABASE IF NOT EXISTS `mycodesnippet` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `mycodesnippet`;

-- --------------------------------------------------------

--
-- Table structure for table `codesnippets`
--

CREATE TABLE `codesnippets` (
  `ID` int(11) NOT NULL,
  `UserID` int(11) DEFAULT NULL,
  `TagCollectionID` int(11) DEFAULT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Code` varchar(1500) DEFAULT NULL,
  `CodeEditDate` varchar(100) DEFAULT NULL,
  `UsageExample` varchar(1500) DEFAULT NULL,
  `UsageEditDate` varchar(100) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `DescriptionEditDate` varchar(100) DEFAULT NULL,
  `LanguageID` varchar(100) DEFAULT NULL,
  `CreateDate` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `codesnippets`
--

INSERT INTO `codesnippets` (`ID`, `UserID`, `TagCollectionID`, `Name`, `Code`, `CodeEditDate`, `UsageExample`, `UsageEditDate`, `Description`, `DescriptionEditDate`, `LanguageID`, `CreateDate`) VALUES
(2, 1, 9999, 'Namesgdfbsd', 'Code0', '10/04/2018 10:32:53', 'Code0\r\n', '10/04/2018 10:32:53', 'Description0', '10/04/2018 10:32:53', '3', '10/04/2018 10:32:53'),
(3, 1, 9999, 'New name', 'Code1', '10/04/2018 10:32:54', 'Code tes 5\r\n', '10/04/2018 10:32:54', 'Description1', '10/04/2018 10:32:54', '3', '10/04/2018 10:32:54'),
(4, 1, 9999, 'Name0', 'Code0', '10/04/2018 10:32:55', 'Usage0', '10/04/2018 10:32:55', 'Description0', '10/04/2018 10:32:55', '4', '10/04/2018 10:32:56'),
(5, 1, 9999, 'Name1', 'Code1', '10/04/2018 10:32:57', 'Usage1', '10/04/2018 10:32:57', 'Description1', '10/04/2018 10:32:57', '4', '10/04/2018 10:32:57'),
(6, 1, 9999, 'Name0', 'Code0', '10/04/2018 10:32:58', 'Usage0', '10/04/2018 10:32:58', 'Description0', '10/04/2018 10:32:58', '5', '10/04/2018 10:32:58'),
(7, 1, 9999, 'Name1', 'Code1', '10/04/2018 10:32:59', 'Usage1', '10/04/2018 10:32:59', 'Description1', '10/04/2018 10:32:59', '5', '10/04/2018 10:32:59'),
(8, 1, 9999, 'Name0', 'Code0', '10/04/2018 10:33:01', 'Usage0', '10/04/2018 10:33:01', 'Description0', '10/04/2018 10:33:01', '6', '10/04/2018 10:33:01'),
(9, 1, 9999, 'Name1', 'Code1', '10/04/2018 10:33:02', 'Usage1', '10/04/2018 10:33:02', 'Description1', '10/04/2018 10:33:02', '6', '10/04/2018 10:33:02'),
(10, 1, 9999, 'Name0', 'Code0', '10/04/2018 10:33:04', 'Usage0', '10/04/2018 10:33:04', 'Description0', '10/04/2018 10:33:04', '7', '10/04/2018 10:33:04'),
(11, 1, 9999, 'Name1', 'Code1', '10/04/2018 10:33:05', 'Usage1', '10/04/2018 10:33:05', 'Description1', '10/04/2018 10:33:05', '7', '10/04/2018 10:33:05'),
(12, 1, 9999, 'Name0', 'Code0', '10/04/2018 10:33:06', 'Usage0', '10/04/2018 10:33:06', 'Description0', '10/04/2018 10:33:06', '8', '10/04/2018 10:33:06'),
(13, 1, 9999, 'Name1', 'Code1', '10/04/2018 10:33:08', 'Usage1', '10/04/2018 10:33:08', 'Description1', '10/04/2018 10:33:08', '8', '10/04/2018 10:33:08'),
(14, 1, 9999, 'Name0', 'Code0', '10/04/2018 10:33:09', 'Usage0', '10/04/2018 10:33:09', 'Description0', '10/04/2018 10:33:09', '9', '10/04/2018 10:33:09'),
(15, 1, 9999, 'Name1', 'Code1', '10/04/2018 10:33:10', 'Usage1', '10/04/2018 10:33:10', 'Description1', '10/04/2018 10:33:10', '9', '10/04/2018 10:33:11'),
(17, 1, 9999, 'Name1', 'Code1', '10/04/2018 10:33:14', 'Usage1', '10/04/2018 10:33:14', 'Description1', '10/04/2018 10:33:14', '10', '10/04/2018 10:33:15'),
(18, 1, 9999, 'Name1', 'Code1', '10/04/2018 10:33:14', 'Usage1', '10/04/2018 10:33:14', 'Description1', '10/04/2018 10:33:14', '10', '10/04/2018 10:33:15'),
(19, 1, 9999, 'Name1', 'Code1', '10/04/2018 10:33:14', 'Usage1', '10/04/2018 10:33:14', 'Description1', '10/04/2018 10:33:14', '10', '10/04/2018 10:33:15'),
(20, 1, 9999, 'Name1', 'Code1', '10/04/2018 10:33:14', 'Usage1', '10/04/2018 10:33:14', 'Description1', '10/04/2018 10:33:14', '10', '10/04/2018 10:33:15'),
(21, 1, 9999, 'Name1', 'Code1', '10/04/2018 10:33:14', 'Usage1', '10/04/2018 10:33:14', 'Description1', '10/04/2018 10:33:14', '10', '10/04/2018 10:33:15'),
(22, 1, 9999, 'Name1', 'Code1', '10/04/2018 10:33:14', 'Usage1', '10/04/2018 10:33:14', 'Description1', '10/04/2018 10:33:14', '10', '10/04/2018 10:33:15'),
(23, 1, 9999, 'Name1', 'Code1', '10/04/2018 10:33:14', 'Usage1', '10/04/2018 10:33:14', 'Description1', '10/04/2018 10:33:14', '10', '10/04/2018 10:33:15'),
(24, 1, 9999, 'dummy', 'Code1', '10/04/2018 10:33:14', 'Code1\r\n', '10/04/2018 10:33:14', 'Description1', '10/04/2018 10:33:14', '10', '10/04/2018 10:33:15'),
(26, 1, 9999, 'Name0', 'Code0', '10/04/2018 10:32:55', 'Code0\r\n', '10/04/2018 10:32:55', 'Description0', '10/04/2018 10:32:55', '4', '10/04/2018 10:32:56'),
(27, 1, 9999, 'Name0', 'Code0', '10/04/2018 10:33:04', 'Usage0', '10/04/2018 10:33:04', 'Description0', '10/04/2018 10:33:04', '7', '10/04/2018 10:33:04'),
(28, 1, 9999, 'Name1', 'Code1', '10/04/2018 10:33:02', 'Usage1', '10/04/2018 10:33:02', 'Description1', '10/04/2018 10:33:02', '6', '10/04/2018 10:33:02'),
(29, 1, 9999, 'new update test', 'Code1', '10/04/2018 10:32:54', 'Code1\r\n', '10/04/2018 10:32:54', 'Description1', '10/04/2018 10:32:54', '3', '10/04/2018 10:32:54'),
(30, 1, 9999, 'Name0', 'Code0', '10/04/2018 10:32:58', 'Usage0', '10/04/2018 10:32:58', 'Description0', '10/04/2018 10:32:58', '5', '10/04/2018 10:32:58'),
(31, 3, 0, '', 'Code\r\n', '20/04/2018 13:17:04', 'Usage\r\n', '20/04/2018 13:17:04', 'Description\r\n', '20/04/2018 13:17:04', '3', '20/04/2018 13:17:04'),
(32, 1, 0, 'CreateDummy2', 'code examp\r\n', '24/04/2018 10:16:23', 'code examp\r\n\r\n', '24/04/2018 10:16:23', 'des examp\r\n', '24/04/2018 10:16:23', '3', '24/04/2018 10:16:23'),
(33, 1, 0, 'new item', 'css\r\n', '24/04/2018 10:34:21', 'css\r\n', '24/04/2018 10:34:21', 'css\r\n', '24/04/2018 10:34:21', '7', '24/04/2018 10:34:21'),
(34, 1, 0, 'testobject', 'css\r\n', '24/04/2018 10:35:43', 'css\r\n\r\n', '24/04/2018 10:35:43', 'css\r\n', '24/04/2018 10:35:43', '7', '24/04/2018 10:35:43'),
(36, 1, 0, 'FinalCode', '        private void Export()\r\n        {\r\n\r\n            SaveFileDialog dlg = new SaveFileDialog();\r\n            dlg.FileName = currentsnippet._Name; // Default file name\r\n            dlg.DefaultExt = \".text\"; // Default file extension\r\n            dlg.Filter = \"Text documents (.txt)|*.txt\"; // Filter files by extension\r\n\r\n            // Show save file dialog box\r\n            Nullable<bool> result = dlg.ShowDialog();\r\n\r\n            // Process save file dialog box results\r\n            if (result == true)\r\n            {\r\n                StreamWriter writer = new StreamWriter(dlg.OpenFile());\r\n\r\n                writer.Write(currentsnippet._Code);\r\n\r\n                writer.Dispose();\r\n                writer.Close();\r\n\r\n                string filename = dlg.FileName;\r\n            }\r\n            ControlState.Execute(c, ControlStateVisuals.Background);\r\n        }\r\n', '24/04/2018 10:56:27', '        private void Export()\r\n        {\r\n\r\n            SaveFileDialog dlg = new SaveFileDialog();\r\n            dlg.FileName = currentsnippet._Name; // Default file name\r\n            dlg.DefaultExt = \".text\"; // Default file extension\r\n            dlg.Filter = \"Text documents (.txt)|*.txt\"; // Filter files by extension\r\n\r\n            // Show save file dialog box\r\n            Nullable<bool> result = dlg.ShowDialog();\r\n\r\n            // Process save file dialog box results\r\n            if (result == true)\r\n            {\r\n                StreamWriter writer = new StreamWriter(dlg.OpenFile());\r\n\r\n                writer.Write(currentsnippet._Code);\r\n\r\n                writer.Dispose();\r\n                writer.Close();\r\n\r\n                string filename = dlg.FileName;\r\n            }\r\n            ControlState.Execute(c, ControlStateVisuals.Background);\r\n        }\r\n\r\n', '24/04/2018 10:56:27', 'Create a file and write data in it.\r\n', '24/04/2018 10:56:27', '3', '24/04/2018 10:56:27');

-- --------------------------------------------------------

--
-- Table structure for table `databases`
--

CREATE TABLE `databases` (
  `ID` int(11) NOT NULL,
  `Datasource` varchar(100) DEFAULT NULL,
  `Username` varchar(100) DEFAULT NULL,
  `Password` varchar(100) DEFAULT NULL,
  `Databasename` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `databases`
--

INSERT INTO `databases` (`ID`, `Datasource`, `Username`, `Password`, `Databasename`) VALUES
(2, 'localhost', 'root', '', 'mycodesnippet'),
(3, 'localhost', 'root', '', 'dorp-logistics');

-- --------------------------------------------------------

--
-- Table structure for table `proglanguage`
--

CREATE TABLE `proglanguage` (
  `ID` int(11) NOT NULL,
  `Name` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `proglanguage`
--

INSERT INTO `proglanguage` (`ID`, `Name`) VALUES
(3, 'C#'),
(4, 'C++'),
(5, 'Java'),
(6, 'JavaScipt'),
(7, 'Css'),
(8, 'Html'),
(9, 'PHP'),
(10, 'Phython');

-- --------------------------------------------------------

--
-- Table structure for table `snippedcollection`
--

CREATE TABLE `snippedcollection` (
  `ID` int(11) NOT NULL,
  `UserID` int(11) DEFAULT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `CreateDate` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `snippedcollection`
--

INSERT INTO `snippedcollection` (`ID`, `UserID`, `Name`, `CreateDate`) VALUES
(1, 1, 'TestSnippet 1', '10/04/2018 10:32:53'),
(2, 1, 'TestSnippet 2', '10/04/2018 10:32:58');

-- --------------------------------------------------------

--
-- Table structure for table `snipped_codecollection`
--

CREATE TABLE `snipped_codecollection` (
  `ID` int(11) NOT NULL,
  `CodeSnippetsID` int(11) DEFAULT NULL,
  `SnippetCollectionID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `snipped_codecollection`
--

INSERT INTO `snipped_codecollection` (`ID`, `CodeSnippetsID`, `SnippetCollectionID`) VALUES
(1, 3, 1),
(6, 3, 2),
(2, 4, 1),
(5, 4, 2),
(3, 12, 1),
(4, 12, 2);

-- --------------------------------------------------------

--
-- Table structure for table `tagcollection`
--

CREATE TABLE `tagcollection` (
  `ID` int(11) NOT NULL,
  `TagsID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tags`
--

CREATE TABLE `tags` (
  `ID` int(11) NOT NULL,
  `TagName` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tags`
--

INSERT INTO `tags` (`ID`, `TagName`) VALUES
(2, 'internal'),
(3, 'NoNotes'),
(4, 'UI Related');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `ID` int(11) NOT NULL,
  `Firstname` varchar(100) DEFAULT NULL,
  `Middlename` varchar(30) DEFAULT NULL,
  `Lastname` varchar(100) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Password` varchar(100) DEFAULT NULL,
  `Pin` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`ID`, `Firstname`, `Middlename`, `Lastname`, `Email`, `Password`, `Pin`) VALUES
(1, 'jeremie', 'de', 'Vos', 'jeremiedevos1999@gmail.com', 'ww', 1710);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `codesnippets`
--
ALTER TABLE `codesnippets`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `FK` (`UserID`,`TagCollectionID`,`LanguageID`);

--
-- Indexes for table `databases`
--
ALTER TABLE `databases`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `proglanguage`
--
ALTER TABLE `proglanguage`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `snippedcollection`
--
ALTER TABLE `snippedcollection`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `FK` (`UserID`);

--
-- Indexes for table `snipped_codecollection`
--
ALTER TABLE `snipped_codecollection`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `FK` (`CodeSnippetsID`,`SnippetCollectionID`);

--
-- Indexes for table `tagcollection`
--
ALTER TABLE `tagcollection`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `FK` (`TagsID`);

--
-- Indexes for table `tags`
--
ALTER TABLE `tags`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `codesnippets`
--
ALTER TABLE `codesnippets`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT for table `databases`
--
ALTER TABLE `databases`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `proglanguage`
--
ALTER TABLE `proglanguage`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `snippedcollection`
--
ALTER TABLE `snippedcollection`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `snipped_codecollection`
--
ALTER TABLE `snipped_codecollection`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `tagcollection`
--
ALTER TABLE `tagcollection`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tags`
--
ALTER TABLE `tags`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
