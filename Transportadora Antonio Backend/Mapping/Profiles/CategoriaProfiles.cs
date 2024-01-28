using AutoMapper;
using Transportadora_Antonio_Backend.DTOs.Categoria;
using Transportadora_Antonio_Backend.Enities;

namespace Transportadora_Antonio_Backend.Mapping.Profiles
{
    public class CategoriaProfiles : Profile
    {
        public CategoriaProfiles() {
            CreateMap<CriarCategoriaDto, Categoria>();
            CreateMap<AtulizarCategoriaDto, Categoria>();
            CreateMap<Categoria, TodasCategoriaDto>();
        }
    }
}
