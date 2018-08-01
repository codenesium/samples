using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiPersonPhoneRequestModelValidator : AbstractValidator<ApiPersonPhoneRequestModel>
	{
		private int existingRecordId;

		private IPersonPhoneRepository personPhoneRepository;

		public AbstractApiPersonPhoneRequestModelValidator(IPersonPhoneRepository personPhoneRepository)
		{
			this.personPhoneRepository = personPhoneRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPersonPhoneRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void PhoneNumberRules()
		{
			this.RuleFor(x => x.PhoneNumber).NotNull();
			this.RuleFor(x => x.PhoneNumber).Length(0, 25);
		}

		public virtual void PhoneNumberTypeIDRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>a7c5285f594a146c452be8bce877a929</Hash>
</Codenesium>*/