USE [ElectronicCommerce]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 3/22/2023 11:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[BrandId] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [nvarchar](200) NULL,
	[LogoUrl] [nvarchar](500) NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 3/22/2023 11:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](200) NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Delivery]    Script Date: 3/22/2023 11:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery](
	[DeliveryId] [int] NOT NULL,
	[DeliveryDate] [datetime] NULL,
	[Address] [nvarchar](500) NOT NULL,
	[PhoneNumber] [nvarchar](12) NOT NULL,
	[CustomerName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Delivery] PRIMARY KEY CLUSTERED 
(
	[DeliveryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 3/22/2023 11:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[OrderDate] [datetime] NOT NULL,
	[IsComplete] [bit] NULL,
	[IsPaid] [bit] NULL,
	[TransactionId] [nvarchar](200) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 3/22/2023 11:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderId] [int] NOT NULL,
	[ProductDetailId] [int] NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ProductDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 3/22/2023 11:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](200) NULL,
	[Quantity] [int] NOT NULL,
	[OriginPrice] [decimal](18, 0) NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CategoryId] [int] NOT NULL,
	[BrandId] [int] NOT NULL,
	[Rating] [float] NULL,
	[ImageUrl] [nvarchar](500) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductDetail]    Script Date: 3/22/2023 11:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDetail](
	[ProductDetailId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Variant] [nvarchar](50) NULL,
	[VariantPrice] [decimal](18, 0) NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_ProductDetail] PRIMARY KEY CLUSTERED 
(
	[ProductDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([BrandId], [BrandName], [LogoUrl]) VALUES (1, N'Asus', N'https://www.freepnglogos.com/uploads/logo-asus-png/asus-logo-hd-photo-15.png')
INSERT [dbo].[Brand] ([BrandId], [BrandName], [LogoUrl]) VALUES (2, N'Dell', N'https://www.freepnglogos.com/uploads/dell-png-logo/dell-png-logo-0.png')
INSERT [dbo].[Brand] ([BrandId], [BrandName], [LogoUrl]) VALUES (3, N'HP', N'https://upload.wikimedia.org/wikipedia/commons/6/6f/HP_logo_630x630.png')
INSERT [dbo].[Brand] ([BrandId], [BrandName], [LogoUrl]) VALUES (4, N'MSI', N'https://brademar.com/wp-content/uploads/2022/05/MSI-Logo-PNG-2011-%E2%80%93-2019.png')
INSERT [dbo].[Brand] ([BrandId], [BrandName], [LogoUrl]) VALUES (5, N'Lenovo', N'https://banner2.cleanpng.com/20180404/hie/kisspng-hewlett-packard-logo-lenovo-computer-software-lenovo-logo-5ac49fb0604651.4490159315228353763944.jpg')
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Description]) VALUES (1, N'Laptop', NULL)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Description]) VALUES (2, N'Chuột', NULL)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Description]) VALUES (3, N'Bàn phím', NULL)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Description]) VALUES (4, N'Màn hình', NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductId], [ProductName], [Quantity], [OriginPrice], [Price], [Description], [CategoryId], [BrandId], [Rating], [ImageUrl]) VALUES (1, N'Laptop Asus Vivobook 15 X515EA BR2045W', 10, CAST(11490000 AS Decimal(18, 0)), CAST(10900000 AS Decimal(18, 0)), N'<table id="tblGeneralAttribute" border="1" cellpadding="3" cellspacing="0" style="background-color:#ffffff; border-collapse:collapse; border-spacing:0px; border:1px solid #eeeeee; box-sizing:border-box; color:#333333; font-family:Roboto,sans-serif; font-size:13px; line-height:20px; margin-bottom:20px; margin-left:auto; margin-right:auto; max-width:100%; min-width:500px; width:100%" class="table table-bordered"><tbody style="box-sizing: border-box;"><tr style="box-sizing:border-box" class="row-info"><td style="background-color:#f7f7f7 !important; border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:190px"><span style="font-size:18px"><strong><a target="_blank" href="https://gearvn.com/collections/cpu-bo-vi-xu-ly">CPU</a></strong></span></td><td style="border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:643px"><span style="font-size:18px"><span style="color:#000000">Intel Core i3-1115G4 1.7GHz up to 4.1GHz 6MB</span></span></td></tr><tr style="box-sizing:border-box" class="row-info"><td style="background-color:#f7f7f7 !important; border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:190px"><span style="font-size:18px"><strong><a target="_blank" href="https://gearvn.com/collections/cpu-bo-vi-xu-ly">RAM</a></strong></span></td><td style="border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:643px"><span style="font-size:18px"><span style="color:#000000">4GB Onboard DDR4 2666MHz (1x SO-DIMM socket, up to 12GB SDRAM)</span></span></td></tr><tr style="box-sizing:border-box" class="row-info"><td style="background-color:#f7f7f7 !important; border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:190px"><span style="font-size:18px"><strong><a target="_blank" href="https://gearvn.com/collections/cpu-bo-vi-xu-ly">Ổ lưu trữ</a></strong></span></td><td style="border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:643px"><span style="font-size:18px"><span style="color:#000000">512GB M.2 NVMe™ PCIe® 3.0 SSD, 1x slot SATA3 2.5"</span></span></td></tr><tr style="box-sizing:border-box" class="row-info"><td style="background-color:#f7f7f7 !important; border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:190px"><span style="font-size:18px"><strong><a target="_blank" href="https://gearvn.com/collections/cpu-bo-vi-xu-ly">Card đồ họa</a></strong></span></td><td style="border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:643px"><span style="font-size:18px"><span style="color:#000000">Intel UHD Graphics</span></span></td></tr><tr style="box-sizing:border-box" class="row-info"><td style="background-color:#f7f7f7 !important; border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:190px"><span style="font-size:18px"><strong><span style="color:#000000"><a target="_blank" href="https://gearvn.com/collections/cpu-bo-vi-xu-ly">Màn hình</a></span></strong></span></td><td style="border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:643px"><span style="font-size:18px"><span style="color:#000000">15.6" HD (1366 x 768), Anti-glare display, LED Backlit, 200nits, NTSC: 45%, Screen-to-body ratio: 83 ％</span></span></td></tr><tr style="box-sizing:border-box" class="row-info"><td style="background-color:#f7f7f7 !important; border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:190px"><span style="font-size:18px"><strong><a target="_blank" href="https://gearvn.com/collections/cpu-bo-vi-xu-ly">Bàn phím</a></strong></span></td><td style="border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:643px"><span style="font-size:18px"><span style="color:#000000">Tiêu chuẩn, có phím số</span></span></td></tr><tr style="box-sizing:border-box" class="row-info"><td style="background-color:#f7f7f7 !important; border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:190px"><span style="font-size:18px"><span style="color:#000000"><strong>Audio</strong></span></span></td><td style="border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:643px"><span style="font-size:18px"><span style="color:#000000">SonicMaster</span></span></td></tr><tr style="box-sizing:border-box" class="row-info"><td style="background-color:#f7f7f7 !important; border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:190px"><span style="font-size:18px"><span style="color:#000000"><strong>Kết nối có dây (LAN)</strong></span></span></td><td style="border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:643px"><span style="font-size:18px"><span style="color:#000000">None</span></span></td></tr><tr style="box-sizing:border-box" class="row-info"><td style="background-color:#f7f7f7 !important; border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:190px"><span style="font-size:18px"><span style="color:#000000"><strong>Kết nối không dây</strong></span></span></td><td style="border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:643px"><span style="font-size:18px"><span style="color:#000000">802.11 AC, Bluetooth v4.1</span></span></td></tr><tr style="box-sizing:border-box" class="row-info"><td style="background-color:#f7f7f7 !important; border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:190px"><span style="font-size:18px"><strong><a target="_blank" href="https://gearvn.com/collections/cpu-bo-vi-xu-ly">Webcam</a></strong></span></td><td style="border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:643px"><span style="font-size:18px">HD camera&nbsp;&nbsp;(720p Webcam)</span></td></tr><tr style="box-sizing:border-box" class="row-info"><td style="background-color:#f7f7f7 !important; border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:190px"><span style="font-size:18px"><span style="color:#000000"><strong>Cổng giao tiếp</strong></span></span></td><td style="border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:643px"><ul><li><span style="font-size:18px">1x USB 3.2 Gen 1 Type-A</span></li><li><span style="font-size:18px">1x USB 3.2 Gen 1 Type-C</span></li><li><span style="font-size:18px">2x USB 2.0 Type-A</span></li><li><span style="font-size:18px">1x HDMI 1.4</span></li><li><span style="font-size:18px">1x 3.5mm Combo Audio Jack</span></li><li><span style="font-size:18px">1x DC-in</span></li></ul></td></tr><tr style="box-sizing:border-box" class="row-info"><td style="background-color:#f7f7f7 !important; border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:190px"><span style="font-size:18px"><span style="color:#000000"><strong>Hệ điều hành</strong></span></span></td><td style="border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:643px"><span style="font-size:18px"><span style="color:#000000">Windows 11 Home</span></span></td></tr><tr style="box-sizing:border-box" class="row-info"><td style="background-color:#f7f7f7 !important; border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:190px"><span style="font-size:18px"><span style="color:#000000"><strong>Pin</strong></span></span></td><td style="border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:643px"><span style="font-size:18px"><span style="color:#000000">2 Cells 37WHrs</span></span></td></tr><tr style="box-sizing:border-box" class="row-info"><td style="background-color:#f7f7f7 !important; border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:190px"><span style="font-size:18px"><span style="color:#000000"><strong>Trọng lượng</strong></span></span></td><td style="border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:643px"><span style="font-size:18px"><span style="color:#000000">1.8 kg</span></span></td></tr><tr style="box-sizing:border-box" class="row-info"><td style="background-color:#f7f7f7 !important; border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:190px"><span style="font-size:18px"><span style="color:#000000"><strong>Màu sắc</strong></span></span></td><td style="border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:643px"><span style="font-size:18px"><span style="color:#000000">Slate Gray</span></span></td></tr><tr style="box-sizing:border-box" class="row-info"><td style="background-color:#f7f7f7 !important; border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:190px"><span style="font-size:18px"><span style="color:#000000"><strong>Bảo mật</strong></span></span></td><td style="border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:643px"><span style="font-size:18px"><span style="color:#000000">Vân tay</span></span></td></tr><tr><td style="background-color:#f7f7f7 !important; border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:190px"><span style="font-size:18px"><span style="color:#000000"><strong>Kích thước</strong></span></span></td><td style="border-color:#eeeeee; border-style:solid; border-width:1px; box-sizing:border-box; padding:8px; vertical-align:top; width:643px"><span style="font-size:18px"><span style="color:#000000">36.00 x 23.50 x 1.99 ~ 1.99 cm</span></span></td></tr></tbody></table>', 1, 1, 4, N'https://product.hstatic.net/1000026716/product/gearvn-laptop-asus-vivobook-15-x515ea-br2045w-1_f7e2bdc9339d400ea1fa3943e7abccba.png')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductDetail] ON 

INSERT [dbo].[ProductDetail] ([ProductDetailId], [ProductId], [Variant], [VariantPrice], [Description]) VALUES (1, 1, N'4GB', CAST(0 AS Decimal(18, 0)), N'4GB Onboard DDR4 2666MHz (1x SO-DIMM socket, up to 12GB SDRAM)')
INSERT [dbo].[ProductDetail] ([ProductDetailId], [ProductId], [Variant], [VariantPrice], [Description]) VALUES (2, 1, N'8GB', CAST(500000 AS Decimal(18, 0)), NULL)
SET IDENTITY_INSERT [dbo].[ProductDetail] OFF
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Delivery] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Delivery] ([DeliveryId])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Delivery]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_ProductDetail] FOREIGN KEY([ProductDetailId])
REFERENCES [dbo].[ProductDetail] ([ProductDetailId])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_ProductDetail]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([BrandId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Brand]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[ProductDetail]  WITH CHECK ADD  CONSTRAINT [FK_ProductDetail_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[ProductDetail] CHECK CONSTRAINT [FK_ProductDetail_Product]
GO
