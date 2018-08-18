using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "KeyAllocation")]
	[Trait("Area", "DALMapper")]
	public class TestDALKeyAllocationMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALKeyAllocationMapper();
			var bo = new BOKeyAllocation();
			bo.SetProperties("A", 1);

			KeyAllocation response = mapper.MapBOToEF(bo);

			response.Allocated.Should().Be(1);
			response.CollectionName.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALKeyAllocationMapper();
			KeyAllocation entity = new KeyAllocation();
			entity.SetProperties(1, "A");

			BOKeyAllocation response = mapper.MapEFToBO(entity);

			response.Allocated.Should().Be(1);
			response.CollectionName.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALKeyAllocationMapper();
			KeyAllocation entity = new KeyAllocation();
			entity.SetProperties(1, "A");

			List<BOKeyAllocation> response = mapper.MapEFToBO(new List<KeyAllocation>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>87584037e5e24fdc40a8efc5ba3f5f91</Hash>
</Codenesium>*/