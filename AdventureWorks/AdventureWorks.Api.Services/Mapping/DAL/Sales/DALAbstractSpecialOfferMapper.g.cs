using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>5bf7dae13b54a093a2bdf639299dafcb</Hash>
</Codenesium>*/