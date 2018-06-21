using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractVendorMapper
        {
                public virtual Vendor MapBOToEF(
                        BOVendor bo)
                {
                        Vendor efVendor = new Vendor();
                        efVendor.SetProperties(
                                bo.AccountNumber,
                                bo.ActiveFlag,
                                bo.BusinessEntityID,
                                bo.CreditRating,
                                bo.ModifiedDate,
                                bo.Name,
                                bo.PreferredVendorStatus,
                                bo.PurchasingWebServiceURL);
                        return efVendor;
                }

                public virtual BOVendor MapEFToBO(
                        Vendor ef)
                {
                        var bo = new BOVendor();

                        bo.SetProperties(
                                ef.BusinessEntityID,
                                ef.AccountNumber,
                                ef.ActiveFlag,
                                ef.CreditRating,
                                ef.ModifiedDate,
                                ef.Name,
                                ef.PreferredVendorStatus,
                                ef.PurchasingWebServiceURL);
                        return bo;
                }

                public virtual List<BOVendor> MapEFToBO(
                        List<Vendor> records)
                {
                        List<BOVendor> response = new List<BOVendor>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>881b8d593ff3fa81e0804c53e63e18b9</Hash>
</Codenesium>*/