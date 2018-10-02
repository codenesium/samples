using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class DALAbstractPostMapper
	{
		public virtual Post MapBOToEF(
			BOPost bo)
		{
			Post efPost = new Post();
			efPost.SetProperties(
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
				bo.Tag,
				bo.Title,
				bo.ViewCount);
			return efPost;
		}

		public virtual BOPost MapEFToBO(
			Post ef)
		{
			var bo = new BOPost();

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
				ef.Tag,
				ef.Title,
				ef.ViewCount);
			return bo;
		}

		public virtual List<BOPost> MapEFToBO(
			List<Post> records)
		{
			List<BOPost> response = new List<BOPost>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ab36bd30f5b30ed9fd7a4222cbbdf27e</Hash>
</Codenesium>*/