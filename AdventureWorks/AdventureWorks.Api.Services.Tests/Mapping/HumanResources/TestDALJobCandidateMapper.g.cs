using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "JobCandidate")]
	[Trait("Area", "DALMapper")]
	public class TestDALJobCandidateMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new DALJobCandidateMapper();
			ApiJobCandidateServerRequestModel model = new ApiJobCandidateServerRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			JobCandidate response = mapper.MapModelToBO(1, model);

			response.BusinessEntityID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Resume.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new DALJobCandidateMapper();
			JobCandidate item = new JobCandidate();
			item.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiJobCandidateServerResponseModel response = mapper.MapBOToModel(item);

			response.BusinessEntityID.Should().Be(1);
			response.JobCandidateID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Resume.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new DALJobCandidateMapper();
			JobCandidate item = new JobCandidate();
			item.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiJobCandidateServerResponseModel> response = mapper.MapBOToModel(new List<JobCandidate>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>6e84da0c8d072b0f89e0c135d07a2298</Hash>
</Codenesium>*/