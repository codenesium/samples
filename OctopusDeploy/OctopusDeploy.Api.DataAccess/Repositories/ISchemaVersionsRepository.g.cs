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
    <Hash>dde9984b48438b41ebe07f1bcd81c214</Hash>
</Codenesium>*/