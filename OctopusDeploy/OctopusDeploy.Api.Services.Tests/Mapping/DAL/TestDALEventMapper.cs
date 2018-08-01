using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Event")]
	[Trait("Area", "DALMapper")]
	public class TestDALEventMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALEventMapper();
			var bo = new BOEvent();
			bo.SetProperties("A", 1, "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A");

			Event response = mapper.MapBOToEF(bo);

			response.AutoId.Should().Be(1);
			response.Category.Should().Be("A");
			response.EnvironmentId.Should().Be("A");
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Message.Should().Be("A");
			response.Occurred.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
			response.ProjectId.Should().Be("A");
			response.RelatedDocumentIds.Should().Be("A");
			response.TenantId.Should().Be("A");
			response.UserId.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALEventMapper();
			Event entity = new Event();
			entity.SetProperties(1, "A", "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A");

			BOEvent response = mapper.MapEFToBO(entity);

			response.AutoId.Should().Be(1);
			response.Category.Should().Be("A");
			response.EnvironmentId.Should().Be("A");
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Message.Should().Be("A");
			response.Occurred.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
			response.ProjectId.Should().Be("A");
			response.RelatedDocumentIds.Should().Be("A");
			response.TenantId.Should().Be("A");
			response.UserId.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALEventMapper();
			Event entity = new Event();
			entity.SetProperties(1, "A", "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A");

			List<BOEvent> response = mapper.MapEFToBO(new List<Event>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>732c04238b73f944f4783052bfaa9684</Hash>
</Codenesium>*/