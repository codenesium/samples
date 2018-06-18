using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Certificate")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLCertificateActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLCertificateMapper();

                        ApiCertificateRequestModel model = new ApiCertificateRequestModel();

                        model.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A");
                        BOCertificate response = mapper.MapModelToBO("A", model);

                        response.Archived.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.EnvironmentIds.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.NotAfter.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.Subject.Should().Be("A");
                        response.TenantIds.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                        response.Thumbprint.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLCertificateMapper();

                        BOCertificate bo = new BOCertificate();

                        bo.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A");
                        ApiCertificateResponseModel response = mapper.MapBOToModel(bo);

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
                public void MapBOToModelList()
                {
                        var mapper = new BOLCertificateMapper();

                        BOCertificate bo = new BOCertificate();

                        bo.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A");
                        List<ApiCertificateResponseModel> response = mapper.MapBOToModel(new List<BOCertificate>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>2498e3c1ce82ac1267c0be4b991e8dd0</Hash>
</Codenesium>*/