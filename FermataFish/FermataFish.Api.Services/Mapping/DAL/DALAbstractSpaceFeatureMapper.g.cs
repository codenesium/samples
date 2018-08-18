using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
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
				bo.StudioId);
			return efSpaceFeature;
		}

		public virtual BOSpaceFeature MapEFToBO(
			SpaceFeature ef)
		{
			var bo = new BOSpaceFeature();

			bo.SetProperties(
				ef.Id,
				ef.Name,
				ef.StudioId);
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
    <Hash>014bb04efbf24770eb043dacfc6c2a8b</Hash>
</Codenesium>*/