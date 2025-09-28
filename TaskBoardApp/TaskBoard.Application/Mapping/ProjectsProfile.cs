using TaskBoard.Application.DTOs;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Mapping
{
    public class ProjectsProfile : BaseProfile
    {
        public ProjectsProfile()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();
        }
    }
}
