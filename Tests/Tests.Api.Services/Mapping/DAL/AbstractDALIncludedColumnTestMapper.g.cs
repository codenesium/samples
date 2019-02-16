using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractDALIncludedColumnTestMapper
	{
		public virtual IncludedColumnTest MapModelToEntity(
			int id,
			ApiIncludedColumnTestServerRequestModel model
			)
		{
			IncludedColumnTest item = new IncludedColumnTest();
			item.SetProperties(
				id,
				model.Name,
				model.Name2);
			return item;
		}

		public virtual ApiIncludedColumnTestServerResponseModel MapEntityToModel(
			IncludedColumnTest item)
		{
			var model = new ApiIncludedColumnTestServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name,
			                    item.Name2);

			return model;
		}

		public virtual List<ApiIncludedColumnTestServerResponseModel> MapEntityToModel(
			List<IncludedColumnTest> items)
		{
			List<ApiIncludedColumnTestServerResponseModel> response = new List<ApiIncludedColumnTestServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>903ad6e7c4d0e7b4c387ae9235034803</Hash>
</Codenesium>*/