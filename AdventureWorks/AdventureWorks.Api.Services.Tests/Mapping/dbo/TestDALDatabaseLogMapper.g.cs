using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "DatabaseLog")]
	[Trait("Area", "DALMapper")]
	public class TestDALDatabaseLogMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALDatabaseLogMapper();
			ApiDatabaseLogServerRequestModel model = new ApiDatabaseLogServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A");
			DatabaseLog response = mapper.MapModelToEntity(1, model);

			response.DatabaseUser.Should().Be("A");
			response.PostTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReservedEvent.Should().Be("A");
			response.ReservedObject.Should().Be("A");
			response.Schema.Should().Be("A");
			response.Tsql.Should().Be("A");
			response.XmlEvent.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALDatabaseLogMapper();
			DatabaseLog item = new DatabaseLog();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A");
			ApiDatabaseLogServerResponseModel response = mapper.MapEntityToModel(item);

			response.DatabaseLogID.Should().Be(1);
			response.DatabaseUser.Should().Be("A");
			response.PostTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReservedEvent.Should().Be("A");
			response.ReservedObject.Should().Be("A");
			response.Schema.Should().Be("A");
			response.Tsql.Should().Be("A");
			response.XmlEvent.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALDatabaseLogMapper();
			DatabaseLog item = new DatabaseLog();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A");
			List<ApiDatabaseLogServerResponseModel> response = mapper.MapEntityToModel(new List<DatabaseLog>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>0d14304708e22fcfd0d5cee9a1e51b91</Hash>
</Codenesium>*/