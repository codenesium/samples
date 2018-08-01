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
	[Trait("Table", "LinkLog")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLLinkLogMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLLinkLogMapper();
			ApiLinkLogRequestModel model = new ApiLinkLogRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			BOLinkLog response = mapper.MapModelToBO(1, model);

			response.DateEntered.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LinkId.Should().Be(1);
			response.Log.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLLinkLogMapper();
			BOLinkLog bo = new BOLinkLog();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			ApiLinkLogResponseModel response = mapper.MapBOToModel(bo);

			response.DateEntered.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.LinkId.Should().Be(1);
			response.Log.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLLinkLogMapper();
			BOLinkLog bo = new BOLinkLog();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			List<ApiLinkLogResponseModel> response = mapper.MapBOToModel(new List<BOLinkLog>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a1ea26b6e1d20c50dfb5e13ea5b68686</Hash>
</Codenesium>*/