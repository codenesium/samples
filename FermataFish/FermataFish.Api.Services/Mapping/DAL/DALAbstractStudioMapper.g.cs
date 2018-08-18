using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
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
				bo.StateId,
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
				ef.StateId,
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
    <Hash>a8cde9e82e96ff5040ae16b2f534539d</Hash>
</Codenesium>*/