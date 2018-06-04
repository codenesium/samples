using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface ISalesReasonService
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
    <Hash>06d4137cf259c5caaf98bc910c79c044</Hash>
</Codenesium>*/