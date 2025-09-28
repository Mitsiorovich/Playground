using TaskBoard.Application.DTOs;
using TaskBoard.Application.Services.Interfaces;

namespace TaskBoard.API.Controllers
{
    public class ProjectsController : ApiBasicCrudController<ProjectDto>
    {
        public ProjectsController(IProjectService service) : base(service)
        {
        }
    }
}
