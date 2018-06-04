using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLProductModelMapper
	{
		BOProductModel MapModelToBO(
			int productModelID,
			ApiProductModelRequestModel model);

		ApiProductModelResponseModel MapBOToModel(
			BOProductModel boProductModel);

		List<ApiProductModelResponseModel> MapBOToModel(
			List<BOProductModel> bos);
	}
}

/*<Codenesium>
    <Hash>368e92a3d684d0e55e85e424aa858e51</Hash>
</Codenesium>*/