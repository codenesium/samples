using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class DALAbstractSaleMapper
        {
                public virtual Sale MapBOToEF(
                        BOSale bo)
                {
                        Sale efSale = new Sale();

                        efSale.SetProperties(
                                bo.Id,
                                bo.IpAddress,
                                bo.Notes,
                                bo.SaleDate,
                                bo.TransactionId);
                        return efSale;
                }

                public virtual BOSale MapEFToBO(
                        Sale ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOSale();

                        bo.SetProperties(
                                ef.Id,
                                ef.IpAddress,
                                ef.Notes,
                                ef.SaleDate,
                                ef.TransactionId);
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
    <Hash>c24442c8050951e0539de33787a1c39f</Hash>
</Codenesium>*/