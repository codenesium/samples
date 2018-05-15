using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiContactTypeModelValidator: AbstractValidator<ApiContactTypeModel>
	{
		public new ValidationResult Validate(ApiContactTypeModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiContactTypeModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IContactTypeRepository ContactTypeRepository { get; set; }
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

		private bool BeUniqueGetName(ApiContactTypeModel model)
		{
			return this.ContactTypeRepository.GetName(model.Name) != null;
		}
	}
}

/*<Codenesium>
    <Hash>28a7ecf5e8edfd9bf0d6ae85d1a01bad</Hash>
</Codenesium>*/