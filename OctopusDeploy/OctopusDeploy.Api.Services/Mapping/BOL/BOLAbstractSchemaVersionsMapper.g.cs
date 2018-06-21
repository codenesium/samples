using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractSchemaVersionsMapper
        {
                public virtual BOSchemaVersions MapModelToBO(
                        int id,
                        ApiSchemaVersionsRequestModel model
                        )
                {
                        BOSchemaVersions boSchemaVersions = new BOSchemaVersions();
                        boSchemaVersions.SetProperties(
                                id,
                                model.Applied,
                                model.ScriptName);
                        return boSchemaVersions;
                }

                public virtual ApiSchemaVersionsResponseModel MapBOToModel(
                        BOSchemaVersions boSchemaVersions)
                {
                        var model = new ApiSchemaVersionsResponseModel();

                        model.SetProperties(boSchemaVersions.Applied, boSchemaVersions.Id, boSchemaVersions.ScriptName);

                        return model;
                }

                public virtual List<ApiSchemaVersionsResponseModel> MapBOToModel(
                        List<BOSchemaVersions> items)
                {
                        List<ApiSchemaVersionsResponseModel> response = new List<ApiSchemaVersionsResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>ffb819cc9290464e7d34c6c469cabf7c</Hash>
</Codenesium>*/