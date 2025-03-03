USE [master]
GO
/****** Object:  Database [CrediconsultigBD]    Script Date: 2/13/2025 8:15:50 PM ******/
CREATE DATABASE [CrediconsultigBD]
GO

GO
USE [CrediconsultigBD]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 2/13/2025 8:15:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[MovimientoID] [int] IDENTITY(1,1) NOT NULL,
	[TarjetaID] [int] NOT NULL,
	[FechaMovimiento] [date] NOT NULL,
	[Descripcion] [varchar](max) NULL,
	[Monto] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MovimientoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pagos]    Script Date: 2/13/2025 8:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pagos](
	[PagoID] [int] IDENTITY(1,1) NOT NULL,
	[TarjetaID] [int] NOT NULL,
	[FechaPago] [date] NOT NULL,
	[Monto] [decimal](18, 2) NOT NULL,
	[MetodoPago] [nvarchar](50) NULL,
 CONSTRAINT [PK__Pagos__F00B61585E70D430] PRIMARY KEY CLUSTERED 
(
	[PagoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TarjetaCredito]    Script Date: 2/13/2025 8:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TarjetaCredito](
	[TarjetaID] [int] IDENTITY(1,1) NOT NULL,
	[TitularID] [int] NOT NULL,
	[NumeroTarjeta] [nvarchar](16) NOT NULL,
	[FechaExpiracion] [date] NOT NULL,
	[CVV] [nvarchar](4) NOT NULL,
	[LimiteCredito] [decimal](18, 2) NOT NULL,
	[PorcentajeInteresConfigurable] [decimal](18, 2) NOT NULL,
	[PorcentajeConfigurableSaldoMinimo] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_TarjetaCredito] PRIMARY KEY CLUSTERED 
(
	[TarjetaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Titular]    Script Date: 2/13/2025 8:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Titular](
	[TitularID] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](150) NOT NULL,
	[Apellidos] [varchar](150) NOT NULL,
	[Correo] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TitularID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Movimientos] ON 

INSERT [dbo].[Movimientos] ([MovimientoID], [TarjetaID], [FechaMovimiento], [Descripcion], [Monto]) VALUES (1, 1, CAST(N'2025-01-08' AS Date), N'Compra en el super selectos', CAST(150.00 AS Decimal(18, 2)))
INSERT [dbo].[Movimientos] ([MovimientoID], [TarjetaID], [FechaMovimiento], [Descripcion], [Monto]) VALUES (2, 1, CAST(N'2025-02-08' AS Date), N'Compra radioshack', CAST(35.99 AS Decimal(18, 2)))
INSERT [dbo].[Movimientos] ([MovimientoID], [TarjetaID], [FechaMovimiento], [Descripcion], [Monto]) VALUES (3, 2, CAST(N'2025-02-09' AS Date), N'Compra en Siman', CAST(89.99 AS Decimal(18, 2)))
INSERT [dbo].[Movimientos] ([MovimientoID], [TarjetaID], [FechaMovimiento], [Descripcion], [Monto]) VALUES (4, 1, CAST(N'2025-02-09' AS Date), N'Compra en Adoc', CAST(55.00 AS Decimal(18, 2)))
INSERT [dbo].[Movimientos] ([MovimientoID], [TarjetaID], [FechaMovimiento], [Descripcion], [Monto]) VALUES (5, 2, CAST(N'2025-02-08' AS Date), N'Compra en Farmacias Farmavalue', CAST(73.49 AS Decimal(18, 2)))
INSERT [dbo].[Movimientos] ([MovimientoID], [TarjetaID], [FechaMovimiento], [Descripcion], [Monto]) VALUES (6, 3, CAST(N'2025-02-08' AS Date), N'Compra en Vidri', CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[Movimientos] ([MovimientoID], [TarjetaID], [FechaMovimiento], [Descripcion], [Monto]) VALUES (7, 3, CAST(N'2025-02-10' AS Date), N'compra en ferrocentro', CAST(250.00 AS Decimal(18, 2)))
INSERT [dbo].[Movimientos] ([MovimientoID], [TarjetaID], [FechaMovimiento], [Descripcion], [Monto]) VALUES (1002, 4, CAST(N'2025-02-12' AS Date), N'Compra en Pollo Campero', CAST(30.00 AS Decimal(18, 2)))
INSERT [dbo].[Movimientos] ([MovimientoID], [TarjetaID], [FechaMovimiento], [Descripcion], [Monto]) VALUES (1003, 8, CAST(N'2025-02-13' AS Date), N'Compra en Farmacias San Nicolas', CAST(28.89 AS Decimal(18, 2)))
INSERT [dbo].[Movimientos] ([MovimientoID], [TarjetaID], [FechaMovimiento], [Descripcion], [Monto]) VALUES (1004, 8, CAST(N'2025-02-13' AS Date), N'Compra en Walmart', CAST(55.35 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Movimientos] OFF
GO
SET IDENTITY_INSERT [dbo].[Pagos] ON 

INSERT [dbo].[Pagos] ([PagoID], [TarjetaID], [FechaPago], [Monto], [MetodoPago]) VALUES (1, 3, CAST(N'2025-02-10' AS Date), CAST(100.00 AS Decimal(18, 2)), N'Banca Movil')
INSERT [dbo].[Pagos] ([PagoID], [TarjetaID], [FechaPago], [Monto], [MetodoPago]) VALUES (2, 3, CAST(N'2025-02-10' AS Date), CAST(250.00 AS Decimal(18, 2)), N'Ventanilla Banco')
INSERT [dbo].[Pagos] ([PagoID], [TarjetaID], [FechaPago], [Monto], [MetodoPago]) VALUES (3, 4, CAST(N'2025-02-12' AS Date), CAST(30.00 AS Decimal(18, 2)), N'Punto de Pago')
INSERT [dbo].[Pagos] ([PagoID], [TarjetaID], [FechaPago], [Monto], [MetodoPago]) VALUES (4, 2, CAST(N'2025-02-12' AS Date), CAST(89.99 AS Decimal(18, 2)), N'Punto de Pago')
INSERT [dbo].[Pagos] ([PagoID], [TarjetaID], [FechaPago], [Monto], [MetodoPago]) VALUES (5, 1, CAST(N'2025-02-13' AS Date), CAST(73.49 AS Decimal(18, 2)), N'Ventanilla Banco')
INSERT [dbo].[Pagos] ([PagoID], [TarjetaID], [FechaPago], [Monto], [MetodoPago]) VALUES (6, 8, CAST(N'2025-02-13' AS Date), CAST(28.89 AS Decimal(18, 2)), N'Banca Electronica')
SET IDENTITY_INSERT [dbo].[Pagos] OFF
GO
SET IDENTITY_INSERT [dbo].[TarjetaCredito] ON 

INSERT [dbo].[TarjetaCredito] ([TarjetaID], [TitularID], [NumeroTarjeta], [FechaExpiracion], [CVV], [LimiteCredito], [PorcentajeInteresConfigurable], [PorcentajeConfigurableSaldoMinimo]) VALUES (1, 1, N'1400202020202020', CAST(N'2028-03-08' AS Date), N'321', CAST(1000.00 AS Decimal(18, 2)), CAST(25.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)))
INSERT [dbo].[TarjetaCredito] ([TarjetaID], [TitularID], [NumeroTarjeta], [FechaExpiracion], [CVV], [LimiteCredito], [PorcentajeInteresConfigurable], [PorcentajeConfigurableSaldoMinimo]) VALUES (2, 2, N'3203345612343212', CAST(N'2027-12-15' AS Date), N'322', CAST(1500.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), CAST(2.50 AS Decimal(18, 2)))
INSERT [dbo].[TarjetaCredito] ([TarjetaID], [TitularID], [NumeroTarjeta], [FechaExpiracion], [CVV], [LimiteCredito], [PorcentajeInteresConfigurable], [PorcentajeConfigurableSaldoMinimo]) VALUES (3, 3, N'2020234533001789', CAST(N'2030-02-08' AS Date), N'712', CAST(2000.00 AS Decimal(18, 2)), CAST(25.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)))
INSERT [dbo].[TarjetaCredito] ([TarjetaID], [TitularID], [NumeroTarjeta], [FechaExpiracion], [CVV], [LimiteCredito], [PorcentajeInteresConfigurable], [PorcentajeConfigurableSaldoMinimo]) VALUES (4, 4, N'3344898078902312', CAST(N'2029-02-10' AS Date), N'506', CAST(1200.00 AS Decimal(18, 2)), CAST(17.00 AS Decimal(18, 2)), CAST(4.40 AS Decimal(18, 2)))
INSERT [dbo].[TarjetaCredito] ([TarjetaID], [TitularID], [NumeroTarjeta], [FechaExpiracion], [CVV], [LimiteCredito], [PorcentajeInteresConfigurable], [PorcentajeConfigurableSaldoMinimo]) VALUES (5, 4, N'3343778178902344', CAST(N'2030-02-08' AS Date), N'135', CAST(2500.00 AS Decimal(18, 2)), CAST(30.00 AS Decimal(18, 2)), CAST(8.20 AS Decimal(18, 2)))
INSERT [dbo].[TarjetaCredito] ([TarjetaID], [TitularID], [NumeroTarjeta], [FechaExpiracion], [CVV], [LimiteCredito], [PorcentajeInteresConfigurable], [PorcentajeConfigurableSaldoMinimo]) VALUES (6, 5, N'8181818111118888', CAST(N'2030-02-12' AS Date), N'310', CAST(1500.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), CAST(2.40 AS Decimal(18, 2)))
INSERT [dbo].[TarjetaCredito] ([TarjetaID], [TitularID], [NumeroTarjeta], [FechaExpiracion], [CVV], [LimiteCredito], [PorcentajeInteresConfigurable], [PorcentajeConfigurableSaldoMinimo]) VALUES (7, 6, N'2020899012341234', CAST(N'2030-02-12' AS Date), N'212', CAST(1500.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), CAST(7.80 AS Decimal(18, 2)))
INSERT [dbo].[TarjetaCredito] ([TarjetaID], [TitularID], [NumeroTarjeta], [FechaExpiracion], [CVV], [LimiteCredito], [PorcentajeInteresConfigurable], [PorcentajeConfigurableSaldoMinimo]) VALUES (8, 6, N'2335339022351234', CAST(N'2030-02-12' AS Date), N'321', CAST(3500.00 AS Decimal(18, 2)), CAST(12.50 AS Decimal(18, 2)), CAST(3.20 AS Decimal(18, 2)))
INSERT [dbo].[TarjetaCredito] ([TarjetaID], [TitularID], [NumeroTarjeta], [FechaExpiracion], [CVV], [LimiteCredito], [PorcentajeInteresConfigurable], [PorcentajeConfigurableSaldoMinimo]) VALUES (9, 2, N'8890907867463423', CAST(N'2030-02-13' AS Date), N'101', CAST(2500.00 AS Decimal(18, 2)), CAST(13.20 AS Decimal(18, 2)), CAST(4.30 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[TarjetaCredito] OFF
GO
SET IDENTITY_INSERT [dbo].[Titular] ON 

INSERT [dbo].[Titular] ([TitularID], [Nombres], [Apellidos], [Correo]) VALUES (1, N'Jose Antonio', N'Paredes', N'jose.antonio@correo.com')
INSERT [dbo].[Titular] ([TitularID], [Nombres], [Apellidos], [Correo]) VALUES (2, N'Maria Jose', N'Aparicio Gomez', N'majo.aparicio@correo.com')
INSERT [dbo].[Titular] ([TitularID], [Nombres], [Apellidos], [Correo]) VALUES (3, N'Carmen Maria', N'Lozano', N'carmen.lozano@correo.com')
INSERT [dbo].[Titular] ([TitularID], [Nombres], [Apellidos], [Correo]) VALUES (4, N'Carlos Jose', N'Coto Rivas', N'carlos.coto@correo.com')
INSERT [dbo].[Titular] ([TitularID], [Nombres], [Apellidos], [Correo]) VALUES (5, N'Nestor Alejandro', N'Caballero Ortiz', N'nestor.a.caballero@correo.com')
INSERT [dbo].[Titular] ([TitularID], [Nombres], [Apellidos], [Correo]) VALUES (6, N'Monica Patricia', N'Rojas Cuellar', N'monica.rojas@usuario.com')
INSERT [dbo].[Titular] ([TitularID], [Nombres], [Apellidos], [Correo]) VALUES (7, N'Julio Armando', N'Quezada Lopez', N'julio.a.quezada@usuario.com')
INSERT [dbo].[Titular] ([TitularID], [Nombres], [Apellidos], [Correo]) VALUES (8, N'Alejandra Evangelina', N'Duarte Molina', N'alejandra.duarte@correo.com')
SET IDENTITY_INSERT [dbo].[Titular] OFF
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllComprasPorMes]    Script Date: 2/13/2025 8:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Wallas Velasquez>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetAllComprasPorMes]
	@TarjetaID INT, @Mes INT
AS
BEGIN
	SELECT
	M.MovimientoID,
	M.TarjetaID,
	M.FechaMovimiento,
	M.Descripcion,
	M.Monto	
	FROM Movimientos M WHERE M.TarjetaID = @TarjetaID AND MONTH(M.FechaMovimiento) = @Mes AND YEAR(M.FechaMovimiento) = YEAR(GETDATE())
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllPagosPorMes]    Script Date: 2/13/2025 8:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Wallas Velasquez>
-- =============================================
Create PROCEDURE [dbo].[usp_GetAllPagosPorMes]
	@TarjetaID INT, @Mes INT
AS
BEGIN
	SELECT
	  P.PagoID,
      P.TarjetaID,	
      P.FechaPago,
      P.Monto,
      P.MetodoPago
	FROM Pagos P WHERE P.TarjetaID = @TarjetaID AND MONTH(P.FechaPago) = @Mes AND YEAR(P.FechaPago) = YEAR(GETDATE())
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetEstadosDeCuentaPorTarjeta]    Script Date: 2/13/2025 8:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Wallas Velasquez>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetEstadosDeCuentaPorTarjeta]
	@TarjetaID INT,  @Mes INT
AS
BEGIN
--DECLARE @TarjetaID INT = 1;
--DECLARE @Mes INT = 2;
DECLARE @SaldoActual DECIMAL(18,2) = 0.0;
DECLARE @MontoTotalMesActual DECIMAL(18,2) = 0.0;
DECLARE @MontoTotalMesAnterior DECIMAL(18,2) = 0.0;
DECLARE @InteresBonificable DECIMAL(18,2) = 0.0;
DECLARE @CuotaMinima DECIMAL(18,2) = 0.0;

SET @SaldoActual =  COALESCE((SELECT SUM(M.Monto) FROM Movimientos M WHERE M.TarjetaID = @TarjetaID), 0.0)
SET @MontoTotalMesActual =  COALESCE((SELECT SUM(M.Monto) FROM Movimientos M WHERE M.TarjetaID = @TarjetaID AND MONTH(M.FechaMovimiento) = @Mes AND YEAR(M.FechaMovimiento) = YEAR(GETDATE())), 0.0)
SET @MontoTotalMesAnterior =  COALESCE((SELECT SUM(M.Monto) FROM Movimientos M WHERE M.TarjetaID = @TarjetaID AND MONTH(M.FechaMovimiento) = (@Mes -1) AND YEAR(M.FechaMovimiento) = YEAR(GETDATE())) , 0.0)
SET @InteresBonificable = COALESCE(((SELECT (TC.PorcentajeInteresConfigurable/100) FROM TarjetaCredito TC WHERE TC.TarjetaID = @TarjetaID))*@SaldoActual, 0.0)
SET @CuotaMinima = COALESCE(((SELECT (TC.PorcentajeConfigurableSaldoMinimo/100) FROM TarjetaCredito TC WHERE TC.TarjetaID = @TarjetaID))*@SaldoActual, 0.0)

SELECT
	(T.Nombres + ' ' + T.Apellidos) AS Titular,
	TC.NumeroTarjeta,
	TC.LimiteCredito,	
    @SaldoActual AS SaldoActual,
	(TC.LimiteCredito - @SaldoActual) AS SaldoDisponible,
	@MontoTotalMesActual AS MontoTotalMesActual,
	@MontoTotalMesAnterior AS MontoTotalMesAnterior,
	TC.PorcentajeInteresConfigurable,
	TC.PorcentajeConfigurableSaldoMinimo,
    @InteresBonificable AS InteresBonificable,
	@CuotaMinima AS CuotaMinima,
	(@SaldoActual + @InteresBonificable) AS MontoTotalContadoInteres
FROM Titular T INNER JOIN TarjetaCredito TC ON T.TitularID = TC.TitularID
WHERE TC.TarjetaID = @TarjetaID
END


GO
/****** Object:  StoredProcedure [dbo].[usp_HistorialTransaccionesPorTarjeta]    Script Date: 2/13/2025 8:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Wallas Velasquez>
-- =============================================
CREATE PROCEDURE [dbo].[usp_HistorialTransaccionesPorTarjeta] 
	@TarjetaID INT
AS
BEGIN
		SELECT 
		P.PagoID AS TransaccionID,
		T.NumeroTarjeta,
		'Pago' AS TipoTransaccion,
		P.FechaPago AS Fecha,
		P.Monto AS Monto
	FROM Pagos P INNER JOIN TarjetaCredito T ON P.TarjetaID = T.TarjetaID   WHERE P.TarjetaID = @TarjetaID
UNION ALL
	SELECT 
		M.MovimientoID AS TransaccionID,
		T.NumeroTarjeta,
		'Compra' AS TipoTransaccion,
		M.FechaMovimiento AS Fecha,
		M.Monto
	FROM Movimientos M INNER JOIN TarjetaCredito T ON M.TarjetaID = T.TarjetaID WHERE M.TarjetaID = @TarjetaID
ORDER BY Fecha DESC;
END
GO
USE [master]
GO
ALTER DATABASE [CrediconsultigBD] SET  READ_WRITE 
GO
