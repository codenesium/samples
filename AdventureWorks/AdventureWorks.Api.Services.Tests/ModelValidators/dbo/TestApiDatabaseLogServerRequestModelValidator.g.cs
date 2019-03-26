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
	public partial class ApiDatabaseLogServerRequestModelValidatorTest
	{
		public ApiDatabaseLogServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void DatabaseUser_Create_null()
		{
			Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
			databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

			var validator = new ApiDatabaseLogServerRequestModelValidator(databaseLogRepository.Object);
			await validator.ValidateCreateAsync(new ApiDatabaseLogServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.DatabaseUser, null as string);
		}

		[Fact]
		public async void DatabaseUser_Update_null()
		{
			Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
			databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

			var validator = new ApiDatabaseLogServerRequestModelValidator(databaseLogRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiDatabaseLogServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.DatabaseUser, null as string);
		}

		[Fact]
		public async void DatabaseUser_Create_length()
		{
			Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
			databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

			var validator = new ApiDatabaseLogServerRequestModelValidator(databaseLogRepository.Object);
			await validator.ValidateCreateAsync(new ApiDatabaseLogServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.DatabaseUser, new string('A', 129));
		}

		[Fact]
		public async void DatabaseUser_Update_length()
		{
			Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
			databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

			var validator = new ApiDatabaseLogServerRequestModelValidator(databaseLogRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiDatabaseLogServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.DatabaseUser, new string('A', 129));
		}

		[Fact]
		public async void ReservedEvent_Create_null()
		{
			Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
			databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

			var validator = new ApiDatabaseLogServerRequestModelValidator(databaseLogRepository.Object);
			await validator.ValidateCreateAsync(new ApiDatabaseLogServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ReservedEvent, null as string);
		}

		[Fact]
		public async void ReservedEvent_Update_null()
		{
			Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
			databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

			var validator = new ApiDatabaseLogServerRequestModelValidator(databaseLogRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiDatabaseLogServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ReservedEvent, null as string);
		}

		[Fact]
		public async void ReservedEvent_Create_length()
		{
			Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
			databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

			var validator = new ApiDatabaseLogServerRequestModelValidator(databaseLogRepository.Object);
			await validator.ValidateCreateAsync(new ApiDatabaseLogServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ReservedEvent, new string('A', 129));
		}

		[Fact]
		public async void ReservedEvent_Update_length()
		{
			Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
			databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

			var validator = new ApiDatabaseLogServerRequestModelValidator(databaseLogRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiDatabaseLogServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ReservedEvent, new string('A', 129));
		}

		[Fact]
		public async void ReservedObject_Create_length()
		{
			Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
			databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

			var validator = new ApiDatabaseLogServerRequestModelValidator(databaseLogRepository.Object);
			await validator.ValidateCreateAsync(new ApiDatabaseLogServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ReservedObject, new string('A', 129));
		}

		[Fact]
		public async void ReservedObject_Update_length()
		{
			Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
			databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

			var validator = new ApiDatabaseLogServerRequestModelValidator(databaseLogRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiDatabaseLogServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ReservedObject, new string('A', 129));
		}

		[Fact]
		public async void Schema_Create_length()
		{
			Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
			databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

			var validator = new ApiDatabaseLogServerRequestModelValidator(databaseLogRepository.Object);
			await validator.ValidateCreateAsync(new ApiDatabaseLogServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Schema, new string('A', 129));
		}

		[Fact]
		public async void Schema_Update_length()
		{
			Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
			databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

			var validator = new ApiDatabaseLogServerRequestModelValidator(databaseLogRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiDatabaseLogServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Schema, new string('A', 129));
		}

		[Fact]
		public async void Tsql_Create_null()
		{
			Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
			databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

			var validator = new ApiDatabaseLogServerRequestModelValidator(databaseLogRepository.Object);
			await validator.ValidateCreateAsync(new ApiDatabaseLogServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Tsql, null as string);
		}

		[Fact]
		public async void Tsql_Update_null()
		{
			Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
			databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

			var validator = new ApiDatabaseLogServerRequestModelValidator(databaseLogRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiDatabaseLogServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Tsql, null as string);
		}

		[Fact]
		public async void XmlEvent_Create_null()
		{
			Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
			databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

			var validator = new ApiDatabaseLogServerRequestModelValidator(databaseLogRepository.Object);
			await validator.ValidateCreateAsync(new ApiDatabaseLogServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.XmlEvent, null as string);
		}

		[Fact]
		public async void XmlEvent_Update_null()
		{
			Mock<IDatabaseLogRepository> databaseLogRepository = new Mock<IDatabaseLogRepository>();
			databaseLogRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));

			var validator = new ApiDatabaseLogServerRequestModelValidator(databaseLogRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiDatabaseLogServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.XmlEvent, null as string);
		}
	}
}

/*<Codenesium>
    <Hash>b266c1c1037a7b1e305a8a4d097dccb8</Hash>
</Codenesium>*/