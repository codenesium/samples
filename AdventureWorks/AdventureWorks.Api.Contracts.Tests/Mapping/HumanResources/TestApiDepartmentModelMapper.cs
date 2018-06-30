using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Department")]
        [Trait("Area", "ApiModel")]
        public class TestApiDepartmentModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiDepartmentModelMapper();
                        var model = new ApiDepartmentRequestModel();
                        model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiDepartmentResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.DepartmentID.Should().Be(1);
                        response.GroupName.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiDepartmentModelMapper();
                        var model = new ApiDepartmentResponseModel();
                        model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiDepartmentRequestModel response = mapper.MapResponseToRequest(model);

                        response.GroupName.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>7d048eef9043af6e2017f6c3ed86e9dc</Hash>
</Codenesium>*/