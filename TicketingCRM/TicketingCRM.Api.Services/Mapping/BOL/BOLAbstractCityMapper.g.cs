using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class BOLAbstractCityMapper
        {
                public virtual BOCity MapModelToBO(
                        int id,
                        ApiCityRequestModel model
                        )
                {
                        BOCity boCity = new BOCity();

                        boCity.SetProperties(
                                id,
                                model.Name,
                                model.ProvinceId);
                        return boCity;
                }

                public virtual ApiCityResponseModel MapBOToModel(
                        BOCity boCity)
                {
                        var model = new ApiCityResponseModel();

                        model.SetProperties(boCity.Id, boCity.Name, boCity.ProvinceId);

                        return model;
                }

                public virtual List<ApiCityResponseModel> MapBOToModel(
                        List<BOCity> items)
                {
                        List<ApiCityResponseModel> response = new List<ApiCityResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>acca2cbdddb5bb9fa1e83172ff3c16b8</Hash>
</Codenesium>*/