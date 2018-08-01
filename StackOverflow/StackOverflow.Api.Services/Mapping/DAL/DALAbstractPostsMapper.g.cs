using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class DALAbstractPostsMapper
	{
		public virtual Posts MapBOToEF(
			BOPosts bo)
		{
			Posts efPosts = new Posts();
			efPosts.SetProperties(
				bo.AcceptedAnswerId,
				bo.AnswerCount,
				bo.Body,
				bo.ClosedDate,
				bo.CommentCount,
				bo.CommunityOwnedDate,
				bo.CreationDate,
				bo.FavoriteCount,
				bo.Id,
				bo.LastActivityDate,
				bo.LastEditDate,
				bo.LastEditorDisplayName,
				bo.LastEditorUserId,
				bo.OwnerUserId,
				bo.ParentId,
				bo.PostTypeId,
				bo.Score,
				bo.Tags,
				bo.Title,
				bo.ViewCount);
			return efPosts;
		}

		public virtual BOPosts MapEFToBO(
			Posts ef)
		{
			var bo = new BOPosts();

			bo.SetProperties(
				ef.Id,
				ef.AcceptedAnswerId,
				ef.AnswerCount,
				ef.Body,
				ef.ClosedDate,
				ef.CommentCount,
				ef.CommunityOwnedDate,
				ef.CreationDate,
				ef.FavoriteCount,
				ef.LastActivityDate,
				ef.LastEditDate,
				ef.LastEditorDisplayName,
				ef.LastEditorUserId,
				ef.OwnerUserId,
				ef.ParentId,
				ef.PostTypeId,
				ef.Score,
				ef.Tags,
				ef.Title,
				ef.ViewCount);
			return bo;
		}

		public virtual List<BOPosts> MapEFToBO(
			List<Posts> records)
		{
			List<BOPosts> response = new List<BOPosts>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a087a0c4083916ef443d30e5a6765412</Hash>
</Codenesium>*/