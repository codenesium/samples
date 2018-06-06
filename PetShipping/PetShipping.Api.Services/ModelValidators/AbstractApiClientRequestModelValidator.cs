using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services

{
	public abstract class AbstractApiClientRequestModelValidator: AbstractValidator<ApiClientRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiClientRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiClientRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public virtual void EmailRules()
		{
			this.RuleFor(x => x.Email).NotNull();
			this.RuleFor(x => x.Email).Length(0, 128);
		}

		public virtual void FirstNameRules()
		{
			this.RuleFor(x => x.FirstName).NotNull();
			this.RuleFor(x => x.FirstName).Length(0, 128);
		}

		public virtual void LastNameRules()
		{
			this.RuleFor(x => x.LastName).NotNull();
			this.RuleFor(x => x.LastName).Length(0, 128);
		}

		public virtual void NotesRules()
		{
			this.RuleFor(x => x.Notes).Length(0, 2147483647);
		}

		public virtual void PhoneRules()
		{
			this.RuleFor(x => x.Phone).NotNull();
			this.RuleFor(x => x.Phone).Length(0, 10);
		}
	}
}

/*<Codenesium>
    <Hash>f2f0473db0084c66b83815d6324196f4</Hash>
</Codenesium>*/