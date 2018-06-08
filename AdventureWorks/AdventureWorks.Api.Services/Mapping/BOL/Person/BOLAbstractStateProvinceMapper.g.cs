using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractStateProvinceMapper
        {
                public virtual BOStateProvince MapModelToBO(
                        int stateProvinceID,
                        ApiStateProvinceRequestModel model
                        )
                {
                        BOStateProvince boStateProvince = new BOStateProvince();

                        boStateProvince.SetProperties(
                                stateProvinceID,
                                model.CountryRegionCode,
                                model.IsOnlyStateProvinceFlag,
                                model.ModifiedDate,
                                model.Name,
                                model.Rowguid,
                                model.StateProvinceCode,
                                model.TerritoryID);
                        return boStateProvince;
                }

                public virtual ApiStateProvinceResponseModel MapBOToModel(
                        BOStateProvince boStateProvince)
                {
                        var model = new ApiStateProvinceResponseModel();

                        model.SetProperties(boStateProvince.CountryRegionCode, boStateProvince.IsOnlyStateProvinceFlag, boStateProvince.ModifiedDate, boStateProvince.Name, boStateProvince.Rowguid, boStateProvince.StateProvinceCode, boStateProvince.StateProvinceID, boStateProvince.TerritoryID);

                        return model;
                }

                public virtual List<ApiStateProvinceResponseModel> MapBOToModel(
                        List<BOStateProvince> items)
                {
                        List<ApiStateProvinceResponseModel> response = new List<ApiStateProvinceResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>5ea06ed74ee00db5a3ff4f8555e4eba5</Hash>
</Codenesium>*/