using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractSubscriptionMapper
        {
                public virtual Subscription MapBOToEF(
                        BOSubscription bo)
                {
                        Subscription efSubscription = new Subscription();
                        efSubscription.SetProperties(
                                bo.Id,
                                bo.IsDisabled,
                                bo.JSON,
                                bo.Name,
                                bo.Type);
                        return efSubscription;
                }

                public virtual BOSubscription MapEFToBO(
                        Subscription ef)
                {
                        var bo = new BOSubscription();

                        bo.SetProperties(
                                ef.Id,
                                ef.IsDisabled,
                                ef.JSON,
                                ef.Name,
                                ef.Type);
                        return bo;
                }

                public virtual List<BOSubscription> MapEFToBO(
                        List<Subscription> records)
                {
                        List<BOSubscription> response = new List<BOSubscription>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>15466ee1f8e7738f5fa27c318ea38b74</Hash>
</Codenesium>*/