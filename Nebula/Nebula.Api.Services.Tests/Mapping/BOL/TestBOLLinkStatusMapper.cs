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
	[Trait("Table", "LinkStatus")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLLinkStatusMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLLinkStatusMapper();
			ApiLinkStatusRequestModel model = new ApiLinkStatusRequestModel();
			model.SetProperties("A");
			BOLinkStatus response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLLinkStatusMapper();
			BOLinkStatus bo = new BOLinkStatus();
			bo.SetProperties(1, "A");
			ApiLinkStatusResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLLinkStatusMapper();
			BOLinkStatus bo = new BOLinkStatus();
			bo.SetProperties(1, "A");
			List<ApiLinkStatusResponseModel> response = mapper.MapBOToModel(new List<BOLinkStatus>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>6ef3168d35824b1fb31495ce3c722f8a</Hash>
</Codenesium>*/