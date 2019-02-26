using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace SecureVideoCRMNS.Api.Services
{
	public partial interface IDALSubscriptionMapper
	{
		Subscription MapModelToEntity(
			int id,
			ApiSubscriptionServerRequestModel model);

		ApiSubscriptionServerResponseModel MapEntityToModel(
			Subscription item);

		List<ApiSubscriptionServerResponseModel> MapEntityToModel(
			List<Subscription> items);
	}
}

/*<Codenesium>
    <Hash>4e92fee3a81e06a1dd4de97d397727ce</Hash>
</Codenesium>*/