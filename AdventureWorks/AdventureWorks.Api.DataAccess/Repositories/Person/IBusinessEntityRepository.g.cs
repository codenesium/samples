using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBusinessEntityRepository
	{
		Task<POCOBusinessEntity> Create(ApiBusinessEntityModel model);

		Task Update(int businessEntityID,
		            ApiBusinessEntityModel model);

		Task Delete(int businessEntityID);

		Task<POCOBusinessEntity> Get(int businessEntityID);

		Task<List<POCOBusinessEntity>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b7c8c41ca5793ce4c26b1237a1fcd23e</Hash>
</Codenesium>*/