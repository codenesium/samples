using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractFeedMapper
        {
                public virtual BOFeed MapModelToBO(
                        string id,
                        ApiFeedRequestModel model
                        )
                {
                        BOFeed boFeed = new BOFeed();

                        boFeed.SetProperties(
                                id,
                                model.FeedType,
                                model.FeedUri,
                                model.JSON,
                                model.Name);
                        return boFeed;
                }

                public virtual ApiFeedResponseModel MapBOToModel(
                        BOFeed boFeed)
                {
                        var model = new ApiFeedResponseModel();

                        model.SetProperties(boFeed.FeedType, boFeed.FeedUri, boFeed.Id, boFeed.JSON, boFeed.Name);

                        return model;
                }

                public virtual List<ApiFeedResponseModel> MapBOToModel(
                        List<BOFeed> items)
                {
                        List<ApiFeedResponseModel> response = new List<ApiFeedResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>046cc1dad04e0133ae2b2709ebb66783</Hash>
</Codenesium>*/