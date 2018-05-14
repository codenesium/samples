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
		Task<CreateResponse<POCOProductDescription>> Create(
			ApiProductDescriptionModel model);

		Task<ActionResponse> Update(int productDescriptionID,
		                            ApiProductDescriptionModel model);

		Task<ActionResponse> Delete(int productDescriptionID);

		POCOProductDescription Get(int productDescriptionID);

		List<POCOProductDescription> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>090f94bd035e22ecdf2b1f491edd8523</Hash>
</Codenesium>*/