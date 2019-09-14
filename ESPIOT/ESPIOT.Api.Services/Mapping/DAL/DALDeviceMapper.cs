using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
	public class DALDeviceMapper : IDALDeviceMapper
	{
		public virtual Device MapModelToEntity(
			int id,
			ApiDeviceServerRequestModel model
			)
		{
			Device item = new Device();
			item.SetProperties(
				id,
				model.DateOfLastPing,
				model.IsActive,
				model.Name,
				model.PublicId);
			return item;
		}

		public virtual ApiDeviceServerResponseModel MapEntityToModel(
			Device item)
		{
			var model = new ApiDeviceServerResponseModel();

			model.SetProperties(item.Id,
			                    item.DateOfLastPing,
			                    item.IsActive,
			                    item.Name,
			                    item.PublicId);

			return model;
		}

		public virtual List<ApiDeviceServerResponseModel> MapEntityToModel(
			List<Device> items)
		{
			List<ApiDeviceServerResponseModel> response = new List<ApiDeviceServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>440d74a2614fab19fc39bf3b0d2c3834</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/