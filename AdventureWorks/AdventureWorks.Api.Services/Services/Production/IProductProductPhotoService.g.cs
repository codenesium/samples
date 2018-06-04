using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IProductProductPhotoService
	{
		Task<CreateResponse<ApiProductProductPhotoResponseModel>> Create(
			ApiProductProductPhotoRequestModel model);

		Task<ActionResponse> Update(int productID,
		                            ApiProductProductPhotoRequestModel model);

		Task<ActionResponse> Delete(int productID);

		Task<ApiProductProductPhotoResponseModel> Get(int productID);

		Task<List<ApiProductProductPhotoResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cf1d7f93020f61e1ccfd2501db478950</Hash>
</Codenesium>*/