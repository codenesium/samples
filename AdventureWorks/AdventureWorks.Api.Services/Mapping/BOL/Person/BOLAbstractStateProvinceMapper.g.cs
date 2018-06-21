using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>d4a0857f710c704095f49bc6b1204679</Hash>
</Codenesium>*/