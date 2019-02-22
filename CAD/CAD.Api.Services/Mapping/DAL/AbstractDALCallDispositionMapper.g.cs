using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALCallDispositionMapper
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
    <Hash>70b2f209bf3e5aaa29efe879e573484e</Hash>
</Codenesium>*/