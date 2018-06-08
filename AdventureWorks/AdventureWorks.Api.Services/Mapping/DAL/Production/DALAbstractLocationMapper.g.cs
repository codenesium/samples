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
                        if (ef == null)
                        {
                                return null;
                        }

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
    <Hash>4cff42ec3242553f0c07008b3bfa32bb</Hash>
</Codenesium>*/