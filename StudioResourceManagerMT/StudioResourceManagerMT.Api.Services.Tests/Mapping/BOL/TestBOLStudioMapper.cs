using FluentAssertions;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using StudioResourceManagerMTNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Studio")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLStudioMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLStudioMapper();
			ApiStudioServerRequestModel model = new ApiStudioServerRequestModel();
			model.SetProperties("A", "A", "A", "A", "A", "A", "A");
			BOStudio response = mapper.MapModelToBO(1, model);

			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.Name.Should().Be("A");
			response.Province.Should().Be("A");
			response.Website.Should().Be("A");
			response.Zip.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLStudioMapper();
			BOStudio bo = new BOStudio();
			bo.SetProperties(1, "A", "A", "A", "A", "A", "A", "A");
			ApiStudioServerResponseModel response = mapper.MapBOToModel(bo);

			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Province.Should().Be("A");
			response.Website.Should().Be("A");
			response.Zip.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLStudioMapper();
			BOStudio bo = new BOStudio();
			bo.SetProperties(1, "A", "A", "A", "A", "A", "A", "A");
			List<ApiStudioServerResponseModel> response = mapper.MapBOToModel(new List<BOStudio>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d78a8cde156481b08b9f6e0bd7afda2f</Hash>
</Codenesium>*/