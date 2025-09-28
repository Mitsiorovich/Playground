namespace TaskBoard.Application.Services.Interfaces
{
    public interface ICrudService<TDto> where TDto : class
    {
        Task<TDto> CreateAsync(TDto dto);
        Task<List<TDto>> GetAllAsync();
        Task<TDto?> GetByIdAsync(Guid id);
        Task<TDto> UpdateAsync(TDto dto);
        Task DeleteByIdAsync(Guid id);
        Guid GetId(TDto dto);
    }
}
