using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
                        if (ef == null)
                        {
                                return null;
                        }

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
    <Hash>67390c7f3591a5cb6932c7cde549cd2c</Hash>
</Codenesium>*/