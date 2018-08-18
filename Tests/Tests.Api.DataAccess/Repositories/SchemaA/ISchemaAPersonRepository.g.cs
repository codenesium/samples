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
    <Hash>cd8f3442ef62a494db17724a22d9cebe</Hash>
</Codenesium>*/