using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALLinkTypeMapper
	{
		LinkType MapModelToEntity(
			int id,
			ApiLinkTypeServerRequestModel model);

		ApiLinkTypeServerResponseModel MapEntityToModel(
			LinkType item);

		List<ApiLinkTypeServerResponseModel> MapEntityToModel(
			List<LinkType> items);
	}
}

/*<Codenesium>
    <Hash>163b1b37b2f4fd8d2ec7ff37818ec337</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/