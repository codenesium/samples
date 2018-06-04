using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALLocationMapper
	{
		public virtual Location MapBOToEF(
			BOLocation bo)
		{
			Location efLocation = new Location ();

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
    <Hash>2d9c2899d01d401c8889ea72c9c5d558</Hash>
</Codenesium>*/