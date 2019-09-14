using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace SecureVideoCRMNS.Api.Services
{
	public partial interface IDALUserMapper
	{
		User MapModelToEntity(
			int id,
			ApiUserServerRequestModel model);

		ApiUserServerResponseModel MapEntityToModel(
			User item);

		List<ApiUserServerResponseModel> MapEntityToModel(
			List<User> items);
	}
}

/*<Codenesium>
    <Hash>c5667c73285ba30a16be0aa71de40147</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/