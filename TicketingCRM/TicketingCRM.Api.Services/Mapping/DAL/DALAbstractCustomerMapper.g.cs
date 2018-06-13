using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class DALAbstractCustomerMapper
        {
                public virtual Customer MapBOToEF(
                        BOCustomer bo)
                {
                        Customer efCustomer = new Customer();

                        efCustomer.SetProperties(
                                bo.Email,
                                bo.FirstName,
                                bo.Id,
                                bo.LastName,
                                bo.Phone);
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
                                ef.Id,
                                ef.Email,
                                ef.FirstName,
                                ef.LastName,
                                ef.Phone);
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
    <Hash>cfd971bc207709d141129d7d6153db95</Hash>
</Codenesium>*/