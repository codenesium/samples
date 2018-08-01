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
			await validator.ValidateUpdateAsync(default(int), new ApiDatabaseLogRequestModel());

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
			await validator.ValidateUpdateAsync(default(int), new ApiDatabaseLogRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.DatabaseUser, new string('A', 129));
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
			await validator.ValidateUpdateAsync(default(int), new ApiDatabaseLogRequestModel());

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
			await validator.ValidateUpdateAsync(default(int), new ApiDatabaseLogRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.@Event, new string('A', 129));
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
			await validator.ValidateUpdateAsync(default(int), new ApiDatabaseLogRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.@Object, new string('A', 129));
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
			await validator.ValidateUpdateAsync(default(int), new ApiDatabaseLogRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Schema, new string('A', 129));
		}

		[Fact]
		public async void Tsql_Create_null()
		{
			Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
			databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

			var validator = new ApiDatabaseLogRequestModelValidator(databaseLogRepository.Object);
			await validator.ValidateCreateAsync(new ApiDatabaseLogRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Tsql, null as string);
		}

		[Fact]
		public async void Tsql_Update_null()
		{
			Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
			databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

			var validator = new ApiDatabaseLogRequestModelValidator(databaseLogRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiDatabaseLogRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Tsql, null as string);
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
			await validator.ValidateUpdateAsync(default(int), new ApiDatabaseLogRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.XmlEvent, null as string);
		}
	}
}

/*<Codenesium>
    <Hash>61b76c98874f3e4a2058c14bc3790fa4</Hash>
</Codenesium>*/