using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using FileServiceNS.Api.DataAccess;
using FileServiceNS.Api.Services;

namespace FileServiceNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "File")]
        [Trait("Area", "DALMapper")]
        public class TestDALFileActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALFileMapper();

                        var bo = new BOFile();

                        bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, "A", "A", "A");

                        File response = mapper.MapBOToEF(bo);

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
                public void MapEFToBO()
                {
                        var mapper = new DALFileMapper();

                        File entity = new File();

                        entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1, "A", "A", "A");

                        BOFile  response = mapper.MapEFToBO(entity);

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
                public void MapEFToBOList()
                {
                        var mapper = new DALFileMapper();

                        File entity = new File();

                        entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1, "A", "A", "A");

                        List<BOFile> response = mapper.MapEFToBO(new List<File>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>551637ab9188ee08a2a911062d2520ba</Hash>
</Codenesium>*/