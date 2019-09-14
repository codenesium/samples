using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostHistoryType")]
	[Trait("Area", "DALMapper")]
	public class TestDALPostHistoryTypeMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALPostHistoryTypeMapper();
			ApiPostHistoryTypeServerRequestModel model = new ApiPostHistoryTypeServerRequestModel();
			model.SetProperties("A");
			PostHistoryType response = mapper.MapModelToEntity(1, model);

			response.RwType.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPostHistoryTypeMapper();
			PostHistoryType item = new PostHistoryType();
			item.SetProperties(1, "A");
			ApiPostHistoryTypeServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.RwType.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPostHistoryTypeMapper();
			PostHistoryType item = new PostHistoryType();
			item.SetProperties(1, "A");
			List<ApiPostHistoryTypeServerResponseModel> response = mapper.MapEntityToModel(new List<PostHistoryType>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>c4018b120b55a9165aee6a41699937a2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/