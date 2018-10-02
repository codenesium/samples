using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class DALAbstractTagMapper
	{
		public virtual Tag MapBOToEF(
			BOTag bo)
		{
			Tag efTag = new Tag();
			efTag.SetProperties(
				bo.Count,
				bo.ExcerptPostId,
				bo.Id,
				bo.TagName,
				bo.WikiPostId);
			return efTag;
		}

		public virtual BOTag MapEFToBO(
			Tag ef)
		{
			var bo = new BOTag();

			bo.SetProperties(
				ef.Id,
				ef.Count,
				ef.ExcerptPostId,
				ef.TagName,
				ef.WikiPostId);
			return bo;
		}

		public virtual List<BOTag> MapEFToBO(
			List<Tag> records)
		{
			List<BOTag> response = new List<BOTag>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>90a19f076db0b4144ae8561b500334d5</Hash>
</Codenesium>*/