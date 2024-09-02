using API.Domain.DTOs;
using API.Domain.Model;
using AutoMapper;

namespace API.Application.Mapping {
    public class DomainToDTOMapping : Profile {

        public DomainToDTOMapping() {
            CreateMap<Employee, EmployeeDTO>().ForMember(x => x.NameEmployee, x => x.MapFrom(p => p.name));

        }
    }
}
