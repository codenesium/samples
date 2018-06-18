using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractLocationMapper
        {
                public virtual Location MapBOToEF(
                        BOLocation bo)
                {
                        Location efLocation = new Location();

                        efLocation.SetProperties(
                                bo.Availability,
                                bo.CostRate,
                                bo.LocationID,
                                bo.ModifiedDate,
                                bo.Name);
                        return efLocation;
                }

                public virtual BOLocation MapEFToBO(
                        Location ef)
                {
                        var bo = new BOLocation();

                        bo.SetProperties(
                                ef.LocationID,
                                ef.Availability,
                                ef.CostRate,
                                ef.ModifiedDate,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOLocation> MapEFToBO(
                        List<Location> records)
                {
                        List<BOLocation> response = new List<BOLocation>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>cd8a3a18c69103d4a3a24e81aa04cf42</Hash>
</Codenesium>*/