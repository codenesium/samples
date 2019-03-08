using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LinkTypes")]
	[Trait("Area", "DALMapper")]
	public class TestDALLinkTypesMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALLinkTypesMapper();
			ApiLinkTypesServerRequestModel model = new ApiLinkTypesServerRequestModel();
			model.SetProperties("A");
			LinkTypes response = mapper.MapModelToEntity(1, model);

			response.RwType.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALLinkTypesMapper();
			LinkTypes item = new LinkTypes();
			item.SetProperties(1, "A");
			ApiLinkTypesServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.RwType.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALLinkTypesMapper();
			LinkTypes item = new LinkTypes();
			item.SetProperties(1, "A");
			List<ApiLinkTypesServerResponseModel> response = mapper.MapEntityToModel(new List<LinkTypes>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>eaae1ed1e663de8116079b66d223e5b9</Hash>
</Codenesium>*/