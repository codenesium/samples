using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class BOLAbstractReplyMapper
	{
		public virtual BOReply MapModelToBO(
			int replyId,
			ApiReplyServerRequestModel model
			)
		{
			BOReply boReply = new BOReply();
			boReply.SetProperties(
				replyId,
				model.Content,
				model.Date,
				model.ReplierUserId,
				model.Time);
			return boReply;
		}

		public virtual ApiReplyServerResponseModel MapBOToModel(
			BOReply boReply)
		{
			var model = new ApiReplyServerResponseModel();

			model.SetProperties(boReply.ReplyId, boReply.Content, boReply.Date, boReply.ReplierUserId, boReply.Time);

			return model;
		}

		public virtual List<ApiReplyServerResponseModel> MapBOToModel(
			List<BOReply> items)
		{
			List<ApiReplyServerResponseModel> response = new List<ApiReplyServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>aa953e5a1be7ad8d7cc908e85e9ed5c4</Hash>
</Codenesium>*/