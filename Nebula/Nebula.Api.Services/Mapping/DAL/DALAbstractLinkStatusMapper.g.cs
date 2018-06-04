using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
{
	public abstract class AbstractDALLinkStatusMapper
	{
		public virtual LinkStatus MapBOToEF(
			BOLinkStatus bo)
		{
			LinkStatus efLinkStatus = new LinkStatus ();

			efLinkStatus.SetProperties(
				bo.Id,
				bo.Name);
			return efLinkStatus;
		}

		public virtual BOLinkStatus MapEFToBO(
			LinkStatus ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOLinkStatus();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOLinkStatus> MapEFToBO(
			List<LinkStatus> records)
		{
			List<BOLinkStatus> response = new List<BOLinkStatus>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0eec3f1fff93467698c16f9a1f50234c</Hash>
</Codenesium>*/