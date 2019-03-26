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
		public void MapModelToEntity()
		{
			var mapper = new DALJobCandidateMapper();
			ApiJobCandidateServerRequestModel model = new ApiJobCandidateServerRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			JobCandidate response = mapper.MapModelToEntity(1, model);

			response.BusinessEntityID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Resume.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALJobCandidateMapper();
			JobCandidate item = new JobCandidate();
			item.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiJobCandidateServerResponseModel response = mapper.MapEntityToModel(item);

			response.BusinessEntityID.Should().Be(1);
			response.JobCandidateID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Resume.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALJobCandidateMapper();
			JobCandidate item = new JobCandidate();
			item.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiJobCandidateServerResponseModel> response = mapper.MapEntityToModel(new List<JobCandidate>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>3ea289321b50cd10db3b327ad844f0a0</Hash>
</Codenesium>*/