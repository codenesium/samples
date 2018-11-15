using Microsoft.EntityFrameworkCore;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>013138b4d0265a2b1fcf5483b3a0e4c0</Hash>
</Codenesium>*/