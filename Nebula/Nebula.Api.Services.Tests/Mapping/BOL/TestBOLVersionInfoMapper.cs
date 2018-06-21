using FluentAssertions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "VersionInfo")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLVersionInfoMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLVersionInfoMapper();
                        ApiVersionInfoRequestModel model = new ApiVersionInfoRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        BOVersionInfo response = mapper.MapModelToBO(1, model);

                        response.AppliedOn.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Description.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLVersionInfoMapper();
                        BOVersionInfo bo = new BOVersionInfo();
                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiVersionInfoResponseModel response = mapper.MapBOToModel(bo);

                        response.AppliedOn.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Description.Should().Be("A");
                        response.Version.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLVersionInfoMapper();
                        BOVersionInfo bo = new BOVersionInfo();
                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        List<ApiVersionInfoResponseModel> response = mapper.MapBOToModel(new List<BOVersionInfo>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>cce92234ad433a998a98bf6b36cd0109</Hash>
</Codenesium>*/