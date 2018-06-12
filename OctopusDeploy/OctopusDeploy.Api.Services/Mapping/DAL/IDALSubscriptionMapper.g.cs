using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>22bbbbef928e7e3e09d3cfb3b880bcaa</Hash>
</Codenesium>*/