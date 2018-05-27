using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOUnitMeasure
	{
		Task<CreateResponse<ApiUnitMeasureResponseModel>> Create(
			ApiUnitMeasureRequestModel model);

		Task<ActionResponse> Update(string unitMeasureCode,
		                            ApiUnitMeasureRequestModel model);

		Task<ActionResponse> Delete(string unitMeasureCode);

		Task<ApiUnitMeasureResponseModel> Get(string unitMeasureCode);

		Task<List<ApiUnitMeasureResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiUnitMeasureResponseModel> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>4b4ed164bb31a14f8e012a7f4bfa39eb</Hash>
</Codenesium>*/