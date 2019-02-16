using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractDALVPersonMapper
	{
		public virtual VPerson MapModelToEntity(
			int personId,
			ApiVPersonServerRequestModel model
			)
		{
			VPerson item = new VPerson();
			item.SetProperties(
				personId,
				model.PersonName);
			return item;
		}

		public virtual ApiVPersonServerResponseModel MapEntityToModel(
			VPerson item)
		{
			var model = new ApiVPersonServerResponseModel();

			model.SetProperties(item.PersonId,
			                    item.PersonName);

			return model;
		}

		public virtual List<ApiVPersonServerResponseModel> MapEntityToModel(
			List<VPerson> items)
		{
			List<ApiVPersonServerResponseModel> response = new List<ApiVPersonServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>24406c7c5e740a8ba2bc9d6a4e06b940</Hash>
</Codenesium>*/