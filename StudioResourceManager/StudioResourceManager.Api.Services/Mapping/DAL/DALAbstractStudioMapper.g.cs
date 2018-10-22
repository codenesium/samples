using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class DALAbstractStudioMapper
	{
		public virtual Studio MapBOToEF(
			BOStudio bo)
		{
			Studio efStudio = new Studio();
			efStudio.SetProperties(
				bo.Address1,
				bo.Address2,
				bo.City,
				bo.Id,
				bo.Name,
				bo.Province,
				bo.Website,
				bo.Zip);
			return efStudio;
		}

		public virtual BOStudio MapEFToBO(
			Studio ef)
		{
			var bo = new BOStudio();

			bo.SetProperties(
				ef.Id,
				ef.Address1,
				ef.Address2,
				ef.City,
				ef.Name,
				ef.Province,
				ef.Website,
				ef.Zip);
			return bo;
		}

		public virtual List<BOStudio> MapEFToBO(
			List<Studio> records)
		{
			List<BOStudio> response = new List<BOStudio>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>805af7daeae463c421836e97b9587073</Hash>
</Codenesium>*/