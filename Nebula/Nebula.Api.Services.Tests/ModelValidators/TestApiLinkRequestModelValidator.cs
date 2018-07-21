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
        public partial class ApiLinkRequestModelValidatorTest
        {
                public ApiLinkRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void AssignedMachineId_Create_Valid_Reference()
                {
                        Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
                        linkRepository.Setup(x => x.GetMachine(It.IsAny<int>())).Returns(Task.FromResult<Machine>(new Machine()));

                        var validator = new ApiLinkRequestModelValidator(linkRepository.Object);
                        await validator.ValidateCreateAsync(new ApiLinkRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.AssignedMachineId, 1);
                }

                [Fact]
                public async void AssignedMachineId_Create_Invalid_Reference()
                {
                        Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
                        linkRepository.Setup(x => x.GetMachine(It.IsAny<int>())).Returns(Task.FromResult<Machine>(null));

                        var validator = new ApiLinkRequestModelValidator(linkRepository.Object);

                        await validator.ValidateCreateAsync(new ApiLinkRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AssignedMachineId, 1);
                }

                [Fact]
                public async void AssignedMachineId_Update_Valid_Reference()
                {
                        Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
                        linkRepository.Setup(x => x.GetMachine(It.IsAny<int>())).Returns(Task.FromResult<Machine>(new Machine()));

                        var validator = new ApiLinkRequestModelValidator(linkRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiLinkRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.AssignedMachineId, 1);
                }

                [Fact]
                public async void AssignedMachineId_Update_Invalid_Reference()
                {
                        Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
                        linkRepository.Setup(x => x.GetMachine(It.IsAny<int>())).Returns(Task.FromResult<Machine>(null));

                        var validator = new ApiLinkRequestModelValidator(linkRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiLinkRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AssignedMachineId, 1);
                }

                [Fact]
                public async void ChainId_Create_Valid_Reference()
                {
                        Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
                        linkRepository.Setup(x => x.GetChain(It.IsAny<int>())).Returns(Task.FromResult<Chain>(new Chain()));

                        var validator = new ApiLinkRequestModelValidator(linkRepository.Object);
                        await validator.ValidateCreateAsync(new ApiLinkRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ChainId, 1);
                }

                [Fact]
                public async void ChainId_Create_Invalid_Reference()
                {
                        Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
                        linkRepository.Setup(x => x.GetChain(It.IsAny<int>())).Returns(Task.FromResult<Chain>(null));

                        var validator = new ApiLinkRequestModelValidator(linkRepository.Object);

                        await validator.ValidateCreateAsync(new ApiLinkRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ChainId, 1);
                }

                [Fact]
                public async void ChainId_Update_Valid_Reference()
                {
                        Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
                        linkRepository.Setup(x => x.GetChain(It.IsAny<int>())).Returns(Task.FromResult<Chain>(new Chain()));

                        var validator = new ApiLinkRequestModelValidator(linkRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiLinkRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ChainId, 1);
                }

                [Fact]
                public async void ChainId_Update_Invalid_Reference()
                {
                        Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
                        linkRepository.Setup(x => x.GetChain(It.IsAny<int>())).Returns(Task.FromResult<Chain>(null));

                        var validator = new ApiLinkRequestModelValidator(linkRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiLinkRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ChainId, 1);
                }

                [Fact]
                public async void LinkStatusId_Create_Valid_Reference()
                {
                        Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
                        linkRepository.Setup(x => x.GetLinkStatus(It.IsAny<int>())).Returns(Task.FromResult<LinkStatus>(new LinkStatus()));

                        var validator = new ApiLinkRequestModelValidator(linkRepository.Object);
                        await validator.ValidateCreateAsync(new ApiLinkRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.LinkStatusId, 1);
                }

                [Fact]
                public async void LinkStatusId_Create_Invalid_Reference()
                {
                        Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
                        linkRepository.Setup(x => x.GetLinkStatus(It.IsAny<int>())).Returns(Task.FromResult<LinkStatus>(null));

                        var validator = new ApiLinkRequestModelValidator(linkRepository.Object);

                        await validator.ValidateCreateAsync(new ApiLinkRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LinkStatusId, 1);
                }

                [Fact]
                public async void LinkStatusId_Update_Valid_Reference()
                {
                        Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
                        linkRepository.Setup(x => x.GetLinkStatus(It.IsAny<int>())).Returns(Task.FromResult<LinkStatus>(new LinkStatus()));

                        var validator = new ApiLinkRequestModelValidator(linkRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiLinkRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.LinkStatusId, 1);
                }

                [Fact]
                public async void LinkStatusId_Update_Invalid_Reference()
                {
                        Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
                        linkRepository.Setup(x => x.GetLinkStatus(It.IsAny<int>())).Returns(Task.FromResult<LinkStatus>(null));

                        var validator = new ApiLinkRequestModelValidator(linkRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiLinkRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LinkStatusId, 1);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
                        linkRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Link()));

                        var validator = new ApiLinkRequestModelValidator(linkRepository.Object);
                        await validator.ValidateCreateAsync(new ApiLinkRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<ILinkRepository> linkRepository = new Mock<ILinkRepository>();
                        linkRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Link()));

                        var validator = new ApiLinkRequestModelValidator(linkRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiLinkRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }
        }
}

/*<Codenesium>
    <Hash>c4b8ebd464c3f8d74faccf5d230d038b</Hash>
</Codenesium>*/