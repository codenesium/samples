using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>5f98b7d8b3c0e93f2a3407bab5f2f162</Hash>
</Codenesium>*/