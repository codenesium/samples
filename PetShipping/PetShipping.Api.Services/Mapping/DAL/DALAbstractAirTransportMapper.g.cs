using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class DALAbstractAirTransportMapper
        {
                public virtual AirTransport MapBOToEF(
                        BOAirTransport bo)
                {
                        AirTransport efAirTransport = new AirTransport();

                        efAirTransport.SetProperties(
                                bo.AirlineId,
                                bo.FlightNumber,
                                bo.HandlerId,
                                bo.Id,
                                bo.LandDate,
                                bo.PipelineStepId,
                                bo.TakeoffDate);
                        return efAirTransport;
                }

                public virtual BOAirTransport MapEFToBO(
                        AirTransport ef)
                {
                        var bo = new BOAirTransport();

                        bo.SetProperties(
                                ef.AirlineId,
                                ef.FlightNumber,
                                ef.HandlerId,
                                ef.Id,
                                ef.LandDate,
                                ef.PipelineStepId,
                                ef.TakeoffDate);
                        return bo;
                }

                public virtual List<BOAirTransport> MapEFToBO(
                        List<AirTransport> records)
                {
                        List<BOAirTransport> response = new List<BOAirTransport>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>c63d6f6f783250fec474fe9b81479a71</Hash>
</Codenesium>*/