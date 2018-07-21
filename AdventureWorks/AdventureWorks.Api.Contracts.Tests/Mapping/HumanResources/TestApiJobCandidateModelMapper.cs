using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "JobCandidate")]
        [Trait("Area", "ApiModel")]
        public class TestApiJobCandidateModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiJobCandidateModelMapper();
                        var model = new ApiJobCandidateRequestModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiJobCandidateResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.BusinessEntityID.Should().Be(1);
                        response.JobCandidateID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Resume.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiJobCandidateModelMapper();
                        var model = new ApiJobCandidateResponseModel();
                        model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiJobCandidateRequestModel response = mapper.MapResponseToRequest(model);

                        response.BusinessEntityID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Resume.Should().Be("A");
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiJobCandidateModelMapper();
                        var model = new ApiJobCandidateRequestModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        JsonPatchDocument<ApiJobCandidateRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiJobCandidateRequestModel();
                        patch.ApplyTo(response);

                        response.BusinessEntityID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Resume.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>f5ef7d8ce8302bdf84cd9e20183e5848</Hash>
</Codenesium>*/