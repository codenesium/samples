using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
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
                        if (ef == null)
                        {
                                return null;
                        }

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
    <Hash>d0d7aa169041a7d103721dd978bdb6b7</Hash>
</Codenesium>*/