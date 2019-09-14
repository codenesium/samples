using FluentAssertions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ChainStatus")]
	[Trait("Area", "DALMapper")]
	public class TestDALChainStatusMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALChainStatusMapper();
			ApiChainStatusServerRequestModel model = new ApiChainStatusServerRequestModel();
			model.SetProperties("A");
			ChainStatus response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALChainStatusMapper();
			ChainStatus item = new ChainStatus();
			item.SetProperties(1, "A");
			ApiChainStatusServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALChainStatusMapper();
			ChainStatus item = new ChainStatus();
			item.SetProperties(1, "A");
			List<ApiChainStatusServerResponseModel> response = mapper.MapEntityToModel(new List<ChainStatus>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>233e963a5c1595adefcd46913872a9bc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/