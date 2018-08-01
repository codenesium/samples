using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>3121a0ca4ab0a1ac1cd9861b3ed10b3d</Hash>
</Codenesium>*/