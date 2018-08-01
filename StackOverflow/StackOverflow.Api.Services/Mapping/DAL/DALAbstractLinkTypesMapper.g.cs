using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class DALAbstractLinkTypesMapper
	{
		public virtual LinkTypes MapBOToEF(
			BOLinkTypes bo)
		{
			LinkTypes efLinkTypes = new LinkTypes();
			efLinkTypes.SetProperties(
				bo.Id,
				bo.Type);
			return efLinkTypes;
		}

		public virtual BOLinkTypes MapEFToBO(
			LinkTypes ef)
		{
			var bo = new BOLinkTypes();

			bo.SetProperties(
				ef.Id,
				ef.Type);
			return bo;
		}

		public virtual List<BOLinkTypes> MapEFToBO(
			List<LinkTypes> records)
		{
			List<BOLinkTypes> response = new List<BOLinkTypes>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>51127a4d315f5e48142e57e7818a9282</Hash>
</Codenesium>*/