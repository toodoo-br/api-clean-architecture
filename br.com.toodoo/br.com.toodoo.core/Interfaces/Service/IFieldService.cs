using br.com.toodoo.core.FieldAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.toodoo.core.Interfaces.Service
{
    public interface IFieldService
    {
        Task<Field> Add(Field field);
        Task Delete(long formId);
        Task<Field?> GetByIdAsync(long id);
        Task<List<Field>> ListAsync();
        Task<Field> UpdateAsync(Field field);
    }
}
