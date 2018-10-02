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
	[Trait("Table", "LinkStatu")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLLinkStatuMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLLinkStatuMapper();
			ApiLinkStatuRequestModel model = new ApiLinkStatuRequestModel();
			model.SetProperties("A");
			BOLinkStatu response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLLinkStatuMapper();
			BOLinkStatu bo = new BOLinkStatu();
			bo.SetProperties(1, "A");
			ApiLinkStatuResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLLinkStatuMapper();
			BOLinkStatu bo = new BOLinkStatu();
			bo.SetProperties(1, "A");
			List<ApiLinkStatuResponseModel> response = mapper.MapBOToModel(new List<BOLinkStatu>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>3325059a6ac8cdbab5345089b97f5ba0</Hash>
</Codenesium>*/