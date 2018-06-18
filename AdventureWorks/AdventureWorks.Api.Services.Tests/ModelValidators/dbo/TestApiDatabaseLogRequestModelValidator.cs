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
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "DatabaseLog")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiDatabaseLogRequestModelValidatorTest
        {
                public ApiDatabaseLogRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void DatabaseUser_Create_null()
                {
                        Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
                        databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

                        var validator = new ApiDatabaseLogRequestModelValidator(databaseLogRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDatabaseLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DatabaseUser, null as string);
                }

                [Fact]
                public async void DatabaseUser_Update_null()
                {
                        Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
                        databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

                        var validator = new ApiDatabaseLogRequestModelValidator(databaseLogRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiDatabaseLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DatabaseUser, null as string);
                }

                [Fact]
                public async void DatabaseUser_Create_length()
                {
                        Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
                        databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

                        var validator = new ApiDatabaseLogRequestModelValidator(databaseLogRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDatabaseLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DatabaseUser, new string('A', 129));
                }

                [Fact]
                public async void DatabaseUser_Update_length()
                {
                        Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
                        databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

                        var validator = new ApiDatabaseLogRequestModelValidator(databaseLogRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiDatabaseLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DatabaseUser, new string('A', 129));
                }

                [Fact]
                public async void DatabaseUser_Delete()
                {
                        Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
                        databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

                        var validator = new ApiDatabaseLogRequestModelValidator(databaseLogRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void @Event_Create_null()
                {
                        Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
                        databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

                        var validator = new ApiDatabaseLogRequestModelValidator(databaseLogRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDatabaseLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.@Event, null as string);
                }

                [Fact]
                public async void @Event_Update_null()
                {
                        Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
                        databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

                        var validator = new ApiDatabaseLogRequestModelValidator(databaseLogRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiDatabaseLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.@Event, null as string);
                }

                [Fact]
                public async void @Event_Create_length()
                {
                        Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
                        databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

                        var validator = new ApiDatabaseLogRequestModelValidator(databaseLogRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDatabaseLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.@Event, new string('A', 129));
                }

                [Fact]
                public async void @Event_Update_length()
                {
                        Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
                        databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

                        var validator = new ApiDatabaseLogRequestModelValidator(databaseLogRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiDatabaseLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.@Event, new string('A', 129));
                }

                [Fact]
                public async void @Event_Delete()
                {
                        Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
                        databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

                        var validator = new ApiDatabaseLogRequestModelValidator(databaseLogRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void @Object_Create_length()
                {
                        Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
                        databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

                        var validator = new ApiDatabaseLogRequestModelValidator(databaseLogRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDatabaseLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.@Object, new string('A', 129));
                }

                [Fact]
                public async void @Object_Update_length()
                {
                        Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
                        databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

                        var validator = new ApiDatabaseLogRequestModelValidator(databaseLogRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiDatabaseLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.@Object, new string('A', 129));
                }

                [Fact]
                public async void @Object_Delete()
                {
                        Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
                        databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

                        var validator = new ApiDatabaseLogRequestModelValidator(databaseLogRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Schema_Create_length()
                {
                        Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
                        databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

                        var validator = new ApiDatabaseLogRequestModelValidator(databaseLogRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDatabaseLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Schema, new string('A', 129));
                }

                [Fact]
                public async void Schema_Update_length()
                {
                        Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
                        databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

                        var validator = new ApiDatabaseLogRequestModelValidator(databaseLogRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiDatabaseLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Schema, new string('A', 129));
                }

                [Fact]
                public async void Schema_Delete()
                {
                        Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
                        databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

                        var validator = new ApiDatabaseLogRequestModelValidator(databaseLogRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void TSQL_Create_null()
                {
                        Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
                        databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

                        var validator = new ApiDatabaseLogRequestModelValidator(databaseLogRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDatabaseLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TSQL, null as string);
                }

                [Fact]
                public async void TSQL_Update_null()
                {
                        Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
                        databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

                        var validator = new ApiDatabaseLogRequestModelValidator(databaseLogRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiDatabaseLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TSQL, null as string);
                }

                [Fact]
                public async void XmlEvent_Create_null()
                {
                        Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
                        databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

                        var validator = new ApiDatabaseLogRequestModelValidator(databaseLogRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDatabaseLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.XmlEvent, null as string);
                }

                [Fact]
                public async void XmlEvent_Update_null()
                {
                        Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
                        databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

                        var validator = new ApiDatabaseLogRequestModelValidator(databaseLogRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiDatabaseLogRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.XmlEvent, null as string);
                }
        }
}

/*<Codenesium>
    <Hash>58c15369a665679b7162129a4af3c1d6</Hash>
</Codenesium>*/