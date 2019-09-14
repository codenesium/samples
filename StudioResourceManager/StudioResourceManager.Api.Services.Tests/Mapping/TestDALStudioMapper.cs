using FluentAssertions;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Studio")]
	[Trait("Area", "DALMapper")]
	public class TestDALStudioMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALStudioMapper();
			ApiStudioServerRequestModel model = new ApiStudioServerRequestModel();
			model.SetProperties("A", "A", "A", "A", "A", "A", "A");
			Studio response = mapper.MapModelToEntity(1, model);

			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.Name.Should().Be("A");
			response.Province.Should().Be("A");
			response.Website.Should().Be("A");
			response.Zip.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALStudioMapper();
			Studio item = new Studio();
			item.SetProperties(1, "A", "A", "A", "A", "A", "A", "A");
			ApiStudioServerResponseModel response = mapper.MapEntityToModel(item);

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
		public void MapEntityToModelList()
		{
			var mapper = new DALStudioMapper();
			Studio item = new Studio();
			item.SetProperties(1, "A", "A", "A", "A", "A", "A", "A");
			List<ApiStudioServerResponseModel> response = mapper.MapEntityToModel(new List<Studio>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>58387757ae3a1b97e250da331ca4599b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/