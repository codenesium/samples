using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class BOLAbstractMessengerMapper
	{
		public virtual BOMessenger MapModelToBO(
			int id,
			ApiMessengerServerRequestModel model
			)
		{
			BOMessenger boMessenger = new BOMessenger();
			boMessenger.SetProperties(
				id,
				model.Date,
				model.FromUserId,
				model.MessageId,
				model.Time,
				model.ToUserId,
				model.UserId);
			return boMessenger;
		}

		public virtual ApiMessengerServerResponseModel MapBOToModel(
			BOMessenger boMessenger)
		{
			var model = new ApiMessengerServerResponseModel();

			model.SetProperties(boMessenger.Id, boMessenger.Date, boMessenger.FromUserId, boMessenger.MessageId, boMessenger.Time, boMessenger.ToUserId, boMessenger.UserId);

			return model;
		}

		public virtual List<ApiMessengerServerResponseModel> MapBOToModel(
			List<BOMessenger> items)
		{
			List<ApiMessengerServerResponseModel> response = new List<ApiMessengerServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f6f52040bd22d963d36f7e7d090f20a5</Hash>
</Codenesium>*/