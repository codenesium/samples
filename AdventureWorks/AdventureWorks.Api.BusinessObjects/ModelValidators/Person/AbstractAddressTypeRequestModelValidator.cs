using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiAddressTypeRequestModelValidator: AbstractValidator<ApiAddressTypeRequestModel>
	{
		public new ValidationResult Validate(ApiAddressTypeRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiAddressTypeRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IAddressTypeRepository AddressTypeRepository { get; set; }
		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiAddressTypeRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		private async Task<bool> BeUniqueGetName(ApiAddressTypeRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.AddressTypeRepository.GetName(model.Name);

			return record == null;
		}
	}
}

/*<Codenesium>
    <Hash>2f83fdaa7e19873db8c1731990b513f1</Hash>
</Codenesium>*/