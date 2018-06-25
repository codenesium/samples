using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Person")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiPersonRequestModelValidatorTest
        {
                public ApiPersonRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void FirstName_Create_null()
                {
                        Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
                        personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

                        var validator = new ApiPersonRequestModelValidator(personRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPersonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
                }

                [Fact]
                public async void FirstName_Update_null()
                {
                        Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
                        personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

                        var validator = new ApiPersonRequestModelValidator(personRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPersonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
                }

                [Fact]
                public async void FirstName_Create_length()
                {
                        Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
                        personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

                        var validator = new ApiPersonRequestModelValidator(personRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPersonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 51));
                }

                [Fact]
                public async void FirstName_Update_length()
                {
                        Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
                        personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

                        var validator = new ApiPersonRequestModelValidator(personRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPersonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 51));
                }

                [Fact]
                public async void LastName_Create_null()
                {
                        Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
                        personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

                        var validator = new ApiPersonRequestModelValidator(personRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPersonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
                }

                [Fact]
                public async void LastName_Update_null()
                {
                        Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
                        personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

                        var validator = new ApiPersonRequestModelValidator(personRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPersonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
                }

                [Fact]
                public async void LastName_Create_length()
                {
                        Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
                        personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

                        var validator = new ApiPersonRequestModelValidator(personRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPersonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 51));
                }

                [Fact]
                public async void LastName_Update_length()
                {
                        Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
                        personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

                        var validator = new ApiPersonRequestModelValidator(personRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPersonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 51));
                }

                [Fact]
                public async void MiddleName_Create_length()
                {
                        Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
                        personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

                        var validator = new ApiPersonRequestModelValidator(personRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPersonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.MiddleName, new string('A', 51));
                }

                [Fact]
                public async void MiddleName_Update_length()
                {
                        Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
                        personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

                        var validator = new ApiPersonRequestModelValidator(personRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPersonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.MiddleName, new string('A', 51));
                }

                [Fact]
                public async void PersonType_Create_null()
                {
                        Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
                        personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

                        var validator = new ApiPersonRequestModelValidator(personRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPersonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PersonType, null as string);
                }

                [Fact]
                public async void PersonType_Update_null()
                {
                        Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
                        personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

                        var validator = new ApiPersonRequestModelValidator(personRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPersonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PersonType, null as string);
                }

                [Fact]
                public async void PersonType_Create_length()
                {
                        Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
                        personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

                        var validator = new ApiPersonRequestModelValidator(personRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPersonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PersonType, new string('A', 3));
                }

                [Fact]
                public async void PersonType_Update_length()
                {
                        Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
                        personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

                        var validator = new ApiPersonRequestModelValidator(personRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPersonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PersonType, new string('A', 3));
                }

                [Fact]
                public async void Suffix_Create_length()
                {
                        Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
                        personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

                        var validator = new ApiPersonRequestModelValidator(personRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPersonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Suffix, new string('A', 11));
                }

                [Fact]
                public async void Suffix_Update_length()
                {
                        Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
                        personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

                        var validator = new ApiPersonRequestModelValidator(personRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPersonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Suffix, new string('A', 11));
                }

                [Fact]
                public async void Title_Create_length()
                {
                        Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
                        personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

                        var validator = new ApiPersonRequestModelValidator(personRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPersonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Title, new string('A', 9));
                }

                [Fact]
                public async void Title_Update_length()
                {
                        Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
                        personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

                        var validator = new ApiPersonRequestModelValidator(personRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPersonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Title, new string('A', 9));
                }
        }
}

/*<Codenesium>
    <Hash>d803a447e04a2db51006eb9f8976bacd</Hash>
</Codenesium>*/