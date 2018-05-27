using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOContactType
	{
		Task<CreateResponse<ApiContactTypeResponseModel>> Create(
			ApiContactTypeRequestModel model);

		Task<ActionResponse> Update(int contactTypeID,
		                            ApiContactTypeRequestModel model);

		Task<ActionResponse> Delete(int contactTypeID);

		Task<ApiContactTypeResponseModel> Get(int contactTypeID);

		Task<List<ApiContactTypeResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiContactTypeResponseModel> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>8b4c122561c5b42e77752a15fe95fd5a</Hash>
</Codenesium>*/