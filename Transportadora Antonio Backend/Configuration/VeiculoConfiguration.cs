using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transportadora_Antonio_Backend.Enities;

namespace Transportadora_Antonio_Backend.Configuration
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Descricao).IsRequired();
            builder.Property(x => x.Placa).IsRequired();
            builder.Property(x => x.CriadoEm).IsRequired();
            builder.Property(x => x.ModificadoEm);

        }
    }
}
