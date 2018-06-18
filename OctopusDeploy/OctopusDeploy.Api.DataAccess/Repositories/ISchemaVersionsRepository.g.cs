using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface ISchemaVersionsRepository
        {
                Task<SchemaVersions> Create(SchemaVersions item);

                Task Update(SchemaVersions item);

                Task Delete(int id);

                Task<SchemaVersions> Get(int id);

                Task<List<SchemaVersions>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>788ebe4d671d41fc26a2b17c895d0e12</Hash>
</Codenesium>*/