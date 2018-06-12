using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
                        if (ef == null)
                        {
                                return null;
                        }

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
    <Hash>b5056a7943159fe1b1c1ede80d33deff</Hash>
</Codenesium>*/