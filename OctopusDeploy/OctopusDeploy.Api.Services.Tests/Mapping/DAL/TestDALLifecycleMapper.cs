using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Lifecycle")]
	[Trait("Area", "DALMapper")]
	public class TestDALLifecycleMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALLifecycleMapper();
			var bo = new BOLifecycle();
			bo.SetProperties("A", BitConverter.GetBytes(1), "A", "A");

			Lifecycle response = mapper.MapBOToEF(bo);

			response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALLifecycleMapper();
			Lifecycle entity = new Lifecycle();
			entity.SetProperties(BitConverter.GetBytes(1), "A", "A", "A");

			BOLifecycle response = mapper.MapEFToBO(entity);

			response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALLifecycleMapper();
			Lifecycle entity = new Lifecycle();
			entity.SetProperties(BitConverter.GetBytes(1), "A", "A", "A");

			List<BOLifecycle> response = mapper.MapEFToBO(new List<Lifecycle>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1c8d32f189df0449568ec09aaced6035</Hash>
</Codenesium>*/