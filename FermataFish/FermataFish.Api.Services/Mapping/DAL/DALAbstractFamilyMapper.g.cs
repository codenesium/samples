using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public abstract class DALAbstractFamilyMapper
        {
                public virtual Family MapBOToEF(
                        BOFamily bo)
                {
                        Family efFamily = new Family();

                        efFamily.SetProperties(
                                bo.Id,
                                bo.Notes,
                                bo.PcEmail,
                                bo.PcFirstName,
                                bo.PcLastName,
                                bo.PcPhone,
                                bo.StudioId);
                        return efFamily;
                }

                public virtual BOFamily MapEFToBO(
                        Family ef)
                {
                        var bo = new BOFamily();

                        bo.SetProperties(
                                ef.Id,
                                ef.Notes,
                                ef.PcEmail,
                                ef.PcFirstName,
                                ef.PcLastName,
                                ef.PcPhone,
                                ef.StudioId);
                        return bo;
                }

                public virtual List<BOFamily> MapEFToBO(
                        List<Family> records)
                {
                        List<BOFamily> response = new List<BOFamily>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>47284745b8c878fa724016a2de8d81f1</Hash>
</Codenesium>*/