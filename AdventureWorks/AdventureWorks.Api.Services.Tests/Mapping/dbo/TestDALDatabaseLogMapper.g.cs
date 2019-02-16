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
		public void MapModelToBO()
		{
			var mapper = new DALDatabaseLogMapper();
			ApiDatabaseLogServerRequestModel model = new ApiDatabaseLogServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");
			DatabaseLog response = mapper.MapModelToBO(1, model);

			response.DatabaseUser.Should().Be("A");
			response.PostTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Schema.Should().Be("A");
			response.Tsql.Should().Be("A");
			response.XmlEvent.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new DALDatabaseLogMapper();
			DatabaseLog item = new DatabaseLog();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");
			ApiDatabaseLogServerResponseModel response = mapper.MapBOToModel(item);

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
			var mapper = new DALDatabaseLogMapper();
			DatabaseLog item = new DatabaseLog();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");
			List<ApiDatabaseLogServerResponseModel> response = mapper.MapBOToModel(new List<DatabaseLog>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>0ce2aef19fa5533bf0a393855cca3187</Hash>
</Codenesium>*/