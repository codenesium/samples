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

                Task<List<SchemaVersions>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>1a55701d08587c38cce6fa55ad46c172</Hash>
</Codenesium>*/