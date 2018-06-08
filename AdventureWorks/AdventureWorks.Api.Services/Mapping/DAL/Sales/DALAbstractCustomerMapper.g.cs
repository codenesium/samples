using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractCustomerMapper
        {
                public virtual Customer MapBOToEF(
                        BOCustomer bo)
                {
                        Customer efCustomer = new Customer();

                        efCustomer.SetProperties(
                                bo.AccountNumber,
                                bo.CustomerID,
                                bo.ModifiedDate,
                                bo.PersonID,
                                bo.Rowguid,
                                bo.StoreID,
                                bo.TerritoryID);
                        return efCustomer;
                }

                public virtual BOCustomer MapEFToBO(
                        Customer ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOCustomer();

                        bo.SetProperties(
                                ef.CustomerID,
                                ef.AccountNumber,
                                ef.ModifiedDate,
                                ef.PersonID,
                                ef.Rowguid,
                                ef.StoreID,
                                ef.TerritoryID);
                        return bo;
                }

                public virtual List<BOCustomer> MapEFToBO(
                        List<Customer> records)
                {
                        List<BOCustomer> response = new List<BOCustomer>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>7f951e7d3030e4081a0f7171a3eaf565</Hash>
</Codenesium>*/