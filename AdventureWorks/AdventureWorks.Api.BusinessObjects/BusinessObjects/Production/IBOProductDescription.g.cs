using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductDescription
	{
		Task<CreateResponse<int>> Create(
			ProductDescriptionModel model);

		Task<ActionResponse> Update(int productDescriptionID,
		                            ProductDescriptionModel model);

		Task<ActionResponse> Delete(int productDescriptionID);

		POCOProductDescription Get(int productDescriptionID);

		List<POCOProductDescription> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>dfa98e241a5fe049ec4dc9d34883d6ba</Hash>
</Codenesium>*/