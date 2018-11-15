using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLPasswordMapper
	{
		BOPassword MapModelToBO(
			int businessEntityID,
			ApiPasswordServerRequestModel model);

		ApiPasswordServerResponseModel MapBOToModel(
			BOPassword boPassword);

		List<ApiPasswordServerResponseModel> MapBOToModel(
			List<BOPassword> items);
	}
}

/*<Codenesium>
    <Hash>c800f0ac8241dfbc72a2d7c42a2cde34</Hash>
</Codenesium>*/