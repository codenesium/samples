using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractDALMessengerMapper
	{
		public virtual Messenger MapModelToEntity(
			int id,
			ApiMessengerServerRequestModel model
			)
		{
			Messenger item = new Messenger();
			item.SetProperties(
				id,
				model.Date,
				model.FromUserId,
				model.MessageId,
				model.Time,
				model.ToUserId,
				model.UserId);
			return item;
		}

		public virtual ApiMessengerServerResponseModel MapEntityToModel(
			Messenger item)
		{
			var model = new ApiMessengerServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Date,
			                    item.FromUserId,
			                    item.MessageId,
			                    item.Time,
			                    item.ToUserId,
			                    item.UserId);
			if (item.MessageIdNavigation != null)
			{
				var messageIdModel = new ApiMessageServerResponseModel();
				messageIdModel.SetProperties(
					item.MessageIdNavigation.MessageId,
					item.MessageIdNavigation.Content,
					item.MessageIdNavigation.SenderUserId);

				model.SetMessageIdNavigation(messageIdModel);
			}

			if (item.ToUserIdNavigation != null)
			{
				var toUserIdModel = new ApiUserServerResponseModel();
				toUserIdModel.SetProperties(
					item.ToUserIdNavigation.UserId,
					item.ToUserIdNavigation.BioImgUrl,
					item.ToUserIdNavigation.Birthday,
					item.ToUserIdNavigation.ContentDescription,
					item.ToUserIdNavigation.Email,
					item.ToUserIdNavigation.FullName,
					item.ToUserIdNavigation.HeaderImgUrl,
					item.ToUserIdNavigation.Interest,
					item.ToUserIdNavigation.LocationLocationId,
					item.ToUserIdNavigation.Password,
					item.ToUserIdNavigation.PhoneNumber,
					item.ToUserIdNavigation.Privacy,
					item.ToUserIdNavigation.Username,
					item.ToUserIdNavigation.Website);

				model.SetToUserIdNavigation(toUserIdModel);
			}

			if (item.UserIdNavigation != null)
			{
				var userIdModel = new ApiUserServerResponseModel();
				userIdModel.SetProperties(
					item.UserIdNavigation.UserId,
					item.UserIdNavigation.BioImgUrl,
					item.UserIdNavigation.Birthday,
					item.UserIdNavigation.ContentDescription,
					item.UserIdNavigation.Email,
					item.UserIdNavigation.FullName,
					item.UserIdNavigation.HeaderImgUrl,
					item.UserIdNavigation.Interest,
					item.UserIdNavigation.LocationLocationId,
					item.UserIdNavigation.Password,
					item.UserIdNavigation.PhoneNumber,
					item.UserIdNavigation.Privacy,
					item.UserIdNavigation.Username,
					item.UserIdNavigation.Website);

				model.SetUserIdNavigation(userIdModel);
			}

			return model;
		}

		public virtual List<ApiMessengerServerResponseModel> MapEntityToModel(
			List<Messenger> items)
		{
			List<ApiMessengerServerResponseModel> response = new List<ApiMessengerServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>dfb0f385d4a0fd2612bb2614bf3a2f13</Hash>
</Codenesium>*/