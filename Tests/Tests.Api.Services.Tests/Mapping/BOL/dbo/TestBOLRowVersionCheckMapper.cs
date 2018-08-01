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
	[Trait("Table", "RowVersionCheck")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLRowVersionCheckMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLRowVersionCheckMapper();
			ApiRowVersionCheckRequestModel model = new ApiRowVersionCheckRequestModel();
			model.SetProperties("A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			BORowVersionCheck response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
			response.RowVersion.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLRowVersionCheckMapper();
			BORowVersionCheck bo = new BORowVersionCheck();
			bo.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiRowVersionCheckResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.RowVersion.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLRowVersionCheckMapper();
			BORowVersionCheck bo = new BORowVersionCheck();
			bo.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			List<ApiRowVersionCheckResponseModel> response = mapper.MapBOToModel(new List<BORowVersionCheck>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f1ab80038b426da8ca2f164018e2a0c5</Hash>
</Codenesium>*/