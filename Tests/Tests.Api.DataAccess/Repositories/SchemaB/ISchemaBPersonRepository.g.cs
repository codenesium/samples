using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public partial interface ISchemaBPersonRepository
	{
		Task<SchemaBPerson> Create(SchemaBPerson item);

		Task Update(SchemaBPerson item);

		Task Delete(int id);

		Task<SchemaBPerson> Get(int id);

		Task<List<SchemaBPerson>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3eb14b09e252ee1dc628edf135e108f3</Hash>
</Codenesium>*/