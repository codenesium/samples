using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractDALAirTransportMapper
	{
		public virtual void MapDTOToEF(
			int airlineId,
			DTOAirTransport dto,
			AirTransport efAirTransport)
		{
			efAirTransport.SetProperties(
				airlineId,
				dto.FlightNumber,
				dto.HandlerId,
				dto.Id,
				dto.LandDate,
				dto.PipelineStepId,
				dto.TakeoffDate);
		}

		public virtual DTOAirTransport MapEFToDTO(
			AirTransport ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOAirTransport();

			dto.SetProperties(
				ef.AirlineId,
				ef.FlightNumber,
				ef.HandlerId,
				ef.Id,
				ef.LandDate,
				ef.PipelineStepId,
				ef.TakeoffDate);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>2e4eda579cd85cba06e356732eb97640</Hash>
</Codenesium>*/