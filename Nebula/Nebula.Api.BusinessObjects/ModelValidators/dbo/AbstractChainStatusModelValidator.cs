using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects

{
	public abstract class AbstractApiChainStatusModelValidator: AbstractValidator<ApiChainStatusModel>
	{
		public new ValidationResult Validate(ApiChainStatusModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiChainStatusModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IChainStatusRepository ChainStatusRepository { get; set; }
		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiChainStatusModel.Name));
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		private bool BeUniqueGetName(ApiChainStatusModel model)
		{
			return this.ChainStatusRepository.GetName(model.Name) == null;
		}
	}
}

/*<Codenesium>
    <Hash>ec876902d8bec498dbafed3d23c58f2f</Hash>
</Codenesium>*/