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
    <Hash>2ff8570d65c9d9e99a683846cb23dd71</Hash>
</Codenesium>*/