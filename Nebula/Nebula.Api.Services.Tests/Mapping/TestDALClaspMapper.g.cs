using FluentAssertions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Clasp")]
	[Trait("Area", "DALMapper")]
	public class TestDALClaspMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALClaspMapper();
			ApiClaspServerRequestModel model = new ApiClaspServerRequestModel();
			model.SetProperties(1, 1);
			Clasp response = mapper.MapModelToEntity(1, model);

			response.NextChainId.Should().Be(1);
			response.PreviousChainId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALClaspMapper();
			Clasp item = new Clasp();
			item.SetProperties(1, 1, 1);
			ApiClaspServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.NextChainId.Should().Be(1);
			response.PreviousChainId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALClaspMapper();
			Clasp item = new Clasp();
			item.SetProperties(1, 1, 1);
			List<ApiClaspServerResponseModel> response = mapper.MapEntityToModel(new List<Clasp>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5f2fc454349e6086ace2cdc7941686f4</Hash>
</Codenesium>*/