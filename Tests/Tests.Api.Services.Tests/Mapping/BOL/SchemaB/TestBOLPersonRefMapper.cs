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
	[Trait("Table", "PersonRef")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPersonRefMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPersonRefMapper();
			ApiPersonRefServerRequestModel model = new ApiPersonRefServerRequestModel();
			model.SetProperties(1, 1);
			BOPersonRef response = mapper.MapModelToBO(1, model);

			response.PersonAId.Should().Be(1);
			response.PersonBId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLPersonRefMapper();
			BOPersonRef bo = new BOPersonRef();
			bo.SetProperties(1, 1, 1);
			ApiPersonRefServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.PersonAId.Should().Be(1);
			response.PersonBId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPersonRefMapper();
			BOPersonRef bo = new BOPersonRef();
			bo.SetProperties(1, 1, 1);
			List<ApiPersonRefServerResponseModel> response = mapper.MapBOToModel(new List<BOPersonRef>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2ce38efaefecbfca61cf9850e8a42a37</Hash>
</Codenesium>*/