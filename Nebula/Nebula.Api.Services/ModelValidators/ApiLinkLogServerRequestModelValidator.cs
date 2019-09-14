using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiLinkLogServerRequestModelValidator : AbstractValidator<ApiLinkLogServerRequestModel>, IApiLinkLogServerRequestModelValidator
	{
		private int existingRecordId;

		protected ILinkLogRepository LinkLogRepository { get; private set; }

		public ApiLinkLogServerRequestModelValidator(ILinkLogRepository linkLogRepository)
		{
			this.LinkLogRepository = linkLogRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLinkLogServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiLinkLogServerRequestModel model)
		{
			this.DateEnteredRules();
			this.LinkIdRules();
			this.LogRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkLogServerRequestModel model)
		{
			this.DateEnteredRules();
			this.LinkIdRules();
			this.LogRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void DateEnteredRules()
		{
		}

		public virtual void LinkIdRules()
		{
			this.RuleFor(x => x.LinkId).MustAsync(this.BeValidLinkByLinkId).When(x => !x?.LinkId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void LogRules()
		{
			this.RuleFor(x => x.Log).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Log).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeValidLinkByLinkId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.LinkLogRepository.LinkByLinkId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>a78b2adde3ef4bb9e9c8d7c156bfb7e7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/