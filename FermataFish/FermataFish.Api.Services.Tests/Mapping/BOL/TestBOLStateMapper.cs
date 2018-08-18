using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "State")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLStateMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLStateMapper();
			ApiStateRequestModel model = new ApiStateRequestModel();
			model.SetProperties("A");
			BOState response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLStateMapper();
			BOState bo = new BOState();
			bo.SetProperties(1, "A");
			ApiStateResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLStateMapper();
			BOState bo = new BOState();
			bo.SetProperties(1, "A");
			List<ApiStateResponseModel> response = mapper.MapBOToModel(new List<BOState>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>90f1e77a489ec9b927f6d6881a852ed0</Hash>
</Codenesium>*/