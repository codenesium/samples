using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Document")]
        [Trait("Area", "ApiModel")]
        public class TestApiDocumentModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiDocumentModelMapper();
                        var model = new ApiDocumentRequestModel();
                        model.SetProperties(1, BitConverter.GetBytes(1), 1, "A", "A", "A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, "A");
                        ApiDocumentResponseModel response = mapper.MapRequestToResponse(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), model);

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
                public void MapResponseToRequest()
                {
                        var mapper = new ApiDocumentModelMapper();
                        var model = new ApiDocumentResponseModel();
                        model.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, BitConverter.GetBytes(1), 1, "A", "A", "A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, "A");
                        ApiDocumentRequestModel response = mapper.MapResponseToRequest(model);

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
    <Hash>9b4457513d398bbf739f8900057e3713</Hash>
</Codenesium>*/