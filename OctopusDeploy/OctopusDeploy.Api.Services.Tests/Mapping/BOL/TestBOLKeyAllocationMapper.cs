using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "KeyAllocation")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLKeyAllocationMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLKeyAllocationMapper();
			ApiKeyAllocationRequestModel model = new ApiKeyAllocationRequestModel();
			model.SetProperties(1);
			BOKeyAllocation response = mapper.MapModelToBO("A", model);

			response.Allocated.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLKeyAllocationMapper();
			BOKeyAllocation bo = new BOKeyAllocation();
			bo.SetProperties("A", 1);
			ApiKeyAllocationResponseModel response = mapper.MapBOToModel(bo);

			response.Allocated.Should().Be(1);
			response.CollectionName.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLKeyAllocationMapper();
			BOKeyAllocation bo = new BOKeyAllocation();
			bo.SetProperties("A", 1);
			List<ApiKeyAllocationResponseModel> response = mapper.MapBOToModel(new List<BOKeyAllocation>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ec5139b10d90f94543c38920da01b654</Hash>
</Codenesium>*/