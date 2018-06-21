using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class BOLAbstractProvinceMapper
        {
                public virtual BOProvince MapModelToBO(
                        int id,
                        ApiProvinceRequestModel model
                        )
                {
                        BOProvince boProvince = new BOProvince();
                        boProvince.SetProperties(
                                id,
                                model.CountryId,
                                model.Name);
                        return boProvince;
                }

                public virtual ApiProvinceResponseModel MapBOToModel(
                        BOProvince boProvince)
                {
                        var model = new ApiProvinceResponseModel();

                        model.SetProperties(boProvince.CountryId, boProvince.Id, boProvince.Name);

                        return model;
                }

                public virtual List<ApiProvinceResponseModel> MapBOToModel(
                        List<BOProvince> items)
                {
                        List<ApiProvinceResponseModel> response = new List<ApiProvinceResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>2a3f06216c13204822a0ae3a2795b3ea</Hash>
</Codenesium>*/