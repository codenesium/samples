using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOCulture
	{
		Task<CreateResponse<ApiCultureResponseModel>> Create(
			ApiCultureRequestModel model);

		Task<ActionResponse> Update(string cultureID,
		                            ApiCultureRequestModel model);

		Task<ActionResponse> Delete(string cultureID);

		Task<ApiCultureResponseModel> Get(string cultureID);

		Task<List<ApiCultureResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiCultureResponseModel> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>eaa76001893c0b3a677d60934d16f40f</Hash>
</Codenesium>*/