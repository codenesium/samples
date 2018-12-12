using ESPIOTNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
	public abstract class DALAbstractEfmigrationshistoryMapper
	{
		public virtual Efmigrationshistory MapBOToEF(
			BOEfmigrationshistory bo)
		{
			Efmigrationshistory efEfmigrationshistory = new Efmigrationshistory();
			efEfmigrationshistory.SetProperties(
				bo.MigrationId,
				bo.ProductVersion);
			return efEfmigrationshistory;
		}

		public virtual BOEfmigrationshistory MapEFToBO(
			Efmigrationshistory ef)
		{
			var bo = new BOEfmigrationshistory();

			bo.SetProperties(
				ef.MigrationId,
				ef.ProductVersion);
			return bo;
		}

		public virtual List<BOEfmigrationshistory> MapEFToBO(
			List<Efmigrationshistory> records)
		{
			List<BOEfmigrationshistory> response = new List<BOEfmigrationshistory>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>00490f08e8c7f9d7bf26658130a8c96b</Hash>
</Codenesium>*/