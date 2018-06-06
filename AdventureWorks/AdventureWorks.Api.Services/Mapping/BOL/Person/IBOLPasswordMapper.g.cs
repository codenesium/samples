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
			List<BOPassword> items);
	}
}

/*<Codenesium>
    <Hash>500843fa3d90762aef0f8547a0209a8a</Hash>
</Codenesium>*/