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
			this.RuleFor(x => x).Must(this.BeUniqueName).When(x => x ?.Name != null).WithMessage("Violates unique constraint");
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		private bool BeUniqueName(ApiOrganizationModel model)
		{
			return this.OrganizationRepository.Name(model.Name) != null;
		}
	}
}

/*<Codenesium>
    <Hash>d92b58e7bc98a4d5347536f225c9570d</Hash>
</Codenesium>*/