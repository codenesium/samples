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
	public abstract class AbstractApiCallStatuServerRequestModelValidator : AbstractValidator<ApiCallStatuServerRequestModel>
	{
		private int existingRecordId;

		protected ICallStatuRepository CallStatuRepository { get; private set; }

		public AbstractApiCallStatuServerRequestModelValidator(ICallStatuRepository callStatuRepository)
		{
			this.CallStatuRepository = callStatuRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCallStatuServerRequestModel model, int id)
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
    <Hash>2781fa2c7ec17ebe3ec52c511a6cc4cd</Hash>
</Codenesium>*/