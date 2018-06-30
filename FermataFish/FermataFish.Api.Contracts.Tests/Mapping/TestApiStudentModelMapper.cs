using FermataFishNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Student")]
        [Trait("Area", "ApiModel")]
        public class TestApiStudentModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiStudentModelMapper();
                        var model = new ApiStudentRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, 1, "A", true, "A", "A", true, 1);
                        ApiStudentResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Email.Should().Be("A");
                        response.EmailRemindersEnabled.Should().Be(true);
                        response.FamilyId.Should().Be(1);
                        response.FirstName.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.IsAdult.Should().Be(true);
                        response.LastName.Should().Be("A");
                        response.Phone.Should().Be("A");
                        response.SmsRemindersEnabled.Should().Be(true);
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiStudentModelMapper();
                        var model = new ApiStudentResponseModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, 1, "A", true, "A", "A", true, 1);
                        ApiStudentRequestModel response = mapper.MapResponseToRequest(model);

                        response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Email.Should().Be("A");
                        response.EmailRemindersEnabled.Should().Be(true);
                        response.FamilyId.Should().Be(1);
                        response.FirstName.Should().Be("A");
                        response.IsAdult.Should().Be(true);
                        response.LastName.Should().Be("A");
                        response.Phone.Should().Be("A");
                        response.SmsRemindersEnabled.Should().Be(true);
                        response.StudioId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>ffdfb9acdbb16e307e223dbf599cdf7e</Hash>
</Codenesium>*/