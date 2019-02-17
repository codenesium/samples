using FluentAssertions;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventStatu")]
	[Trait("Area", "DALMapper")]
	public class TestDALEventStatuMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALEventStatuMapper();
			ApiEventStatuServerRequestModel model = new ApiEventStatuServerRequestModel();
			model.SetProperties("A");
			EventStatu response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALEventStatuMapper();
			EventStatu item = new EventStatu();
			item.SetProperties(1, "A");
			ApiEventStatuServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALEventStatuMapper();
			EventStatu item = new EventStatu();
			item.SetProperties(1, "A");
			List<ApiEventStatuServerResponseModel> response = mapper.MapEntityToModel(new List<EventStatu>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>466b00ded14a5a99cd98c596edba2659</Hash>
</Codenesium>*/