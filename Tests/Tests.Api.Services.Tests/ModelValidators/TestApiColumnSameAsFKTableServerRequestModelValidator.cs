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
	[Trait("Table", "ColumnSameAsFKTable")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiColumnSameAsFKTableServerRequestModelValidatorTest
	{
		public ApiColumnSameAsFKTableServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Person_Create_Valid_Reference()
		{
			Mock<IColumnSameAsFKTableRepository> columnSameAsFKTableRepository = new Mock<IColumnSameAsFKTableRepository>();
			columnSameAsFKTableRepository.Setup(x => x.PersonByPerson(It.IsAny<int>())).Returns(Task.FromResult<Person>(new Person()));

			var validator = new ApiColumnSameAsFKTableServerRequestModelValidator(columnSameAsFKTableRepository.Object);
			await validator.ValidateCreateAsync(new ApiColumnSameAsFKTableServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Person, 1);
		}

		[Fact]
		public async void Person_Create_Invalid_Reference()
		{
			Mock<IColumnSameAsFKTableRepository> columnSameAsFKTableRepository = new Mock<IColumnSameAsFKTableRepository>();
			columnSameAsFKTableRepository.Setup(x => x.PersonByPerson(It.IsAny<int>())).Returns(Task.FromResult<Person>(null));

			var validator = new ApiColumnSameAsFKTableServerRequestModelValidator(columnSameAsFKTableRepository.Object);

			await validator.ValidateCreateAsync(new ApiColumnSameAsFKTableServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Person, 1);
		}

		[Fact]
		public async void Person_Update_Valid_Reference()
		{
			Mock<IColumnSameAsFKTableRepository> columnSameAsFKTableRepository = new Mock<IColumnSameAsFKTableRepository>();
			columnSameAsFKTableRepository.Setup(x => x.PersonByPerson(It.IsAny<int>())).Returns(Task.FromResult<Person>(new Person()));

			var validator = new ApiColumnSameAsFKTableServerRequestModelValidator(columnSameAsFKTableRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiColumnSameAsFKTableServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Person, 1);
		}

		[Fact]
		public async void Person_Update_Invalid_Reference()
		{
			Mock<IColumnSameAsFKTableRepository> columnSameAsFKTableRepository = new Mock<IColumnSameAsFKTableRepository>();
			columnSameAsFKTableRepository.Setup(x => x.PersonByPerson(It.IsAny<int>())).Returns(Task.FromResult<Person>(null));

			var validator = new ApiColumnSameAsFKTableServerRequestModelValidator(columnSameAsFKTableRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiColumnSameAsFKTableServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Person, 1);
		}

		[Fact]
		public async void PersonId_Create_Valid_Reference()
		{
			Mock<IColumnSameAsFKTableRepository> columnSameAsFKTableRepository = new Mock<IColumnSameAsFKTableRepository>();
			columnSameAsFKTableRepository.Setup(x => x.PersonByPersonId(It.IsAny<int>())).Returns(Task.FromResult<Person>(new Person()));

			var validator = new ApiColumnSameAsFKTableServerRequestModelValidator(columnSameAsFKTableRepository.Object);
			await validator.ValidateCreateAsync(new ApiColumnSameAsFKTableServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PersonId, 1);
		}

		[Fact]
		public async void PersonId_Create_Invalid_Reference()
		{
			Mock<IColumnSameAsFKTableRepository> columnSameAsFKTableRepository = new Mock<IColumnSameAsFKTableRepository>();
			columnSameAsFKTableRepository.Setup(x => x.PersonByPersonId(It.IsAny<int>())).Returns(Task.FromResult<Person>(null));

			var validator = new ApiColumnSameAsFKTableServerRequestModelValidator(columnSameAsFKTableRepository.Object);

			await validator.ValidateCreateAsync(new ApiColumnSameAsFKTableServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonId, 1);
		}

		[Fact]
		public async void PersonId_Update_Valid_Reference()
		{
			Mock<IColumnSameAsFKTableRepository> columnSameAsFKTableRepository = new Mock<IColumnSameAsFKTableRepository>();
			columnSameAsFKTableRepository.Setup(x => x.PersonByPersonId(It.IsAny<int>())).Returns(Task.FromResult<Person>(new Person()));

			var validator = new ApiColumnSameAsFKTableServerRequestModelValidator(columnSameAsFKTableRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiColumnSameAsFKTableServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PersonId, 1);
		}

		[Fact]
		public async void PersonId_Update_Invalid_Reference()
		{
			Mock<IColumnSameAsFKTableRepository> columnSameAsFKTableRepository = new Mock<IColumnSameAsFKTableRepository>();
			columnSameAsFKTableRepository.Setup(x => x.PersonByPersonId(It.IsAny<int>())).Returns(Task.FromResult<Person>(null));

			var validator = new ApiColumnSameAsFKTableServerRequestModelValidator(columnSameAsFKTableRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiColumnSameAsFKTableServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>de7c8bddeb7c39158a95ebc5480c3ea5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/