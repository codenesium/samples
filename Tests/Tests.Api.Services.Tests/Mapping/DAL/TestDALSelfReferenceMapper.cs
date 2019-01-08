using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SelfReference")]
	[Trait("Area", "DALMapper")]
	public class TestDALSelfReferenceMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALSelfReferenceMapper();
			var bo = new BOSelfReference();
			bo.SetProperties(1, 1, 1);

			SelfReference response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.SelfReferenceId.Should().Be(1);
			response.SelfReferenceId2.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALSelfReferenceMapper();
			SelfReference entity = new SelfReference();
			entity.SetProperties(1, 1, 1);

			BOSelfReference response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.SelfReferenceId.Should().Be(1);
			response.SelfReferenceId2.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALSelfReferenceMapper();
			SelfReference entity = new SelfReference();
			entity.SetProperties(1, 1, 1);

			List<BOSelfReference> response = mapper.MapEFToBO(new List<SelfReference>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d839ba2fd57c7d2b63362a3348e98593</Hash>
</Codenesium>*/