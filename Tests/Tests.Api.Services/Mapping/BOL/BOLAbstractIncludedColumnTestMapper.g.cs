using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class BOLAbstractIncludedColumnTestMapper
	{
		public virtual BOIncludedColumnTest MapModelToBO(
			int id,
			ApiIncludedColumnTestServerRequestModel model
			)
		{
			BOIncludedColumnTest boIncludedColumnTest = new BOIncludedColumnTest();
			boIncludedColumnTest.SetProperties(
				id,
				model.Name,
				model.Name2);
			return boIncludedColumnTest;
		}

		public virtual ApiIncludedColumnTestServerResponseModel MapBOToModel(
			BOIncludedColumnTest boIncludedColumnTest)
		{
			var model = new ApiIncludedColumnTestServerResponseModel();

			model.SetProperties(boIncludedColumnTest.Id, boIncludedColumnTest.Name, boIncludedColumnTest.Name2);

			return model;
		}

		public virtual List<ApiIncludedColumnTestServerResponseModel> MapBOToModel(
			List<BOIncludedColumnTest> items)
		{
			List<ApiIncludedColumnTestServerResponseModel> response = new List<ApiIncludedColumnTestServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b5f0efcda9c33a4cbe795b39132e3429</Hash>
</Codenesium>*/