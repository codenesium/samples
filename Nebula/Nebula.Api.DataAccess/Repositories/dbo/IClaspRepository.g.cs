using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IClaspRepository
	{
		Task<POCOClasp> Create(ApiClaspModel model);

		Task Update(int id,
		            ApiClaspModel model);

		Task Delete(int id);

		Task<POCOClasp> Get(int id);

		Task<List<POCOClasp>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>665eb2292df8691fb1c8a2592cc8566a</Hash>
</Codenesium>*/