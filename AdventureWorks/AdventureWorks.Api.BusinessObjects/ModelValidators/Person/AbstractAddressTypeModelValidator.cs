using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiAddressTypeModelValidator: AbstractValidator<ApiAddressTypeModel>
	{
		public new ValidationResult Validate(ApiAddressTypeModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiAddressTypeModel model)
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
			this.RuleFor(x => x).Must(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint");
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		private bool BeUniqueGetName(ApiAddressTypeModel model)
		{
			return this.AddressTypeRepository.GetName(model.Name) != null;
		}
	}
}

/*<Codenesium>
    <Hash>42a76651607e83e56379535897bbb890</Hash>
</Codenesium>*/