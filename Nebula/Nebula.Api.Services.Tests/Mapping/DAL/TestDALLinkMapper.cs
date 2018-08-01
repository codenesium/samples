using FluentAssertions;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Link")]
	[Trait("Area", "DALMapper")]
	public class TestDALLinkMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALLinkMapper();
			var bo = new BOLink();
			bo.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A", 1, "A", "A", 1);

			Link response = mapper.MapBOToEF(bo);

			response.AssignedMachineId.Should().Be(1);
			response.ChainId.Should().Be(1);
			response.DateCompleted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DateStarted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DynamicParameters.Should().Be("A");
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Id.Should().Be(1);
			response.LinkStatusId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Order.Should().Be(1);
			response.Response.Should().Be("A");
			response.StaticParameters.Should().Be("A");
			response.TimeoutInSeconds.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALLinkMapper();
			Link entity = new Link();
			entity.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, "A", 1, "A", "A", 1);

			BOLink response = mapper.MapEFToBO(entity);

			response.AssignedMachineId.Should().Be(1);
			response.ChainId.Should().Be(1);
			response.DateCompleted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DateStarted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DynamicParameters.Should().Be("A");
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Id.Should().Be(1);
			response.LinkStatusId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Order.Should().Be(1);
			response.Response.Should().Be("A");
			response.StaticParameters.Should().Be("A");
			response.TimeoutInSeconds.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALLinkMapper();
			Link entity = new Link();
			entity.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, "A", 1, "A", "A", 1);

			List<BOLink> response = mapper.MapEFToBO(new List<Link>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ec0d5644cc90bd87655b5236d37c532c</Hash>
</Codenesium>*/