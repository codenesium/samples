using FluentAssertions;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventStatus")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLEventStatusMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLEventStatusMapper();
			ApiEventStatusRequestModel model = new ApiEventStatusRequestModel();
			model.SetProperties("A");
			BOEventStatus response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLEventStatusMapper();
			BOEventStatus bo = new BOEventStatus();
			bo.SetProperties(1, "A");
			ApiEventStatusResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLEventStatusMapper();
			BOEventStatus bo = new BOEventStatus();
			bo.SetProperties(1, "A");
			List<ApiEventStatusResponseModel> response = mapper.MapBOToModel(new List<BOEventStatus>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>36cf9f53d1bb3e23f9320fb30f8c7d88</Hash>
</Codenesium>*/