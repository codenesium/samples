using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractSalesOrderHeaderSalesReasonMapper
        {
                public virtual SalesOrderHeaderSalesReason MapBOToEF(
                        BOSalesOrderHeaderSalesReason bo)
                {
                        SalesOrderHeaderSalesReason efSalesOrderHeaderSalesReason = new SalesOrderHeaderSalesReason();

                        efSalesOrderHeaderSalesReason.SetProperties(
                                bo.ModifiedDate,
                                bo.SalesOrderID,
                                bo.SalesReasonID);
                        return efSalesOrderHeaderSalesReason;
                }

                public virtual BOSalesOrderHeaderSalesReason MapEFToBO(
                        SalesOrderHeaderSalesReason ef)
                {
                        var bo = new BOSalesOrderHeaderSalesReason();

                        bo.SetProperties(
                                ef.SalesOrderID,
                                ef.ModifiedDate,
                                ef.SalesReasonID);
                        return bo;
                }

                public virtual List<BOSalesOrderHeaderSalesReason> MapEFToBO(
                        List<SalesOrderHeaderSalesReason> records)
                {
                        List<BOSalesOrderHeaderSalesReason> response = new List<BOSalesOrderHeaderSalesReason>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>27b0567e764a4531d997216482c42fb5</Hash>
</Codenesium>*/