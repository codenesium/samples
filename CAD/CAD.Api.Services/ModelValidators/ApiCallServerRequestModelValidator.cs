using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiCallServerRequestModelValidator : AbstractApiCallServerRequestModelValidator, IApiCallServerRequestModelValidator
	{
		public ApiCallServerRequestModelValidator(ICallRepository callRepository)
			: base(callRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCallServerRequestModel model)
		{
			this.AddressIdRules();
			this.CallDispositionIdRules();
			this.CallStatusIdRules();
			this.CallStringRules();
			this.CallTypeIdRules();
			this.DateClearedRules();
			this.DateCreatedRules();
			this.DateDispatchedRules();
			this.QuickCallNumberRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCallServerRequestModel model)
		{
			this.AddressIdRules();
			this.CallDispositionIdRules();
			this.CallStatusIdRules();
			this.CallStringRules();
			this.CallTypeIdRules();
			this.DateClearedRules();
			this.DateCreatedRules();
			this.DateDispatchedRules();
			this.QuickCallNumberRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>9a119ce1cee7c53dad124cb6489ca472</Hash>
</Codenesium>*/