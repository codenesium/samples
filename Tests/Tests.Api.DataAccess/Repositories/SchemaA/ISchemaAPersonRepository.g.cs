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
    <Hash>feb38d5de498a68b7777b1d71a4edb6f</Hash>
</Codenesium>*/