using FluentAssertions;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
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
			ApiStudioRequestModel model = new ApiStudioRequestModel();
			model.SetProperties("A", "A", "A", "A", "A", "A", "A", true);
			BOStudio response = mapper.MapModelToBO(1, model);

			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.Name.Should().Be("A");
			response.Province.Should().Be("A");
			response.Website.Should().Be("A");
			response.Zip.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLStudioMapper();
			BOStudio bo = new BOStudio();
			bo.SetProperties(1, "A", "A", "A", "A", "A", "A", "A", true);
			ApiStudioResponseModel response = mapper.MapBOToModel(bo);

			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Province.Should().Be("A");
			response.Website.Should().Be("A");
			response.Zip.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLStudioMapper();
			BOStudio bo = new BOStudio();
			bo.SetProperties(1, "A", "A", "A", "A", "A", "A", "A", true);
			List<ApiStudioResponseModel> response = mapper.MapBOToModel(new List<BOStudio>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5197ec97f7e6384e4232d2c6c4fa60b0</Hash>
</Codenesium>*/