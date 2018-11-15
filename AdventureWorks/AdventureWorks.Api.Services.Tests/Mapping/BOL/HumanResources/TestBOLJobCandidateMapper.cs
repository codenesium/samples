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
			ApiJobCandidateServerRequestModel model = new ApiJobCandidateServerRequestModel();
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
			ApiJobCandidateServerResponseModel response = mapper.MapBOToModel(bo);

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
			List<ApiJobCandidateServerResponseModel> response = mapper.MapBOToModel(new List<BOJobCandidate>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>9934e28556f18d9434f771d1ebfd366c</Hash>
</Codenesium>*/