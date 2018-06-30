using FluentAssertions;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PostTypes")]
        [Trait("Area", "DALMapper")]
        public class TestDALPostTypesMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALPostTypesMapper();
                        var bo = new BOPostTypes();
                        bo.SetProperties(1, "A");

                        PostTypes response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.Type.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALPostTypesMapper();
                        PostTypes entity = new PostTypes();
                        entity.SetProperties(1, "A");

                        BOPostTypes response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.Type.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALPostTypesMapper();
                        PostTypes entity = new PostTypes();
                        entity.SetProperties(1, "A");

                        List<BOPostTypes> response = mapper.MapEFToBO(new List<PostTypes>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>ac770bfdfeac47c42cfaa2e7ce62e823</Hash>
</Codenesium>*/