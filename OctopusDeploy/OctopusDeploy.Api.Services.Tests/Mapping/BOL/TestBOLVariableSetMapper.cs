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
        [Trait("Table", "VariableSet")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLVariableSetMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLVariableSetMapper();
                        ApiVariableSetRequestModel model = new ApiVariableSetRequestModel();
                        model.SetProperties(true, "A", "A", "A", 1);
                        BOVariableSet response = mapper.MapModelToBO("A", model);

                        response.IsFrozen.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.OwnerId.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.Version.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLVariableSetMapper();
                        BOVariableSet bo = new BOVariableSet();
                        bo.SetProperties("A", true, "A", "A", "A", 1);
                        ApiVariableSetResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be("A");
                        response.IsFrozen.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.OwnerId.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.Version.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLVariableSetMapper();
                        BOVariableSet bo = new BOVariableSet();
                        bo.SetProperties("A", true, "A", "A", "A", 1);
                        List<ApiVariableSetResponseModel> response = mapper.MapBOToModel(new List<BOVariableSet>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>950fe6b3453a2cb4040e1ef3b654b8ce</Hash>
</Codenesium>*/