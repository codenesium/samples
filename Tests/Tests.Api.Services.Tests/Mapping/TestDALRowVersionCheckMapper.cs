using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "RowVersionCheck")]
	[Trait("Area", "DALMapper")]
	public class TestDALRowVersionCheckMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALRowVersionCheckMapper();
			ApiRowVersionCheckServerRequestModel model = new ApiRowVersionCheckServerRequestModel();
			model.SetProperties("A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			RowVersionCheck response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
			response.RowVersion.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALRowVersionCheckMapper();
			RowVersionCheck item = new RowVersionCheck();
			item.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiRowVersionCheckServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.RowVersion.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALRowVersionCheckMapper();
			RowVersionCheck item = new RowVersionCheck();
			item.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			List<ApiRowVersionCheckServerResponseModel> response = mapper.MapEntityToModel(new List<RowVersionCheck>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2c502a66f2f98488d40d4902f1d5daa9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/