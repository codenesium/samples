using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractDALMessageMapper
	{
		public virtual Message MapModelToEntity(
			int messageId,
			ApiMessageServerRequestModel model
			)
		{
			Message item = new Message();
			item.SetProperties(
				messageId,
				model.Content,
				model.SenderUserId);
			return item;
		}

		public virtual ApiMessageServerResponseModel MapEntityToModel(
			Message item)
		{
			var model = new ApiMessageServerResponseModel();

			model.SetProperties(item.MessageId,
			                    item.Content,
			                    item.SenderUserId);
			if (item.SenderUserIdNavigation != null)
			{
				var senderUserIdModel = new ApiUserServerResponseModel();
				senderUserIdModel.SetProperties(
					item.SenderUserIdNavigation.UserId,
					item.SenderUserIdNavigation.BioImgUrl,
					item.SenderUserIdNavigation.Birthday,
					item.SenderUserIdNavigation.ContentDescription,
					item.SenderUserIdNavigation.Email,
					item.SenderUserIdNavigation.FullName,
					item.SenderUserIdNavigation.HeaderImgUrl,
					item.SenderUserIdNavigation.Interest,
					item.SenderUserIdNavigation.LocationLocationId,
					item.SenderUserIdNavigation.Password,
					item.SenderUserIdNavigation.PhoneNumber,
					item.SenderUserIdNavigation.Privacy,
					item.SenderUserIdNavigation.Username,
					item.SenderUserIdNavigation.Website);

				model.SetSenderUserIdNavigation(senderUserIdModel);
			}

			return model;
		}

		public virtual List<ApiMessageServerResponseModel> MapEntityToModel(
			List<Message> items)
		{
			List<ApiMessageServerResponseModel> response = new List<ApiMessageServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>61c6bf765cac726c93fb58e4f5660727</Hash>
</Codenesium>*/