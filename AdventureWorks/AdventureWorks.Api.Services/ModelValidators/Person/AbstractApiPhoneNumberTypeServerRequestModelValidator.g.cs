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
	public abstract class AbstractApiPhoneNumberTypeServerRequestModelValidator : AbstractValidator<ApiPhoneNumberTypeServerRequestModel>
	{
		private int existingRecordId;

		private IPhoneNumberTypeRepository phoneNumberTypeRepository;

		public AbstractApiPhoneNumberTypeServerRequestModelValidator(IPhoneNumberTypeRepository phoneNumberTypeRepository)
		{
			this.phoneNumberTypeRepository = phoneNumberTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPhoneNumberTypeServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>c9886162908cf90e313ef626b10a040d</Hash>
</Codenesium>*/