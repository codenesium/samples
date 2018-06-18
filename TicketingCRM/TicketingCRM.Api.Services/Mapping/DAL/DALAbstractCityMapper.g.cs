using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class DALAbstractCityMapper
        {
                public virtual City MapBOToEF(
                        BOCity bo)
                {
                        City efCity = new City();

                        efCity.SetProperties(
                                bo.Id,
                                bo.Name,
                                bo.ProvinceId);
                        return efCity;
                }

                public virtual BOCity MapEFToBO(
                        City ef)
                {
                        var bo = new BOCity();

                        bo.SetProperties(
                                ef.Id,
                                ef.Name,
                                ef.ProvinceId);
                        return bo;
                }

                public virtual List<BOCity> MapEFToBO(
                        List<City> records)
                {
                        List<BOCity> response = new List<BOCity>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>7f3ce348f3b35e0eecf8ac9f447b7fb5</Hash>
</Codenesium>*/