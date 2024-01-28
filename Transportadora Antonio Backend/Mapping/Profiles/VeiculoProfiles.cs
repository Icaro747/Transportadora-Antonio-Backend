using AutoMapper;
using Transportadora_Antonio_Backend.DTOs.Veiculo;
using Transportadora_Antonio_Backend.Enities;

namespace Transportadora_Antonio_Backend.Mapping.Profiles
{
    public class VeiculoProfiles : Profile
    {
        public VeiculoProfiles()
        {
            CreateMap<CriarVeiculoDto, Veiculo>();
            CreateMap<AtulizarVeiculoDto, Veiculo>();
            CreateMap<Veiculo, TodosVeiculoDto>()
                .ForMember(dest => dest.Funcionarios, opt => opt.MapFrom(src => src.RelacaoFuncionárioVeiculo.Select(x => x.FuncionarioId).ToList()));
        }
    }
}
