using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiTestAllFieldTypesNullableServerRequestModelValidator : AbstractValidator<ApiTestAllFieldTypesNullableServerRequestModel>
	{
		private int existingRecordId;

		private ITestAllFieldTypesNullableRepository testAllFieldTypesNullableRepository;

		public AbstractApiTestAllFieldTypesNullableServerRequestModelValidator(ITestAllFieldTypesNullableRepository testAllFieldTypesNullableRepository)
		{
			this.testAllFieldTypesNullableRepository = testAllFieldTypesNullableRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTestAllFieldTypesNullableServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void FieldBigIntRules()
		{
		}

		public virtual void FieldBinaryRules()
		{
			this.RuleFor(x => x.FieldBinary).Must(x => x == null || x.Length < 50).WithMessage($"Exceeds maximum length of {50}");
		}

		public virtual void FieldBitRules()
		{
		}

		public virtual void FieldCharRules()
		{
			this.RuleFor(x => x.FieldChar).Length(0, 10);
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
			this.RuleFor(x => x.FieldNChar).Length(0, 10);
		}

		public virtual void FieldNTextRules()
		{
			this.RuleFor(x => x.FieldNText).Length(0, 1073741823);
		}

		public virtual void FieldNumericRules()
		{
		}

		public virtual void FieldNVarcharRules()
		{
			this.RuleFor(x => x.FieldNVarchar).Length(0, 50);
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
			this.RuleFor(x => x.FieldText).Length(0, 2147483647);
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
			this.RuleFor(x => x.FieldVarBinary).Must(x => x == null || x.Length < 50).WithMessage($"Exceeds maximum length of {50}");
		}

		public virtual void FieldVarcharRules()
		{
			this.RuleFor(x => x.FieldVarchar).Length(0, 50);
		}

		public virtual void FieldXMLRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>1e0ed6dd846d1eb2fd178375c7cd2592</Hash>
</Codenesium>*/