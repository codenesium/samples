using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALSubscriptionMapper
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
    <Hash>520094c59ace5d9771480147949e546e</Hash>
</Codenesium>*/