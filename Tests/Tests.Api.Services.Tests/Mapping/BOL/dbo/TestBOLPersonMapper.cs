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
        [Trait("Table", "Person")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLPersonMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLPersonMapper();
                        ApiPersonRequestModel model = new ApiPersonRequestModel();
                        model.SetProperties("A");
                        BOPerson response = mapper.MapModelToBO(1, model);

                        response.PersonName.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLPersonMapper();
                        BOPerson bo = new BOPerson();
                        bo.SetProperties(1, "A");
                        ApiPersonResponseModel response = mapper.MapBOToModel(bo);

                        response.PersonId.Should().Be(1);
                        response.PersonName.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLPersonMapper();
                        BOPerson bo = new BOPerson();
                        bo.SetProperties(1, "A");
                        List<ApiPersonResponseModel> response = mapper.MapBOToModel(new List<BOPerson>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>86ecf8a5333a354bf064ae27d3d4d998</Hash>
</Codenesium>*/