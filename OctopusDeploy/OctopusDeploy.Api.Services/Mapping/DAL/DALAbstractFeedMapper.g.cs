using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractFeedMapper
        {
                public virtual Feed MapBOToEF(
                        BOFeed bo)
                {
                        Feed efFeed = new Feed();
                        efFeed.SetProperties(
                                bo.FeedType,
                                bo.FeedUri,
                                bo.Id,
                                bo.JSON,
                                bo.Name);
                        return efFeed;
                }

                public virtual BOFeed MapEFToBO(
                        Feed ef)
                {
                        var bo = new BOFeed();

                        bo.SetProperties(
                                ef.Id,
                                ef.FeedType,
                                ef.FeedUri,
                                ef.JSON,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOFeed> MapEFToBO(
                        List<Feed> records)
                {
                        List<BOFeed> response = new List<BOFeed>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>36d08e8d79bc96b5482d36da6576b223</Hash>
</Codenesium>*/