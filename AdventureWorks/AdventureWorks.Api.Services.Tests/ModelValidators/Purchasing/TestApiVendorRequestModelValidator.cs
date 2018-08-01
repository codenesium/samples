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
	[Trait("Table", "Vendor")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiVendorRequestModelValidatorTest
	{
		public ApiVendorRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void AccountNumber_Create_null()
		{
			Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
			vendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vendor()));

			var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);
			await validator.ValidateCreateAsync(new ApiVendorRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, null as string);
		}

		[Fact]
		public async void AccountNumber_Update_null()
		{
			Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
			vendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vendor()));

			var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVendorRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, null as string);
		}

		[Fact]
		public async void AccountNumber_Create_length()
		{
			Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
			vendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vendor()));

			var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);
			await validator.ValidateCreateAsync(new ApiVendorRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, new string('A', 16));
		}

		[Fact]
		public async void AccountNumber_Update_length()
		{
			Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
			vendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vendor()));

			var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVendorRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, new string('A', 16));
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
			vendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vendor()));

			var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);
			await validator.ValidateCreateAsync(new ApiVendorRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
			vendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vendor()));

			var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVendorRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
			vendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vendor()));

			var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);
			await validator.ValidateCreateAsync(new ApiVendorRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
			vendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vendor()));

			var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVendorRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void PurchasingWebServiceURL_Create_length()
		{
			Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
			vendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vendor()));

			var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);
			await validator.ValidateCreateAsync(new ApiVendorRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PurchasingWebServiceURL, new string('A', 1025));
		}

		[Fact]
		public async void PurchasingWebServiceURL_Update_length()
		{
			Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
			vendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vendor()));

			var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVendorRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PurchasingWebServiceURL, new string('A', 1025));
		}

		[Fact]
		private async void BeUniqueByAccountNumber_Create_Exists()
		{
			Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
			vendorRepository.Setup(x => x.ByAccountNumber(It.IsAny<string>())).Returns(Task.FromResult<Vendor>(new Vendor()));
			var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);

			await validator.ValidateCreateAsync(new ApiVendorRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, "A");
		}

		[Fact]
		private async void BeUniqueByAccountNumber_Create_Not_Exists()
		{
			Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
			vendorRepository.Setup(x => x.ByAccountNumber(It.IsAny<string>())).Returns(Task.FromResult<Vendor>(null));
			var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);

			await validator.ValidateCreateAsync(new ApiVendorRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.AccountNumber, "A");
		}

		[Fact]
		private async void BeUniqueByAccountNumber_Update_Exists()
		{
			Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
			vendorRepository.Setup(x => x.ByAccountNumber(It.IsAny<string>())).Returns(Task.FromResult<Vendor>(new Vendor()));
			var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiVendorRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, "A");
		}

		[Fact]
		private async void BeUniqueByAccountNumber_Update_Not_Exists()
		{
			Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
			vendorRepository.Setup(x => x.ByAccountNumber(It.IsAny<string>())).Returns(Task.FromResult<Vendor>(null));
			var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiVendorRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.AccountNumber, "A");
		}
	}
}

/*<Codenesium>
    <Hash>2ea91e6ddff336098171c0632ec981e6</Hash>
</Codenesium>*/