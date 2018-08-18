using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class DALAbstractPostLinksMapper
	{
		public virtual PostLinks MapBOToEF(
			BOPostLinks bo)
		{
			PostLinks efPostLinks = new PostLinks();
			efPostLinks.SetProperties(
				bo.CreationDate,
				bo.Id,
				bo.LinkTypeId,
				bo.PostId,
				bo.RelatedPostId);
			return efPostLinks;
		}

		public virtual BOPostLinks MapEFToBO(
			PostLinks ef)
		{
			var bo = new BOPostLinks();

			bo.SetProperties(
				ef.Id,
				ef.CreationDate,
				ef.LinkTypeId,
				ef.PostId,
				ef.RelatedPostId);
			return bo;
		}

		public virtual List<BOPostLinks> MapEFToBO(
			List<PostLinks> records)
		{
			List<BOPostLinks> response = new List<BOPostLinks>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4cf0770e7379a03b8e60ed395b211fd7</Hash>
</Codenesium>*/