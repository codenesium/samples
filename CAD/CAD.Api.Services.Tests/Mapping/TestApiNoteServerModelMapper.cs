using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Note")]
	[Trait("Area", "ApiModel")]
	public class TestApiNoteServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiNoteServerModelMapper();
			var model = new ApiNoteServerRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			ApiNoteServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CallId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.NoteText.Should().Be("A");
			response.OfficerId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiNoteServerModelMapper();
			var model = new ApiNoteServerResponseModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			ApiNoteServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.CallId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.NoteText.Should().Be("A");
			response.OfficerId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiNoteServerModelMapper();
			var model = new ApiNoteServerRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);

			JsonPatchDocument<ApiNoteServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiNoteServerRequestModel();
			patch.ApplyTo(response);
			response.CallId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.NoteText.Should().Be("A");
			response.OfficerId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>000e68b715e302a6414d2c7fd82d6f5b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/