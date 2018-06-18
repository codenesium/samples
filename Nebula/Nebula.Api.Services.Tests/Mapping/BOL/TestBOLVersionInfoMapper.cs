using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;

namespace NebulaNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "VersionInfo")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLVersionInfoActionMapper
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
    <Hash>7b05367be6d359f28d1dfb7eaf5f3877</Hash>
</Codenesium>*/