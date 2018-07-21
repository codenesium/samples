using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
        public interface ISchemaAPersonRepository
        {
                Task<SchemaAPerson> Create(SchemaAPerson item);

                Task Update(SchemaAPerson item);

                Task Delete(int id);

                Task<SchemaAPerson> Get(int id);

                Task<List<SchemaAPerson>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>69e9d65e4a53d7bd1579fc4381896bf4</Hash>
</Codenesium>*/