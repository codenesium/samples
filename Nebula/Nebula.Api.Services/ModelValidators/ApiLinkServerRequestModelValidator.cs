using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiLinkServerRequestModelValidator : AbstractApiLinkServerRequestModelValidator, IApiLinkServerRequestModelValidator
	{
		public ApiLinkServerRequestModelValidator(ILinkRepository linkRepository)
			: base(linkRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiLinkServerRequestModel model)
		{
			this.AssignedMachineIdRules();
			this.ChainIdRules();
			this.DateCompletedRules();
			this.DateStartedRules();
			this.DynamicParameterRules();
			this.ExternalIdRules();
			this.LinkStatusIdRules();
			this.NameRules();
			this.OrderRules();
			this.ResponseRules();
			this.StaticParameterRules();
			this.TimeoutInSecondRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkServerRequestModel model)
		{
			this.AssignedMachineIdRules();
			this.ChainIdRules();
			this.DateCompletedRules();
			this.DateStartedRules();
			this.DynamicParameterRules();
			this.ExternalIdRules();
			this.LinkStatusIdRules();
			this.NameRules();
			this.OrderRules();
			this.ResponseRules();
			this.StaticParameterRules();
			this.TimeoutInSecondRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>e4920e1d88a76bcccb08c68764bb7ff8</Hash>
</Codenesium>*/