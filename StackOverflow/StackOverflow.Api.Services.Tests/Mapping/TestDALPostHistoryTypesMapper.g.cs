using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostHistoryTypes")]
	[Trait("Area", "DALMapper")]
	public class TestDALPostHistoryTypesMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALPostHistoryTypesMapper();
			ApiPostHistoryTypesServerRequestModel model = new ApiPostHistoryTypesServerRequestModel();
			model.SetProperties("A");
			PostHistoryTypes response = mapper.MapModelToEntity(1, model);

			response.RwType.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPostHistoryTypesMapper();
			PostHistoryTypes item = new PostHistoryTypes();
			item.SetProperties(1, "A");
			ApiPostHistoryTypesServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.RwType.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPostHistoryTypesMapper();
			PostHistoryTypes item = new PostHistoryTypes();
			item.SetProperties(1, "A");
			List<ApiPostHistoryTypesServerResponseModel> response = mapper.MapEntityToModel(new List<PostHistoryTypes>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>906ac66de79e6d6aeab550e50fd21301</Hash>
</Codenesium>*/