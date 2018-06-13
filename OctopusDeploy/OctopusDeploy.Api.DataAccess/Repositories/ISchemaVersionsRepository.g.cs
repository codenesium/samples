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

                Task<List<SchemaVersions>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>4b7a5650b3f1b6eeef459bc5aef45f27</Hash>
</Codenesium>*/