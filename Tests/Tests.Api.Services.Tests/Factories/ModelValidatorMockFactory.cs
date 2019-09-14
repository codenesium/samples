using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;

namespace TestsNS.Api.Services.Tests
{
	public class ModelValidatorMockFactory
	{
		public Mock<IApiColumnSameAsFKTableServerRequestModelValidator> ColumnSameAsFKTableModelValidatorMock { get; set; } = new Mock<IApiColumnSameAsFKTableServerRequestModelValidator>();

		public Mock<IApiIncludedColumnTestServerRequestModelValidator> IncludedColumnTestModelValidatorMock { get; set; } = new Mock<IApiIncludedColumnTestServerRequestModelValidator>();

		public Mock<IApiPersonServerRequestModelValidator> PersonModelValidatorMock { get; set; } = new Mock<IApiPersonServerRequestModelValidator>();

		public Mock<IApiRowVersionCheckServerRequestModelValidator> RowVersionCheckModelValidatorMock { get; set; } = new Mock<IApiRowVersionCheckServerRequestModelValidator>();

		public Mock<IApiSelfReferenceServerRequestModelValidator> SelfReferenceModelValidatorMock { get; set; } = new Mock<IApiSelfReferenceServerRequestModelValidator>();

		public Mock<IApiTableServerRequestModelValidator> TableModelValidatorMock { get; set; } = new Mock<IApiTableServerRequestModelValidator>();

		public Mock<IApiTestAllFieldTypeServerRequestModelValidator> TestAllFieldTypeModelValidatorMock { get; set; } = new Mock<IApiTestAllFieldTypeServerRequestModelValidator>();

		public Mock<IApiTestAllFieldTypesNullableServerRequestModelValidator> TestAllFieldTypesNullableModelValidatorMock { get; set; } = new Mock<IApiTestAllFieldTypesNullableServerRequestModelValidator>();

		public Mock<IApiTimestampCheckServerRequestModelValidator> TimestampCheckModelValidatorMock { get; set; } = new Mock<IApiTimestampCheckServerRequestModelValidator>();

		public Mock<IApiVPersonServerRequestModelValidator> VPersonModelValidatorMock { get; set; } = new Mock<IApiVPersonServerRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.ColumnSameAsFKTableModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiColumnSameAsFKTableServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ColumnSameAsFKTableModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiColumnSameAsFKTableServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ColumnSameAsFKTableModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.IncludedColumnTestModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiIncludedColumnTestServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.IncludedColumnTestModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiIncludedColumnTestServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.IncludedColumnTestModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PersonModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPersonServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PersonModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PersonModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.RowVersionCheckModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiRowVersionCheckServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.RowVersionCheckModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiRowVersionCheckServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.RowVersionCheckModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SelfReferenceModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSelfReferenceServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SelfReferenceModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSelfReferenceServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SelfReferenceModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TableModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTableServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TableModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTableServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TableModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TestAllFieldTypeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTestAllFieldTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TestAllFieldTypeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TestAllFieldTypeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TestAllFieldTypesNullableModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTestAllFieldTypesNullableServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TestAllFieldTypesNullableModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypesNullableServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TestAllFieldTypesNullableModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TimestampCheckModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTimestampCheckServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TimestampCheckModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTimestampCheckServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TimestampCheckModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.VPersonModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVPersonServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VPersonModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVPersonServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VPersonModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>e1b870434efb5c7226ef3d27f33f0e37</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/