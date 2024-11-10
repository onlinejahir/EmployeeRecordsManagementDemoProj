using _07_EmployeeRecordsManagementProj.EntityModels;
using _07_EmployeeRecordsManagementProj.ViewModels.DepartmentVM;
using _07_EmployeeRecordsManagementProj.ViewModels.EmployeeVM;
using AutoMapper;

namespace _07_EmployeeRecordsManagementProj.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeCreateViewModel, Employee>().ReverseMap();
            CreateMap<DepartmentCreateViewModel, Department>().ReverseMap();
        }
    }
}
