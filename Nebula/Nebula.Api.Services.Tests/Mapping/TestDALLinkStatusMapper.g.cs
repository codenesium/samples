using FluentAssertions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LinkStatus")]
	[Trait("Area", "DALMapper")]
	public class TestDALLinkStatusMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALLinkStatusMapper();
			ApiLinkStatusServerRequestModel model = new ApiLinkStatusServerRequestModel();
			model.SetProperties("A");
			LinkStatus response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALLinkStatusMapper();
			LinkStatus item = new LinkStatus();
			item.SetProperties(1, "A");
			ApiLinkStatusServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALLinkStatusMapper();
			LinkStatus item = new LinkStatus();
			item.SetProperties(1, "A");
			List<ApiLinkStatusServerResponseModel> response = mapper.MapEntityToModel(new List<LinkStatus>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f656a8db110ef3412972211d3c6a5be2</Hash>
</Codenesium>*/