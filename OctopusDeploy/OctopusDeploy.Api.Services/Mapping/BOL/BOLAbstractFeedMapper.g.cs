using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>c33db6fcc93df87dea6ecf518ec94c7f</Hash>
</Codenesium>*/