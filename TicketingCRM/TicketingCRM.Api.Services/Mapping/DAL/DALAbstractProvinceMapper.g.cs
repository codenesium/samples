using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class DALAbstractProvinceMapper
        {
                public virtual Province MapBOToEF(
                        BOProvince bo)
                {
                        Province efProvince = new Province();

                        efProvince.SetProperties(
                                bo.CountryId,
                                bo.Id,
                                bo.Name);
                        return efProvince;
                }

                public virtual BOProvince MapEFToBO(
                        Province ef)
                {
                        var bo = new BOProvince();

                        bo.SetProperties(
                                ef.Id,
                                ef.CountryId,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOProvince> MapEFToBO(
                        List<Province> records)
                {
                        List<BOProvince> response = new List<BOProvince>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>6aeb0917c9cce4be71f069dca72d8dbb</Hash>
</Codenesium>*/