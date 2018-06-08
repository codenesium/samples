using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public abstract class DALAbstractBreedMapper
        {
                public virtual Breed MapBOToEF(
                        BOBreed bo)
                {
                        Breed efBreed = new Breed();

                        efBreed.SetProperties(
                                bo.Id,
                                bo.Name);
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
                                ef.Name);
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
    <Hash>d7aedb6074885839f2d37166f191763e</Hash>
</Codenesium>*/