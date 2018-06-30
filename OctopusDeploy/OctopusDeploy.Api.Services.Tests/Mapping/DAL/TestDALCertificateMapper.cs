using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Certificate")]
        [Trait("Area", "DALMapper")]
        public class TestDALCertificateMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALCertificateMapper();
                        var bo = new BOCertificate();
                        bo.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A");

                        Certificate response = mapper.MapBOToEF(bo);

                        response.Archived.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.EnvironmentIds.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.NotAfter.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.Subject.Should().Be("A");
                        response.TenantIds.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                        response.Thumbprint.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALCertificateMapper();
                        Certificate entity = new Certificate();
                        entity.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A");

                        BOCertificate response = mapper.MapEFToBO(entity);

                        response.Archived.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.EnvironmentIds.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.NotAfter.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.Subject.Should().Be("A");
                        response.TenantIds.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                        response.Thumbprint.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALCertificateMapper();
                        Certificate entity = new Certificate();
                        entity.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A");

                        List<BOCertificate> response = mapper.MapEFToBO(new List<Certificate>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>e6ae28cc054b3622df3897c6766310a8</Hash>
</Codenesium>*/