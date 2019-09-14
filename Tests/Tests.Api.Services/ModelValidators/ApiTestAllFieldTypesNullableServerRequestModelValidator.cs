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
	public class ApiTestAllFieldTypesNullableServerRequestModelValidator : AbstractValidator<ApiTestAllFieldTypesNullableServerRequestModel>, IApiTestAllFieldTypesNullableServerRequestModelValidator
	{
		private int existingRecordId;

		protected ITestAllFieldTypesNullableRepository TestAllFieldTypesNullableRepository { get; private set; }

		public ApiTestAllFieldTypesNullableServerRequestModelValidator(ITestAllFieldTypesNullableRepository testAllFieldTypesNullableRepository)
		{
			this.TestAllFieldTypesNullableRepository = testAllFieldTypesNullableRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTestAllFieldTypesNullableServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTestAllFieldTypesNullableServerRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTestAllFieldTypesNullableServerRequestModel model)
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
			this.RuleFor(x => x.FieldNChar).Length(0, 10).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void FieldNTextRules()
		{
			this.RuleFor(x => x.FieldNText).Length(0, 1073741823).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void FieldNumericRules()
		{
		}

		public virtual void FieldNVarcharRules()
		{
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
			this.RuleFor(x => x.FieldVarchar).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void FieldXMLRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>4c3b396ff824cca144903912dbdad310</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/