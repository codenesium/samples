using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

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
    <Hash>3492b546c953a0a4c1bfdd66a3ff58ed</Hash>
</Codenesium>*/