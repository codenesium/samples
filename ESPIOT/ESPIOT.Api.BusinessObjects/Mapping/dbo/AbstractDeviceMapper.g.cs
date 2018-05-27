using System;
using System.Collections.Generic;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
namespace ESPIOTNS.Api.BusinessObjects
{
	public abstract class AbstractBOLDeviceMapper
	{
		public virtual DTODevice MapModelToDTO(
			int id,
			ApiDeviceRequestModel model
			)
		{
			DTODevice dtoDevice = new DTODevice();

			dtoDevice.SetProperties(
				id,
				model.Name,
				model.PublicId);
			return dtoDevice;
		}

		public virtual ApiDeviceResponseModel MapDTOToModel(
			DTODevice dtoDevice)
		{
			if (dtoDevice == null)
			{
				return null;
			}

			var model = new ApiDeviceResponseModel();

			model.SetProperties(dtoDevice.Id, dtoDevice.Name, dtoDevice.PublicId);

			return model;
		}

		public virtual List<ApiDeviceResponseModel> MapDTOToModel(
			List<DTODevice> dtos)
		{
			List<ApiDeviceResponseModel> response = new List<ApiDeviceResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8bf9b2581d06191b39db91e1bb957c52</Hash>
</Codenesium>*/