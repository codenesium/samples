using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>e004f3990600285a71aac76d28948c95</Hash>
</Codenesium>*/