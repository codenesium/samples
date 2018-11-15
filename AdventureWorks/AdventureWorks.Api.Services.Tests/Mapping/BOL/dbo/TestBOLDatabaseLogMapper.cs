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
	[Trait("Table", "DatabaseLog")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLDatabaseLogMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLDatabaseLogMapper();
			ApiDatabaseLogServerRequestModel model = new ApiDatabaseLogServerRequestModel();
			model.SetProperties("A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");
			BODatabaseLog response = mapper.MapModelToBO(1, model);

			response.@Event.Should().Be("A");
			response.@Object.Should().Be("A");
			response.DatabaseUser.Should().Be("A");
			response.PostTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Schema.Should().Be("A");
			response.Tsql.Should().Be("A");
			response.XmlEvent.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLDatabaseLogMapper();
			BODatabaseLog bo = new BODatabaseLog();
			bo.SetProperties(1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");
			ApiDatabaseLogServerResponseModel response = mapper.MapBOToModel(bo);

			response.@Event.Should().Be("A");
			response.@Object.Should().Be("A");
			response.DatabaseLogID.Should().Be(1);
			response.DatabaseUser.Should().Be("A");
			response.PostTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Schema.Should().Be("A");
			response.Tsql.Should().Be("A");
			response.XmlEvent.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLDatabaseLogMapper();
			BODatabaseLog bo = new BODatabaseLog();
			bo.SetProperties(1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");
			List<ApiDatabaseLogServerResponseModel> response = mapper.MapBOToModel(new List<BODatabaseLog>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a8ebb6cfba4fdac336f3eeabe07e2dea</Hash>
</Codenesium>*/