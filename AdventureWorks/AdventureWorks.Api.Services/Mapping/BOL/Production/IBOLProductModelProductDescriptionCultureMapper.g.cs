using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLProductModelProductDescriptionCultureMapper
	{
		BOProductModelProductDescriptionCulture MapModelToBO(
			int productModelID,
			ApiProductModelProductDescriptionCultureRequestModel model);

		ApiProductModelProductDescriptionCultureResponseModel MapBOToModel(
			BOProductModelProductDescriptionCulture boProductModelProductDescriptionCulture);

		List<ApiProductModelProductDescriptionCultureResponseModel> MapBOToModel(
			List<BOProductModelProductDescriptionCulture> items);
	}
}

/*<Codenesium>
    <Hash>0e53ec981ad77d6062b492e2fb541a56</Hash>
</Codenesium>*/