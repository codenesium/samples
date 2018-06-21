using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
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
                                model.Name);
                        return boBreed;
                }

                public virtual ApiBreedResponseModel MapBOToModel(
                        BOBreed boBreed)
                {
                        var model = new ApiBreedResponseModel();

                        model.SetProperties(boBreed.Id, boBreed.Name);

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
    <Hash>132936147cc64958c0ca2ab8a9b66386</Hash>
</Codenesium>*/