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
	[Trait("Table", "Document")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLDocumentMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLDocumentMapper();
			ApiDocumentServerRequestModel model = new ApiDocumentServerRequestModel();
			model.SetProperties(1, BitConverter.GetBytes(1), 1, "A", "A", "A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, "A");
			BODocument response = mapper.MapModelToBO(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), model);

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
		public void MapBOToModel()
		{
			var mapper = new BOLDocumentMapper();
			BODocument bo = new BODocument();
			bo.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, BitConverter.GetBytes(1), 1, "A", "A", "A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, "A");
			ApiDocumentServerResponseModel response = mapper.MapBOToModel(bo);

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
		public void MapBOToModelList()
		{
			var mapper = new BOLDocumentMapper();
			BODocument bo = new BODocument();
			bo.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, BitConverter.GetBytes(1), 1, "A", "A", "A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, "A");
			List<ApiDocumentServerResponseModel> response = mapper.MapBOToModel(new List<BODocument>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>7b403bfdb09d0447cf854a50285adaec</Hash>
</Codenesium>*/