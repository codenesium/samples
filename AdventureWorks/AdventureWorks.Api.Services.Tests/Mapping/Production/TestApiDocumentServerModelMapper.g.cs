using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Document")]
	[Trait("Area", "ApiModel")]
	public class TestApiDocumentServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiDocumentServerModelMapper();
			var model = new ApiDocumentServerRequestModel();
			model.SetProperties(1, BitConverter.GetBytes(1), 1, "A", "A", "A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, "A");
			ApiDocumentServerResponseModel response = mapper.MapServerRequestToResponse(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), model);
			response.Should().NotBeNull();
			response.ChangeNumber.Should().Be(1);
			response.Document1.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.DocumentLevel.Should().Be(1);
			response.DocumentSummary.Should().Be("A");
			response.FileExtension.Should().Be("A");
			response.FileName.Should().Be("A");
			response.FolderFlag.Should().Be(true);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Owner.Should().Be(1);
			response.Revision.Should().Be("A");
			response.Status.Should().Be(1);
			response.Title.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiDocumentServerModelMapper();
			var model = new ApiDocumentServerResponseModel();
			model.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, BitConverter.GetBytes(1), 1, "A", "A", "A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, "A");
			ApiDocumentServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.ChangeNumber.Should().Be(1);
			response.Document1.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.DocumentLevel.Should().Be(1);
			response.DocumentSummary.Should().Be("A");
			response.FileExtension.Should().Be("A");
			response.FileName.Should().Be("A");
			response.FolderFlag.Should().Be(true);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Owner.Should().Be(1);
			response.Revision.Should().Be("A");
			response.Status.Should().Be(1);
			response.Title.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiDocumentServerModelMapper();
			var model = new ApiDocumentServerRequestModel();
			model.SetProperties(1, BitConverter.GetBytes(1), 1, "A", "A", "A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, "A");

			JsonPatchDocument<ApiDocumentServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiDocumentServerRequestModel();
			patch.ApplyTo(response);
			response.ChangeNumber.Should().Be(1);
			response.Document1.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.DocumentLevel.Should().Be(1);
			response.DocumentSummary.Should().Be("A");
			response.FileExtension.Should().Be("A");
			response.FileName.Should().Be("A");
			response.FolderFlag.Should().Be(true);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Owner.Should().Be(1);
			response.Revision.Should().Be("A");
			response.Status.Should().Be(1);
			response.Title.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>e134708d28d8950532264afca0045379</Hash>
</Codenesium>*/