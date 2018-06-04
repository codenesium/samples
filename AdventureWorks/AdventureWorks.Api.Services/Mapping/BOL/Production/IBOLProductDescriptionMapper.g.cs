using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLProductDescriptionMapper
	{
		BOProductDescription MapModelToBO(
			int productDescriptionID,
			ApiProductDescriptionRequestModel model);

		ApiProductDescriptionResponseModel MapBOToModel(
			BOProductDescription boProductDescription);

		List<ApiProductDescriptionResponseModel> MapBOToModel(
			List<BOProductDescription> bos);
	}
}

/*<Codenesium>
    <Hash>5ea0e7460ba2c42124dda65dbcc65568</Hash>
</Codenesium>*/