using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface ISchemaVersionsRepository
	{
		Task<SchemaVersions> Create(SchemaVersions item);

		Task Update(SchemaVersions item);

		Task Delete(int id);

		Task<SchemaVersions> Get(int id);

		Task<List<SchemaVersions>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a2d78b2f4f106daa7e491783539f3342</Hash>
</Codenesium>*/