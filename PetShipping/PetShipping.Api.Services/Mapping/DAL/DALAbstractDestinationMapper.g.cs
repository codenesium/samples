using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALDestinationMapper
	{
		public virtual Destination MapBOToEF(
			BODestination bo)
		{
			Destination efDestination = new Destination ();

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
			if (ef == null)
			{
				return null;
			}

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
    <Hash>b1d5f15f4e22438f70b880c54695fd95</Hash>
</Codenesium>*/