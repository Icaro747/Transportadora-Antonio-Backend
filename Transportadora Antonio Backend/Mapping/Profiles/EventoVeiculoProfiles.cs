using AutoMapper;
using Transportadora_Antonio_Backend.DTOs.EventoVeiculo;
using Transportadora_Antonio_Backend.Enities;

namespace Transportadora_Antonio_Backend.Mapping.Profiles
{
    public class EventoVeiculoProfiles : Profile
    {
        public EventoVeiculoProfiles()
        {
            CreateMap<CriarEventoVeiculoDto, EventoVeiculo>();
            CreateMap<AtulizarEventoVeiculoDto, EventoVeiculo>();
            CreateMap<EventoVeiculo, TodosEventoVeiculoDto>()
                .ForMember(dest => dest.VeiculoPlaca, opt => opt.MapFrom(src => src.Veiculo.Placa));
        }
    }
}
