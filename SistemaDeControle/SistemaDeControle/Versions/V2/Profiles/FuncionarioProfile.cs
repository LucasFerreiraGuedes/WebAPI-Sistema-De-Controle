using AutoMapper;
using SistemaDeControle.Model;
using SistemaDeControle.Versions.V2.Profiles.DTO;

namespace SistemaDeControle.Versions.V2.Profiles
{
	public class FuncionarioProfile : Profile
	{
        public FuncionarioProfile()
        {
            CreateMap<FuncionarioDTO,Funcionario>().ReverseMap();
        }
    }
}
