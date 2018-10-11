using FluentAssertions;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventStudent")]
	[Trait("Area", "DALMapper")]
	public class TestDALEventStudentMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALEventStudentMapper();
			var bo = new BOEventStudent();
			bo.SetProperties(1, 1);

			EventStudent response = mapper.MapBOToEF(bo);

			response.EventId.Should().Be(1);
			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALEventStudentMapper();
			EventStudent entity = new EventStudent();
			entity.SetProperties(1, 1);

			BOEventStudent response = mapper.MapEFToBO(entity);

			response.EventId.Should().Be(1);
			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALEventStudentMapper();
			EventStudent entity = new EventStudent();
			entity.SetProperties(1, 1);

			List<BOEventStudent> response = mapper.MapEFToBO(new List<EventStudent>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>60eb1e3c61c5ab8781fa830327cd0012</Hash>
</Codenesium>*/