using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class DALAbstractDestinationMapper
        {
                public virtual Destination MapBOToEF(
                        BODestination bo)
                {
                        Destination efDestination = new Destination();

                        efDestination.SetProperties(
                                bo.CountryId,
                                bo.Id,
                                bo.Name,
                                bo.Order);
                        return efDestination;
                }

                public virtual BODestination MapEFToBO(
                        Destination ef)
                {
                        var bo = new BODestination();

                        bo.SetProperties(
                                ef.Id,
                                ef.CountryId,
                                ef.Name,
                                ef.Order);
                        return bo;
                }

                public virtual List<BODestination> MapEFToBO(
                        List<Destination> records)
                {
                        List<BODestination> response = new List<BODestination>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>b1a730583ea4750916b9e789fab8bbc4</Hash>
</Codenesium>*/