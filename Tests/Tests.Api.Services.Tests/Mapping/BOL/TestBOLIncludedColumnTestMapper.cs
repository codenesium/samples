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
	[Trait("Table", "IncludedColumnTest")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLIncludedColumnTestMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLIncludedColumnTestMapper();
			ApiIncludedColumnTestServerRequestModel model = new ApiIncludedColumnTestServerRequestModel();
			model.SetProperties("A", "A");
			BOIncludedColumnTest response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
			response.Name2.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLIncludedColumnTestMapper();
			BOIncludedColumnTest bo = new BOIncludedColumnTest();
			bo.SetProperties(1, "A", "A");
			ApiIncludedColumnTestServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Name2.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLIncludedColumnTestMapper();
			BOIncludedColumnTest bo = new BOIncludedColumnTest();
			bo.SetProperties(1, "A", "A");
			List<ApiIncludedColumnTestServerResponseModel> response = mapper.MapBOToModel(new List<BOIncludedColumnTest>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>20c4953dde7bd0f1b43ee7fa5f5291fb</Hash>
</Codenesium>*/