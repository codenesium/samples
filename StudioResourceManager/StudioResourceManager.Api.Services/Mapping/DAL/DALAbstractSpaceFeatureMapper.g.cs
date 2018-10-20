using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
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
				bo.Name,
				bo.IsDeleted);
			return efSpaceFeature;
		}

		public virtual BOSpaceFeature MapEFToBO(
			SpaceFeature ef)
		{
			var bo = new BOSpaceFeature();

			bo.SetProperties(
				ef.Id,
				ef.Name,
				ef.IsDeleted);
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
    <Hash>2db8f3f56574f772bebaf4cde360a2ec</Hash>
</Codenesium>*/