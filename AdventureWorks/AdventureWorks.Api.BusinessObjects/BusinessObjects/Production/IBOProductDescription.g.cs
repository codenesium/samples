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
		Task<CreateResponse<ApiProductDescriptionResponseModel>> Create(
			ApiProductDescriptionRequestModel model);

		Task<ActionResponse> Update(int productDescriptionID,
		                            ApiProductDescriptionRequestModel model);

		Task<ActionResponse> Delete(int productDescriptionID);

		Task<ApiProductDescriptionResponseModel> Get(int productDescriptionID);

		Task<List<ApiProductDescriptionResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0b70fca0cbf75514e61b68c58ab9556d</Hash>
</Codenesium>*/