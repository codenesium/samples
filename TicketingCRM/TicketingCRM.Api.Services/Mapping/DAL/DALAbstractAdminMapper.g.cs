using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class DALAbstractAdminMapper
        {
                public virtual Admin MapBOToEF(
                        BOAdmin bo)
                {
                        Admin efAdmin = new Admin();
                        efAdmin.SetProperties(
                                bo.Email,
                                bo.FirstName,
                                bo.Id,
                                bo.LastName,
                                bo.Password,
                                bo.Phone,
                                bo.Username);
                        return efAdmin;
                }

                public virtual BOAdmin MapEFToBO(
                        Admin ef)
                {
                        var bo = new BOAdmin();

                        bo.SetProperties(
                                ef.Id,
                                ef.Email,
                                ef.FirstName,
                                ef.LastName,
                                ef.Password,
                                ef.Phone,
                                ef.Username);
                        return bo;
                }

                public virtual List<BOAdmin> MapEFToBO(
                        List<Admin> records)
                {
                        List<BOAdmin> response = new List<BOAdmin>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>4cbaafc5aa9416ffd621db57ea10af01</Hash>
</Codenesium>*/