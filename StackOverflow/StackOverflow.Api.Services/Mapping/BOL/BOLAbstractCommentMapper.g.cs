using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractCommentMapper
	{
		public virtual BOComment MapModelToBO(
			int id,
			ApiCommentServerRequestModel model
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

		public virtual ApiCommentServerResponseModel MapBOToModel(
			BOComment boComment)
		{
			var model = new ApiCommentServerResponseModel();

			model.SetProperties(boComment.Id, boComment.CreationDate, boComment.PostId, boComment.Score, boComment.Text, boComment.UserId);

			return model;
		}

		public virtual List<ApiCommentServerResponseModel> MapBOToModel(
			List<BOComment> items)
		{
			List<ApiCommentServerResponseModel> response = new List<ApiCommentServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ac9ceadb45d5ee6cc0c71c4eda7d5b0a</Hash>
</Codenesium>*/