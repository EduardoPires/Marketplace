# Feedback - Avaliação Geral

## Front End

### Navegação
  * Pontos positivos:
    - Projeto MVC está implementado com controllers e views básicas para CRUD de entidades.

### Design
  - Interface adequada, mas gerada e mantida com o foco apenas técnico, sem aprimoramento visual adicional.

### Funcionalidade
  * Pontos positivos:
    - CRUD de Produto, Categoria e Vendedor presente tanto na camada API quanto MVC.
    - Identity implementado em ambas as camadas, com autenticação e controle de sessão operacionais.
    - Modelagem de entidades é aderente ao domínio proposto.

  * Pontos negativos:
    - Produtos não são vinculados ao usuário logado (vendedor), falha grave de segurança e de funcionalidade.
    - Qualquer vendedor pode editar ou excluir produtos de outro sem qualquer restrição.
    - Não há associação entre usuário do Identity e vendedor no momento da criação do usuário.
    - Não há execução de seed de dados nem migrations automáticas na inicialização da aplicação.
    - Implementação da entidade `Login` dentro do `Domain` é redundante e desnecessária, dado o uso do ASP.NET Identity.
  
## Back End

### Arquitetura
  * Pontos positivos:
    - Arquitetura extremamente modular com separação de responsabilidades bem definida (Application, Domain, Infra, UI, API).

  * Pontos negativos:
    - Complexidade excessiva para um projeto de CRUD simples.
    - Múltiplas camadas implementam apenas pass-through de chamadas, sem adição de lógica de negócio.
    - A abordagem "DDD" aplicada está além do necessário e compromete a legibilidade e a manutenção de um projeto com escopo reduzido.

### Funcionalidade
  * Pontos positivos:
    - Funcionalidades básicas operacionais para CRUD.

  * Pontos negativos:
    - Ausência de vinculação entre vendedor e usuário.
    - Falta de restrições de segurança para propriedade de produtos.
    - Cadastro do vendedor desacoplado do fluxo de registro de usuário.

### Modelagem
  * Pontos positivos:
    - Modelagem clara, com separação de entidades, serviços e interfaces bem estruturada.

  * Pontos negativos:
    - Entidade `Login` dentro do `Domain` é redundante e fora de contexto com o uso de ASP.NET Identity.

## Projeto

### Organização
  * Pontos positivos:
    - Estrutura de pastas clara, múltiplos projetos com responsabilidades específicas.
    - Solution organizada e padronizada.

  * Pontos negativos:
    - Ausência de seed/migrations automáticas compromete a experiência de setup.
    - Documentação não menciona ou justifica a complexidade da estrutura adotada.

### Documentação
  * Pontos positivos:
    - Arquivos `README.md` e `FEEDBACK.md` presentes com informações úteis.

### Instalação
  * Pontos positivos:
    - Estrutura modular e organizável para futuras ampliações.

  * Pontos negativos:
    - Falta de seed e migrations automáticas torna a aplicação inativa por padrão.

---

# 📊 Matriz de Avaliação de Projetos

| **Critério**                   | **Peso** | **Nota** | **Resultado Ponderado**                  |
|-------------------------------|----------|----------|------------------------------------------|
| **Funcionalidade**            | 30%      | 8        | 2,4                                      |
| **Qualidade do Código**       | 20%      | 8        | 1,6                                      |
| **Eficiência e Desempenho**   | 20%      | 7        | 1,4                                      |
| **Inovação e Diferenciais**   | 10%      | 8        | 0,8                                      |
| **Documentação e Organização**| 10%      | 10       | 1,0                                      |
| **Resolução de Feedbacks**    | 10%      | 8        | 0,8                                      |
| **Total**                     | 100%     | -        | **8,0**                                  |

## 🎯 **Nota Final: 8 / 10**
