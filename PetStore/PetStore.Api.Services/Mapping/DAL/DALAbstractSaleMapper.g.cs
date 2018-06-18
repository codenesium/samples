using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public abstract class DALAbstractSaleMapper
        {
                public virtual Sale MapBOToEF(
                        BOSale bo)
                {
                        Sale efSale = new Sale();

                        efSale.SetProperties(
                                bo.Amount,
                                bo.FirstName,
                                bo.Id,
                                bo.LastName,
                                bo.PaymentTypeId,
                                bo.PetId,
                                bo.Phone);
                        return efSale;
                }

                public virtual BOSale MapEFToBO(
                        Sale ef)
                {
                        var bo = new BOSale();

                        bo.SetProperties(
                                ef.Id,
                                ef.Amount,
                                ef.FirstName,
                                ef.LastName,
                                ef.PaymentTypeId,
                                ef.PetId,
                                ef.Phone);
                        return bo;
                }

                public virtual List<BOSale> MapEFToBO(
                        List<Sale> records)
                {
                        List<BOSale> response = new List<BOSale>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>42d23e7df2c80c3ef6d42239d35bd4d2</Hash>
</Codenesium>*/