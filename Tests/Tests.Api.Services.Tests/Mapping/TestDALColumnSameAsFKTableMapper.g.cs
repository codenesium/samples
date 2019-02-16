using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ColumnSameAsFKTable")]
	[Trait("Area", "DALMapper")]
	public class TestDALColumnSameAsFKTableMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALColumnSameAsFKTableMapper();
			ApiColumnSameAsFKTableServerRequestModel model = new ApiColumnSameAsFKTableServerRequestModel();
			model.SetProperties(1, 1);
			ColumnSameAsFKTable response = mapper.MapModelToEntity(1, model);

			response.Person.Should().Be(1);
			response.PersonId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALColumnSameAsFKTableMapper();
			ColumnSameAsFKTable item = new ColumnSameAsFKTable();
			item.SetProperties(1, 1, 1);
			ApiColumnSameAsFKTableServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Person.Should().Be(1);
			response.PersonId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALColumnSameAsFKTableMapper();
			ColumnSameAsFKTable item = new ColumnSameAsFKTable();
			item.SetProperties(1, 1, 1);
			List<ApiColumnSameAsFKTableServerResponseModel> response = mapper.MapEntityToModel(new List<ColumnSameAsFKTable>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ad8c4aff3dcf526d5a602f29f6d8f7d3</Hash>
</Codenesium>*/