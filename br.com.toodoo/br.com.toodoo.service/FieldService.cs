using br.com.toodoo.core.FieldAggregate;
using br.com.toodoo.core.Interfaces.Infrastructure;
using br.com.toodoo.core.Interfaces.Service;
using br.com.toodoo.sharedkernel;

namespace br.com.toodoo.service
{
    public class FieldService : BaseService<Field>, IFieldService
    {
        private readonly IFieldRepository _fieldRepository;

        public FieldService(IFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
        }

        public async Task<Field> Add(Field field)
        {
            return await _fieldRepository.AddAsync(field);
        }

        public async Task Delete(long fieldId)
        {
            await _fieldRepository.DeleteAsync(fieldId);
        }

        public async Task<Field?> GetByIdAsync(long id)
        {
            return await _fieldRepository.GetByIdAsync(id);
        }

        public async Task<List<Field>> ListAsync()
        {
            return await _fieldRepository.ListAsync();
        }

        public async Task<Field> UpdateAsync(Field field)
        {
            return await _fieldRepository.UpdateAsync(field);
        }
    }
}