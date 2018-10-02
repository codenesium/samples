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
	[Trait("Table", "ChainStatu")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLChainStatuMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLChainStatuMapper();
			ApiChainStatuRequestModel model = new ApiChainStatuRequestModel();
			model.SetProperties("A");
			BOChainStatu response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLChainStatuMapper();
			BOChainStatu bo = new BOChainStatu();
			bo.SetProperties(1, "A");
			ApiChainStatuResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLChainStatuMapper();
			BOChainStatu bo = new BOChainStatu();
			bo.SetProperties(1, "A");
			List<ApiChainStatuResponseModel> response = mapper.MapBOToModel(new List<BOChainStatu>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>8ead2f0b3d0c65bdad6a561f0576fa92</Hash>
</Codenesium>*/