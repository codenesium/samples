using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "DatabaseLog")]
	[Trait("Area", "ApiModel")]
	public class TestApiDatabaseLogServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiDatabaseLogServerModelMapper();
			var model = new ApiDatabaseLogServerRequestModel();
			model.SetProperties("A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");
			ApiDatabaseLogServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.@Event.Should().Be("A");
			response.@Object.Should().Be("A");
			response.DatabaseUser.Should().Be("A");
			response.PostTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Schema.Should().Be("A");
			response.Tsql.Should().Be("A");
			response.XmlEvent.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiDatabaseLogServerModelMapper();
			var model = new ApiDatabaseLogServerResponseModel();
			model.SetProperties(1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");
			ApiDatabaseLogServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.@Event.Should().Be("A");
			response.@Object.Should().Be("A");
			response.DatabaseUser.Should().Be("A");
			response.PostTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Schema.Should().Be("A");
			response.Tsql.Should().Be("A");
			response.XmlEvent.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiDatabaseLogServerModelMapper();
			var model = new ApiDatabaseLogServerRequestModel();
			model.SetProperties("A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");

			JsonPatchDocument<ApiDatabaseLogServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiDatabaseLogServerRequestModel();
			patch.ApplyTo(response);
			response.@Event.Should().Be("A");
			response.@Object.Should().Be("A");
			response.DatabaseUser.Should().Be("A");
			response.PostTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Schema.Should().Be("A");
			response.Tsql.Should().Be("A");
			response.XmlEvent.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>e17b0f0983cb1b948882b7cb2b03147e</Hash>
</Codenesium>*/