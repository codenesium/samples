using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class DALAbstractSpaceMapper
	{
		public virtual Space MapBOToEF(
			BOSpace bo)
		{
			Space efSpace = new Space();
			efSpace.SetProperties(
				bo.Description,
				bo.Id,
				bo.Name);
			return efSpace;
		}

		public virtual BOSpace MapEFToBO(
			Space ef)
		{
			var bo = new BOSpace();

			bo.SetProperties(
				ef.Id,
				ef.Description,
				ef.Name);
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
    <Hash>88765cd57bd25211c6b4fa4bd16204a5</Hash>
</Codenesium>*/