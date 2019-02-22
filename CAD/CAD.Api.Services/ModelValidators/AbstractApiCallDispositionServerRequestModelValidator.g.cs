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
	public abstract class AbstractApiCallDispositionServerRequestModelValidator : AbstractValidator<ApiCallDispositionServerRequestModel>
	{
		private int existingRecordId;

		protected ICallDispositionRepository CallDispositionRepository { get; private set; }

		public AbstractApiCallDispositionServerRequestModelValidator(ICallDispositionRepository callDispositionRepository)
		{
			this.CallDispositionRepository = callDispositionRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCallDispositionServerRequestModel model, int id)
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
    <Hash>5bf56f2b4bd2c4e6bf9683a70c8b44f3</Hash>
</Codenesium>*/