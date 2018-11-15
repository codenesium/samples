using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class DALAbstractPostTypeMapper
	{
		public virtual PostType MapBOToEF(
			BOPostType bo)
		{
			PostType efPostType = new PostType();
			efPostType.SetProperties(
				bo.Id,
				bo.Type);
			return efPostType;
		}

		public virtual BOPostType MapEFToBO(
			PostType ef)
		{
			var bo = new BOPostType();

			bo.SetProperties(
				ef.Id,
				ef.Type);
			return bo;
		}

		public virtual List<BOPostType> MapEFToBO(
			List<PostType> records)
		{
			List<BOPostType> response = new List<BOPostType>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a34d504a09e2483bc36abd90b8bf6bb0</Hash>
</Codenesium>*/