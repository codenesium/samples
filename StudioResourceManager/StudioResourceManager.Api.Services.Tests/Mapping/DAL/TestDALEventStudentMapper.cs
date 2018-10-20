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
			bo.SetProperties(1, 1, true);

			EventStudent response = mapper.MapBOToEF(bo);

			response.EventId.Should().Be(1);
			response.StudentId.Should().Be(1);
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALEventStudentMapper();
			EventStudent entity = new EventStudent();
			entity.SetProperties(1, 1, true);

			BOEventStudent response = mapper.MapEFToBO(entity);

			response.EventId.Should().Be(1);
			response.StudentId.Should().Be(1);
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALEventStudentMapper();
			EventStudent entity = new EventStudent();
			entity.SetProperties(1, 1, true);

			List<BOEventStudent> response = mapper.MapEFToBO(new List<EventStudent>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>120c2a85feb0889c362bcaede2893f5c</Hash>
</Codenesium>*/