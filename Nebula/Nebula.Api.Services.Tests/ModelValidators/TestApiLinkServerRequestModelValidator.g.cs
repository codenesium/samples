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
	[Trait("Table", "Link")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiLinkServerRequestModelValidatorTest
	{
		public ApiLinkServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void AssignedMachineId_Create_Valid_Reference()
		{
			Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
			linkRepository.Setup(x => x.MachineByAssignedMachineId(It.IsAny<int>())).Returns(Task.FromResult<Machine>(new Machine()));

			var validator = new ApiLinkServerRequestModelValidator(linkRepository.Object);
			await validator.ValidateCreateAsync(new ApiLinkServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.AssignedMachineId, 1);
		}

		[Fact]
		public async void AssignedMachineId_Create_Invalid_Reference()
		{
			Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
			linkRepository.Setup(x => x.MachineByAssignedMachineId(It.IsAny<int>())).Returns(Task.FromResult<Machine>(null));

			var validator = new ApiLinkServerRequestModelValidator(linkRepository.Object);

			await validator.ValidateCreateAsync(new ApiLinkServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AssignedMachineId, 1);
		}

		[Fact]
		public async void AssignedMachineId_Update_Valid_Reference()
		{
			Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
			linkRepository.Setup(x => x.MachineByAssignedMachineId(It.IsAny<int>())).Returns(Task.FromResult<Machine>(new Machine()));

			var validator = new ApiLinkServerRequestModelValidator(linkRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLinkServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.AssignedMachineId, 1);
		}

		[Fact]
		public async void AssignedMachineId_Update_Invalid_Reference()
		{
			Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
			linkRepository.Setup(x => x.MachineByAssignedMachineId(It.IsAny<int>())).Returns(Task.FromResult<Machine>(null));

			var validator = new ApiLinkServerRequestModelValidator(linkRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiLinkServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AssignedMachineId, 1);
		}

		[Fact]
		public async void LinkStatusId_Create_Valid_Reference()
		{
			Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
			linkRepository.Setup(x => x.LinkStatusByLinkStatusId(It.IsAny<int>())).Returns(Task.FromResult<LinkStatus>(new LinkStatus()));

			var validator = new ApiLinkServerRequestModelValidator(linkRepository.Object);
			await validator.ValidateCreateAsync(new ApiLinkServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LinkStatusId, 1);
		}

		[Fact]
		public async void LinkStatusId_Create_Invalid_Reference()
		{
			Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
			linkRepository.Setup(x => x.LinkStatusByLinkStatusId(It.IsAny<int>())).Returns(Task.FromResult<LinkStatus>(null));

			var validator = new ApiLinkServerRequestModelValidator(linkRepository.Object);

			await validator.ValidateCreateAsync(new ApiLinkServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LinkStatusId, 1);
		}

		[Fact]
		public async void LinkStatusId_Update_Valid_Reference()
		{
			Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
			linkRepository.Setup(x => x.LinkStatusByLinkStatusId(It.IsAny<int>())).Returns(Task.FromResult<LinkStatus>(new LinkStatus()));

			var validator = new ApiLinkServerRequestModelValidator(linkRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLinkServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LinkStatusId, 1);
		}

		[Fact]
		public async void LinkStatusId_Update_Invalid_Reference()
		{
			Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
			linkRepository.Setup(x => x.LinkStatusByLinkStatusId(It.IsAny<int>())).Returns(Task.FromResult<LinkStatus>(null));

			var validator = new ApiLinkServerRequestModelValidator(linkRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiLinkServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LinkStatusId, 1);
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
			linkRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Link()));

			var validator = new ApiLinkServerRequestModelValidator(linkRepository.Object);
			await validator.ValidateCreateAsync(new ApiLinkServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
			linkRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Link()));

			var validator = new ApiLinkServerRequestModelValidator(linkRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLinkServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
			linkRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Link()));

			var validator = new ApiLinkServerRequestModelValidator(linkRepository.Object);
			await validator.ValidateCreateAsync(new ApiLinkServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
			linkRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Link()));

			var validator = new ApiLinkServerRequestModelValidator(linkRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLinkServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		private async void BeUniqueByExternalId_Create_Exists()
		{
			Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
			linkRepository.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<Link>(new Link()));
			var validator = new ApiLinkServerRequestModelValidator(linkRepository.Object);

			await validator.ValidateCreateAsync(new ApiLinkServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByExternalId_Create_Not_Exists()
		{
			Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
			linkRepository.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<Link>(null));
			var validator = new ApiLinkServerRequestModelValidator(linkRepository.Object);

			await validator.ValidateCreateAsync(new ApiLinkServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByExternalId_Update_Exists()
		{
			Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
			linkRepository.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<Link>(new Link()));
			var validator = new ApiLinkServerRequestModelValidator(linkRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiLinkServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByExternalId_Update_Not_Exists()
		{
			Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
			linkRepository.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<Link>(null));
			var validator = new ApiLinkServerRequestModelValidator(linkRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiLinkServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}
	}
}

/*<Codenesium>
    <Hash>11719612de3f8f55c6f39a08f613b2d4</Hash>
</Codenesium>*/