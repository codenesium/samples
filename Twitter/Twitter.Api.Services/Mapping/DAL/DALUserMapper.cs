using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class DALUserMapper : IDALUserMapper
	{
		public virtual User MapModelToEntity(
			int userId,
			ApiUserServerRequestModel model
			)
		{
			User item = new User();
			item.SetProperties(
				userId,
				model.BioImgUrl,
				model.Birthday,
				model.ContentDescription,
				model.Email,
				model.FullName,
				model.HeaderImgUrl,
				model.Interest,
				model.LocationLocationId,
				model.Password,
				model.PhoneNumber,
				model.Privacy,
				model.Username,
				model.Website);
			return item;
		}

		public virtual ApiUserServerResponseModel MapEntityToModel(
			User item)
		{
			var model = new ApiUserServerResponseModel();

			model.SetProperties(item.UserId,
			                    item.BioImgUrl,
			                    item.Birthday,
			                    item.ContentDescription,
			                    item.Email,
			                    item.FullName,
			                    item.HeaderImgUrl,
			                    item.Interest,
			                    item.LocationLocationId,
			                    item.Password,
			                    item.PhoneNumber,
			                    item.Privacy,
			                    item.Username,
			                    item.Website);
			if (item.LocationLocationIdNavigation != null)
			{
				var locationLocationIdModel = new ApiLocationServerResponseModel();
				locationLocationIdModel.SetProperties(
					item.LocationLocationIdNavigation.LocationId,
					item.LocationLocationIdNavigation.GpsLat,
					item.LocationLocationIdNavigation.GpsLong,
					item.LocationLocationIdNavigation.LocationName);

				model.SetLocationLocationIdNavigation(locationLocationIdModel);
			}

			return model;
		}

		public virtual List<ApiUserServerResponseModel> MapEntityToModel(
			List<User> items)
		{
			List<ApiUserServerResponseModel> response = new List<ApiUserServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>569189748567dd9892f324d1144e4e10</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/