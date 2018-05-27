using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class ApiLinkRequestModelValidator: AbstractApiLinkRequestModelValidator, IApiLinkRequestModelValidator
	{
		public ApiLinkRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiLinkRequestModel model)
		{
			this.AssignedMachineIdRules();
			this.ChainIdRules();
			this.DateCompletedRules();
			this.DateStartedRules();
			this.DynamicParametersRules();
			this.ExternalIdRules();
			this.LinkStatusIdRules();
			this.NameRules();
			this.OrderRules();
			this.ResponseRules();
			this.StaticParametersRules();
			this.TimeoutInSecondsRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkRequestModel model)
		{
			this.AssignedMachineIdRules();
			this.ChainIdRules();
			this.DateCompletedRules();
			this.DateStartedRules();
			this.DynamicParametersRules();
			this.ExternalIdRules();
			this.LinkStatusIdRules();
			this.NameRules();
			this.OrderRules();
			this.ResponseRules();
			this.StaticParametersRules();
			this.TimeoutInSecondsRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>515fad4fe0682f9152ebcbadb0ebc40a</Hash>
</Codenesium>*/