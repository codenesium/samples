using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
			List<BOProductModel> items);
	}
}

/*<Codenesium>
    <Hash>2091f8b80daba7adc1d9303dc081e746</Hash>
</Codenesium>*/