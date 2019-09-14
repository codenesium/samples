using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LinkType")]
	[Trait("Area", "DALMapper")]
	public class TestDALLinkTypeMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALLinkTypeMapper();
			ApiLinkTypeServerRequestModel model = new ApiLinkTypeServerRequestModel();
			model.SetProperties("A");
			LinkType response = mapper.MapModelToEntity(1, model);

			response.RwType.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALLinkTypeMapper();
			LinkType item = new LinkType();
			item.SetProperties(1, "A");
			ApiLinkTypeServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.RwType.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALLinkTypeMapper();
			LinkType item = new LinkType();
			item.SetProperties(1, "A");
			List<ApiLinkTypeServerResponseModel> response = mapper.MapEntityToModel(new List<LinkType>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>15287ee3f6f486a6f1ca2566af42f0fb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/