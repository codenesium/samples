using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractSpecialOfferProductMapper
        {
                public virtual SpecialOfferProduct MapBOToEF(
                        BOSpecialOfferProduct bo)
                {
                        SpecialOfferProduct efSpecialOfferProduct = new SpecialOfferProduct();

                        efSpecialOfferProduct.SetProperties(
                                bo.ModifiedDate,
                                bo.ProductID,
                                bo.Rowguid,
                                bo.SpecialOfferID);
                        return efSpecialOfferProduct;
                }

                public virtual BOSpecialOfferProduct MapEFToBO(
                        SpecialOfferProduct ef)
                {
                        var bo = new BOSpecialOfferProduct();

                        bo.SetProperties(
                                ef.SpecialOfferID,
                                ef.ModifiedDate,
                                ef.ProductID,
                                ef.Rowguid);
                        return bo;
                }

                public virtual List<BOSpecialOfferProduct> MapEFToBO(
                        List<SpecialOfferProduct> records)
                {
                        List<BOSpecialOfferProduct> response = new List<BOSpecialOfferProduct>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>29e1212183c7167f0533506a0280362a</Hash>
</Codenesium>*/