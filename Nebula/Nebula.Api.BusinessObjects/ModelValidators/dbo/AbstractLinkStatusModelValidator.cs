using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects

{
	public abstract class AbstractApiLinkStatusModelValidator: AbstractValidator<ApiLinkStatusModel>
	{
		public new ValidationResult Validate(ApiLinkStatusModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiLinkStatusModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ILinkStatusRepository LinkStatusRepository { get; set; }
		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueName).When(x => x ?.Name != null).WithMessage("Violates unique constraint");
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		private bool BeUniqueName(ApiLinkStatusModel model)
		{
			return this.LinkStatusRepository.Name(model.Name) != null;
		}
	}
}

/*<Codenesium>
    <Hash>c9fe1ef35a20de3b0f6ee7625cb31755</Hash>
</Codenesium>*/