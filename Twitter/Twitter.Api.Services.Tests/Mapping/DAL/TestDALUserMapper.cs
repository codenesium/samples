using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;
using TwitterNS.Api.Services;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "User")]
	[Trait("Area", "DALMapper")]
	public class TestDALUserMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALUserMapper();
			var bo = new BOUser();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", 1, "A", "A", "A", "A", "A");

			User response = mapper.MapBOToEF(bo);

			response.BioImgUrl.Should().Be("A");
			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ContentDescription.Should().Be("A");
			response.Email.Should().Be("A");
			response.FullName.Should().Be("A");
			response.HeaderImgUrl.Should().Be("A");
			response.Interest.Should().Be("A");
			response.LocationLocationId.Should().Be(1);
			response.Password.Should().Be("A");
			response.PhoneNumber.Should().Be("A");
			response.Privacy.Should().Be("A");
			response.UserId.Should().Be(1);
			response.Username.Should().Be("A");
			response.Website.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALUserMapper();
			User entity = new User();
			entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", 1, "A", "A", "A", 1, "A", "A");

			BOUser response = mapper.MapEFToBO(entity);

			response.BioImgUrl.Should().Be("A");
			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ContentDescription.Should().Be("A");
			response.Email.Should().Be("A");
			response.FullName.Should().Be("A");
			response.HeaderImgUrl.Should().Be("A");
			response.Interest.Should().Be("A");
			response.LocationLocationId.Should().Be(1);
			response.Password.Should().Be("A");
			response.PhoneNumber.Should().Be("A");
			response.Privacy.Should().Be("A");
			response.UserId.Should().Be(1);
			response.Username.Should().Be("A");
			response.Website.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALUserMapper();
			User entity = new User();
			entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", 1, "A", "A", "A", 1, "A", "A");

			List<BOUser> response = mapper.MapEFToBO(new List<User>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>0457480d5d80a824a567661db56644fe</Hash>
</Codenesium>*/