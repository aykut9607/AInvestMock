using Microsoft.EntityFrameworkCore;
using FinanceProfile.Api.Domain.Entities;

namespace FinanceProfile.Api.Infrastructure.EntityFramework;

public class FinanceDbContext : DbContext
{
    public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options) { }

    public DbSet<FinancialProfile> FinancialProfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FinancialProfile>(entity =>
        {
            entity.ToTable("financial_profiles");

            entity.Property(p => p.Id).HasColumnName("id");
            entity.Property(p => p.UserId).HasColumnName("user_id");
            entity.Property(p => p.MonthlyIncome).HasColumnName("monthly_income");
            entity.Property(p => p.MonthlyExpenses).HasColumnName("monthly_expenses");
            entity.Property(p => p.MonthlyDebtPayment).HasColumnName("monthly_debt_payment");
            entity.Property(p => p.TotalDebt).HasColumnName("total_debt");
            entity.Property(p => p.CashReserve).HasColumnName("cash_reserve");
            entity.Property(p => p.InvestmentAmount).HasColumnName("investment_amount");
            entity.Property(p => p.RiskPreference).HasColumnName("risk_preference");
            entity.Property(p => p.CreatedAt).HasColumnName("created_at");
            entity.Property(p => p.UpdatedAt).HasColumnName("updated_at");
        });
    }
}