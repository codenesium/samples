using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class BOLAbstractBreedMapper
        {
                public virtual BOBreed MapModelToBO(
                        int id,
                        ApiBreedRequestModel model
                        )
                {
                        BOBreed boBreed = new BOBreed();

                        boBreed.SetProperties(
                                id,
                                model.Name,
                                model.SpeciesId);
                        return boBreed;
                }

                public virtual ApiBreedResponseModel MapBOToModel(
                        BOBreed boBreed)
                {
                        var model = new ApiBreedResponseModel();

                        model.SetProperties(boBreed.Id, boBreed.Name, boBreed.SpeciesId);

                        return model;
                }

                public virtual List<ApiBreedResponseModel> MapBOToModel(
                        List<BOBreed> items)
                {
                        List<ApiBreedResponseModel> response = new List<ApiBreedResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>da83a9f1a62f8981deb8f65d1312fece</Hash>
</Codenesium>*/