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
	[Trait("Table", "Chain")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLChainMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLChainMapper();
			ApiChainServerRequestModel model = new ApiChainServerRequestModel();
			model.SetProperties(1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);
			BOChain response = mapper.MapModelToBO(1, model);

			response.ChainStatusId.Should().Be(1);
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
			response.TeamId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLChainMapper();
			BOChain bo = new BOChain();
			bo.SetProperties(1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);
			ApiChainServerResponseModel response = mapper.MapBOToModel(bo);

			response.ChainStatusId.Should().Be(1);
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.TeamId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLChainMapper();
			BOChain bo = new BOChain();
			bo.SetProperties(1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);
			List<ApiChainServerResponseModel> response = mapper.MapBOToModel(new List<BOChain>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>74d5348f1c789018193ef6fecdd2871c</Hash>
</Codenesium>*/