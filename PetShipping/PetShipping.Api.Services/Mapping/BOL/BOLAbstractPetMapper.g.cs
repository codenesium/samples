using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public abstract class BOLAbstractPetMapper
        {
                public virtual BOPet MapModelToBO(
                        int id,
                        ApiPetRequestModel model
                        )
                {
                        BOPet boPet = new BOPet();
                        boPet.SetProperties(
                                id,
                                model.BreedId,
                                model.ClientId,
                                model.Name,
                                model.Weight);
                        return boPet;
                }

                public virtual ApiPetResponseModel MapBOToModel(
                        BOPet boPet)
                {
                        var model = new ApiPetResponseModel();

                        model.SetProperties(boPet.BreedId, boPet.ClientId, boPet.Id, boPet.Name, boPet.Weight);

                        return model;
                }

                public virtual List<ApiPetResponseModel> MapBOToModel(
                        List<BOPet> items)
                {
                        List<ApiPetResponseModel> response = new List<ApiPetResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>bc3934b562c84350cacb44fe65251bda</Hash>
</Codenesium>*/