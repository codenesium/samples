using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class BOLAbstractReplyMapper
	{
		public virtual BOReply MapModelToBO(
			int replyId,
			ApiReplyRequestModel model
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

		public virtual ApiReplyResponseModel MapBOToModel(
			BOReply boReply)
		{
			var model = new ApiReplyResponseModel();

			model.SetProperties(boReply.ReplyId, boReply.Content, boReply.Date, boReply.ReplierUserId, boReply.Time);

			return model;
		}

		public virtual List<ApiReplyResponseModel> MapBOToModel(
			List<BOReply> items)
		{
			List<ApiReplyResponseModel> response = new List<ApiReplyResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d0e5eb3dc444c3e815af42f14e06df32</Hash>
</Codenesium>*/