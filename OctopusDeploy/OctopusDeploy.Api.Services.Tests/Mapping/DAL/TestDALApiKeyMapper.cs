using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ApiKey")]
        [Trait("Area", "DALMapper")]
        public class TestDALApiKeyActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALApiKeyMapper();

                        var bo = new BOApiKey();

                        bo.SetProperties("A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A");

                        ApiKey response = mapper.MapBOToEF(bo);

                        response.ApiKeyHashed.Should().Be("A");
                        response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.UserId.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALApiKeyMapper();

                        ApiKey entity = new ApiKey();

                        entity.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");

                        BOApiKey  response = mapper.MapEFToBO(entity);

                        response.ApiKeyHashed.Should().Be("A");
                        response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.UserId.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALApiKeyMapper();

                        ApiKey entity = new ApiKey();

                        entity.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");

                        List<BOApiKey> response = mapper.MapEFToBO(new List<ApiKey>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>fa8c12756cecd8c78309539fedc6fc57</Hash>
</Codenesium>*/