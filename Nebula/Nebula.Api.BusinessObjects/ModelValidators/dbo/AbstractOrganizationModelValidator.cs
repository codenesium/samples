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
			this.RuleFor(x => x).Must(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiOrganizationModel.Name));
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		private bool BeUniqueGetName(ApiOrganizationModel model)
		{
			return this.OrganizationRepository.GetName(model.Name) == null;
		}
	}
}

/*<Codenesium>
    <Hash>9887627d826b2082c5563c16c106ffe5</Hash>
</Codenesium>*/