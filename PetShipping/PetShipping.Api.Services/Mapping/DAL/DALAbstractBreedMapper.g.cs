using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public abstract class DALAbstractBreedMapper
        {
                public virtual Breed MapBOToEF(
                        BOBreed bo)
                {
                        Breed efBreed = new Breed();
                        efBreed.SetProperties(
                                bo.Id,
                                bo.Name,
                                bo.SpeciesId);
                        return efBreed;
                }

                public virtual BOBreed MapEFToBO(
                        Breed ef)
                {
                        var bo = new BOBreed();

                        bo.SetProperties(
                                ef.Id,
                                ef.Name,
                                ef.SpeciesId);
                        return bo;
                }

                public virtual List<BOBreed> MapEFToBO(
                        List<Breed> records)
                {
                        List<BOBreed> response = new List<BOBreed>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>b7a84ea3f160b2e6c631004844414379</Hash>
</Codenesium>*/