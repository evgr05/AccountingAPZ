USE [APZAccounting]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 09.12.2024 20:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](250) NULL,
	[SurName] [nvarchar](250) NULL,
	[Patronymic] [nvarchar](250) NULL,
	[Phone] [nchar](15) NULL,
	[Adress] [nvarchar](250) NULL,
	[PostId] [int] NULL,
	[WorkshopId] [int] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeesMaterials]    Script Date: 09.12.2024 20:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeesMaterials](
	[MaterialId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_EmployeesMaterials] PRIMARY KEY CLUSTERED 
(
	[MaterialId] ASC,
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeesProducts]    Script Date: 09.12.2024 20:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeesProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NULL,
	[ProductId] [int] NULL,
	[Count] [int] NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_EmployeesProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialProducts]    Script Date: 09.12.2024 20:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialProducts](
	[MaterialId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_MaterialProducts] PRIMARY KEY CLUSTERED 
(
	[MaterialId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 09.12.2024 20:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materials](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Unit] [nvarchar](50) NULL,
	[Count] [int] NULL,
 CONSTRAINT [PK_Materials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 09.12.2024 20:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 09.12.2024 20:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 09.12.2024 20:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 09.12.2024 20:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](650) NULL,
	[EmployeId] [int] NULL,
	[RoleId] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workshops]    Script Date: 09.12.2024 20:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workshops](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](350) NULL,
	[WorkshopNubmer] [nchar](10) NULL,
 CONSTRAINT [PK_Workshops] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Posts] FOREIGN KEY([PostId])
REFERENCES [dbo].[Posts] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Posts]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Workshops] FOREIGN KEY([WorkshopId])
REFERENCES [dbo].[Workshops] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Workshops]
GO
ALTER TABLE [dbo].[EmployeesMaterials]  WITH CHECK ADD  CONSTRAINT [FK_EmployeesMaterials_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[EmployeesMaterials] CHECK CONSTRAINT [FK_EmployeesMaterials_Employees]
GO
ALTER TABLE [dbo].[EmployeesMaterials]  WITH CHECK ADD  CONSTRAINT [FK_EmployeesMaterials_Materials] FOREIGN KEY([MaterialId])
REFERENCES [dbo].[Materials] ([Id])
GO
ALTER TABLE [dbo].[EmployeesMaterials] CHECK CONSTRAINT [FK_EmployeesMaterials_Materials]
GO
ALTER TABLE [dbo].[EmployeesProducts]  WITH CHECK ADD  CONSTRAINT [FK_EmployeesProducts_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[EmployeesProducts] CHECK CONSTRAINT [FK_EmployeesProducts_Employees]
GO
ALTER TABLE [dbo].[EmployeesProducts]  WITH CHECK ADD  CONSTRAINT [FK_EmployeesProducts_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[EmployeesProducts] CHECK CONSTRAINT [FK_EmployeesProducts_Products]
GO
ALTER TABLE [dbo].[MaterialProducts]  WITH CHECK ADD  CONSTRAINT [FK_MaterialProducts_Materials] FOREIGN KEY([MaterialId])
REFERENCES [dbo].[Materials] ([Id])
GO
ALTER TABLE [dbo].[MaterialProducts] CHECK CONSTRAINT [FK_MaterialProducts_Materials]
GO
ALTER TABLE [dbo].[MaterialProducts]  WITH CHECK ADD  CONSTRAINT [FK_MaterialProducts_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[MaterialProducts] CHECK CONSTRAINT [FK_MaterialProducts_Products]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Employees] FOREIGN KEY([EmployeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Employees]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Role]
GO
