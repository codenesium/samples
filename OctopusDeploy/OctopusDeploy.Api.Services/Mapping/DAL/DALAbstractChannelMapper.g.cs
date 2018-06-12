using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractChannelMapper
        {
                public virtual Channel MapBOToEF(
                        BOChannel bo)
                {
                        Channel efChannel = new Channel();

                        efChannel.SetProperties(
                                bo.DataVersion,
                                bo.Id,
                                bo.JSON,
                                bo.LifecycleId,
                                bo.Name,
                                bo.ProjectId,
                                bo.TenantTags);
                        return efChannel;
                }

                public virtual BOChannel MapEFToBO(
                        Channel ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOChannel();

                        bo.SetProperties(
                                ef.Id,
                                ef.DataVersion,
                                ef.JSON,
                                ef.LifecycleId,
                                ef.Name,
                                ef.ProjectId,
                                ef.TenantTags);
                        return bo;
                }

                public virtual List<BOChannel> MapEFToBO(
                        List<Channel> records)
                {
                        List<BOChannel> response = new List<BOChannel>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>d413d26405a5350678b74a946ccefc71</Hash>
</Codenesium>*/