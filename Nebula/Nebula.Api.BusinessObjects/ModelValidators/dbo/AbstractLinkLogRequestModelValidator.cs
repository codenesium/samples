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
	public abstract class AbstractApiLinkLogRequestModelValidator: AbstractValidator<ApiLinkLogRequestModel>
	{
		public new ValidationResult Validate(ApiLinkLogRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiLinkLogRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ILinkRepository LinkRepository { get; set; }
		public virtual void DateEnteredRules()
		{
			this.RuleFor(x => x.DateEntered).NotNull();
		}

		public virtual void LinkIdRules()
		{
			this.RuleFor(x => x.LinkId).NotNull();
			this.RuleFor(x => x.LinkId).MustAsync(this.BeValidLink).When(x => x ?.LinkId != null).WithMessage("Invalid reference");
		}

		public virtual void LogRules()
		{
			this.RuleFor(x => x.Log).NotNull();
			this.RuleFor(x => x.Log).Length(0, 2147483647);
		}

		private async Task<bool> BeValidLink(int id,  CancellationToken cancellationToken)
		{
			var record = await this.LinkRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>d62bb3e485645af5d9b35f3f0555a796</Hash>
</Codenesium>*/