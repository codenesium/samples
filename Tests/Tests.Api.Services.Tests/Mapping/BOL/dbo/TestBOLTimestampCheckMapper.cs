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
        [Trait("Table", "TimestampCheck")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLTimestampCheckMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLTimestampCheckMapper();
                        ApiTimestampCheckRequestModel model = new ApiTimestampCheckRequestModel();
                        model.SetProperties("A", BitConverter.GetBytes(1));
                        BOTimestampCheck response = mapper.MapModelToBO(1, model);

                        response.Name.Should().Be("A");
                        response.Timestamp.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLTimestampCheckMapper();
                        BOTimestampCheck bo = new BOTimestampCheck();
                        bo.SetProperties(1, "A", BitConverter.GetBytes(1));
                        ApiTimestampCheckResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.Timestamp.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLTimestampCheckMapper();
                        BOTimestampCheck bo = new BOTimestampCheck();
                        bo.SetProperties(1, "A", BitConverter.GetBytes(1));
                        List<ApiTimestampCheckResponseModel> response = mapper.MapBOToModel(new List<BOTimestampCheck>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>03aec3925416dbbd465ee90e24773c5a</Hash>
</Codenesium>*/