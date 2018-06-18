using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public abstract class DALAbstractStudioMapper
        {
                public virtual Studio MapBOToEF(
                        BOStudio bo)
                {
                        Studio efStudio = new Studio();

                        efStudio.SetProperties(
                                bo.Address1,
                                bo.Address2,
                                bo.City,
                                bo.Id,
                                bo.Name,
                                bo.StateId,
                                bo.Website,
                                bo.Zip);
                        return efStudio;
                }

                public virtual BOStudio MapEFToBO(
                        Studio ef)
                {
                        var bo = new BOStudio();

                        bo.SetProperties(
                                ef.Id,
                                ef.Address1,
                                ef.Address2,
                                ef.City,
                                ef.Name,
                                ef.StateId,
                                ef.Website,
                                ef.Zip);
                        return bo;
                }

                public virtual List<BOStudio> MapEFToBO(
                        List<Studio> records)
                {
                        List<BOStudio> response = new List<BOStudio>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>5e4b4c2cd7a4a1a6d125f5fdaf06e5ff</Hash>
</Codenesium>*/