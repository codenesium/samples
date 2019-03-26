using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "DatabaseLog")]
	[Trait("Area", "ApiModel")]
	public class TestApiDatabaseLogModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiDatabaseLogModelMapper();
			var model = new ApiDatabaseLogClientRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A");
			ApiDatabaseLogClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.DatabaseUser.Should().Be("A");
			response.PostTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReservedEvent.Should().Be("A");
			response.ReservedObject.Should().Be("A");
			response.Schema.Should().Be("A");
			response.Tsql.Should().Be("A");
			response.XmlEvent.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiDatabaseLogModelMapper();
			var model = new ApiDatabaseLogClientResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A");
			ApiDatabaseLogClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.DatabaseUser.Should().Be("A");
			response.PostTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReservedEvent.Should().Be("A");
			response.ReservedObject.Should().Be("A");
			response.Schema.Should().Be("A");
			response.Tsql.Should().Be("A");
			response.XmlEvent.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>d076ec0f84cb60137e6db570d1379048</Hash>
</Codenesium>*/