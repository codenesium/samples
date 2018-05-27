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
	public abstract class AbstractApiLinkStatusRequestModelValidator: AbstractValidator<ApiLinkStatusRequestModel>
	{
		public new ValidationResult Validate(ApiLinkStatusRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiLinkStatusRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ILinkStatusRepository LinkStatusRepository { get; set; }
		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiLinkStatusRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		private async Task<bool> BeUniqueGetName(ApiLinkStatusRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.LinkStatusRepository.GetName(model.Name);

			return record == null;
		}
	}
}

/*<Codenesium>
    <Hash>739e0b9fa43483e1070ac2ed1aa3ead4</Hash>
</Codenesium>*/