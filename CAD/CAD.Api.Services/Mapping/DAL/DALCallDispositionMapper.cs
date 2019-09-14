using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public class DALCallDispositionMapper : IDALCallDispositionMapper
	{
		public virtual CallDisposition MapModelToEntity(
			int id,
			ApiCallDispositionServerRequestModel model
			)
		{
			CallDisposition item = new CallDisposition();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiCallDispositionServerResponseModel MapEntityToModel(
			CallDisposition item)
		{
			var model = new ApiCallDispositionServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiCallDispositionServerResponseModel> MapEntityToModel(
			List<CallDisposition> items)
		{
			List<ApiCallDispositionServerResponseModel> response = new List<ApiCallDispositionServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>731140f218c1e4a0f861a3cfc9f1e521</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/