using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractEmailAddressModelValidator: AbstractValidator<EmailAddressModel>
	{
		public new ValidationResult Validate(EmailAddressModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(EmailAddressModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IPersonRepository PersonRepository {get; set;}
		public virtual void EmailAddressIDRules()
		{
			RuleFor(x => x.EmailAddressID).NotNull();
		}

		public virtual void EmailAddress1Rules()
		{
			RuleFor(x => x.EmailAddress1).Length(0,50);
		}

		public virtual void RowguidRules()
		{
			RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		public bool BeValidPerson(int id)
		{
			Response response = new Response();

			this.PersonRepository.GetById(id,response);
			return response.People.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>e37dff9e9edd695f6eea771eed8fda5c</Hash>
</Codenesium>*/