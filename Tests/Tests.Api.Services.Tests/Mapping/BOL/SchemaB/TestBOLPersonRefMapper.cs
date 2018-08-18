using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PersonRef")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPersonRefMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPersonRefMapper();
			ApiPersonRefRequestModel model = new ApiPersonRefRequestModel();
			model.SetProperties(1, 1);
			BOPersonRef response = mapper.MapModelToBO(1, model);

			response.PersonAId.Should().Be(1);
			response.PersonBId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLPersonRefMapper();
			BOPersonRef bo = new BOPersonRef();
			bo.SetProperties(1, 1, 1);
			ApiPersonRefResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.PersonAId.Should().Be(1);
			response.PersonBId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPersonRefMapper();
			BOPersonRef bo = new BOPersonRef();
			bo.SetProperties(1, 1, 1);
			List<ApiPersonRefResponseModel> response = mapper.MapBOToModel(new List<BOPersonRef>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b0a70ff5c0cfde0e26e6e5fef64551f4</Hash>
</Codenesium>*/