using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services

{
	public abstract class AbstractApiLinkLogRequestModelValidator: AbstractValidator<ApiLinkLogRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiLinkLogRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiLinkLogRequestModel model, int id)
		{
			this.existingRecordId = id;
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
    <Hash>40922ce57e86c15f4431dfe07062beff</Hash>
</Codenesium>*/