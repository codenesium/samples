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
			model.SetProperties("A", true);
			BOEventStatus response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLEventStatusMapper();
			BOEventStatus bo = new BOEventStatus();
			bo.SetProperties(1, "A", true);
			ApiEventStatusResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLEventStatusMapper();
			BOEventStatus bo = new BOEventStatus();
			bo.SetProperties(1, "A", true);
			List<ApiEventStatusResponseModel> response = mapper.MapBOToModel(new List<BOEventStatus>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>eaaad1cea64be0d84ae1804f582bee9e</Hash>
</Codenesium>*/