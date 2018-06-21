using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public abstract class BOLAbstractPostLinksMapper
        {
                public virtual BOPostLinks MapModelToBO(
                        int id,
                        ApiPostLinksRequestModel model
                        )
                {
                        BOPostLinks boPostLinks = new BOPostLinks();
                        boPostLinks.SetProperties(
                                id,
                                model.CreationDate,
                                model.LinkTypeId,
                                model.PostId,
                                model.RelatedPostId);
                        return boPostLinks;
                }

                public virtual ApiPostLinksResponseModel MapBOToModel(
                        BOPostLinks boPostLinks)
                {
                        var model = new ApiPostLinksResponseModel();

                        model.SetProperties(boPostLinks.CreationDate, boPostLinks.Id, boPostLinks.LinkTypeId, boPostLinks.PostId, boPostLinks.RelatedPostId);

                        return model;
                }

                public virtual List<ApiPostLinksResponseModel> MapBOToModel(
                        List<BOPostLinks> items)
                {
                        List<ApiPostLinksResponseModel> response = new List<ApiPostLinksResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>25faf3c3bfae151aaae184d972f18f83</Hash>
</Codenesium>*/