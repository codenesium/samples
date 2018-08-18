using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALSubscriptionMapper
	{
		Subscription MapBOToEF(
			BOSubscription bo);

		BOSubscription MapEFToBO(
			Subscription efSubscription);

		List<BOSubscription> MapEFToBO(
			List<Subscription> records);
	}
}

/*<Codenesium>
    <Hash>2c629e5cc5c17558b7d793036a6178f7</Hash>
</Codenesium>*/