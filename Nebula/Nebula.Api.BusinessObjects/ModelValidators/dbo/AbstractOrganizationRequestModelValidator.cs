using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects

{
	public abstract class AbstractApiOrganizationRequestModelValidator: AbstractValidator<ApiOrganizationRequestModel>
	{
		public new ValidationResult Validate(ApiOrganizationRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiOrganizationRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IOrganizationRepository OrganizationRepository { get; set; }
		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiOrganizationRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		private async Task<bool> BeUniqueGetName(ApiOrganizationRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.OrganizationRepository.GetName(model.Name);

			return record == null;
		}
	}
}

/*<Codenesium>
    <Hash>dd218b9da7147383206b4c3a126a832c</Hash>
</Codenesium>*/