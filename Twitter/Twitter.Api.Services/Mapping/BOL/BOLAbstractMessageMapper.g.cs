using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class BOLAbstractMessageMapper
	{
		public virtual BOMessage MapModelToBO(
			int messageId,
			ApiMessageServerRequestModel model
			)
		{
			BOMessage boMessage = new BOMessage();
			boMessage.SetProperties(
				messageId,
				model.Content,
				model.SenderUserId);
			return boMessage;
		}

		public virtual ApiMessageServerResponseModel MapBOToModel(
			BOMessage boMessage)
		{
			var model = new ApiMessageServerResponseModel();

			model.SetProperties(boMessage.MessageId, boMessage.Content, boMessage.SenderUserId);

			return model;
		}

		public virtual List<ApiMessageServerResponseModel> MapBOToModel(
			List<BOMessage> items)
		{
			List<ApiMessageServerResponseModel> response = new List<ApiMessageServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ea9ded2cb00f9f626095db636b728a19</Hash>
</Codenesium>*/