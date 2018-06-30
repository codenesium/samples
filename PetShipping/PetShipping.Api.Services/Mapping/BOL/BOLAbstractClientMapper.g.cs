using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public abstract class BOLAbstractClientMapper
        {
                public virtual BOClient MapModelToBO(
                        int id,
                        ApiClientRequestModel model
                        )
                {
                        BOClient boClient = new BOClient();
                        boClient.SetProperties(
                                id,
                                model.Email,
                                model.FirstName,
                                model.LastName,
                                model.Notes,
                                model.Phone);
                        return boClient;
                }

                public virtual ApiClientResponseModel MapBOToModel(
                        BOClient boClient)
                {
                        var model = new ApiClientResponseModel();

                        model.SetProperties(boClient.Id, boClient.Email, boClient.FirstName, boClient.LastName, boClient.Notes, boClient.Phone);

                        return model;
                }

                public virtual List<ApiClientResponseModel> MapBOToModel(
                        List<BOClient> items)
                {
                        List<ApiClientResponseModel> response = new List<ApiClientResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>a4cee08cbc1384a229a455c39c642458</Hash>
</Codenesium>*/