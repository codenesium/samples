using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
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
                                model.AcquiredDate,
                                model.BreedId,
                                model.Description,
                                model.PenId,
                                model.Price,
                                model.SpeciesId);
                        return boPet;
                }

                public virtual ApiPetResponseModel MapBOToModel(
                        BOPet boPet)
                {
                        var model = new ApiPetResponseModel();

                        model.SetProperties(boPet.AcquiredDate, boPet.BreedId, boPet.Description, boPet.Id, boPet.PenId, boPet.Price, boPet.SpeciesId);

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
    <Hash>9d65c91f820495af91f695e817c65307</Hash>
</Codenesium>*/