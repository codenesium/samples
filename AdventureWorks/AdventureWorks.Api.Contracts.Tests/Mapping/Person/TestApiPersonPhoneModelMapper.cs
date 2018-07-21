using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PersonPhone")]
        [Trait("Area", "ApiModel")]
        public class TestApiPersonPhoneModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiPersonPhoneModelMapper();
                        var model = new ApiPersonPhoneRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
                        ApiPersonPhoneResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.BusinessEntityID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PhoneNumber.Should().Be("A");
                        response.PhoneNumberTypeID.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiPersonPhoneModelMapper();
                        var model = new ApiPersonPhoneResponseModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
                        ApiPersonPhoneRequestModel response = mapper.MapResponseToRequest(model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PhoneNumber.Should().Be("A");
                        response.PhoneNumberTypeID.Should().Be(1);
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiPersonPhoneModelMapper();
                        var model = new ApiPersonPhoneRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);

                        JsonPatchDocument<ApiPersonPhoneRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiPersonPhoneRequestModel();
                        patch.ApplyTo(response);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PhoneNumber.Should().Be("A");
                        response.PhoneNumberTypeID.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>3c66a8a5162a69bd96b93ae201aef297</Hash>
</Codenesium>*/