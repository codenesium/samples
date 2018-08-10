using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public partial interface ISchemaAPersonRepository
	{
		Task<SchemaAPerson> Create(SchemaAPerson item);

		Task Update(SchemaAPerson item);

		Task Delete(int id);

		Task<SchemaAPerson> Get(int id);

		Task<List<SchemaAPerson>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3290c7fe53e875cad278544172607617</Hash>
</Codenesium>*/