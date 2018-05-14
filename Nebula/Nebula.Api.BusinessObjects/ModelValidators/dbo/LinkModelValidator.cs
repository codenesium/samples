using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class ApiLinkModelValidator: AbstractApiLinkModelValidator, IApiLinkModelValidator
	{
		public ApiLinkModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiLinkModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkModel model)
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
    <Hash>cdf990247d8e7657e1f14f5e6d2f7465</Hash>
</Codenesium>*/