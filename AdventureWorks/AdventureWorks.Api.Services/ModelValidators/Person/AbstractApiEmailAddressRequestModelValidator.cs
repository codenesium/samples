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
	public abstract class AbstractApiEmailAddressRequestModelValidator : AbstractValidator<ApiEmailAddressRequestModel>
	{
		private int existingRecordId;

		private IEmailAddressRepository emailAddressRepository;

		public AbstractApiEmailAddressRequestModelValidator(IEmailAddressRepository emailAddressRepository)
		{
			this.emailAddressRepository = emailAddressRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiEmailAddressRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void EmailAddress1Rules()
		{
			this.RuleFor(x => x.EmailAddress1).Length(0, 50);
		}

		public virtual void EmailAddressIDRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void RowguidRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>5aa982cb926e61afeec49def43a9e158</Hash>
</Codenesium>*/