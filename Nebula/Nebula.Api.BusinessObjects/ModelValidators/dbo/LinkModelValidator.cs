using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class LinkModelValidator: AbstractLinkModelValidator, ILinkModelValidator
	{
		public LinkModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(LinkModel model)
		{
			this.NameRules();
			this.DynamicParametersRules();
			this.StaticParametersRules();
			this.ChainIdRules();
			this.AssignedMachineIdRules();
			this.LinkStatusIdRules();
			this.OrderRules();
			this.DateStartedRules();
			this.DateCompletedRules();
			this.ResponseRules();
			this.ExternalIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, LinkModel model)
		{
			this.NameRules();
			this.DynamicParametersRules();
			this.StaticParametersRules();
			this.ChainIdRules();
			this.AssignedMachineIdRules();
			this.LinkStatusIdRules();
			this.OrderRules();
			this.DateStartedRules();
			this.DateCompletedRules();
			this.ResponseRules();
			this.ExternalIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>12d55ec70a2ddb4c4ba8f0b1517c1a0f</Hash>
</Codenesium>*/