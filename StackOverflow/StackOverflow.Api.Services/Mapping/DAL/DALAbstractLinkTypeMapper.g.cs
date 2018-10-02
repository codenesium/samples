using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class DALAbstractLinkTypeMapper
	{
		public virtual LinkType MapBOToEF(
			BOLinkType bo)
		{
			LinkType efLinkType = new LinkType();
			efLinkType.SetProperties(
				bo.Id,
				bo.Type);
			return efLinkType;
		}

		public virtual BOLinkType MapEFToBO(
			LinkType ef)
		{
			var bo = new BOLinkType();

			bo.SetProperties(
				ef.Id,
				ef.Type);
			return bo;
		}

		public virtual List<BOLinkType> MapEFToBO(
			List<LinkType> records)
		{
			List<BOLinkType> response = new List<BOLinkType>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>67d21c9e9ff6e55bb05650fd5e3f92b0</Hash>
</Codenesium>*/