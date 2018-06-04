using System;
using System.Collections.Generic;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
namespace ESPIOTNS.Api.Services
{
	public abstract class BOLAbstractDeviceActionMapper
	{
		public virtual BODeviceAction MapModelToBO(
			int id,
			ApiDeviceActionRequestModel model
			)
		{
			BODeviceAction BODeviceAction = new BODeviceAction();

			BODeviceAction.SetProperties(
				id,
				model.DeviceId,
				model.Name,
				model.@Value);
			return BODeviceAction;
		}

		public virtual ApiDeviceActionResponseModel MapBOToModel(
			BODeviceAction BODeviceAction)
		{
			if (BODeviceAction == null)
			{
				return null;
			}

			var model = new ApiDeviceActionResponseModel();

			model.SetProperties(BODeviceAction.DeviceId, BODeviceAction.Id, BODeviceAction.Name, BODeviceAction.@Value);

			return model;
		}

		public virtual List<ApiDeviceActionResponseModel> MapBOToModel(
			List<BODeviceAction> BOs)
		{
			List<ApiDeviceActionResponseModel> response = new List<ApiDeviceActionResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f21002230489c29e599d21b6e9b8c4e1</Hash>
</Codenesium>*/