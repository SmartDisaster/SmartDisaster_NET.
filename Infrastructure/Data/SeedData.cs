using Microsoft.EntityFrameworkCore;
using SmartDisaster.Domain.Entities;
using SmartDisaster.Domain.Enums;

namespace SmartDisaster.Infrastructure.Data;

public static class SeedData
{
    public static async Task InitializeAsync(AppDbContext context)
    {
        if (await context.Abrigos.AnyAsync()) return;

        var abrigos = new List<Abrigo>
        {
            new()
            {
                Nome = "Abrigo Central São Paulo",
                Cidade = "São Paulo",
                Estado = "SP",
                Endereco = "Av. Paulista, 1500 - Bela Vista",
                CapacidadeMaxima = 500,
                Status = StatusAbrigo.Ativo
            },
            new()
            {
                Nome = "Centro de Acolhimento Rio Sul",
                Cidade = "Rio de Janeiro",
                Estado = "RJ",
                Endereco = "Rua das Laranjeiras, 300 - Laranjeiras",
                CapacidadeMaxima = 300,
                Status = StatusAbrigo.Lotado
            },
            new()
            {
                Nome = "Abrigo Emergencial Curitiba",
                Cidade = "Curitiba",
                Estado = "PR",
                Endereco = "Rua XV de Novembro, 800 - Centro",
                CapacidadeMaxima = 250,
                Status = StatusAbrigo.Ativo
            }
        };

        await context.Abrigos.AddRangeAsync(abrigos);
        await context.SaveChangesAsync();

        var voluntarios = new List<Voluntario>
        {
            new()
            {
                Nome = "Ana Lima",
                Email = "ana.lima@smartdisaster.com",
                Telefone = "(11) 98765-4321"
            },
            new()
            {
                Nome = "Carlos Mendes",
                Email = "carlos.mendes@smartdisaster.com",
                Telefone = "(21) 97654-3210"
            },
            new()
            {
                Nome = "Fernanda Costa",
                Email = "fernanda.costa@smartdisaster.com",
                Telefone = "(41) 96543-2109"
            }
        };

        await context.Voluntarios.AddRangeAsync(voluntarios);
        await context.SaveChangesAsync();

        var necessidades = new List<Necessidade>
        {
            new()
            {
                Tipo = TipoNecessidade.Alimento,
                QuantidadeNecessaria = 1000,
                Prioridade = PrioridadeNecessidade.Critica,
                Status = StatusNecessidade.Pendente,
                AbrigoId = abrigos[0].Id
            },
            new()
            {
                Tipo = TipoNecessidade.Medicamento,
                QuantidadeNecessaria = 200,
                Prioridade = PrioridadeNecessidade.Alta,
                Status = StatusNecessidade.EmAndamento,
                AbrigoId = abrigos[0].Id
            },
            new()
            {
                Tipo = TipoNecessidade.Agua,
                QuantidadeNecessaria = 5000,
                Prioridade = PrioridadeNecessidade.Critica,
                Status = StatusNecessidade.Pendente,
                AbrigoId = abrigos[1].Id
            },
            new()
            {
                Tipo = TipoNecessidade.Roupa,
                QuantidadeNecessaria = 300,
                Prioridade = PrioridadeNecessidade.Media,
                Status = StatusNecessidade.Pendente,
                AbrigoId = abrigos[2].Id
            },
            new()
            {
                Tipo = TipoNecessidade.Higiene,
                QuantidadeNecessaria = 150,
                Prioridade = PrioridadeNecessidade.Alta,
                Status = StatusNecessidade.EmAndamento,
                AbrigoId = abrigos[2].Id
            }
        };

        await context.Necessidades.AddRangeAsync(necessidades);
        await context.SaveChangesAsync();

        var doacoes = new List<Doacao>
        {
            new()
            {
                Item = "Cesta Básica",
                Quantidade = 100,
                DataRegistro = DateTime.UtcNow.AddDays(-3),
                Status = StatusDoacao.Entregue,
                AbrigoId = abrigos[0].Id,
                VoluntarioId = voluntarios[0].Id
            },
            new()
            {
                Item = "Água Mineral (garrafas 500ml)",
                Quantidade = 500,
                DataRegistro = DateTime.UtcNow.AddDays(-2),
                Status = StatusDoacao.EmTransito,
                AbrigoId = abrigos[1].Id,
                VoluntarioId = voluntarios[1].Id
            },
            new()
            {
                Item = "Medicamentos Básicos",
                Quantidade = 50,
                DataRegistro = DateTime.UtcNow.AddDays(-1),
                Status = StatusDoacao.Registrada,
                AbrigoId = abrigos[0].Id,
                VoluntarioId = voluntarios[2].Id
            },
            new()
            {
                Item = "Roupas Infantis",
                Quantidade = 80,
                DataRegistro = DateTime.UtcNow.AddDays(-4),
                Status = StatusDoacao.Entregue,
                AbrigoId = abrigos[2].Id,
                VoluntarioId = voluntarios[0].Id
            },
            new()
            {
                Item = "Kit Higiene Pessoal",
                Quantidade = 60,
                DataRegistro = DateTime.UtcNow,
                Status = StatusDoacao.Registrada,
                AbrigoId = abrigos[2].Id,
                VoluntarioId = voluntarios[1].Id
            }
        };

        await context.Doacoes.AddRangeAsync(doacoes);
        await context.SaveChangesAsync();
    }
}
