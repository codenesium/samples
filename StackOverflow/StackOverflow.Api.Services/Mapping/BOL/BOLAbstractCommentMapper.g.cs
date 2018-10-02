using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractCommentMapper
	{
		public virtual BOComment MapModelToBO(
			int id,
			ApiCommentRequestModel model
			)
		{
			BOComment boComment = new BOComment();
			boComment.SetProperties(
				id,
				model.CreationDate,
				model.PostId,
				model.Score,
				model.Text,
				model.UserId);
			return boComment;
		}

		public virtual ApiCommentResponseModel MapBOToModel(
			BOComment boComment)
		{
			var model = new ApiCommentResponseModel();

			model.SetProperties(boComment.Id, boComment.CreationDate, boComment.PostId, boComment.Score, boComment.Text, boComment.UserId);

			return model;
		}

		public virtual List<ApiCommentResponseModel> MapBOToModel(
			List<BOComment> items)
		{
			List<ApiCommentResponseModel> response = new List<ApiCommentResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d2caffd74cd99eabfe5cea16f83edad3</Hash>
</Codenesium>*/