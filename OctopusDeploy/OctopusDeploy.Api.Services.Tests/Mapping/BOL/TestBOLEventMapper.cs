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
        [Trait("Table", "Event")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLEventActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLEventMapper();

                        ApiEventRequestModel model = new ApiEventRequestModel();

                        model.SetProperties(1, "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A");
                        BOEvent response = mapper.MapModelToBO("A", model);

                        response.AutoId.Should().Be(1);
                        response.Category.Should().Be("A");
                        response.EnvironmentId.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Message.Should().Be("A");
                        response.Occurred.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.ProjectId.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.TenantId.Should().Be("A");
                        response.UserId.Should().Be("A");
                        response.Username.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLEventMapper();

                        BOEvent bo = new BOEvent();

                        bo.SetProperties("A", 1, "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A");
                        ApiEventResponseModel response = mapper.MapBOToModel(bo);

                        response.AutoId.Should().Be(1);
                        response.Category.Should().Be("A");
                        response.EnvironmentId.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Message.Should().Be("A");
                        response.Occurred.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.ProjectId.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.TenantId.Should().Be("A");
                        response.UserId.Should().Be("A");
                        response.Username.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLEventMapper();

                        BOEvent bo = new BOEvent();

                        bo.SetProperties("A", 1, "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A");
                        List<ApiEventResponseModel> response = mapper.MapBOToModel(new List<BOEvent>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>09425fc5f542cac8d267039064c18626</Hash>
</Codenesium>*/