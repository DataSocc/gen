-- Remove a tabela temporária se ela já existir
IF OBJECT_ID('tempdb..#temp') IS NOT NULL
    DROP TABLE #temp;

-- Cria a tabela temporária e armazena as menores datas de pagamento para co_tipo 1
SELECT
    co_contrato,
    MIN(dt_pagamento) AS min_dt_pagamento
INTO #temp
FROM
    sua_tabela
WHERE
    co_tipo = 1
GROUP BY
    co_contrato;

-- Realiza a soma dos valores para co_tipo 2, considerando a condição de data
SELECT
    t2.co_contrato,
    SUM(t2.vr_valor) AS soma_vr_valor
FROM
    sua_tabela t2
INNER JOIN #temp t ON t2.co_contrato = t.co_contrato
WHERE
    t2.co_tipo = 2
    AND t2.dt_pagamento = DATEADD(day, 59, t.min_dt_pagamento)
GROUP BY
    t2.co_contrato;

-- Limpa a tabela temporária ao final (opcional, pois será automaticamente descartada ao fim da sessão)
DROP TABLE IF EXISTS #temp;
