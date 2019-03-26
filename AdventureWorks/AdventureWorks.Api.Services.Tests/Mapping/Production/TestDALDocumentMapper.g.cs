using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Document")]
	[Trait("Area", "DALMapper")]
	public class TestDALDocumentMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALDocumentMapper();
			ApiDocumentServerRequestModel model = new ApiDocumentServerRequestModel();
			model.SetProperties(1, BitConverter.GetBytes(1), 1, "A", "A", "A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, "A");
			Document response = mapper.MapModelToEntity(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), model);

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
		public void MapEntityToModel()
		{
			var mapper = new DALDocumentMapper();
			Document item = new Document();
			item.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, BitConverter.GetBytes(1), 1, "A", "A", "A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, "A");
			ApiDocumentServerResponseModel response = mapper.MapEntityToModel(item);

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
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Status.Should().Be(1);
			response.Title.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALDocumentMapper();
			Document item = new Document();
			item.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, BitConverter.GetBytes(1), 1, "A", "A", "A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, "A");
			List<ApiDocumentServerResponseModel> response = mapper.MapEntityToModel(new List<Document>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>245ed869e2f2da76c2d64b3fe2b9155d</Hash>
</Codenesium>*/