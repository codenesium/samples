using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Location")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLLocationMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLLocationMapper();
			ApiLocationServerRequestModel model = new ApiLocationServerRequestModel();
			model.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			BOLocation response = mapper.MapModelToBO(1, model);

			response.Availability.Should().Be(1);
			response.CostRate.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLLocationMapper();
			BOLocation bo = new BOLocation();
			bo.SetProperties(1, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiLocationServerResponseModel response = mapper.MapBOToModel(bo);

			response.Availability.Should().Be(1);
			response.CostRate.Should().Be(1m);
			response.LocationID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLLocationMapper();
			BOLocation bo = new BOLocation();
			bo.SetProperties(1, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiLocationServerResponseModel> response = mapper.MapBOToModel(new List<BOLocation>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b459aab553718acf67c7d4f2a7b9f1c6</Hash>
</Codenesium>*/