using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLPasswordMapper
	{
		BOPassword MapModelToBO(
			int businessEntityID,
			ApiPasswordRequestModel model);

		ApiPasswordResponseModel MapBOToModel(
			BOPassword boPassword);

		List<ApiPasswordResponseModel> MapBOToModel(
			List<BOPassword> bos);
	}
}

/*<Codenesium>
    <Hash>3ead85bfb7791001ff7c61ab9b0ae904</Hash>
</Codenesium>*/