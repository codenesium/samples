using System;
using System.Collections.Generic;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
namespace ESPIOTNS.Api.BusinessObjects
{
	public abstract class AbstractBOLDeviceActionMapper
	{
		public virtual DTODeviceAction MapModelToDTO(
			int id,
			ApiDeviceActionRequestModel model
			)
		{
			DTODeviceAction dtoDeviceAction = new DTODeviceAction();

			dtoDeviceAction.SetProperties(
				id,
				model.DeviceId,
				model.Name,
				model.@Value);
			return dtoDeviceAction;
		}

		public virtual ApiDeviceActionResponseModel MapDTOToModel(
			DTODeviceAction dtoDeviceAction)
		{
			if (dtoDeviceAction == null)
			{
				return null;
			}

			var model = new ApiDeviceActionResponseModel();

			model.SetProperties(dtoDeviceAction.DeviceId, dtoDeviceAction.Id, dtoDeviceAction.Name, dtoDeviceAction.@Value);

			return model;
		}

		public virtual List<ApiDeviceActionResponseModel> MapDTOToModel(
			List<DTODeviceAction> dtos)
		{
			List<ApiDeviceActionResponseModel> response = new List<ApiDeviceActionResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>31fcae6507a298670e3150fab2a4b3be</Hash>
</Codenesium>*/