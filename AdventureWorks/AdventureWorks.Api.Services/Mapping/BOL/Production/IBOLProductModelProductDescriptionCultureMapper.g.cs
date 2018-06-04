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
			List<BOProductModelProductDescriptionCulture> bos);
	}
}

/*<Codenesium>
    <Hash>cd9e678a96f2a2821f044c2af42394db</Hash>
</Codenesium>*/