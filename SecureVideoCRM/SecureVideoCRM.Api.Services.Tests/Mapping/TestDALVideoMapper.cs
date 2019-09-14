using FluentAssertions;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace SecureVideoCRMNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Video")]
	[Trait("Area", "DALMapper")]
	public class TestDALVideoMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALVideoMapper();
			ApiVideoServerRequestModel model = new ApiVideoServerRequestModel();
			model.SetProperties("A", "A", "A");
			Video response = mapper.MapModelToEntity(1, model);

			response.Description.Should().Be("A");
			response.Title.Should().Be("A");
			response.Url.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALVideoMapper();
			Video item = new Video();
			item.SetProperties(1, "A", "A", "A");
			ApiVideoServerResponseModel response = mapper.MapEntityToModel(item);

			response.Description.Should().Be("A");
			response.Id.Should().Be(1);
			response.Title.Should().Be("A");
			response.Url.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALVideoMapper();
			Video item = new Video();
			item.SetProperties(1, "A", "A", "A");
			List<ApiVideoServerResponseModel> response = mapper.MapEntityToModel(new List<Video>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5ca5bd28e4e815c094bc84f690a45ea9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/