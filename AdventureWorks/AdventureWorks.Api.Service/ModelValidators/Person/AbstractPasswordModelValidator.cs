using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractPasswordModelValidator: AbstractValidator<PasswordModel>
	{
		public new ValidationResult Validate(PasswordModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(PasswordModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IPersonRepository PersonRepository {get; set;}
		public virtual void PasswordHashRules()
		{
			RuleFor(x => x.PasswordHash).NotNull();
			RuleFor(x => x.PasswordHash).Length(0,128);
		}

		public virtual void PasswordSaltRules()
		{
			RuleFor(x => x.PasswordSalt).NotNull();
			RuleFor(x => x.PasswordSalt).Length(0,10);
		}

		public virtual void RowguidRules()
		{
			RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidPerson(int id)
		{
			return this.PersonRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>8c972aeec31be00e3ba96e524b3b6d44</Hash>
</Codenesium>*/