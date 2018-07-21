using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PersonRef")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiPersonRefRequestModelValidatorTest
        {
                public ApiPersonRefRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void PersonBId_Create_Valid_Reference()
                {
                        Mock<IPersonRefRepository> personRefRepository = new Mock<IPersonRefRepository>();
                        personRefRepository.Setup(x => x.GetSchemaBPerson(It.IsAny<int>())).Returns(Task.FromResult<SchemaBPerson>(new SchemaBPerson()));

                        var validator = new ApiPersonRefRequestModelValidator(personRefRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPersonRefRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.PersonBId, 1);
                }

                [Fact]
                public async void PersonBId_Create_Invalid_Reference()
                {
                        Mock<IPersonRefRepository> personRefRepository = new Mock<IPersonRefRepository>();
                        personRefRepository.Setup(x => x.GetSchemaBPerson(It.IsAny<int>())).Returns(Task.FromResult<SchemaBPerson>(null));

                        var validator = new ApiPersonRefRequestModelValidator(personRefRepository.Object);

                        await validator.ValidateCreateAsync(new ApiPersonRefRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PersonBId, 1);
                }

                [Fact]
                public async void PersonBId_Update_Valid_Reference()
                {
                        Mock<IPersonRefRepository> personRefRepository = new Mock<IPersonRefRepository>();
                        personRefRepository.Setup(x => x.GetSchemaBPerson(It.IsAny<int>())).Returns(Task.FromResult<SchemaBPerson>(new SchemaBPerson()));

                        var validator = new ApiPersonRefRequestModelValidator(personRefRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPersonRefRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.PersonBId, 1);
                }

                [Fact]
                public async void PersonBId_Update_Invalid_Reference()
                {
                        Mock<IPersonRefRepository> personRefRepository = new Mock<IPersonRefRepository>();
                        personRefRepository.Setup(x => x.GetSchemaBPerson(It.IsAny<int>())).Returns(Task.FromResult<SchemaBPerson>(null));

                        var validator = new ApiPersonRefRequestModelValidator(personRefRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiPersonRefRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PersonBId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>afaddbb2730f23d7e11a428e5a7528d9</Hash>
</Codenesium>*/