using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractApiPersonServerRequestModelValidator : AbstractValidator<ApiPersonServerRequestModel>
	{
		private int existingRecordId;

		protected IPersonRepository PersonRepository { get; private set; }

		public AbstractApiPersonServerRequestModelValidator(IPersonRepository personRepository)
		{
			this.PersonRepository = personRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPersonServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void FirstNameRules()
		{
			this.RuleFor(x => x.FirstName).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void LastNameRules()
		{
			this.RuleFor(x => x.LastName).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PhoneRules()
		{
			this.RuleFor(x => x.Phone).Length(0, 32).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void SsnRules()
		{
			this.RuleFor(x => x.Ssn).Length(0, 12).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>bea70800db99d83dbd93371a2274b0ca</Hash>
</Codenesium>*/