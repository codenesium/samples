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
        [Trait("Table", "LibraryVariableSet")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLLibraryVariableSetActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLLibraryVariableSetMapper();

                        ApiLibraryVariableSetRequestModel model = new ApiLibraryVariableSetRequestModel();

                        model.SetProperties("A", "A", "A", "A");
                        BOLibraryVariableSet response = mapper.MapModelToBO("A", model);

                        response.ContentType.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.VariableSetId.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLLibraryVariableSetMapper();

                        BOLibraryVariableSet bo = new BOLibraryVariableSet();

                        bo.SetProperties("A", "A", "A", "A", "A");
                        ApiLibraryVariableSetResponseModel response = mapper.MapBOToModel(bo);

                        response.ContentType.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.VariableSetId.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLLibraryVariableSetMapper();

                        BOLibraryVariableSet bo = new BOLibraryVariableSet();

                        bo.SetProperties("A", "A", "A", "A", "A");
                        List<ApiLibraryVariableSetResponseModel> response = mapper.MapBOToModel(new List<BOLibraryVariableSet>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>05b243822845dd23d4eb1123ea016650</Hash>
</Codenesium>*/