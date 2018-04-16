Create Database AYD1_P3_DB;

use AYD1_P3_DB;

CREATE TABLE usuario  (
    CodUsuario int,
    NombreCompleto varchar(255),
    NombreUsuario varchar(100),
    CorreoElectronico varchar(255),
    Contraseña varchar(100) 
	PRIMARY KEY (CodUsuario)
);

use AYD1_P3_DB;
CREATE TABLE cuenta (
    CodCuenta int,
    MontoTotal int,
    UsuarioCta int,
	PRIMARY KEY (CodCuenta),
    FOREIGN KEY (UsuarioCta) REFERENCES usuario(CodUsuario)
);

use AYD1_P3_DB;
CREATE TABLE transferencia (
    CodTransferencia int,
    CtaDestino int,
    CtaFuente int,
	Monto int,
	PRIMARY KEY (CodTransferencia),
    FOREIGN KEY (CtaDestino) REFERENCES cuenta(CodCuenta),
    FOREIGN KEY (CtaFuente) REFERENCES cuenta(CodCuenta)
);

use AYD1_P3_DB;
CREATE TABLE credito (
    CodCredito int,
    CtaCredito int,
    Monto int,
	PRIMARY KEY (CodCredito),
    FOREIGN KEY (CtaCredito) REFERENCES cuenta(CodCuenta)
);

use AYD1_P3_DB;
CREATE TABLE debito (
    CodDebito int,
    CtaDebito int,
    Monto int,
	PRIMARY KEY (CodDebito),
    FOREIGN KEY (CtaDebito) REFERENCES cuenta(CodCuenta)
);

Select * from usuario;