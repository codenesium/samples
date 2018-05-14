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

		POCOBusinessEntity Get(int businessEntityID);

		List<POCOBusinessEntity> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>050e1697a41d831f7342a99a6c430913</Hash>
</Codenesium>*/