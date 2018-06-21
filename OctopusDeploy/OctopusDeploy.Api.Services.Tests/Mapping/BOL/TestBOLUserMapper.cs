using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "User")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLUserMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLUserMapper();
                        ApiUserRequestModel model = new ApiUserRequestModel();
                        model.SetProperties("A", "A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), true, true, "A", "A");
                        BOUser response = mapper.MapModelToBO("A", model);

                        response.DisplayName.Should().Be("A");
                        response.EmailAddress.Should().Be("A");
                        response.ExternalId.Should().Be("A");
                        response.ExternalIdentifiers.Should().Be("A");
                        response.IdentificationToken.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.IsActive.Should().Be(true);
                        response.IsService.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.Username.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLUserMapper();
                        BOUser bo = new BOUser();
                        bo.SetProperties("A", "A", "A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), true, true, "A", "A");
                        ApiUserResponseModel response = mapper.MapBOToModel(bo);

                        response.DisplayName.Should().Be("A");
                        response.EmailAddress.Should().Be("A");
                        response.ExternalId.Should().Be("A");
                        response.ExternalIdentifiers.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.IdentificationToken.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.IsActive.Should().Be(true);
                        response.IsService.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.Username.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLUserMapper();
                        BOUser bo = new BOUser();
                        bo.SetProperties("A", "A", "A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), true, true, "A", "A");
                        List<ApiUserResponseModel> response = mapper.MapBOToModel(new List<BOUser>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>7ef8a182930601befab4ccdd27c6305c</Hash>
</Codenesium>*/