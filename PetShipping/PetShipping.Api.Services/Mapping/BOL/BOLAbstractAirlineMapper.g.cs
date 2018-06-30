using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public abstract class BOLAbstractAirlineMapper
        {
                public virtual BOAirline MapModelToBO(
                        int id,
                        ApiAirlineRequestModel model
                        )
                {
                        BOAirline boAirline = new BOAirline();
                        boAirline.SetProperties(
                                id,
                                model.Name);
                        return boAirline;
                }

                public virtual ApiAirlineResponseModel MapBOToModel(
                        BOAirline boAirline)
                {
                        var model = new ApiAirlineResponseModel();

                        model.SetProperties(boAirline.Id, boAirline.Name);

                        return model;
                }

                public virtual List<ApiAirlineResponseModel> MapBOToModel(
                        List<BOAirline> items)
                {
                        List<ApiAirlineResponseModel> response = new List<ApiAirlineResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>71aad8a6d3a262ecb91667c19ad90aab</Hash>
</Codenesium>*/