using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using FileServiceNS.Api.Services;

namespace FileServiceNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "File")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLFileActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLFileMapper();

                        ApiFileRequestModel model = new ApiFileRequestModel();

                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, "A", "A", "A");
                        BOFile response = mapper.MapModelToBO(1, model);

                        response.BucketId.Should().Be(1);
                        response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Description.Should().Be("A");
                        response.Expiration.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Extension.Should().Be("A");
                        response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.FileSizeInBytes.Should().Be(1);
                        response.FileTypeId.Should().Be(1);
                        response.Location.Should().Be("A");
                        response.PrivateKey.Should().Be("A");
                        response.PublicKey.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLFileMapper();

                        BOFile bo = new BOFile();

                        bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, "A", "A", "A");
                        ApiFileResponseModel response = mapper.MapBOToModel(bo);

                        response.BucketId.Should().Be(1);
                        response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Description.Should().Be("A");
                        response.Expiration.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Extension.Should().Be("A");
                        response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.FileSizeInBytes.Should().Be(1);
                        response.FileTypeId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.Location.Should().Be("A");
                        response.PrivateKey.Should().Be("A");
                        response.PublicKey.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLFileMapper();

                        BOFile bo = new BOFile();

                        bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, "A", "A", "A");
                        List<ApiFileResponseModel> response = mapper.MapBOToModel(new List<BOFile>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>35206d69096f5fb05af500cc4118aad9</Hash>
</Codenesium>*/