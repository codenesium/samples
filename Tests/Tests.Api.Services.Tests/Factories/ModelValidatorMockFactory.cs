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
		public Mock<IApiPersonRequestModelValidator> PersonModelValidatorMock { get; set; } = new Mock<IApiPersonRequestModelValidator>();

		public Mock<IApiRowVersionCheckRequestModelValidator> RowVersionCheckModelValidatorMock { get; set; } = new Mock<IApiRowVersionCheckRequestModelValidator>();

		public Mock<IApiSelfReferenceRequestModelValidator> SelfReferenceModelValidatorMock { get; set; } = new Mock<IApiSelfReferenceRequestModelValidator>();

		public Mock<IApiTableRequestModelValidator> TableModelValidatorMock { get; set; } = new Mock<IApiTableRequestModelValidator>();

		public Mock<IApiTestAllFieldTypeRequestModelValidator> TestAllFieldTypeModelValidatorMock { get; set; } = new Mock<IApiTestAllFieldTypeRequestModelValidator>();

		public Mock<IApiTestAllFieldTypesNullableRequestModelValidator> TestAllFieldTypesNullableModelValidatorMock { get; set; } = new Mock<IApiTestAllFieldTypesNullableRequestModelValidator>();

		public Mock<IApiTimestampCheckRequestModelValidator> TimestampCheckModelValidatorMock { get; set; } = new Mock<IApiTimestampCheckRequestModelValidator>();

		public Mock<IApiSchemaAPersonRequestModelValidator> SchemaAPersonModelValidatorMock { get; set; } = new Mock<IApiSchemaAPersonRequestModelValidator>();

		public Mock<IApiSchemaBPersonRequestModelValidator> SchemaBPersonModelValidatorMock { get; set; } = new Mock<IApiSchemaBPersonRequestModelValidator>();

		public Mock<IApiPersonRefRequestModelValidator> PersonRefModelValidatorMock { get; set; } = new Mock<IApiPersonRefRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.PersonModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPersonRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PersonModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PersonModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.RowVersionCheckModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiRowVersionCheckRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.RowVersionCheckModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiRowVersionCheckRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.RowVersionCheckModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SelfReferenceModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSelfReferenceRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SelfReferenceModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSelfReferenceRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SelfReferenceModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TableModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTableRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TableModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTableRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TableModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TestAllFieldTypeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTestAllFieldTypeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TestAllFieldTypeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TestAllFieldTypeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TestAllFieldTypesNullableModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTestAllFieldTypesNullableRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TestAllFieldTypesNullableModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypesNullableRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TestAllFieldTypesNullableModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TimestampCheckModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTimestampCheckRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TimestampCheckModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTimestampCheckRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TimestampCheckModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SchemaAPersonModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSchemaAPersonRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SchemaAPersonModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSchemaAPersonRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SchemaAPersonModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SchemaBPersonModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSchemaBPersonRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SchemaBPersonModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSchemaBPersonRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SchemaBPersonModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PersonRefModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPersonRefRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PersonRefModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonRefRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PersonRefModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>35fd0e8a471dfa85e6c96a3431d7abe4</Hash>
</Codenesium>*/