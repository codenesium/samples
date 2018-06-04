using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IContactTypeService
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
    <Hash>a305e34b3a2567a40c6826d62b384ac9</Hash>
</Codenesium>*/