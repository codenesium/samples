using FluentAssertions;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Rate")]
	[Trait("Area", "DALMapper")]
	public class TestDALRateMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALRateMapper();
			var bo = new BORate();
			bo.SetProperties(1, 1m, 1, 1);

			Rate response = mapper.MapBOToEF(bo);

			response.AmountPerMinute.Should().Be(1m);
			response.Id.Should().Be(1);
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALRateMapper();
			Rate entity = new Rate();
			entity.SetProperties(1m, 1, 1, 1);

			BORate response = mapper.MapEFToBO(entity);

			response.AmountPerMinute.Should().Be(1m);
			response.Id.Should().Be(1);
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALRateMapper();
			Rate entity = new Rate();
			entity.SetProperties(1m, 1, 1, 1);

			List<BORate> response = mapper.MapEFToBO(new List<Rate>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f42e86cce50fb0980c88972274f4e11b</Hash>
</Codenesium>*/