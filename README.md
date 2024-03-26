DECLARE @ValorString VARCHAR(20)
SET @ValorString = 'R$ 5.666,87'

-- Remover o símbolo 'R$ ' e substituir ',' por '.'
SET @ValorString = REPLACE(REPLACE(@ValorString, 'R$ ', ''), ',', '.')

-- Converter string para money
DECLARE @ValorMoney MONEY
SET @ValorMoney = CONVERT(MONEY, @ValorString)

SELECT @ValorMoney AS ValorConvertido
