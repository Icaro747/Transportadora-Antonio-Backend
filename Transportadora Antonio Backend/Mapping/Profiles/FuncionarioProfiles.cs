using AutoMapper;
using Transportadora_Antonio_Backend.DTOs.Funcionario;
using Transportadora_Antonio_Backend.Enities;

namespace Transportadora_Antonio_Backend.Mapping.Profiles
{
    public class FuncionarioProfiles : Profile
    {
        public FuncionarioProfiles() {
            CreateMap<CriarFuncionarioDto, Funcionario>();
            CreateMap<AtulizarFuncionarioDto, Funcionario>();
            CreateMap<Funcionario, TodosFuncionarioDto>();
        }
    }
}
