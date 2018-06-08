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
                        if (ef == null)
                        {
                                return null;
                        }

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
    <Hash>48aaf62076b7576c5c7803b128a5e5c9</Hash>
</Codenesium>*/