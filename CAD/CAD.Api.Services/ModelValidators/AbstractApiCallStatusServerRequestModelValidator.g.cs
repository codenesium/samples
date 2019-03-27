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
	public abstract class AbstractApiCallStatusServerRequestModelValidator : AbstractValidator<ApiCallStatusServerRequestModel>
	{
		private int existingRecordId;

		protected ICallStatusRepository CallStatusRepository { get; private set; }

		public AbstractApiCallStatusServerRequestModelValidator(ICallStatusRepository callStatusRepository)
		{
			this.CallStatusRepository = callStatusRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCallStatusServerRequestModel model, int id)
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
    <Hash>39c7ed84b718ff4fa9ea064edef608d4</Hash>
</Codenesium>*/