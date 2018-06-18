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
        [Trait("Table", "Invitation")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLInvitationActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLInvitationMapper();

                        ApiInvitationRequestModel model = new ApiInvitationRequestModel();

                        model.SetProperties("A", "A");
                        BOInvitation response = mapper.MapModelToBO("A", model);

                        response.InvitationCode.Should().Be("A");
                        response.JSON.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLInvitationMapper();

                        BOInvitation bo = new BOInvitation();

                        bo.SetProperties("A", "A", "A");
                        ApiInvitationResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be("A");
                        response.InvitationCode.Should().Be("A");
                        response.JSON.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLInvitationMapper();

                        BOInvitation bo = new BOInvitation();

                        bo.SetProperties("A", "A", "A");
                        List<ApiInvitationResponseModel> response = mapper.MapBOToModel(new List<BOInvitation>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>95ce3b11c1fe36289b1fcf037e5143dc</Hash>
</Codenesium>*/