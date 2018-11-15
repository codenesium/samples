using Microsoft.EntityFrameworkCore;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>465d11df7b0a8c1074436b571f5e64d4</Hash>
</Codenesium>*/