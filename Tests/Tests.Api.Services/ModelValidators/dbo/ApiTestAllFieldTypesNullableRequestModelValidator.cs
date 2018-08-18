using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiTestAllFieldTypesNullableRequestModelValidator : AbstractApiTestAllFieldTypesNullableRequestModelValidator, IApiTestAllFieldTypesNullableRequestModelValidator
	{
		public ApiTestAllFieldTypesNullableRequestModelValidator(ITestAllFieldTypesNullableRepository testAllFieldTypesNullableRepository)
			: base(testAllFieldTypesNullableRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTestAllFieldTypesNullableRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTestAllFieldTypesNullableRequestModel model)
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
	}
}

/*<Codenesium>
    <Hash>9c2d438201d151bd37433642f13a9c3a</Hash>
</Codenesium>*/