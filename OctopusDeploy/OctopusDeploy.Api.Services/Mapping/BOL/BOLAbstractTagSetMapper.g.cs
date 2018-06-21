using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractTagSetMapper
        {
                public virtual BOTagSet MapModelToBO(
                        string id,
                        ApiTagSetRequestModel model
                        )
                {
                        BOTagSet boTagSet = new BOTagSet();
                        boTagSet.SetProperties(
                                id,
                                model.DataVersion,
                                model.JSON,
                                model.Name,
                                model.SortOrder);
                        return boTagSet;
                }

                public virtual ApiTagSetResponseModel MapBOToModel(
                        BOTagSet boTagSet)
                {
                        var model = new ApiTagSetResponseModel();

                        model.SetProperties(boTagSet.DataVersion, boTagSet.Id, boTagSet.JSON, boTagSet.Name, boTagSet.SortOrder);

                        return model;
                }

                public virtual List<ApiTagSetResponseModel> MapBOToModel(
                        List<BOTagSet> items)
                {
                        List<ApiTagSetResponseModel> response = new List<ApiTagSetResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>07e06b73fb37fa288c2dacffe8bb6d53</Hash>
</Codenesium>*/