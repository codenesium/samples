using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class DALAbstractCommentMapper
	{
		public virtual Comment MapBOToEF(
			BOComment bo)
		{
			Comment efComment = new Comment();
			efComment.SetProperties(
				bo.CreationDate,
				bo.Id,
				bo.PostId,
				bo.Score,
				bo.Text,
				bo.UserId);
			return efComment;
		}

		public virtual BOComment MapEFToBO(
			Comment ef)
		{
			var bo = new BOComment();

			bo.SetProperties(
				ef.Id,
				ef.CreationDate,
				ef.PostId,
				ef.Score,
				ef.Text,
				ef.UserId);
			return bo;
		}

		public virtual List<BOComment> MapEFToBO(
			List<Comment> records)
		{
			List<BOComment> response = new List<BOComment>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ed71d5b19f2636cf9e6edffdc5754587</Hash>
</Codenesium>*/