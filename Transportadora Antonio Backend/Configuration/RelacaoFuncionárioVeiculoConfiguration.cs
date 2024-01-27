using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transportadora_Antonio_Backend.Enities;

namespace Transportadora_Antonio_Backend.Configuration
{
    public class RelacaoFuncionárioVeiculoConfiguration : IEntityTypeConfiguration<RelacaoFuncionárioVeiculo>
    {
        public void Configure(EntityTypeBuilder<RelacaoFuncionárioVeiculo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.CriadoEm).IsRequired();
            builder.Property(x => x.ModificadoEm);

            builder.HasOne(fv => fv.Funcionario)
                   .WithMany(f => f.RelacaoFuncionárioVeiculo)
                   .HasForeignKey(fv => fv.FuncionarioId)
                   .OnDelete(DeleteBehavior.Cascade); // Ajuste o comportamento de exclusão conforme necessário

            builder.HasOne(fv => fv.Veiculo)
                   .WithMany(v => v.RelacaoFuncionárioVeiculo)
                   .HasForeignKey(fv => fv.VeiculoId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
