using FluentAssertions;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventStatus")]
	[Trait("Area", "DALMapper")]
	public class TestDALEventStatusMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALEventStatusMapper();
			ApiEventStatusServerRequestModel model = new ApiEventStatusServerRequestModel();
			model.SetProperties("A");
			EventStatus response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALEventStatusMapper();
			EventStatus item = new EventStatus();
			item.SetProperties(1, "A");
			ApiEventStatusServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALEventStatusMapper();
			EventStatus item = new EventStatus();
			item.SetProperties(1, "A");
			List<ApiEventStatusServerResponseModel> response = mapper.MapEntityToModel(new List<EventStatus>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>69ecc378c8dffd6c3c6571d67f44ae09</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/