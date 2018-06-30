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
        [Trait("Table", "Comments")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLCommentsMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLCommentsMapper();
                        ApiCommentsRequestModel model = new ApiCommentsRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1);
                        BOComments response = mapper.MapModelToBO(1, model);

                        response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PostId.Should().Be(1);
                        response.Score.Should().Be(1);
                        response.Text.Should().Be("A");
                        response.UserId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLCommentsMapper();
                        BOComments bo = new BOComments();
                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1);
                        ApiCommentsResponseModel response = mapper.MapBOToModel(bo);

                        response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Id.Should().Be(1);
                        response.PostId.Should().Be(1);
                        response.Score.Should().Be(1);
                        response.Text.Should().Be("A");
                        response.UserId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLCommentsMapper();
                        BOComments bo = new BOComments();
                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1);
                        List<ApiCommentsResponseModel> response = mapper.MapBOToModel(new List<BOComments>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>491632e1490fe1473fe29d6094625c70</Hash>
</Codenesium>*/