using FermataFishNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Teacher")]
        [Trait("Area", "ApiModel")]
        public class TestApiTeacherModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiTeacherModelMapper();
                        var model = new ApiTeacherRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", 1);
                        ApiTeacherResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.LastName.Should().Be("A");
                        response.Phone.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiTeacherModelMapper();
                        var model = new ApiTeacherResponseModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", 1);
                        ApiTeacherRequestModel response = mapper.MapResponseToRequest(model);

                        response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.LastName.Should().Be("A");
                        response.Phone.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiTeacherModelMapper();
                        var model = new ApiTeacherRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", 1);

                        JsonPatchDocument<ApiTeacherRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiTeacherRequestModel();
                        patch.ApplyTo(response);

                        response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.LastName.Should().Be("A");
                        response.Phone.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>4ff16becb25ecf2c4bcb20900cb51a92</Hash>
</Codenesium>*/