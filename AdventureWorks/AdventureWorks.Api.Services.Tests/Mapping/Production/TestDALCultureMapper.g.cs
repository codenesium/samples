using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Culture")]
	[Trait("Area", "DALMapper")]
	public class TestDALCultureMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALCultureMapper();
			ApiCultureServerRequestModel model = new ApiCultureServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			Culture response = mapper.MapModelToEntity("A", model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALCultureMapper();
			Culture item = new Culture();
			item.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiCultureServerResponseModel response = mapper.MapEntityToModel(item);

			response.CultureID.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALCultureMapper();
			Culture item = new Culture();
			item.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiCultureServerResponseModel> response = mapper.MapEntityToModel(new List<Culture>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d0e0183541d20fe3ef74404355b958a3</Hash>
</Codenesium>*/