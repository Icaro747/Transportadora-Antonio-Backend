using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transportadora_Antonio_Backend.Enities;

namespace Transportadora_Antonio_Backend.Configuration
{
    public class EventoVeiculoConfiguration : IEntityTypeConfiguration<EventoVeiculo>
    {
        public void Configure(EntityTypeBuilder<EventoVeiculo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Data).IsRequired(false);
            builder.Property(x => x.Descricao).IsRequired();
            builder.Property(x => x.Valor).HasColumnType("decimal(18, 2)");
            builder.Property(x => x.IsDespesa).IsRequired();
            builder.Property(x => x.CriadoEm).IsRequired();
            builder.Property(x => x.ModificadoEm);

            builder.HasOne(x => x.Veiculo).WithMany(x => x.EventosVeiculo).HasForeignKey(x => x.VeiculoId);
        }
    }
}
