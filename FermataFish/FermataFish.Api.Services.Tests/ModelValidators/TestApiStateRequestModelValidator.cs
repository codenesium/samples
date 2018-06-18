using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using System.Linq;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "State")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiStateRequestModelValidatorTest
        {
                public ApiStateRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IStateRepository> stateRepository = new Mock<IStateRepository>();
                        stateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new State()));

                        var validator = new ApiStateRequestModelValidator(stateRepository.Object);

                        await validator.ValidateCreateAsync(new ApiStateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IStateRepository> stateRepository = new Mock<IStateRepository>();
                        stateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new State()));

                        var validator = new ApiStateRequestModelValidator(stateRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiStateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IStateRepository> stateRepository = new Mock<IStateRepository>();
                        stateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new State()));

                        var validator = new ApiStateRequestModelValidator(stateRepository.Object);

                        await validator.ValidateCreateAsync(new ApiStateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 3));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IStateRepository> stateRepository = new Mock<IStateRepository>();
                        stateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new State()));

                        var validator = new ApiStateRequestModelValidator(stateRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiStateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 3));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IStateRepository> stateRepository = new Mock<IStateRepository>();
                        stateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new State()));

                        var validator = new ApiStateRequestModelValidator(stateRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>624c6a25a17d5cacdc6b946e11ef90bd</Hash>
</Codenesium>*/