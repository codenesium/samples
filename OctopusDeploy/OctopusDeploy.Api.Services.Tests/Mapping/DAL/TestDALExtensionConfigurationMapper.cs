using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ExtensionConfiguration")]
        [Trait("Area", "DALMapper")]
        public class TestDALExtensionConfigurationActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALExtensionConfigurationMapper();

                        var bo = new BOExtensionConfiguration();

                        bo.SetProperties("A", "A", "A", "A");

                        ExtensionConfiguration response = mapper.MapBOToEF(bo);

                        response.ExtensionAuthor.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALExtensionConfigurationMapper();

                        ExtensionConfiguration entity = new ExtensionConfiguration();

                        entity.SetProperties("A", "A", "A", "A");

                        BOExtensionConfiguration  response = mapper.MapEFToBO(entity);

                        response.ExtensionAuthor.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALExtensionConfigurationMapper();

                        ExtensionConfiguration entity = new ExtensionConfiguration();

                        entity.SetProperties("A", "A", "A", "A");

                        List<BOExtensionConfiguration> response = mapper.MapEFToBO(new List<ExtensionConfiguration>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>7f5c75fb34c3cf076a8298f80dac9c94</Hash>
</Codenesium>*/