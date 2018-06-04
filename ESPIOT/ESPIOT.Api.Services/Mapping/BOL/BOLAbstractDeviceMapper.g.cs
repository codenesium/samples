using System;
using System.Collections.Generic;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
namespace ESPIOTNS.Api.Services
{
	public abstract class BOLAbstractDeviceMapper
	{
		public virtual BODevice MapModelToBO(
			int id,
			ApiDeviceRequestModel model
			)
		{
			BODevice BODevice = new BODevice();

			BODevice.SetProperties(
				id,
				model.Name,
				model.PublicId);
			return BODevice;
		}

		public virtual ApiDeviceResponseModel MapBOToModel(
			BODevice BODevice)
		{
			if (BODevice == null)
			{
				return null;
			}

			var model = new ApiDeviceResponseModel();

			model.SetProperties(BODevice.Id, BODevice.Name, BODevice.PublicId);

			return model;
		}

		public virtual List<ApiDeviceResponseModel> MapBOToModel(
			List<BODevice> BOs)
		{
			List<ApiDeviceResponseModel> response = new List<ApiDeviceResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e08fe59378361aea1aaa6b4cc65497bd</Hash>
</Codenesium>*/