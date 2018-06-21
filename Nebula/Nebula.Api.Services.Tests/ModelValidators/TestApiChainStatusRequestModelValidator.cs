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
        [Trait("Table", "ChainStatus")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiChainStatusRequestModelValidatorTest
        {
                public ApiChainStatusRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IChainStatusRepository> chainStatusRepository = new Mock<IChainStatusRepository>();
                        chainStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ChainStatus()));

                        var validator = new ApiChainStatusRequestModelValidator(chainStatusRepository.Object);
                        await validator.ValidateCreateAsync(new ApiChainStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IChainStatusRepository> chainStatusRepository = new Mock<IChainStatusRepository>();
                        chainStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ChainStatus()));

                        var validator = new ApiChainStatusRequestModelValidator(chainStatusRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiChainStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IChainStatusRepository> chainStatusRepository = new Mock<IChainStatusRepository>();
                        chainStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ChainStatus()));

                        var validator = new ApiChainStatusRequestModelValidator(chainStatusRepository.Object);
                        await validator.ValidateCreateAsync(new ApiChainStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IChainStatusRepository> chainStatusRepository = new Mock<IChainStatusRepository>();
                        chainStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ChainStatus()));

                        var validator = new ApiChainStatusRequestModelValidator(chainStatusRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiChainStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IChainStatusRepository> chainStatusRepository = new Mock<IChainStatusRepository>();
                        chainStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ChainStatus()));

                        var validator = new ApiChainStatusRequestModelValidator(chainStatusRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>12a38c4c1cea7e961728186768bcb18b</Hash>
</Codenesium>*/