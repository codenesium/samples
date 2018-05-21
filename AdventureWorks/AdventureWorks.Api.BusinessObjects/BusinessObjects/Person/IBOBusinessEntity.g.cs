using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOBusinessEntity
	{
		Task<CreateResponse<POCOBusinessEntity>> Create(
			ApiBusinessEntityModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiBusinessEntityModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<POCOBusinessEntity> Get(int businessEntityID);

		Task<List<POCOBusinessEntity>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0f4eff5e8a2a84dff4a303a39efb317d</Hash>
</Codenesium>*/