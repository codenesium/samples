using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiTestAllFieldTypeServerRequestModelValidator : AbstractValidator<ApiTestAllFieldTypeServerRequestModel>, IApiTestAllFieldTypeServerRequestModelValidator
	{
		private int existingRecordId;

		protected ITestAllFieldTypeRepository TestAllFieldTypeRepository { get; private set; }

		public ApiTestAllFieldTypeServerRequestModelValidator(ITestAllFieldTypeRepository testAllFieldTypeRepository)
		{
			this.TestAllFieldTypeRepository = testAllFieldTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTestAllFieldTypeServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTestAllFieldTypeServerRequestModel model)
		{
			this.FieldBigIntRules();
			this.FieldBinaryRules();
			this.FieldBitRules();
			this.FieldCharRules();
			this.FieldDateRules();
			this.FieldDateTimeRules();
			this.FieldDateTime2Rules();
			this.FieldDateTimeOffsetRules();
			this.FieldDecimalRules();
			this.FieldFloatRules();
			this.FieldImageRules();
			this.FieldMoneyRules();
			this.FieldNCharRules();
			this.FieldNTextRules();
			this.FieldNumericRules();
			this.FieldNVarcharRules();
			this.FieldRealRules();
			this.FieldSmallDateTimeRules();
			this.FieldSmallIntRules();
			this.FieldSmallMoneyRules();
			this.FieldTextRules();
			this.FieldTimeRules();
			this.FieldTimestampRules();
			this.FieldTinyIntRules();
			this.FieldUniqueIdentifierRules();
			this.FieldVarBinaryRules();
			this.FieldVarcharRules();
			this.FieldXMLRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTestAllFieldTypeServerRequestModel model)
		{
			this.FieldBigIntRules();
			this.FieldBinaryRules();
			this.FieldBitRules();
			this.FieldCharRules();
			this.FieldDateRules();
			this.FieldDateTimeRules();
			this.FieldDateTime2Rules();
			this.FieldDateTimeOffsetRules();
			this.FieldDecimalRules();
			this.FieldFloatRules();
			this.FieldImageRules();
			this.FieldMoneyRules();
			this.FieldNCharRules();
			this.FieldNTextRules();
			this.FieldNumericRules();
			this.FieldNVarcharRules();
			this.FieldRealRules();
			this.FieldSmallDateTimeRules();
			this.FieldSmallIntRules();
			this.FieldSmallMoneyRules();
			this.FieldTextRules();
			this.FieldTimeRules();
			this.FieldTimestampRules();
			this.FieldTinyIntRules();
			this.FieldUniqueIdentifierRules();
			this.FieldVarBinaryRules();
			this.FieldVarcharRules();
			this.FieldXMLRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void FieldBigIntRules()
		{
		}

		public virtual void FieldBinaryRules()
		{
			this.RuleFor(x => x.FieldBinary).Must(x => x == null || x.Length < 50).WithMessage($"Exceeds maximum length of {50}").WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void FieldBitRules()
		{
		}

		public virtual void FieldCharRules()
		{
			this.RuleFor(x => x.FieldChar).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.FieldChar).Length(0, 10).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void FieldDateRules()
		{
		}

		public virtual void FieldDateTimeRules()
		{
		}

		public virtual void FieldDateTime2Rules()
		{
		}

		public virtual void FieldDateTimeOffsetRules()
		{
		}

		public virtual void FieldDecimalRules()
		{
		}

		public virtual void FieldFloatRules()
		{
		}

		public virtual void FieldImageRules()
		{
		}

		public virtual void FieldMoneyRules()
		{
		}

		public virtual void FieldNCharRules()
		{
			this.RuleFor(x => x.FieldNChar).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.FieldNChar).Length(0, 10).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void FieldNTextRules()
		{
			this.RuleFor(x => x.FieldNText).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.FieldNText).Length(0, 1073741823).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void FieldNumericRules()
		{
		}

		public virtual void FieldNVarcharRules()
		{
			this.RuleFor(x => x.FieldNVarchar).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.FieldNVarchar).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void FieldRealRules()
		{
		}

		public virtual void FieldSmallDateTimeRules()
		{
		}

		public virtual void FieldSmallIntRules()
		{
		}

		public virtual void FieldSmallMoneyRules()
		{
		}

		public virtual void FieldTextRules()
		{
			this.RuleFor(x => x.FieldText).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.FieldText).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void FieldTimeRules()
		{
		}

		public virtual void FieldTimestampRules()
		{
		}

		public virtual void FieldTinyIntRules()
		{
		}

		public virtual void FieldUniqueIdentifierRules()
		{
		}

		public virtual void FieldVarBinaryRules()
		{
			this.RuleFor(x => x.FieldVarBinary).Must(x => x == null || x.Length < 50).WithMessage($"Exceeds maximum length of {50}").WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void FieldVarcharRules()
		{
			this.RuleFor(x => x.FieldVarchar).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.FieldVarchar).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void FieldXMLRules()
		{
			this.RuleFor(x => x.FieldXML).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
		}
	}
}

/*<Codenesium>
    <Hash>562510567a27cee0030a308dfbf334e4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/