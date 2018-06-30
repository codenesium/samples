using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>6f281d88d040e1493f77440526f40f90</Hash>
</Codenesium>*/