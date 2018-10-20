using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class DALAbstractSpaceSpaceFeatureMapper
	{
		public virtual SpaceSpaceFeature MapBOToEF(
			BOSpaceSpaceFeature bo)
		{
			SpaceSpaceFeature efSpaceSpaceFeature = new SpaceSpaceFeature();
			efSpaceSpaceFeature.SetProperties(
				bo.SpaceFeatureId,
				bo.SpaceId,
				bo.IsDeleted);
			return efSpaceSpaceFeature;
		}

		public virtual BOSpaceSpaceFeature MapEFToBO(
			SpaceSpaceFeature ef)
		{
			var bo = new BOSpaceSpaceFeature();

			bo.SetProperties(
				ef.SpaceId,
				ef.SpaceFeatureId,
				ef.IsDeleted);
			return bo;
		}

		public virtual List<BOSpaceSpaceFeature> MapEFToBO(
			List<SpaceSpaceFeature> records)
		{
			List<BOSpaceSpaceFeature> response = new List<BOSpaceSpaceFeature>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b4d0b64e16971fea9a33d53bc605ddfb</Hash>
</Codenesium>*/