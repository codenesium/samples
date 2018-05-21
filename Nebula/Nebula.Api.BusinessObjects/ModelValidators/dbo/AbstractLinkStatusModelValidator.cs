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
			this.RuleFor(x => x).Must(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiLinkStatusModel.Name));
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		private bool BeUniqueGetName(ApiLinkStatusModel model)
		{
			return this.LinkStatusRepository.GetName(model.Name) == null;
		}
	}
}

/*<Codenesium>
    <Hash>68b8da4bbee979d9cd0dc55d73cc278e</Hash>
</Codenesium>*/