using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class BOLAbstractMessageMapper
	{
		public virtual BOMessage MapModelToBO(
			int messageId,
			ApiMessageRequestModel model
			)
		{
			BOMessage boMessage = new BOMessage();
			boMessage.SetProperties(
				messageId,
				model.Content,
				model.SenderUserId);
			return boMessage;
		}

		public virtual ApiMessageResponseModel MapBOToModel(
			BOMessage boMessage)
		{
			var model = new ApiMessageResponseModel();

			model.SetProperties(boMessage.MessageId, boMessage.Content, boMessage.SenderUserId);

			return model;
		}

		public virtual List<ApiMessageResponseModel> MapBOToModel(
			List<BOMessage> items)
		{
			List<ApiMessageResponseModel> response = new List<ApiMessageResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c2a95d2ee9b303a7833b124ea8c88fca</Hash>
</Codenesium>*/