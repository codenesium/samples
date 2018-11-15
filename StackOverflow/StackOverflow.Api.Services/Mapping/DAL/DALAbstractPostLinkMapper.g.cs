using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class DALAbstractPostLinkMapper
	{
		public virtual PostLink MapBOToEF(
			BOPostLink bo)
		{
			PostLink efPostLink = new PostLink();
			efPostLink.SetProperties(
				bo.CreationDate,
				bo.Id,
				bo.LinkTypeId,
				bo.PostId,
				bo.RelatedPostId);
			return efPostLink;
		}

		public virtual BOPostLink MapEFToBO(
			PostLink ef)
		{
			var bo = new BOPostLink();

			bo.SetProperties(
				ef.Id,
				ef.CreationDate,
				ef.LinkTypeId,
				ef.PostId,
				ef.RelatedPostId);
			return bo;
		}

		public virtual List<BOPostLink> MapEFToBO(
			List<PostLink> records)
		{
			List<BOPostLink> response = new List<BOPostLink>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>eb23d1b6d61d197ee92996fed4548f2a</Hash>
</Codenesium>*/