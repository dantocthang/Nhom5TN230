-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th4 16, 2022 lúc 05:43 AM
-- Phiên bản máy phục vụ: 10.4.22-MariaDB
-- Phiên bản PHP: 7.4.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `qldt`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `academic_years`
--

CREATE TABLE `academic_years` (
  `id` int(11) NOT NULL,
  `name` varchar(5) NOT NULL,
  `year_start` year(4) NOT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `academic_years`
--

INSERT INTO `academic_years` (`id`, `name`, `year_start`, `created_at`, `updated_at`) VALUES
(16, 'K1', 1991, '2022-01-28 00:27:45', '2022-02-05 05:24:16'),
(20, 'K12', 2012, '2022-01-28 00:54:41', '2022-01-28 00:54:41'),
(49, 'K45', 2019, '2022-03-19 18:42:48', '2022-03-19 18:42:48');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `conditional_courses`
--

CREATE TABLE `conditional_courses` (
  `id` int(11) NOT NULL,
  `course_id` int(11) NOT NULL,
  `conditional_course_id` int(11) NOT NULL,
  `conditional_course_code` varchar(80) NOT NULL,
  `type` int(11) NOT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `conditional_courses`
--

INSERT INTO `conditional_courses` (`id`, `course_id`, `conditional_course_id`, `conditional_course_code`, `type`, `created_at`, `updated_at`) VALUES
(30, 18, 19, 'CT207', 0, '2022-03-13 02:29:18', '2022-03-13 02:29:18'),
(42, 25, 22, 'CK101', 0, '2022-03-19 18:49:01', '2022-03-19 18:49:01'),
(46, 26, 19, 'CT207', 0, '2022-03-19 19:18:58', '2022-03-19 19:18:58');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `courses`
--

CREATE TABLE `courses` (
  `id` int(11) NOT NULL,
  `code` varchar(10) NOT NULL,
  `name` varchar(80) NOT NULL,
  `num_of_credit` int(2) NOT NULL,
  `course_type_id` int(11) NOT NULL,
  `optional_course_type_id` int(11) NOT NULL,
  `course_method_id` int(11) NOT NULL,
  `subject_id` int(11) NOT NULL,
  `status` int(1) DEFAULT 0,
  `goal` text DEFAULT NULL,
  `theory` text DEFAULT NULL,
  `practice` text DEFAULT NULL,
  `self_study` text DEFAULT NULL,
  `evaluate` text DEFAULT NULL,
  `document` text DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `courses`
--

INSERT INTO `courses` (`id`, `code`, `name`, `num_of_credit`, `course_type_id`, `optional_course_type_id`, `course_method_id`, `subject_id`, `status`, `goal`, `theory`, `practice`, `self_study`, `evaluate`, `document`, `created_at`, `updated_at`) VALUES
(18, 'TN201', 'Lập trình .NET', 4, 2, 1, 1, 1, 2, '<p>dsd</p>', '<p>dfasdf</p>', '<p>fsdf</p>', '<p>fsadf</p>', '<p>fasd</p>', '<p>fsda</p>', '2022-03-02 20:30:57', '2022-03-11 21:39:54'),
(19, 'CT207', 'Tin học căn bản', 5, 1, 4, 2, 13, 1, '<p>aa</p>', '', '', '', '', '', '2022-03-04 19:57:36', '2022-03-11 21:40:05'),
(20, 'XL014', 'Chủ nghĩa Mác-Lênin', 2, 1, 1, 1, 14, 2, '<p>fdsf</p>', '<p>fdsf</p>', '', '<p>fsdaf</p>', '<p>fdasf</p>', '<p>fas</p>', '2022-03-05 22:02:33', '2022-03-18 18:53:11'),
(21, 'CT200', 'Niên luận cơ sở', 3, 3, 1, 2, 1, 2, '<p><strong style=\"margin: 0px; padding: 0px; font-family: \'Open Sans\', Arial, sans-serif; font-size: 14px; text-align: justify; background-color: #ffffff;\">Lorem Ipsum</strong><span style=\"font-family: \'Open Sans\', Arial, sans-serif; font-size: 14px; text-align: justify; background-color: #ffffff;\">&nbsp;is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</span></p>', '<p><strong style=\"margin: 0px; padding: 0px; font-family: \'Open Sans\', Arial, sans-serif; font-size: 14px; text-align: justify; background-color: #ffffff;\">Lorem Ipsum</strong><span style=\"font-family: \'Open Sans\', Arial, sans-serif; font-size: 14px; text-align: justify; background-color: #ffffff;\">&nbsp;is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</span></p>', '<p><strong style=\"margin: 0px; padding: 0px; font-family: \'Open Sans\', Arial, sans-serif; font-size: 14px; text-align: justify; background-color: #ffffff;\">Lorem Ipsum</strong><span style=\"font-family: \'Open Sans\', Arial, sans-serif; font-size: 14px; text-align: justify; background-color: #ffffff;\">&nbsp;is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</span></p>', '<p><strong style=\"margin: 0px; padding: 0px; font-family: \'Open Sans\', Arial, sans-serif; font-size: 14px; text-align: justify; background-color: #ffffff;\">Lorem Ipsum</strong><span style=\"font-family: \'Open Sans\', Arial, sans-serif; font-size: 14px; text-align: justify; background-color: #ffffff;\">&nbsp;is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</span></p>', '<p><strong style=\"margin: 0px; padding: 0px; font-family: \'Open Sans\', Arial, sans-serif; font-size: 14px; text-align: justify; background-color: #ffffff;\">Lorem Ipsum</strong><span style=\"font-family: \'Open Sans\', Arial, sans-serif; font-size: 14px; text-align: justify; background-color: #ffffff;\">&nbsp;is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</span></p>', '<p><strong style=\"margin: 0px; padding: 0px; font-family: \'Open Sans\', Arial, sans-serif; font-size: 14px; text-align: justify; background-color: #ffffff;\">Lorem Ipsum</strong><span style=\"font-family: \'Open Sans\', Arial, sans-serif; font-size: 14px; text-align: justify; background-color: #ffffff;\">&nbsp;is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</span></p>', '2022-03-08 04:13:03', '2022-03-19 19:20:29'),
(22, 'CK101', 'Mạng máy tính', 3, 2, 4, 2, 14, 0, NULL, NULL, NULL, NULL, NULL, NULL, '2022-03-08 04:14:12', '2022-03-19 06:10:59'),
(23, 'TL234', 'Lập trình Web với PHP', 4, 3, 3, 2, 13, 0, NULL, NULL, NULL, NULL, NULL, NULL, '2022-03-11 07:56:20', '2022-03-19 06:11:14'),
(25, 'TN203', 'Lập tình hướng đối tượng', 4, 2, 1, 2, 13, 0, NULL, NULL, NULL, NULL, NULL, NULL, '2022-03-18 18:51:48', '2022-03-18 18:51:48'),
(26, 'CT71', 'Kỹ thuật máy tính', 4, 2, 1, 2, 13, 0, NULL, NULL, NULL, NULL, NULL, NULL, '2022-03-19 19:18:32', '2022-03-19 19:18:32'),
(27, 'XH22', 'Kỹ thuật phần mềm fsdf', 2, 3, 4, 1, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, '2022-03-19 19:24:49', '2022-03-19 19:24:49'),
(28, 'XH23', 'Tự chọn thứ hai', 2, 3, 7, 1, 13, 0, NULL, NULL, NULL, NULL, NULL, NULL, '2022-03-19 19:25:12', '2022-03-19 19:25:12'),
(29, 'XH24', 'Tự chọn thứ ba', 2, 3, 3, 1, 13, 0, NULL, NULL, NULL, NULL, NULL, NULL, '2022-03-19 19:25:29', '2022-03-19 19:25:29'),
(30, 'TN1', 'Mon test a', 2, 1, 3, 1, 13, 0, NULL, NULL, NULL, NULL, NULL, NULL, '2022-03-21 02:00:28', '2022-03-21 02:00:28'),
(31, 'TN2', 'Mon test b', 7, 2, 1, 2, 14, 0, NULL, NULL, NULL, NULL, NULL, NULL, '2022-03-21 02:00:48', '2022-03-21 02:00:48');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `course_method`
--

CREATE TABLE `course_method` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `course_method`
--

INSERT INTO `course_method` (`id`, `name`, `created_at`, `updated_at`) VALUES
(1, 'Lý thuyết', '2022-03-03 02:29:29', '2022-03-03 02:29:29'),
(2, 'Thực hành', '2022-03-03 02:29:37', '2022-03-03 02:29:37');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `course_type`
--

CREATE TABLE `course_type` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `course_type`
--

INSERT INTO `course_type` (`id`, `name`, `created_at`, `updated_at`) VALUES
(1, 'Đại cương', '2022-02-05 01:29:35', '2022-02-05 01:29:35'),
(2, 'Cơ sở ngành', '2022-02-05 01:30:10', '2022-02-05 01:30:10'),
(3, 'Chuyên ngành', '2022-02-05 01:30:10', '2022-02-05 01:30:10');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `curriculums`
--

CREATE TABLE `curriculums` (
  `id` int(11) NOT NULL,
  `academic_year_id` int(11) NOT NULL,
  `major_id` int(11) NOT NULL,
  `general_credit` int(3) NOT NULL,
  `general_mandatory` int(3) NOT NULL,
  `basic_credit` int(3) NOT NULL,
  `basic_mandatory` int(3) NOT NULL,
  `specialist_credit` int(3) NOT NULL,
  `specialist_mandatory` int(3) NOT NULL,
  `target` varchar(3000) NOT NULL,
  `content` varchar(3000) NOT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `curriculums`
--

INSERT INTO `curriculums` (`id`, `academic_year_id`, `major_id`, `general_credit`, `general_mandatory`, `basic_credit`, `basic_mandatory`, `specialist_credit`, `specialist_mandatory`, `target`, `content`, `created_at`, `updated_at`) VALUES
(32, 16, 26, 2, 2, 3, 3, 4, 4, '<p>fdsaff sdfsadfjksadfskfjsdf ksjdfskfsjdfklajsfkdsjfksdfjksafjsdkfsafkasjfk ksdfj ksdafjsdkf</p>', '<p>fsad</p>', '2022-03-04 19:56:03', '2022-03-10 18:52:17'),
(33, 20, 25, 3, 1, 6, 3, 10, 8, '<p>fdsff</p>', '<p>asdfaf</p>', '2022-03-08 04:12:26', '2022-03-11 19:24:49'),
(37, 49, 32, 54, 40, 56, 54, 42, 34, '<p><strong style=\"margin: 0px; padding: 0px; font-family: \'Open Sans\', Arial, sans-serif; font-size: 14px; text-align: justify; background-color: #ffffff;\">Lorem Ipsum</strong><span style=\"font-family: \'Open Sans\', Arial, sans-serif; font-size: 14px; text-align: justify; background-color: #ffffff;\">&nbsp;is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</span></p>', '<p><strong style=\"margin: 0px; padding: 0px; font-family: \'Open Sans\', Arial, sans-serif; font-size: 14px; text-align: justify; background-color: #ffffff;\">Lorem Ipsum</strong><span style=\"font-family: \'Open Sans\', Arial, sans-serif; font-size: 14px; text-align: justify; background-color: #ffffff;\">&nbsp;is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</span></p>', '2022-03-19 19:14:36', '2022-04-04 20:57:49');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `curriculum_courses`
--

CREATE TABLE `curriculum_courses` (
  `id` int(11) NOT NULL,
  `curriculum_id` int(11) NOT NULL,
  `course_id` int(11) NOT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `curriculum_courses`
--

INSERT INTO `curriculum_courses` (`id`, `curriculum_id`, `course_id`, `created_at`, `updated_at`) VALUES
(250, 33, 22, '2022-03-11 19:25:04', '2022-03-11 19:25:04'),
(363, 37, 28, '2022-04-04 20:55:07', '2022-04-04 20:55:07'),
(366, 37, 29, '2022-04-04 20:57:58', '2022-04-04 20:57:58'),
(383, 32, 20, '2022-04-14 22:33:55', '2022-04-14 22:33:55');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `degrees`
--

CREATE TABLE `degrees` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `name_short` varchar(10) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `degrees`
--

INSERT INTO `degrees` (`id`, `name`, `name_short`, `created_at`, `updated_at`) VALUES
(1, 'Thạc sĩ', 'Ths', '2022-02-11 12:30:38', '2022-02-11 12:30:38');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `departments`
--

CREATE TABLE `departments` (
  `id` int(11) NOT NULL,
  `name` varchar(191) NOT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `departments`
--

INSERT INTO `departments` (`id`, `name`, `created_at`, `updated_at`) VALUES
(1, 'Công nghệ thông tin & Truyền thông', '2022-02-03 08:19:26', '2022-02-03 08:19:26'),
(2, 'Kinh tế', '2022-02-05 06:10:01', '2022-02-05 06:10:01');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `lecturers`
--

CREATE TABLE `lecturers` (
  `id` int(11) NOT NULL,
  `lecturer_id` varchar(10) NOT NULL,
  `password` varchar(300) NOT NULL,
  `name` varchar(80) NOT NULL,
  `gender` varchar(4) NOT NULL,
  `birthday` date NOT NULL,
  `phone` varchar(11) NOT NULL,
  `email` varchar(100) NOT NULL,
  `degree_id` int(11) NOT NULL,
  `position_id` int(11) NOT NULL,
  `subject_id` int(11) NOT NULL,
  `role_id` int(11) DEFAULT NULL,
  `profile_img` varchar(200) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `lecturers`
--

INSERT INTO `lecturers` (`id`, `lecturer_id`, `password`, `name`, `gender`, `birthday`, `phone`, `email`, `degree_id`, `position_id`, `subject_id`, `role_id`, `profile_img`, `created_at`, `updated_at`) VALUES
(15, '54321', '$2y$12$DhW1dVHFI/nMA5mHBd7WqeeLIGeAGO5zewvcjNGM4/yxUChT1nMVu', 'Phan Thị Vui Cười', 'Nữ', '1983-06-16', '01279759158', 'vidu@gmail.com', 1, 1, 14, 3, 'tuc_ngu.png', '2022-03-17 21:01:41', '2022-03-28 01:18:30'),
(53, '12345', '$2y$12$Te2EbNNuGhcaos1P3gSs6eZM3DgjIB4omhOGJIrcPcggE3omoAvrC', 'Tran Huu Dan', 'Nam', '1988-01-01', '0915844549', 'vidu@gmail.com', 1, 1, 1, 1, NULL, '2022-04-14 22:06:03', '2022-04-14 22:09:14');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `majors`
--

CREATE TABLE `majors` (
  `id` int(11) NOT NULL,
  `major_id` varchar(10) NOT NULL,
  `name` varchar(100) NOT NULL,
  `name_short` varchar(10) NOT NULL,
  `subject_id` int(11) NOT NULL,
  `education_time` float NOT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `majors`
--

INSERT INTO `majors` (`id`, `major_id`, `name`, `name_short`, `subject_id`, `education_time`, `created_at`, `updated_at`) VALUES
(25, '7480209', 'Tin học ứng dụng', 'TH?D', 1, 4.5, '2022-02-24 00:57:26', '2022-03-19 06:00:07'),
(26, '32428', 'Công nghệ thông tin', 'CNTT', 13, 4.5, '2022-02-25 22:01:35', '2022-03-19 06:00:47'),
(27, '273412', 'Mạng máy tính và truyền thông dữ liệu', 'MMTVTTDL', 14, 4.5, '2022-03-02 20:14:35', '2022-03-19 06:01:04'),
(32, '74802010', 'Kỹ thuật phần mềm abc', 'KTPMA', 13, 5.5, '2022-03-19 19:13:13', '2022-03-19 19:13:21');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `optional_course_type`
--

CREATE TABLE `optional_course_type` (
  `id` int(11) NOT NULL,
  `code` varchar(10) NOT NULL,
  `name` varchar(191) NOT NULL,
  `num_of_credit` int(11) NOT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `optional_course_type`
--

INSERT INTO `optional_course_type` (`id`, `code`, `name`, `num_of_credit`, `created_at`, `updated_at`) VALUES
(1, '0', 'Bắt buộc', 0, '2022-02-06 06:30:51', '2022-02-06 06:30:51'),
(2, 'TC03', 'Nhóm luận văn', 15, '2022-02-05 06:26:31', '2022-02-05 06:26:31'),
(3, 'TC_01', 'Nhóm kỹ năng đại học', 2, '2022-02-05 11:57:26', '2022-02-05 11:57:26'),
(4, 'TC_02', 'Nhóm thể chất', 3, '2022-02-05 06:25:48', '2022-02-05 06:25:48'),
(7, 'TC_04', 'Nhóm mới nữa', 6, '2022-03-19 19:21:09', '2022-03-19 19:21:25');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `positions`
--

CREATE TABLE `positions` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `positions`
--

INSERT INTO `positions` (`id`, `name`, `created_at`, `updated_at`) VALUES
(1, 'Giảng viên', '2022-02-11 12:30:53', '2022-02-11 12:30:53');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `roles`
--

CREATE TABLE `roles` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `roles`
--

INSERT INTO `roles` (`id`, `name`, `created_at`, `updated_at`) VALUES
(0, 'Không có quyền', '2022-03-18 01:00:59', '2022-03-18 01:00:59'),
(1, 'Quản lý chương trinh đào tạo', '2022-03-17 10:15:27', '2022-03-17 10:15:27'),
(2, 'Quản lý giảng viên', '2022-03-17 10:15:27', '2022-03-17 10:15:27'),
(3, 'Admin', '2022-03-17 10:15:44', '2022-03-17 10:15:44');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `subjects`
--

CREATE TABLE `subjects` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `department_id` int(11) NOT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `subjects`
--

INSERT INTO `subjects` (`id`, `name`, `department_id`, `created_at`, `updated_at`) VALUES
(1, 'Tin học ứng dụng', 1, '2022-02-24 06:53:04', '2022-03-19 06:23:32'),
(13, 'Công nghệ thông tin', 1, '2022-02-24 01:18:23', '2022-03-19 06:01:26'),
(14, 'Mạng máy tính và truyền thông', 1, '2022-03-02 20:14:08', '2022-03-19 06:01:47');

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `academic_years`
--
ALTER TABLE `academic_years`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `conditional_courses`
--
ALTER TABLE `conditional_courses`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_conditional_course` (`conditional_course_id`),
  ADD KEY `fk_course` (`course_id`);

--
-- Chỉ mục cho bảng `courses`
--
ALTER TABLE `courses`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_course_type_courses` (`course_type_id`),
  ADD KEY `fk_optional_course_type_courses` (`optional_course_type_id`),
  ADD KEY `fk_subject_courses` (`subject_id`),
  ADD KEY `fk_course_method` (`course_method_id`);

--
-- Chỉ mục cho bảng `course_method`
--
ALTER TABLE `course_method`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `course_type`
--
ALTER TABLE `course_type`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `curriculums`
--
ALTER TABLE `curriculums`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_academic_year` (`academic_year_id`),
  ADD KEY `fk_major` (`major_id`);

--
-- Chỉ mục cho bảng `curriculum_courses`
--
ALTER TABLE `curriculum_courses`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_course_id` (`course_id`),
  ADD KEY `fk_curriculum_id` (`curriculum_id`);

--
-- Chỉ mục cho bảng `degrees`
--
ALTER TABLE `degrees`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `departments`
--
ALTER TABLE `departments`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `lecturers`
--
ALTER TABLE `lecturers`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_position` (`position_id`),
  ADD KEY `fk_lecturer_subject` (`subject_id`),
  ADD KEY `fk_lecturer_degree` (`degree_id`),
  ADD KEY `fk_role` (`role_id`);

--
-- Chỉ mục cho bảng `majors`
--
ALTER TABLE `majors`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_subject` (`subject_id`);

--
-- Chỉ mục cho bảng `optional_course_type`
--
ALTER TABLE `optional_course_type`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `positions`
--
ALTER TABLE `positions`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `subjects`
--
ALTER TABLE `subjects`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_department` (`department_id`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `academic_years`
--
ALTER TABLE `academic_years`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=50;

--
-- AUTO_INCREMENT cho bảng `conditional_courses`
--
ALTER TABLE `conditional_courses`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=47;

--
-- AUTO_INCREMENT cho bảng `courses`
--
ALTER TABLE `courses`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=40;

--
-- AUTO_INCREMENT cho bảng `course_method`
--
ALTER TABLE `course_method`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT cho bảng `course_type`
--
ALTER TABLE `course_type`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT cho bảng `curriculums`
--
ALTER TABLE `curriculums`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;

--
-- AUTO_INCREMENT cho bảng `curriculum_courses`
--
ALTER TABLE `curriculum_courses`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=386;

--
-- AUTO_INCREMENT cho bảng `degrees`
--
ALTER TABLE `degrees`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT cho bảng `departments`
--
ALTER TABLE `departments`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT cho bảng `lecturers`
--
ALTER TABLE `lecturers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=54;

--
-- AUTO_INCREMENT cho bảng `majors`
--
ALTER TABLE `majors`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;

--
-- AUTO_INCREMENT cho bảng `optional_course_type`
--
ALTER TABLE `optional_course_type`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT cho bảng `positions`
--
ALTER TABLE `positions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT cho bảng `roles`
--
ALTER TABLE `roles`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT cho bảng `subjects`
--
ALTER TABLE `subjects`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `conditional_courses`
--
ALTER TABLE `conditional_courses`
  ADD CONSTRAINT `fk_conditional_course` FOREIGN KEY (`conditional_course_id`) REFERENCES `courses` (`id`),
  ADD CONSTRAINT `fk_course` FOREIGN KEY (`course_id`) REFERENCES `courses` (`id`) ON DELETE CASCADE;

--
-- Các ràng buộc cho bảng `courses`
--
ALTER TABLE `courses`
  ADD CONSTRAINT `fk_course_method` FOREIGN KEY (`course_method_id`) REFERENCES `course_method` (`id`),
  ADD CONSTRAINT `fk_course_type_courses` FOREIGN KEY (`course_type_id`) REFERENCES `course_type` (`id`),
  ADD CONSTRAINT `fk_optional_course_type_courses` FOREIGN KEY (`optional_course_type_id`) REFERENCES `optional_course_type` (`id`),
  ADD CONSTRAINT `fk_subject_courses` FOREIGN KEY (`subject_id`) REFERENCES `subjects` (`id`);

--
-- Các ràng buộc cho bảng `curriculums`
--
ALTER TABLE `curriculums`
  ADD CONSTRAINT `fk_academic_year` FOREIGN KEY (`academic_year_id`) REFERENCES `academic_years` (`id`),
  ADD CONSTRAINT `fk_major` FOREIGN KEY (`major_id`) REFERENCES `majors` (`id`);

--
-- Các ràng buộc cho bảng `curriculum_courses`
--
ALTER TABLE `curriculum_courses`
  ADD CONSTRAINT `fk_course_id` FOREIGN KEY (`course_id`) REFERENCES `courses` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_curriculum_id` FOREIGN KEY (`curriculum_id`) REFERENCES `curriculums` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Các ràng buộc cho bảng `lecturers`
--
ALTER TABLE `lecturers`
  ADD CONSTRAINT `fk_lecturer_degree` FOREIGN KEY (`degree_id`) REFERENCES `degrees` (`id`),
  ADD CONSTRAINT `fk_lecturer_subject` FOREIGN KEY (`subject_id`) REFERENCES `subjects` (`id`),
  ADD CONSTRAINT `fk_position` FOREIGN KEY (`position_id`) REFERENCES `positions` (`id`),
  ADD CONSTRAINT `fk_role` FOREIGN KEY (`role_id`) REFERENCES `roles` (`id`);

--
-- Các ràng buộc cho bảng `majors`
--
ALTER TABLE `majors`
  ADD CONSTRAINT `fk_subject` FOREIGN KEY (`subject_id`) REFERENCES `subjects` (`id`);

--
-- Các ràng buộc cho bảng `subjects`
--
ALTER TABLE `subjects`
  ADD CONSTRAINT `fk_department` FOREIGN KEY (`department_id`) REFERENCES `departments` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
