using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Table")]
	[Trait("Area", "DALMapper")]
	public class TestDALTableMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALTableMapper();
			ApiTableServerRequestModel model = new ApiTableServerRequestModel();
			model.SetProperties("A");
			Table response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALTableMapper();
			Table item = new Table();
			item.SetProperties(1, "A");
			ApiTableServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALTableMapper();
			Table item = new Table();
			item.SetProperties(1, "A");
			List<ApiTableServerResponseModel> response = mapper.MapEntityToModel(new List<Table>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>25ae089dcd424b9aeacfad72b8adbe6a</Hash>
</Codenesium>*/