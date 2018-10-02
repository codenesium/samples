using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class BOLAbstractIncludedColumnTestMapper
	{
		public virtual BOIncludedColumnTest MapModelToBO(
			int id,
			ApiIncludedColumnTestRequestModel model
			)
		{
			BOIncludedColumnTest boIncludedColumnTest = new BOIncludedColumnTest();
			boIncludedColumnTest.SetProperties(
				id,
				model.Name,
				model.Name2);
			return boIncludedColumnTest;
		}

		public virtual ApiIncludedColumnTestResponseModel MapBOToModel(
			BOIncludedColumnTest boIncludedColumnTest)
		{
			var model = new ApiIncludedColumnTestResponseModel();

			model.SetProperties(boIncludedColumnTest.Id, boIncludedColumnTest.Name, boIncludedColumnTest.Name2);

			return model;
		}

		public virtual List<ApiIncludedColumnTestResponseModel> MapBOToModel(
			List<BOIncludedColumnTest> items)
		{
			List<ApiIncludedColumnTestResponseModel> response = new List<ApiIncludedColumnTestResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>93df3b8df9603fb150e7c0915b2e4ceb</Hash>
</Codenesium>*/