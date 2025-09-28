using AutoMapper;
using TaskBoard.Application.DTOs;
using TaskBoard.Application.Services.Interfaces;
using TaskBoard.Domain;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Services
{
    public class ProjectService : IProjectService
    {
        private IUnitOfWork _dataWorks;
        private IMapper _mapper;
        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._dataWorks = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<ProjectDto> CreateAsync(ProjectDto projectDto)
        {
            var projectEntity = _mapper.Map<Project>(projectDto);

            await this._dataWorks.Projects.AddAsync(projectEntity);

            await _dataWorks.SaveChangesAsync();

            return _mapper.Map<ProjectDto>(projectEntity);
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var projectEntity = await _dataWorks.Projects.GetByIdAsync(id);

            if (projectEntity == null)
                throw new KeyNotFoundException("Project not found");

            this._dataWorks.Projects.Delete(projectEntity);

            await _dataWorks.SaveChangesAsync();
        }

        public async Task<List<ProjectDto>> GetAllAsync()
        {
            var projectEntities = await _dataWorks.Projects.GetAllAsync();

            return _mapper.Map<List<ProjectDto>>(projectEntities);
        }

        public async Task<ProjectDto?> GetByIdAsync(Guid id)
        {
            var projectEntity = await _dataWorks.Projects.GetByIdAsync(id);

            if (projectEntity == null)
                throw new KeyNotFoundException("Project not found");

            return _mapper.Map<ProjectDto>(projectEntity);
        }

        public async Task<ProjectDto> UpdateAsync(ProjectDto dto)
        {
            var projectEntity = await _dataWorks.Projects.GetByIdAsync(dto.Id);

            if (projectEntity == null)
                throw new KeyNotFoundException("Project not found");

            _mapper.Map(dto, projectEntity);

            _dataWorks.Projects.Update(projectEntity);

            await _dataWorks.SaveChangesAsync();

            return _mapper.Map<ProjectDto>(projectEntity);
        }

        public Guid GetId(ProjectDto dto) => dto.Id;
    }
}
