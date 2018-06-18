using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public abstract class DALAbstractSpeciesMapper
        {
                public virtual Species MapBOToEF(
                        BOSpecies bo)
                {
                        Species efSpecies = new Species();

                        efSpecies.SetProperties(
                                bo.Id,
                                bo.Name);
                        return efSpecies;
                }

                public virtual BOSpecies MapEFToBO(
                        Species ef)
                {
                        var bo = new BOSpecies();

                        bo.SetProperties(
                                ef.Id,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOSpecies> MapEFToBO(
                        List<Species> records)
                {
                        List<BOSpecies> response = new List<BOSpecies>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>ddd929260ae9d6fe6c201c903462c544</Hash>
</Codenesium>*/