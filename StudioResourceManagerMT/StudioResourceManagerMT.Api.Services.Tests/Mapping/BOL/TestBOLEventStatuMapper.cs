using FluentAssertions;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using StudioResourceManagerMTNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventStatu")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLEventStatuMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLEventStatuMapper();
			ApiEventStatuServerRequestModel model = new ApiEventStatuServerRequestModel();
			model.SetProperties("A");
			BOEventStatu response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLEventStatuMapper();
			BOEventStatu bo = new BOEventStatu();
			bo.SetProperties(1, "A");
			ApiEventStatuServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLEventStatuMapper();
			BOEventStatu bo = new BOEventStatu();
			bo.SetProperties(1, "A");
			List<ApiEventStatuServerResponseModel> response = mapper.MapBOToModel(new List<BOEventStatu>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>48d9daf4dbd84f47b9b78bdbcd277fce</Hash>
</Codenesium>*/