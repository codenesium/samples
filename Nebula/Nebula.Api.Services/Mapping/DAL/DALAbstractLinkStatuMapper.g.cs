using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class DALAbstractLinkStatuMapper
	{
		public virtual LinkStatu MapBOToEF(
			BOLinkStatu bo)
		{
			LinkStatu efLinkStatu = new LinkStatu();
			efLinkStatu.SetProperties(
				bo.Id,
				bo.Name);
			return efLinkStatu;
		}

		public virtual BOLinkStatu MapEFToBO(
			LinkStatu ef)
		{
			var bo = new BOLinkStatu();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOLinkStatu> MapEFToBO(
			List<LinkStatu> records)
		{
			List<BOLinkStatu> response = new List<BOLinkStatu>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2d1aa02d1350a750746b696b1b91ebdd</Hash>
</Codenesium>*/