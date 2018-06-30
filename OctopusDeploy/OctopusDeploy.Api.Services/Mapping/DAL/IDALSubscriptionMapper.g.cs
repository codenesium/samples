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
    <Hash>eaac05b97a8147d37476d829afed8699</Hash>
</Codenesium>*/