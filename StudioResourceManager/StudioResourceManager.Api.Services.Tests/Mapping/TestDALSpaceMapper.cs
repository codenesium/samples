using FluentAssertions;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Space")]
	[Trait("Area", "DALMapper")]
	public class TestDALSpaceMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALSpaceMapper();
			ApiSpaceServerRequestModel model = new ApiSpaceServerRequestModel();
			model.SetProperties("A", "A");
			Space response = mapper.MapModelToEntity(1, model);

			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALSpaceMapper();
			Space item = new Space();
			item.SetProperties(1, "A", "A");
			ApiSpaceServerResponseModel response = mapper.MapEntityToModel(item);

			response.Description.Should().Be("A");
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALSpaceMapper();
			Space item = new Space();
			item.SetProperties(1, "A", "A");
			List<ApiSpaceServerResponseModel> response = mapper.MapEntityToModel(new List<Space>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2970d1b729a35048ebc958a4f12037a6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/