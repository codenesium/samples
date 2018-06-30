using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PostTypes")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLPostTypesMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLPostTypesMapper();
                        ApiPostTypesRequestModel model = new ApiPostTypesRequestModel();
                        model.SetProperties("A");
                        BOPostTypes response = mapper.MapModelToBO(1, model);

                        response.Type.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLPostTypesMapper();
                        BOPostTypes bo = new BOPostTypes();
                        bo.SetProperties(1, "A");
                        ApiPostTypesResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.Type.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLPostTypesMapper();
                        BOPostTypes bo = new BOPostTypes();
                        bo.SetProperties(1, "A");
                        List<ApiPostTypesResponseModel> response = mapper.MapBOToModel(new List<BOPostTypes>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>2ca91fdf1cfa3155f2f9fc4101167a39</Hash>
</Codenesium>*/