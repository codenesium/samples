using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Certificate")]
        [Trait("Area", "ApiModel")]
        public class TestApiCertificateModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiCertificateModelMapper();
                        var model = new ApiCertificateRequestModel();
                        model.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A");
                        ApiCertificateResponseModel response = mapper.MapRequestToResponse("A", model);

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
                public void MapResponseToRequest()
                {
                        var mapper = new ApiCertificateModelMapper();
                        var model = new ApiCertificateResponseModel();
                        model.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A");
                        ApiCertificateRequestModel response = mapper.MapResponseToRequest(model);

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
                public void CreatePatch()
                {
                        var mapper = new ApiCertificateModelMapper();
                        var model = new ApiCertificateRequestModel();
                        model.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A");

                        JsonPatchDocument<ApiCertificateRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiCertificateRequestModel();
                        patch.ApplyTo(response);

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
        }
}

/*<Codenesium>
    <Hash>d2e3ef47b133f9b2dd3aaee14186eddb</Hash>
</Codenesium>*/