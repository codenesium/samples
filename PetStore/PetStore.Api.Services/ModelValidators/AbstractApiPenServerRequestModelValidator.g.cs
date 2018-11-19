using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractApiPenServerRequestModelValidator : AbstractValidator<ApiPenServerRequestModel>
	{
		private int existingRecordId;

		private IPenRepository penRepository;

		public AbstractApiPenServerRequestModelValidator(IPenRepository penRepository)
		{
			this.penRepository = penRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPenServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>00c6c21fa0507d05c4dcd35651af45d5</Hash>
</Codenesium>*/