using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects

{
	public abstract class AbstractApiOrganizationModelValidator: AbstractValidator<ApiOrganizationModel>
	{
		public new ValidationResult Validate(ApiOrganizationModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiOrganizationModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IOrganizationRepository OrganizationRepository { get; set; }
		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiOrganizationModel.Name));
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		private bool BeUniqueName(ApiOrganizationModel model)
		{
			return this.OrganizationRepository.Name(model.Name) == null;
		}
	}
}

/*<Codenesium>
    <Hash>fe8e10efd225e8041b41065271bd31c9</Hash>
</Codenesium>*/