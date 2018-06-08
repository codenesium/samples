using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractAWBuildVersionMapper
        {
                public virtual BOAWBuildVersion MapModelToBO(
                        int systemInformationID,
                        ApiAWBuildVersionRequestModel model
                        )
                {
                        BOAWBuildVersion boAWBuildVersion = new BOAWBuildVersion();

                        boAWBuildVersion.SetProperties(
                                systemInformationID,
                                model.Database_Version,
                                model.ModifiedDate,
                                model.VersionDate);
                        return boAWBuildVersion;
                }

                public virtual ApiAWBuildVersionResponseModel MapBOToModel(
                        BOAWBuildVersion boAWBuildVersion)
                {
                        var model = new ApiAWBuildVersionResponseModel();

                        model.SetProperties(boAWBuildVersion.Database_Version, boAWBuildVersion.ModifiedDate, boAWBuildVersion.SystemInformationID, boAWBuildVersion.VersionDate);

                        return model;
                }

                public virtual List<ApiAWBuildVersionResponseModel> MapBOToModel(
                        List<BOAWBuildVersion> items)
                {
                        List<ApiAWBuildVersionResponseModel> response = new List<ApiAWBuildVersionResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>12bc75e51f5c8691c57f7ea7902ee108</Hash>
</Codenesium>*/