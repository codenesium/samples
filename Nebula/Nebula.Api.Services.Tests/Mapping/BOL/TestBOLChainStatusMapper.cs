using FluentAssertions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ChainStatus")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLChainStatusMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLChainStatusMapper();
			ApiChainStatusServerRequestModel model = new ApiChainStatusServerRequestModel();
			model.SetProperties("A");
			BOChainStatus response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLChainStatusMapper();
			BOChainStatus bo = new BOChainStatus();
			bo.SetProperties(1, "A");
			ApiChainStatusServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLChainStatusMapper();
			BOChainStatus bo = new BOChainStatus();
			bo.SetProperties(1, "A");
			List<ApiChainStatusServerResponseModel> response = mapper.MapBOToModel(new List<BOChainStatus>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>c88288fb19469c834b2bf3fcaeb58f2e</Hash>
</Codenesium>*/