using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class DALReplyMapper : IDALReplyMapper
	{
		public virtual Reply MapModelToEntity(
			int replyId,
			ApiReplyServerRequestModel model
			)
		{
			Reply item = new Reply();
			item.SetProperties(
				replyId,
				model.Content,
				model.Date,
				model.ReplierUserId,
				model.Time);
			return item;
		}

		public virtual ApiReplyServerResponseModel MapEntityToModel(
			Reply item)
		{
			var model = new ApiReplyServerResponseModel();

			model.SetProperties(item.ReplyId,
			                    item.Content,
			                    item.Date,
			                    item.ReplierUserId,
			                    item.Time);
			if (item.ReplierUserIdNavigation != null)
			{
				var replierUserIdModel = new ApiUserServerResponseModel();
				replierUserIdModel.SetProperties(
					item.ReplierUserIdNavigation.UserId,
					item.ReplierUserIdNavigation.BioImgUrl,
					item.ReplierUserIdNavigation.Birthday,
					item.ReplierUserIdNavigation.ContentDescription,
					item.ReplierUserIdNavigation.Email,
					item.ReplierUserIdNavigation.FullName,
					item.ReplierUserIdNavigation.HeaderImgUrl,
					item.ReplierUserIdNavigation.Interest,
					item.ReplierUserIdNavigation.LocationLocationId,
					item.ReplierUserIdNavigation.Password,
					item.ReplierUserIdNavigation.PhoneNumber,
					item.ReplierUserIdNavigation.Privacy,
					item.ReplierUserIdNavigation.Username,
					item.ReplierUserIdNavigation.Website);

				model.SetReplierUserIdNavigation(replierUserIdModel);
			}

			return model;
		}

		public virtual List<ApiReplyServerResponseModel> MapEntityToModel(
			List<Reply> items)
		{
			List<ApiReplyServerResponseModel> response = new List<ApiReplyServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>aee7be7f6ded2ca71ada19592097efc8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/