using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class DALAbstractLinkLogMapper
	{
		public virtual LinkLog MapBOToEF(
			BOLinkLog bo)
		{
			LinkLog efLinkLog = new LinkLog();
			efLinkLog.SetProperties(
				bo.DateEntered,
				bo.Id,
				bo.LinkId,
				bo.Log);
			return efLinkLog;
		}

		public virtual BOLinkLog MapEFToBO(
			LinkLog ef)
		{
			var bo = new BOLinkLog();

			bo.SetProperties(
				ef.Id,
				ef.DateEntered,
				ef.LinkId,
				ef.Log);
			return bo;
		}

		public virtual List<BOLinkLog> MapEFToBO(
			List<LinkLog> records)
		{
			List<BOLinkLog> response = new List<BOLinkLog>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>979a488a9a281529736952ee2816746e</Hash>
</Codenesium>*/