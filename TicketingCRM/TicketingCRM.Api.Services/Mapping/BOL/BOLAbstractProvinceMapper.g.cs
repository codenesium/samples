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

                        model.SetProperties(boProvince.Id, boProvince.CountryId, boProvince.Name);

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
    <Hash>1ae9b12a437dfd0ac56775d32e7afdbb</Hash>
</Codenesium>*/