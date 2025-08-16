CREATE TABLE Motoristas (
IdMotorista INT PRIMARY KEY,
Nome VARCHAR(100),
CNH VARCHAR(20)
);

CREATE TABLE Viagens (
IdViagem INT PRIMARY KEY,
IdMotorista INT,
Origem VARCHAR(100),
Destino VARCHAR(100),
Data DATE,
DistanciaKm DECIMAL(10,2),
FOREIGN KEY (IdMotorista) REFERENCES Motoristas(IdMotorista)
);

INSERT INTO Motoristas (IdMotorista, Nome, CNH) VALUES
(1, 'Guilherme ', '123456789'),
(2, 'Thiago', '987654321'),
(3, 'Cristiano ', '456123789'),
(4, 'Júlia', '789321654');

INSERT INTO Viagens (IdViagem, IdMotorista, Origem, Destino, Data, DistanciaKm) VALUES
(1, 1, 'Caxias do Sul ', 'Vacaria', '2025-08-01', 430.0),
(2, 1, 'Rio de Janeiro', 'Belo Horizonte', '2025-08-02', 440.0),
(3, 2, 'Curitiba', 'São Paulo', '2025-08-03', 408.5),
(4, 3, 'Salvador', 'Fortaleza', '2025-08-04', 1020.0),
(5, 3, 'Fortaleza', 'Recife', '2025-08-05', 800.0);



SELECT V.*
FROM Viagens V
JOIN Motoristas M ON V.IdMotorista = M.IdMotorista
WHERE M.Nome = 'Guilherme';
percorrida por cada motorista
SELECT M.Nome, SUM(V.DistanciaKm) AS DistanciaTotal
FROM Motoristas M
JOIN Viagens V ON M.IdMotorista = V.IdMotorista
GROUP BY M.IdMotorista, M.Nome;

SELECT *
FROM Viagens
WHERE DistanciaKm > 500;


SELECT M.*
FROM Motoristas M
LEFT JOIN Viagens V ON M.IdMotorista = V.IdMotorista
WHERE V.IdViagem IS NULL;
