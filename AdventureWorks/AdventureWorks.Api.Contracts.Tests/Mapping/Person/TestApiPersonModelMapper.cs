using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Person")]
        [Trait("Area", "ApiModel")]
        public class TestApiPersonModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiPersonModelMapper();
                        var model = new ApiPersonRequestModel();
                        model.SetProperties("A", "A", 1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A");
                        ApiPersonResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.AdditionalContactInfo.Should().Be("A");
                        response.BusinessEntityID.Should().Be(1);
                        response.Demographic.Should().Be("A");
                        response.EmailPromotion.Should().Be(1);
                        response.FirstName.Should().Be("A");
                        response.LastName.Should().Be("A");
                        response.MiddleName.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.NameStyle.Should().Be(true);
                        response.PersonType.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.Suffix.Should().Be("A");
                        response.Title.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiPersonModelMapper();
                        var model = new ApiPersonResponseModel();
                        model.SetProperties(1, "A", "A", 1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A");
                        ApiPersonRequestModel response = mapper.MapResponseToRequest(model);

                        response.AdditionalContactInfo.Should().Be("A");
                        response.Demographic.Should().Be("A");
                        response.EmailPromotion.Should().Be(1);
                        response.FirstName.Should().Be("A");
                        response.LastName.Should().Be("A");
                        response.MiddleName.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.NameStyle.Should().Be(true);
                        response.PersonType.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.Suffix.Should().Be("A");
                        response.Title.Should().Be("A");
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiPersonModelMapper();
                        var model = new ApiPersonRequestModel();
                        model.SetProperties("A", "A", 1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A");

                        JsonPatchDocument<ApiPersonRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiPersonRequestModel();
                        patch.ApplyTo(response);

                        response.AdditionalContactInfo.Should().Be("A");
                        response.Demographic.Should().Be("A");
                        response.EmailPromotion.Should().Be(1);
                        response.FirstName.Should().Be("A");
                        response.LastName.Should().Be("A");
                        response.MiddleName.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.NameStyle.Should().Be(true);
                        response.PersonType.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.Suffix.Should().Be("A");
                        response.Title.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>21269bfb4359468f7e44cdcd6e909318</Hash>
</Codenesium>*/