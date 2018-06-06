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
			List<BOProduct> items);
	}
}

/*<Codenesium>
    <Hash>a7fcb7d74b7bb5e1c0db5105fd710d74</Hash>
</Codenesium>*/