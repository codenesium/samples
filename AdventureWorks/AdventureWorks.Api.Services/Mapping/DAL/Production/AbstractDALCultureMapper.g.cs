using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALCultureMapper
	{
		public virtual Culture MapModelToEntity(
			string cultureID,
			ApiCultureServerRequestModel model
			)
		{
			Culture item = new Culture();
			item.SetProperties(
				cultureID,
				model.ModifiedDate,
				model.Name);
			return item;
		}

		public virtual ApiCultureServerResponseModel MapEntityToModel(
			Culture item)
		{
			var model = new ApiCultureServerResponseModel();

			model.SetProperties(item.CultureID,
			                    item.ModifiedDate,
			                    item.Name);

			return model;
		}

		public virtual List<ApiCultureServerResponseModel> MapEntityToModel(
			List<Culture> items)
		{
			List<ApiCultureServerResponseModel> response = new List<ApiCultureServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>67152a608e59c0ac2d737d80a13a2537</Hash>
</Codenesium>*/