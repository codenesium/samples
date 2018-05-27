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
	public abstract class AbstractApiChainStatusRequestModelValidator: AbstractValidator<ApiChainStatusRequestModel>
	{
		public new ValidationResult Validate(ApiChainStatusRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiChainStatusRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IChainStatusRepository ChainStatusRepository { get; set; }
		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiChainStatusRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		private async Task<bool> BeUniqueGetName(ApiChainStatusRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.ChainStatusRepository.GetName(model.Name);

			return record == null;
		}
	}
}

/*<Codenesium>
    <Hash>70c9298f90787fe9120cf582a0afee7a</Hash>
</Codenesium>*/