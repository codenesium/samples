using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractLocationMapper
        {
                public virtual BOLocation MapModelToBO(
                        short locationID,
                        ApiLocationRequestModel model
                        )
                {
                        BOLocation boLocation = new BOLocation();

                        boLocation.SetProperties(
                                locationID,
                                model.Availability,
                                model.CostRate,
                                model.ModifiedDate,
                                model.Name);
                        return boLocation;
                }

                public virtual ApiLocationResponseModel MapBOToModel(
                        BOLocation boLocation)
                {
                        var model = new ApiLocationResponseModel();

                        model.SetProperties(boLocation.Availability, boLocation.CostRate, boLocation.LocationID, boLocation.ModifiedDate, boLocation.Name);

                        return model;
                }

                public virtual List<ApiLocationResponseModel> MapBOToModel(
                        List<BOLocation> items)
                {
                        List<ApiLocationResponseModel> response = new List<ApiLocationResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>895eaf63ae0433588524ec4088d4b1a7</Hash>
</Codenesium>*/