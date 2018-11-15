using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LinkLog")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiLinkLogServerRequestModelValidatorTest
	{
		public ApiLinkLogServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void LinkId_Create_Valid_Reference()
		{
			Mock<ILinkLogRepository> linkLogRepository = new Mock<ILinkLogRepository>();
			linkLogRepository.Setup(x => x.LinkByLinkId(It.IsAny<int>())).Returns(Task.FromResult<Link>(new Link()));

			var validator = new ApiLinkLogServerRequestModelValidator(linkLogRepository.Object);
			await validator.ValidateCreateAsync(new ApiLinkLogServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LinkId, 1);
		}

		[Fact]
		public async void LinkId_Create_Invalid_Reference()
		{
			Mock<ILinkLogRepository> linkLogRepository = new Mock<ILinkLogRepository>();
			linkLogRepository.Setup(x => x.LinkByLinkId(It.IsAny<int>())).Returns(Task.FromResult<Link>(null));

			var validator = new ApiLinkLogServerRequestModelValidator(linkLogRepository.Object);

			await validator.ValidateCreateAsync(new ApiLinkLogServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LinkId, 1);
		}

		[Fact]
		public async void LinkId_Update_Valid_Reference()
		{
			Mock<ILinkLogRepository> linkLogRepository = new Mock<ILinkLogRepository>();
			linkLogRepository.Setup(x => x.LinkByLinkId(It.IsAny<int>())).Returns(Task.FromResult<Link>(new Link()));

			var validator = new ApiLinkLogServerRequestModelValidator(linkLogRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLinkLogServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LinkId, 1);
		}

		[Fact]
		public async void LinkId_Update_Invalid_Reference()
		{
			Mock<ILinkLogRepository> linkLogRepository = new Mock<ILinkLogRepository>();
			linkLogRepository.Setup(x => x.LinkByLinkId(It.IsAny<int>())).Returns(Task.FromResult<Link>(null));

			var validator = new ApiLinkLogServerRequestModelValidator(linkLogRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiLinkLogServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LinkId, 1);
		}

		[Fact]
		public async void Log_Create_null()
		{
			Mock<ILinkLogRepository> linkLogRepository = new Mock<ILinkLogRepository>();
			linkLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkLog()));

			var validator = new ApiLinkLogServerRequestModelValidator(linkLogRepository.Object);
			await validator.ValidateCreateAsync(new ApiLinkLogServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Log, null as string);
		}

		[Fact]
		public async void Log_Update_null()
		{
			Mock<ILinkLogRepository> linkLogRepository = new Mock<ILinkLogRepository>();
			linkLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkLog()));

			var validator = new ApiLinkLogServerRequestModelValidator(linkLogRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLinkLogServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Log, null as string);
		}
	}
}

/*<Codenesium>
    <Hash>6b28b2aca818cd16e8e151003c83fc0d</Hash>
</Codenesium>*/