using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class DALAbstractSpaceFeatureMapper
	{
		public virtual SpaceFeature MapBOToEF(
			BOSpaceFeature bo)
		{
			SpaceFeature efSpaceFeature = new SpaceFeature();
			efSpaceFeature.SetProperties(
				bo.Id,
				bo.Name);
			return efSpaceFeature;
		}

		public virtual BOSpaceFeature MapEFToBO(
			SpaceFeature ef)
		{
			var bo = new BOSpaceFeature();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOSpaceFeature> MapEFToBO(
			List<SpaceFeature> records)
		{
			List<BOSpaceFeature> response = new List<BOSpaceFeature>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>87a804f720d8f9d1cdb55a9b2067c052</Hash>
</Codenesium>*/