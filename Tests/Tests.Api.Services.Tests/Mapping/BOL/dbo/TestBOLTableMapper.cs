using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Table")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLTableMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLTableMapper();
                        ApiTableRequestModel model = new ApiTableRequestModel();
                        model.SetProperties("A");
                        BOTable response = mapper.MapModelToBO(1, model);

                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLTableMapper();
                        BOTable bo = new BOTable();
                        bo.SetProperties(1, "A");
                        ApiTableResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLTableMapper();
                        BOTable bo = new BOTable();
                        bo.SetProperties(1, "A");
                        List<ApiTableResponseModel> response = mapper.MapBOToModel(new List<BOTable>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>fd3c96051d7568200d9eec544f620043</Hash>
</Codenesium>*/