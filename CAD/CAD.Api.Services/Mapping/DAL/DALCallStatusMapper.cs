using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public class DALCallStatusMapper : IDALCallStatusMapper
	{
		public virtual CallStatus MapModelToEntity(
			int id,
			ApiCallStatusServerRequestModel model
			)
		{
			CallStatus item = new CallStatus();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiCallStatusServerResponseModel MapEntityToModel(
			CallStatus item)
		{
			var model = new ApiCallStatusServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiCallStatusServerResponseModel> MapEntityToModel(
			List<CallStatus> items)
		{
			List<ApiCallStatusServerResponseModel> response = new List<ApiCallStatusServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f059549136a204f9abdec26c4b215cb5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/