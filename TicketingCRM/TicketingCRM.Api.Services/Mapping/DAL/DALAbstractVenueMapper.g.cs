using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class DALAbstractVenueMapper
        {
                public virtual Venue MapBOToEF(
                        BOVenue bo)
                {
                        Venue efVenue = new Venue();

                        efVenue.SetProperties(
                                bo.Address1,
                                bo.Address2,
                                bo.AdminId,
                                bo.Email,
                                bo.Facebook,
                                bo.Id,
                                bo.Name,
                                bo.Phone,
                                bo.ProvinceId,
                                bo.Website);
                        return efVenue;
                }

                public virtual BOVenue MapEFToBO(
                        Venue ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOVenue();

                        bo.SetProperties(
                                ef.Id,
                                ef.Address1,
                                ef.Address2,
                                ef.AdminId,
                                ef.Email,
                                ef.Facebook,
                                ef.Name,
                                ef.Phone,
                                ef.ProvinceId,
                                ef.Website);
                        return bo;
                }

                public virtual List<BOVenue> MapEFToBO(
                        List<Venue> records)
                {
                        List<BOVenue> response = new List<BOVenue>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>65aa6cbcfc3fc4715cff02085c0d073e</Hash>
</Codenesium>*/