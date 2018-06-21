using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public abstract class BOLAbstractTagsMapper
        {
                public virtual BOTags MapModelToBO(
                        int id,
                        ApiTagsRequestModel model
                        )
                {
                        BOTags boTags = new BOTags();
                        boTags.SetProperties(
                                id,
                                model.Count,
                                model.ExcerptPostId,
                                model.TagName,
                                model.WikiPostId);
                        return boTags;
                }

                public virtual ApiTagsResponseModel MapBOToModel(
                        BOTags boTags)
                {
                        var model = new ApiTagsResponseModel();

                        model.SetProperties(boTags.Count, boTags.ExcerptPostId, boTags.Id, boTags.TagName, boTags.WikiPostId);

                        return model;
                }

                public virtual List<ApiTagsResponseModel> MapBOToModel(
                        List<BOTags> items)
                {
                        List<ApiTagsResponseModel> response = new List<ApiTagsResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>1506222f394d69e55abe7345132c3c4b</Hash>
</Codenesium>*/