USE Retail
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 27.06.2022 23:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](max) NOT NULL,
	[CutomerSurname] [nvarchar](max) NULL,
	[CustomerType] [nvarchar](max) NOT NULL,
	[RecordDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceDiscounts]    Script Date: 27.06.2022 23:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDiscounts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOT NULL,
	[DiscountType] [nvarchar](max) NOT NULL,
	[DiscountValue] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_InvoiceDiscounts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceLines]    Script Date: 27.06.2022 23:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceLines](
	[LineID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[PriceAmount] [decimal](18, 2) NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_InvoiceLines] PRIMARY KEY CLUSTERED 
(
	[LineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 27.06.2022 23:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[InvoiceID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[InvoiceTotalAmount] [decimal](18, 2) NOT NULL,
	[DiscountTotalAmount] [decimal](18, 2) NOT NULL,
	[PayableAmount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 27.06.2022 23:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[ProductPrice] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 
GO
INSERT [dbo].[Customers] ([CustomerID], [CustomerName], [CutomerSurname], [CustomerType], [RecordDate]) VALUES (1, N'Muhammed', N'Dursun', N'1', CAST(N'2022-06-25T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Customers] ([CustomerID], [CustomerName], [CutomerSurname], [CustomerType], [RecordDate]) VALUES (2, N'X Groceries', NULL, N'2', CAST(N'2021-02-25T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Customers] ([CustomerID], [CustomerName], [CutomerSurname], [CustomerType], [RecordDate]) VALUES (3, N'Ahmet', N'Hurma', N'1', CAST(N'2019-01-01T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[InvoiceLines] ON 
GO
INSERT [dbo].[InvoiceLines] ([LineID], [InvoiceID], [ProductID], [Quantity], [PriceAmount], [TotalAmount]) VALUES (2, 2, 1, 10, CAST(25.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[InvoiceLines] ([LineID], [InvoiceID], [ProductID], [Quantity], [PriceAmount], [TotalAmount]) VALUES (3, 2, 2, 120, CAST(30.00 AS Decimal(18, 2)), CAST(3600.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[InvoiceLines] ([LineID], [InvoiceID], [ProductID], [Quantity], [PriceAmount], [TotalAmount]) VALUES (4, 3, 1, 5, CAST(25.00 AS Decimal(18, 2)), CAST(125.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[InvoiceLines] ([LineID], [InvoiceID], [ProductID], [Quantity], [PriceAmount], [TotalAmount]) VALUES (5, 4, 2, 7, CAST(30.00 AS Decimal(18, 2)), CAST(210.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[InvoiceLines] OFF
GO
SET IDENTITY_INSERT [dbo].[Invoices] ON 
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceTotalAmount], [DiscountTotalAmount], [PayableAmount]) VALUES (2, 1, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceTotalAmount], [DiscountTotalAmount], [PayableAmount]) VALUES (3, 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceTotalAmount], [DiscountTotalAmount], [PayableAmount]) VALUES (4, 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Invoices] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [ProductPrice]) VALUES (1, N'Mouse', CAST(25.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [ProductPrice]) VALUES (2, N'Keyboard', CAST(30.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
ALTER TABLE [dbo].[InvoiceDiscounts]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDiscounts_Invoices_InvoiceID] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[Invoices] ([InvoiceID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceDiscounts] CHECK CONSTRAINT [FK_InvoiceDiscounts_Invoices_InvoiceID]
GO
ALTER TABLE [dbo].[InvoiceLines]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceLines_Invoices_InvoiceID] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[Invoices] ([InvoiceID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceLines] CHECK CONSTRAINT [FK_InvoiceLines_Invoices_InvoiceID]
GO
ALTER TABLE [dbo].[InvoiceLines]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceLines_Products_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceLines] CHECK CONSTRAINT [FK_InvoiceLines_Products_ProductID]
GO
ALTER TABLE [dbo].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Customers_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoices] CHECK CONSTRAINT [FK_Invoices_Customers_CustomerID]
GO
