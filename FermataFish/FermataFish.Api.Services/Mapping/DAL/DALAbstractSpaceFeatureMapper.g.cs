using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public abstract class AbstractDALSpaceFeatureMapper
	{
		public virtual SpaceFeature MapBOToEF(
			BOSpaceFeature bo)
		{
			SpaceFeature efSpaceFeature = new SpaceFeature ();

			efSpaceFeature.SetProperties(
				bo.Id,
				bo.Name,
				bo.StudioId);
			return efSpaceFeature;
		}

		public virtual BOSpaceFeature MapEFToBO(
			SpaceFeature ef)
		{
			if (ef == null)
			{
				return null;
			}

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
    <Hash>b4b7852c15bcc9c44a17ed7f30bb7271</Hash>
</Codenesium>*/