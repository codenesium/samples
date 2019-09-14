using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OffCapability")]
	[Trait("Area", "DALMapper")]
	public class TestDALOffCapabilityMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALOffCapabilityMapper();
			ApiOffCapabilityServerRequestModel model = new ApiOffCapabilityServerRequestModel();
			model.SetProperties("A");
			OffCapability response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALOffCapabilityMapper();
			OffCapability item = new OffCapability();
			item.SetProperties(1, "A");
			ApiOffCapabilityServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALOffCapabilityMapper();
			OffCapability item = new OffCapability();
			item.SetProperties(1, "A");
			List<ApiOffCapabilityServerResponseModel> response = mapper.MapEntityToModel(new List<OffCapability>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>38dce18494cfdd7d603c8635fb9bcd1b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/