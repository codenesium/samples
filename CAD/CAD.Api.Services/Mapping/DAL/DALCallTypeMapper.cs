using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public class DALCallTypeMapper : IDALCallTypeMapper
	{
		public virtual CallType MapModelToEntity(
			int id,
			ApiCallTypeServerRequestModel model
			)
		{
			CallType item = new CallType();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiCallTypeServerResponseModel MapEntityToModel(
			CallType item)
		{
			var model = new ApiCallTypeServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiCallTypeServerResponseModel> MapEntityToModel(
			List<CallType> items)
		{
			List<ApiCallTypeServerResponseModel> response = new List<ApiCallTypeServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0ece158c3fd594660fac40defbd0e3b9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/