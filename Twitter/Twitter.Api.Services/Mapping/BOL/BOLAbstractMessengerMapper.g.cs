using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class BOLAbstractMessengerMapper
	{
		public virtual BOMessenger MapModelToBO(
			int id,
			ApiMessengerRequestModel model
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

		public virtual ApiMessengerResponseModel MapBOToModel(
			BOMessenger boMessenger)
		{
			var model = new ApiMessengerResponseModel();

			model.SetProperties(boMessenger.Id, boMessenger.Date, boMessenger.FromUserId, boMessenger.MessageId, boMessenger.Time, boMessenger.ToUserId, boMessenger.UserId);

			return model;
		}

		public virtual List<ApiMessengerResponseModel> MapBOToModel(
			List<BOMessenger> items)
		{
			List<ApiMessengerResponseModel> response = new List<ApiMessengerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c8fe86a153fc1e3eb2014ec500b9b58f</Hash>
</Codenesium>*/