using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractSalesPersonQuotaHistoryMapper
        {
                public virtual SalesPersonQuotaHistory MapBOToEF(
                        BOSalesPersonQuotaHistory bo)
                {
                        SalesPersonQuotaHistory efSalesPersonQuotaHistory = new SalesPersonQuotaHistory();

                        efSalesPersonQuotaHistory.SetProperties(
                                bo.BusinessEntityID,
                                bo.ModifiedDate,
                                bo.QuotaDate,
                                bo.Rowguid,
                                bo.SalesQuota);
                        return efSalesPersonQuotaHistory;
                }

                public virtual BOSalesPersonQuotaHistory MapEFToBO(
                        SalesPersonQuotaHistory ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOSalesPersonQuotaHistory();

                        bo.SetProperties(
                                ef.BusinessEntityID,
                                ef.ModifiedDate,
                                ef.QuotaDate,
                                ef.Rowguid,
                                ef.SalesQuota);
                        return bo;
                }

                public virtual List<BOSalesPersonQuotaHistory> MapEFToBO(
                        List<SalesPersonQuotaHistory> records)
                {
                        List<BOSalesPersonQuotaHistory> response = new List<BOSalesPersonQuotaHistory>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>8b8cc718750cfee71ecfda7e50ee9939</Hash>
</Codenesium>*/