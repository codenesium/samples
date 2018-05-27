using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductPhoto
	{
		Task<CreateResponse<ApiProductPhotoResponseModel>> Create(
			ApiProductPhotoRequestModel model);

		Task<ActionResponse> Update(int productPhotoID,
		                            ApiProductPhotoRequestModel model);

		Task<ActionResponse> Delete(int productPhotoID);

		Task<ApiProductPhotoResponseModel> Get(int productPhotoID);

		Task<List<ApiProductPhotoResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>114513316542c381ad29fa699b816797</Hash>
</Codenesium>*/