using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class DALAbstractCommentsMapper
	{
		public virtual Comments MapBOToEF(
			BOComments bo)
		{
			Comments efComments = new Comments();
			efComments.SetProperties(
				bo.CreationDate,
				bo.Id,
				bo.PostId,
				bo.Score,
				bo.Text,
				bo.UserId);
			return efComments;
		}

		public virtual BOComments MapEFToBO(
			Comments ef)
		{
			var bo = new BOComments();

			bo.SetProperties(
				ef.Id,
				ef.CreationDate,
				ef.PostId,
				ef.Score,
				ef.Text,
				ef.UserId);
			return bo;
		}

		public virtual List<BOComments> MapEFToBO(
			List<Comments> records)
		{
			List<BOComments> response = new List<BOComments>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2394f46e6b9006473ec38fffd850952d</Hash>
</Codenesium>*/