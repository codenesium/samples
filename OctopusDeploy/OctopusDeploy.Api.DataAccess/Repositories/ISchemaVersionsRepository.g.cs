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
    <Hash>ff6143aa2a04d048ef61b7ff3d900112</Hash>
</Codenesium>*/