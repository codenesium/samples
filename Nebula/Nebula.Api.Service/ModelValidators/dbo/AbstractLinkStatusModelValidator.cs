using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service

{
	public abstract class AbstractLinkStatusModelValidator: AbstractValidator<LinkStatusModel>
	{
		public new ValidationResult Validate(LinkStatusModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(LinkStatusModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,128);
		}
	}
}

/*<Codenesium>
    <Hash>bd8eb15916e2e1bf977f8c01615c87df</Hash>
</Codenesium>*/