using FluentAssertions;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventTeacher")]
	[Trait("Area", "DALMapper")]
	public class TestDALEventTeacherMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALEventTeacherMapper();
			var bo = new BOEventTeacher();
			bo.SetProperties(1, 1);

			EventTeacher response = mapper.MapBOToEF(bo);

			response.EventId.Should().Be(1);
			response.Id.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALEventTeacherMapper();
			EventTeacher entity = new EventTeacher();
			entity.SetProperties(1, 1);

			BOEventTeacher response = mapper.MapEFToBO(entity);

			response.EventId.Should().Be(1);
			response.Id.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALEventTeacherMapper();
			EventTeacher entity = new EventTeacher();
			entity.SetProperties(1, 1);

			List<BOEventTeacher> response = mapper.MapEFToBO(new List<EventTeacher>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b40eda7a8888a0605691557c06bf7057</Hash>
</Codenesium>*/