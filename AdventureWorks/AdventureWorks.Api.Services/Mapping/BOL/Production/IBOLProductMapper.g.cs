using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLProductMapper
	{
		BOProduct MapModelToBO(
			int productID,
			ApiProductRequestModel model);

		ApiProductResponseModel MapBOToModel(
			BOProduct boProduct);

		List<ApiProductResponseModel> MapBOToModel(
			List<BOProduct> bos);
	}
}

/*<Codenesium>
    <Hash>f944d44d8870156942b1f6a247e9e5bc</Hash>
</Codenesium>*/