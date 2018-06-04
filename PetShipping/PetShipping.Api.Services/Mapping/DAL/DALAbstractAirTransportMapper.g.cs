using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALAirTransportMapper
	{
		public virtual AirTransport MapBOToEF(
			BOAirTransport bo)
		{
			AirTransport efAirTransport = new AirTransport ();

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
			if (ef == null)
			{
				return null;
			}

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
    <Hash>f6f20214f7d3a713c5a0a2930a6f7664</Hash>
</Codenesium>*/