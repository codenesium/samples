using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class DALAbstractRowVersionCheckMapper
	{
		public virtual RowVersionCheck MapBOToEF(
			BORowVersionCheck bo)
		{
			RowVersionCheck efRowVersionCheck = new RowVersionCheck();
			efRowVersionCheck.SetProperties(
				bo.Id,
				bo.Name,
				bo.RowVersion);
			return efRowVersionCheck;
		}

		public virtual BORowVersionCheck MapEFToBO(
			RowVersionCheck ef)
		{
			var bo = new BORowVersionCheck();

			bo.SetProperties(
				ef.Id,
				ef.Name,
				ef.RowVersion);
			return bo;
		}

		public virtual List<BORowVersionCheck> MapEFToBO(
			List<RowVersionCheck> records)
		{
			List<BORowVersionCheck> response = new List<BORowVersionCheck>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fad60423d7c63ab5539eecee7d0d0832</Hash>
</Codenesium>*/