DECLARE @TeamPlayerStaging TABLE
(
    PlayerId INT NOT NULL,
    TeamId INT NOT NULL,
    SeasonId INT NOT NULL,
    JerseyNumber INT NOT NULL
);

/***************************** Modify values here *****************************/

INSERT INTO @TeamPlayerStaging (PlayerId, TeamId, SeasonId, JerseyNumber)
VALUES
	-- Alabama Crimson Tide (TeamId = 1)
	(1, 1, 1, 15),
	(2, 1, 1, 22),
	(3, 1, 1, 37),
	(4, 1, 1, 48),
	(5, 1, 1, 91),
	(6, 1, 1, 74),
	(7, 1, 1, 33),
	(8, 1, 1, 19),
	(9, 1, 1, 54),
	(10, 1, 1, 68),
	(11, 1, 1, 87),
	(12, 1, 1, 45),
	(13, 1, 1, 66),
	(14, 1, 1, 29),
	(15, 1, 1, 11),
	(16, 1, 1, 73),
	(17, 1, 1, 88),

	-- Georgia Bulldogs (TeamId = 2)
	(18, 2, 1, 44),
	(19, 2, 1, 56),
	(20, 2, 1, 93),
	(21, 2, 1, 72),
	(22, 2, 1, 34),
	(23, 2, 1, 51),
	(24, 2, 1, 60),
	(25, 2, 1, 17),
	(26, 2, 1, 80),
	(27, 2, 1, 41),
	(28, 2, 1, 95),
	(29, 2, 1, 23),
	(30, 2, 1, 77),
	(31, 2, 1, 53),
	(32, 2, 1, 64),
	(33, 2, 1, 18),
	(34, 2, 1, 21),

	-- Florida Gators (TeamId = 3)
	(35, 3, 1, 12),
	(36, 3, 1, 89),
	(37, 3, 1, 30),
	(38, 3, 1, 42),
	(39, 3, 1, 76),
	(40, 3, 1, 58),
	(41, 3, 1, 19),
	(42, 3, 1, 81),
	(43, 3, 1, 90),
	(44, 3, 1, 39),
	(45, 3, 1, 55),
	(46, 3, 1, 13),
	(47, 3, 1, 96),
	(48, 3, 1, 49),
	(49, 3, 1, 70),
	(50, 3, 1, 61),
	(51, 3, 1, 25),

	-- LSU Tigers (TeamId = 4)
	(52, 4, 1, 31),
	(53, 4, 1, 24),
	(54, 4, 1, 67),
	(55, 4, 1, 85),
	(56, 4, 1, 92),
	(57, 4, 1, 36),
	(58, 4, 1, 52),
	(59, 4, 1, 78),
	(60, 4, 1, 10),
	(61, 4, 1, 14),
	(62, 4, 1, 46),
	(63, 4, 1, 82),
	(64, 4, 1, 62),
	(65, 4, 1, 47),
	(66, 4, 1, 99),
	(67, 4, 1, 20),
	(68, 4, 1, 28),

	-- Ohio State Buckeyes (TeamId = 5)
	(69, 5, 1, 15),
	(70, 5, 1, 84),
	(71, 5, 1, 53),
	(72, 5, 1, 63),
	(73, 5, 1, 91),
	(74, 5, 1, 26),
	(75, 5, 1, 37),
	(76, 5, 1, 44),
	(77, 5, 1, 48),
	(78, 5, 1, 59),
	(79, 5, 1, 83),
	(80, 5, 1, 75),
	(81, 5, 1, 21),
	(82, 5, 1, 50),
	(83, 5, 1, 33),
	(84, 5, 1, 71),
	(85, 5, 1, 92),

	-- Michigan Wolverines (TeamId = 6)
	(86, 6, 1, 34),
	(87, 6, 1, 68),
	(88, 6, 1, 81),
	(89, 6, 1, 42),
	(90, 6, 1, 25),
	(91, 6, 1, 54),
	(92, 6, 1, 99),
	(93, 6, 1, 65),
	(94, 6, 1, 17),
	(95, 6, 1, 29),
	(96, 6, 1, 43),
	(97, 6, 1, 62),
	(98, 6, 1, 91),
	(99, 6, 1, 74),
	(100, 6, 1, 18),
	(101, 6, 1, 39),
	(102, 6, 1, 22),

	-- Repeat for all remaining teams and players...
	-- Penn State Nittany Lions (TeamId = 7)
	(103, 7, 1, 12),
	(104, 7, 1, 33),
	(105, 7, 1, 61),
	(106, 7, 1, 42),
	(107, 7, 1, 79),
	(108, 7, 1, 23),
	(109, 7, 1, 56),
	(110, 7, 1, 74),
	(111, 7, 1, 18),
	(112, 7, 1, 37),
	(113, 7, 1, 91),
	(114, 7, 1, 65),
	(115, 7, 1, 50),
	(116, 7, 1, 84),
	(117, 7, 1, 29),
	(118, 7, 1, 46),
	(119, 7, 1, 10),

	-- Wisconsin Badgers (TeamId = 8)
	(120, 8, 1, 17),
	(121, 8, 1, 48),
	(122, 8, 1, 93),
	(123, 8, 1, 62),
	(124, 8, 1, 25),
	(125, 8, 1, 33),
	(126, 8, 1, 11),
	(127, 8, 1, 77),
	(128, 8, 1, 39),
	(129, 8, 1, 15),
	(130, 8, 1, 54),
	(131, 8, 1, 41),
	(132, 8, 1, 68),
	(133, 8, 1, 96),
	(134, 8, 1, 21),
	(135, 8, 1, 45),
	(136, 8, 1, 90),

	-- Kansas State Wildcats (TeamId = 9)
	(137, 9, 1, 22),
	(138, 9, 1, 34),
	(139, 9, 1, 71),
	(140, 9, 1, 89),
	(141, 9, 1, 53),
	(142, 9, 1, 10),
	(143, 9, 1, 29),
	(144, 9, 1, 87),
	(145, 9, 1, 49),
	(146, 9, 1, 66),
	(147, 9, 1, 42),
	(148, 9, 1, 55),
	(149, 9, 1, 93),
	(150, 9, 1, 30),
	(151, 9, 1, 73),
	(152, 9, 1, 12),
	(153, 9, 1, 84),

	-- Kansas Jayhawks (TeamId = 10)
	(154, 10, 1, 64),
	(155, 10, 1, 14),
	(156, 10, 1, 80),
	(157, 10, 1, 26),
	(158, 10, 1, 50),
	(159, 10, 1, 41),
	(160, 10, 1, 77),
	(161, 10, 1, 11),
	(162, 10, 1, 95),
	(163, 10, 1, 44),
	(164, 10, 1, 33),
	(165, 10, 1, 59),
	(166, 10, 1, 22),
	(167, 10, 1, 62),
	(168, 10, 1, 39),
	(169, 10, 1, 99),
	(170, 10, 1, 55),

	-- Colorado Buffaloes (TeamId = 11)
	(171, 11, 1, 46),
	(172, 11, 1, 18),
	(173, 11, 1, 79),
	(174, 11, 1, 92),
	(175, 11, 1, 27),
	(176, 11, 1, 73),
	(177, 11, 1, 12),
	(178, 11, 1, 68),
	(179, 11, 1, 81),
	(180, 11, 1, 43),
	(181, 11, 1, 24),
	(182, 11, 1, 31),
	(183, 11, 1, 66),
	(184, 11, 1, 89),
	(185, 11, 1, 15),
	(186, 11, 1, 30),
	(187, 11, 1, 45),

	-- Iowa State Cyclones (TeamId = 12)
	(188, 12, 1, 14),
	(189, 12, 1, 60),
	(190, 12, 1, 29),
	(191, 12, 1, 93),
	(192, 12, 1, 77),
	(193, 12, 1, 48),
	(194, 12, 1, 21),
	(195, 12, 1, 11),
	(196, 12, 1, 90),
	(197, 12, 1, 53),
	(198, 12, 1, 44),
	(199, 12, 1, 36),
	(200, 12, 1, 12),
	(201, 12, 1, 31),
	(202, 12, 1, 66),
	(203, 12, 1, 17),
	(204, 12, 1, 39),

	-- Clemson Tigers (TeamId = 13)
	(205, 13, 1, 50),
	(206, 13, 1, 55),
	(207, 13, 1, 24),
	(208, 13, 1, 79),
	(209, 13, 1, 44),
	(210, 13, 1, 18),
	(211, 13, 1, 91),
	(212, 13, 1, 27),
	(213, 13, 1, 43),
	(214, 13, 1, 30),
	(215, 13, 1, 74),
	(216, 13, 1, 56),
	(217, 13, 1, 81),
	(218, 13, 1, 89),
	(219, 13, 1, 10),
	(220, 13, 1, 61),
	(221, 13, 1, 33),

	-- Florida State Seminoles (TeamId = 14)
	(222, 14, 1, 48),
	(223, 14, 1, 15),
	(224, 14, 1, 99),
	(225, 14, 1, 84),
	(226, 14, 1, 66),
	(227, 14, 1, 62),
	(228, 14, 1, 33),
	(229, 14, 1, 95),
	(230, 14, 1, 31),
	(231, 14, 1, 50),
	(232, 14, 1, 93),
	(233, 14, 1, 10),
	(234, 14, 1, 60),
	(235, 14, 1, 80),
	(236, 14, 1, 29),
	(237, 14, 1, 36),
	(238, 14, 1, 45),

	-- North Carolina Tar Heels (TeamId = 15)
	(239, 15, 1, 25),
	(240, 15, 1, 44),
	(241, 15, 1, 39),
	(242, 15, 1, 28),
	(243, 15, 1, 54),
	(244, 15, 1, 63),
	(245, 15, 1, 81),
	(246, 15, 1, 72),
	(247, 15, 1, 24),
	(248, 15, 1, 17),
	(249, 15, 1, 13),
	(250, 15, 1, 90),
	(251, 15, 1, 33),
	(252, 15, 1, 99),
	(253, 15, 1, 19),
	(254, 15, 1, 56),
	(255, 15, 1, 62),

	-- Duke Blue Devils (TeamId = 16)
	(256, 16, 1, 46),
	(257, 16, 1, 53),
	(258, 16, 1, 11),
	(259, 16, 1, 67),
	(260, 16, 1, 92),
	(261, 16, 1, 21),
	(262, 16, 1, 33),
	(263, 16, 1, 88),
	(264, 16, 1, 50),
	(265, 16, 1, 12),
	(266, 16, 1, 61),
	(267, 16, 1, 81),
	(268, 16, 1, 19),
	(269, 16, 1, 66),
	(270, 16, 1, 48),
	(271, 16, 1, 84),
	(272, 16, 1, 74),




	-- Alabama Crimson Tide (TeamId = 1)
(1, 1, 2, 15),
(2, 1, 2, 22),
(3, 1, 2, 37),
(4, 1, 2, 48),
(5, 1, 2, 91),
(6, 1, 2, 74),
(7, 1, 2, 33),
(8, 1, 2, 19),
(9, 1, 2, 54),
(10, 1, 2, 68),
(11, 1, 2, 87),
(12, 1, 2, 45),
(13, 1, 2, 66),
(14, 1, 2, 29),
(15, 1, 2, 11),
(16, 1, 2, 73),
(17, 1, 2, 88),

-- Georgia Bulldogs (TeamId = 2)
(18, 2, 2, 44),
(19, 2, 2, 56),
(20, 2, 2, 93),
(21, 2, 2, 72),
(22, 2, 2, 34),
(23, 2, 2, 51),
(24, 2, 2, 60),
(25, 2, 2, 17),
(26, 2, 2, 80),
(27, 2, 2, 41),
(28, 2, 2, 95),
(29, 2, 2, 23),
(30, 2, 2, 77),
(31, 2, 2, 53),
(32, 2, 2, 64),
(33, 2, 2, 18),
(34, 2, 2, 21),

-- Florida Gators (TeamId = 3)
(35, 3, 2, 12),
(36, 3, 2, 89),
(37, 3, 2, 30),
(38, 3, 2, 42),
(39, 3, 2, 76),
(40, 3, 2, 58),
(41, 3, 2, 19),
(42, 3, 2, 81),
(43, 3, 2, 90),
(44, 3, 2, 39),
(45, 3, 2, 55),
(46, 3, 2, 13),
(47, 3, 2, 96),
(48, 3, 2, 49),
(49, 3, 2, 70),
(50, 3, 2, 61),
(51, 3, 2, 25),

-- LSU Tigers (TeamId = 4)
(52, 4, 2, 31),
(53, 4, 2, 24),
(54, 4, 2, 67),
(55, 4, 2, 85),
(56, 4, 2, 92),
(57, 4, 2, 36),
(58, 4, 2, 52),
(59, 4, 2, 78),
(60, 4, 2, 10),
(61, 4, 2, 14),
(62, 4, 2, 46),
(63, 4, 2, 82),
(64, 4, 2, 62),
(65, 4, 2, 47),
(66, 4, 2, 99),
(67, 4, 2, 20),
(68, 4, 2, 28);

-- Repeat for all remaining teams...




	MERGE INTO Football.TeamPlayer AS T
USING @TeamPlayerStaging AS S
   ON T.PlayerId = S.PlayerId AND T.TeamId = S.TeamId AND T.SeasonId = S.SeasonId
WHEN MATCHED THEN
   UPDATE 
   SET JerseyNumber = S.JerseyNumber
WHEN NOT MATCHED THEN
   INSERT (PlayerId, TeamId, SeasonId, JerseyNumber)
   VALUES (S.PlayerId, S.TeamId, S.SeasonId, S.JerseyNumber);
