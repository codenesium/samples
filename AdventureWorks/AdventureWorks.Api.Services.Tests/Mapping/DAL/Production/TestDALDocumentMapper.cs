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
        [Trait("Area", "DALMapper")]
        public class TestDALDocumentMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALDocumentMapper();
                        var bo = new BODocument();
                        bo.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, BitConverter.GetBytes(1), 1, "A", "A", "A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, "A");

                        Document response = mapper.MapBOToEF(bo);

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
                public void MapEFToBO()
                {
                        var mapper = new DALDocumentMapper();
                        Document entity = new Document();
                        entity.SetProperties(1, BitConverter.GetBytes(1), 1, "A", "A", "A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A");

                        BODocument response = mapper.MapEFToBO(entity);

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
                public void MapEFToBOList()
                {
                        var mapper = new DALDocumentMapper();
                        Document entity = new Document();
                        entity.SetProperties(1, BitConverter.GetBytes(1), 1, "A", "A", "A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A");

                        List<BODocument> response = mapper.MapEFToBO(new List<Document>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>55085c4f6e545331d1c77e5200ddcce8</Hash>
</Codenesium>*/