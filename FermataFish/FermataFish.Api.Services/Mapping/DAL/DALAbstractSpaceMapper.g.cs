using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public abstract class AbstractDALSpaceMapper
	{
		public virtual Space MapBOToEF(
			BOSpace bo)
		{
			Space efSpace = new Space ();

			efSpace.SetProperties(
				bo.Description,
				bo.Id,
				bo.Name,
				bo.StudioId);
			return efSpace;
		}

		public virtual BOSpace MapEFToBO(
			Space ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOSpace();

			bo.SetProperties(
				ef.Id,
				ef.Description,
				ef.Name,
				ef.StudioId);
			return bo;
		}

		public virtual List<BOSpace> MapEFToBO(
			List<Space> records)
		{
			List<BOSpace> response = new List<BOSpace>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5d89d2d2d6b55dd4d1adf63919a3856f</Hash>
</Codenesium>*/