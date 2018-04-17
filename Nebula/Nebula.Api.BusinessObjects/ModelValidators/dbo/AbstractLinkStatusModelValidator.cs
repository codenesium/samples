using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects

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
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>59a65ca749c103b709339084c1be97ce</Hash>
</Codenesium>*/