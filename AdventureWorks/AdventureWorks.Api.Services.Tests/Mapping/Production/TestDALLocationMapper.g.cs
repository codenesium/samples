using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Location")]
	[Trait("Area", "DALMapper")]
	public class TestDALLocationMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALLocationMapper();
			ApiLocationServerRequestModel model = new ApiLocationServerRequestModel();
			model.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			Location response = mapper.MapModelToEntity(1, model);

			response.Availability.Should().Be(1);
			response.CostRate.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALLocationMapper();
			Location item = new Location();
			item.SetProperties(1, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiLocationServerResponseModel response = mapper.MapEntityToModel(item);

			response.Availability.Should().Be(1);
			response.CostRate.Should().Be(1m);
			response.LocationID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALLocationMapper();
			Location item = new Location();
			item.SetProperties(1, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiLocationServerResponseModel> response = mapper.MapEntityToModel(new List<Location>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>6a696d7567e12a1138e80c9c967c7e5d</Hash>
</Codenesium>*/