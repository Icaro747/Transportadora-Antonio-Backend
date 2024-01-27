using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transportadora_Antonio_Backend.Enities;

namespace Transportadora_Antonio_Backend.Configuration
{
    public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Apelido).IsRequired(false);
            builder.Property(x => x.CriadoEm).IsRequired();
            builder.Property(x => x.ModificadoEm);
        }
    }
}
