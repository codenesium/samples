using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CallStatu")]
	[Trait("Area", "DALMapper")]
	public class TestDALCallStatuMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALCallStatuMapper();
			ApiCallStatuServerRequestModel model = new ApiCallStatuServerRequestModel();
			model.SetProperties("A");
			CallStatu response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALCallStatuMapper();
			CallStatu item = new CallStatu();
			item.SetProperties(1, "A");
			ApiCallStatuServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALCallStatuMapper();
			CallStatu item = new CallStatu();
			item.SetProperties(1, "A");
			List<ApiCallStatuServerResponseModel> response = mapper.MapEntityToModel(new List<CallStatu>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ce4d3ea569a2c7b708587229bd1a1a76</Hash>
</Codenesium>*/