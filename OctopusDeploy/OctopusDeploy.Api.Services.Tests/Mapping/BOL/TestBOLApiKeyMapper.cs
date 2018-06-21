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
        [Trait("Table", "ApiKey")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLApiKeyMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLApiKeyMapper();
                        ApiApiKeyRequestModel model = new ApiApiKeyRequestModel();
                        model.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A");
                        BOApiKey response = mapper.MapModelToBO("A", model);

                        response.ApiKeyHashed.Should().Be("A");
                        response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.JSON.Should().Be("A");
                        response.UserId.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLApiKeyMapper();
                        BOApiKey bo = new BOApiKey();
                        bo.SetProperties("A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A");
                        ApiApiKeyResponseModel response = mapper.MapBOToModel(bo);

                        response.ApiKeyHashed.Should().Be("A");
                        response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.UserId.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLApiKeyMapper();
                        BOApiKey bo = new BOApiKey();
                        bo.SetProperties("A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A");
                        List<ApiApiKeyResponseModel> response = mapper.MapBOToModel(new List<BOApiKey>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>846f423b8580abf4588e2c000a70a051</Hash>
</Codenesium>*/