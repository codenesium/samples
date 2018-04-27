using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects

{
	public abstract class AbstractLinkLogModelValidator: AbstractValidator<LinkLogModel>
	{
		public new ValidationResult Validate(LinkLogModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(LinkLogModel model)
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
			this.RuleFor(x => x.LinkId).Must(this.BeValidLink).When(x => x ?.LinkId != null).WithMessage("Invalid reference");
		}

		public virtual void LogRules()
		{
			this.RuleFor(x => x.Log).NotNull();
			this.RuleFor(x => x.Log).Length(0, 2147483647);
		}

		private bool BeValidLink(int id)
		{
			return this.LinkRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>e7a53f1ddf3a232b9b2efdba1b4f4b79</Hash>
</Codenesium>*/