using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLProductCategoryMapper
	{
		BOProductCategory MapModelToBO(
			int productCategoryID,
			ApiProductCategoryRequestModel model);

		ApiProductCategoryResponseModel MapBOToModel(
			BOProductCategory boProductCategory);

		List<ApiProductCategoryResponseModel> MapBOToModel(
			List<BOProductCategory> bos);
	}
}

/*<Codenesium>
    <Hash>1d044fba292bcf5bd5f9d6dad04a05f7</Hash>
</Codenesium>*/