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
        [Trait("Table", "Votes")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLVotesMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLVotesMapper();
                        ApiVotesRequestModel model = new ApiVotesRequestModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
                        BOVotes response = mapper.MapModelToBO(1, model);

                        response.BountyAmount.Should().Be(1);
                        response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PostId.Should().Be(1);
                        response.UserId.Should().Be(1);
                        response.VoteTypeId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLVotesMapper();
                        BOVotes bo = new BOVotes();
                        bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
                        ApiVotesResponseModel response = mapper.MapBOToModel(bo);

                        response.BountyAmount.Should().Be(1);
                        response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Id.Should().Be(1);
                        response.PostId.Should().Be(1);
                        response.UserId.Should().Be(1);
                        response.VoteTypeId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLVotesMapper();
                        BOVotes bo = new BOVotes();
                        bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
                        List<ApiVotesResponseModel> response = mapper.MapBOToModel(new List<BOVotes>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>c8bf73984a82b084fad8cf70933855d6</Hash>
</Codenesium>*/