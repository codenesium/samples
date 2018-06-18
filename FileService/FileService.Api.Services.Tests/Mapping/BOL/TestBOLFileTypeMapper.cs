using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using FileServiceNS.Api.Services;

namespace FileServiceNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "FileType")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLFileTypeActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLFileTypeMapper();

                        ApiFileTypeRequestModel model = new ApiFileTypeRequestModel();

                        model.SetProperties("A");
                        BOFileType response = mapper.MapModelToBO(1, model);

                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLFileTypeMapper();

                        BOFileType bo = new BOFileType();

                        bo.SetProperties(1, "A");
                        ApiFileTypeResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLFileTypeMapper();

                        BOFileType bo = new BOFileType();

                        bo.SetProperties(1, "A");
                        List<ApiFileTypeResponseModel> response = mapper.MapBOToModel(new List<BOFileType>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>b4f9bee81946cc1460b2aa87e2edacf7</Hash>
</Codenesium>*/