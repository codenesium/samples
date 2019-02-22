using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiTestAllFieldTypeServerRequestModelValidator : AbstractApiTestAllFieldTypeServerRequestModelValidator, IApiTestAllFieldTypeServerRequestModelValidator
	{
		public ApiTestAllFieldTypeServerRequestModelValidator(ITestAllFieldTypeRepository testAllFieldTypeRepository)
			: base(testAllFieldTypeRepository)
		{
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
			this.FieldGeographyRules();
			this.FieldGeometryRules();
			this.FieldHierarchyIdRules();
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
			this.FieldVariantRules();
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
			this.FieldGeographyRules();
			this.FieldGeometryRules();
			this.FieldHierarchyIdRules();
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
			this.FieldVariantRules();
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
    <Hash>50b2ed1a67e19a65956a8b19f0773120</Hash>
</Codenesium>*/