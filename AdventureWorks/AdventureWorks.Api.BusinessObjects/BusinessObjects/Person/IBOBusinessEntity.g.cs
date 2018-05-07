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
		Task<CreateResponse<int>> Create(
			BusinessEntityModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            BusinessEntityModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		POCOBusinessEntity Get(int businessEntityID);

		List<POCOBusinessEntity> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4862bef4e061b2cfe4c887c66409ffad</Hash>
</Codenesium>*/