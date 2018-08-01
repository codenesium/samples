using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "JobCandidate")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLJobCandidateMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLJobCandidateMapper();
			ApiJobCandidateRequestModel model = new ApiJobCandidateRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			BOJobCandidate response = mapper.MapModelToBO(1, model);

			response.BusinessEntityID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Resume.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLJobCandidateMapper();
			BOJobCandidate bo = new BOJobCandidate();
			bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiJobCandidateResponseModel response = mapper.MapBOToModel(bo);

			response.BusinessEntityID.Should().Be(1);
			response.JobCandidateID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Resume.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLJobCandidateMapper();
			BOJobCandidate bo = new BOJobCandidate();
			bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiJobCandidateResponseModel> response = mapper.MapBOToModel(new List<BOJobCandidate>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e2dcc21c858fd8041a63dc62d2231ea5</Hash>
</Codenesium>*/