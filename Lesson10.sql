USE [LvhK22CNT1Lesson09]
GO
/****** Object:  Table [dbo].[LvhKetQua]    Script Date: 6/24/2024 9:19:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LvhKetQua](
	[LvhMaSV] [nchar](10) NOT NULL,
	[LvhMaMH] [nchar](10) NOT NULL,
	[LvhDiem] [decimal](3, 2) NULL,
 CONSTRAINT [PK_LvhKetQua] PRIMARY KEY CLUSTERED 
(
	[LvhMaSV] ASC,
	[LvhMaMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LvhKhoa]    Script Date: 6/24/2024 9:19:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LvhKhoa](
	[LvhMaKH] [nchar](10) NOT NULL,
	[LvhTenKH] [nvarchar](50) NULL,
 CONSTRAINT [PK_LvhKhoa] PRIMARY KEY CLUSTERED 
(
	[LvhMaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LvhMonHoc]    Script Date: 6/24/2024 9:19:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LvhMonHoc](
	[LvhMaMH] [nchar](10) NOT NULL,
	[LvhTenMH] [nvarchar](50) NULL,
	[LvhSotiet] [int] NULL,
 CONSTRAINT [PK_LvhMonHoc] PRIMARY KEY CLUSTERED 
(
	[LvhMaMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LvhSinhVien]    Script Date: 6/24/2024 9:19:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LvhSinhVien](
	[LvhMaSV] [nchar](10) NOT NULL,
	[LvhHoSV] [nvarchar](50) NULL,
	[LvhTenSV] [nvarchar](50) NULL,
	[LvhPhai] [bit] NULL,
	[LvhNgaySinh] [date] NULL,
	[LvhNoiSinh] [nvarchar](50) NULL,
	[LvhMaKH] [nchar](10) NULL,
	[LvhHocBong] [decimal](10, 2) NULL,
	[LvhDiemTrungBinh] [decimal](3, 2) NULL,
 CONSTRAINT [PK_LvhSinhVien] PRIMARY KEY CLUSTERED 
(
	[LvhMaSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[LvhKetQua] ([LvhMaSV], [LvhMaMH], [LvhDiem]) VALUES (N'2210900106', N'CNT1      ', CAST(9.00 AS Decimal(3, 2)))
INSERT [dbo].[LvhKhoa] ([LvhMaKH], [LvhTenKH]) VALUES (N'K22CNT1   ', N'K22CNT2')
INSERT [dbo].[LvhMonHoc] ([LvhMaMH], [LvhTenMH], [LvhSotiet]) VALUES (N'CNT1      ', N'Công Nghệ Thông Tin', 4)
INSERT [dbo].[LvhSinhVien] ([LvhMaSV], [LvhHoSV], [LvhTenSV], [LvhPhai], [LvhNgaySinh], [LvhNoiSinh], [LvhMaKH], [LvhHocBong], [LvhDiemTrungBinh]) VALUES (N'2210900106', N'Lê Vinh', N'Huy', 1, CAST(N'2004-01-20' AS Date), N'Hà Nội', N'K22CNT1   ', CAST(1000000.00 AS Decimal(10, 2)), CAST(8.00 AS Decimal(3, 2)))
ALTER TABLE [dbo].[LvhKetQua]  WITH CHECK ADD  CONSTRAINT [FK_LvhKetQua_LvhMonHoc] FOREIGN KEY([LvhMaMH])
REFERENCES [dbo].[LvhMonHoc] ([LvhMaMH])
GO
ALTER TABLE [dbo].[LvhKetQua] CHECK CONSTRAINT [FK_LvhKetQua_LvhMonHoc]
GO
ALTER TABLE [dbo].[LvhKetQua]  WITH CHECK ADD  CONSTRAINT [FK_LvhKetQua_LvhSinhVien] FOREIGN KEY([LvhMaSV])
REFERENCES [dbo].[LvhSinhVien] ([LvhMaSV])
GO
ALTER TABLE [dbo].[LvhKetQua] CHECK CONSTRAINT [FK_LvhKetQua_LvhSinhVien]
GO
ALTER TABLE [dbo].[LvhSinhVien]  WITH CHECK ADD  CONSTRAINT [FK_LvhSinhVien_LvhKhoa] FOREIGN KEY([LvhMaKH])
REFERENCES [dbo].[LvhKhoa] ([LvhMaKH])
GO
ALTER TABLE [dbo].[LvhSinhVien] CHECK CONSTRAINT [FK_LvhSinhVien_LvhKhoa]
GO
