using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class DALIncludedColumnTestMapper : IDALIncludedColumnTestMapper
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
    <Hash>7155be475b5565037ed70c0e12d80a3b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/