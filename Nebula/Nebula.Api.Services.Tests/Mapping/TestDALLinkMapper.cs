using FluentAssertions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Link")]
	[Trait("Area", "DALMapper")]
	public class TestDALLinkMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALLinkMapper();
			ApiLinkServerRequestModel model = new ApiLinkServerRequestModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A", 1, "A", "A", 1);
			Link response = mapper.MapModelToEntity(1, model);

			response.AssignedMachineId.Should().Be(1);
			response.ChainId.Should().Be(1);
			response.DateCompleted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DateStarted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DynamicParameters.Should().Be("A");
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.LinkStatusId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Order.Should().Be(1);
			response.Response.Should().Be("A");
			response.StaticParameters.Should().Be("A");
			response.TimeoutInSeconds.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALLinkMapper();
			Link item = new Link();
			item.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A", 1, "A", "A", 1);
			ApiLinkServerResponseModel response = mapper.MapEntityToModel(item);

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
		public void MapEntityToModelList()
		{
			var mapper = new DALLinkMapper();
			Link item = new Link();
			item.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A", 1, "A", "A", 1);
			List<ApiLinkServerResponseModel> response = mapper.MapEntityToModel(new List<Link>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f291d18b77f016f99f98535f96486dbd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/