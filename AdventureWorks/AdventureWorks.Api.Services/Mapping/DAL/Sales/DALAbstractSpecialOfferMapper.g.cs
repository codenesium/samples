using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractSpecialOfferMapper
        {
                public virtual SpecialOffer MapBOToEF(
                        BOSpecialOffer bo)
                {
                        SpecialOffer efSpecialOffer = new SpecialOffer();
                        efSpecialOffer.SetProperties(
                                bo.Category,
                                bo.Description,
                                bo.DiscountPct,
                                bo.EndDate,
                                bo.MaxQty,
                                bo.MinQty,
                                bo.ModifiedDate,
                                bo.Rowguid,
                                bo.SpecialOfferID,
                                bo.StartDate,
                                bo.Type);
                        return efSpecialOffer;
                }

                public virtual BOSpecialOffer MapEFToBO(
                        SpecialOffer ef)
                {
                        var bo = new BOSpecialOffer();

                        bo.SetProperties(
                                ef.SpecialOfferID,
                                ef.Category,
                                ef.Description,
                                ef.DiscountPct,
                                ef.EndDate,
                                ef.MaxQty,
                                ef.MinQty,
                                ef.ModifiedDate,
                                ef.Rowguid,
                                ef.StartDate,
                                ef.Type);
                        return bo;
                }

                public virtual List<BOSpecialOffer> MapEFToBO(
                        List<SpecialOffer> records)
                {
                        List<BOSpecialOffer> response = new List<BOSpecialOffer>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>b0e2ac84db99915d4e4489566d6a1aa0</Hash>
</Codenesium>*/