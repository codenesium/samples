using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractCommunityActionTemplateMapper
        {
                public virtual BOCommunityActionTemplate MapModelToBO(
                        string id,
                        ApiCommunityActionTemplateRequestModel model
                        )
                {
                        BOCommunityActionTemplate boCommunityActionTemplate = new BOCommunityActionTemplate();

                        boCommunityActionTemplate.SetProperties(
                                id,
                                model.ExternalId,
                                model.JSON,
                                model.Name);
                        return boCommunityActionTemplate;
                }

                public virtual ApiCommunityActionTemplateResponseModel MapBOToModel(
                        BOCommunityActionTemplate boCommunityActionTemplate)
                {
                        var model = new ApiCommunityActionTemplateResponseModel();

                        model.SetProperties(boCommunityActionTemplate.ExternalId, boCommunityActionTemplate.Id, boCommunityActionTemplate.JSON, boCommunityActionTemplate.Name);

                        return model;
                }

                public virtual List<ApiCommunityActionTemplateResponseModel> MapBOToModel(
                        List<BOCommunityActionTemplate> items)
                {
                        List<ApiCommunityActionTemplateResponseModel> response = new List<ApiCommunityActionTemplateResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>e7ef9ca3bb8b55271c60a0421656de1a</Hash>
</Codenesium>*/