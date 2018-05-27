using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSalesReason
	{
		Task<CreateResponse<ApiSalesReasonResponseModel>> Create(
			ApiSalesReasonRequestModel model);

		Task<ActionResponse> Update(int salesReasonID,
		                            ApiSalesReasonRequestModel model);

		Task<ActionResponse> Delete(int salesReasonID);

		Task<ApiSalesReasonResponseModel> Get(int salesReasonID);

		Task<List<ApiSalesReasonResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c1f4109c3db4ab7ad4d42b6246c31aa1</Hash>
</Codenesium>*/