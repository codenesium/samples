using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ApiKey")]
	[Trait("Area", "DALMapper")]
	public class TestDALApiKeyMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALApiKeyMapper();
			var bo = new BOApiKey();
			bo.SetProperties("A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A");

			ApiKey response = mapper.MapBOToEF(bo);

			response.ApiKeyHashed.Should().Be("A");
			response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.UserId.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALApiKeyMapper();
			ApiKey entity = new ApiKey();
			entity.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");

			BOApiKey response = mapper.MapEFToBO(entity);

			response.ApiKeyHashed.Should().Be("A");
			response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.UserId.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALApiKeyMapper();
			ApiKey entity = new ApiKey();
			entity.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");

			List<BOApiKey> response = mapper.MapEFToBO(new List<ApiKey>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>bdca5b82ad7593f61b1b94e7a59e50c5</Hash>
</Codenesium>*/