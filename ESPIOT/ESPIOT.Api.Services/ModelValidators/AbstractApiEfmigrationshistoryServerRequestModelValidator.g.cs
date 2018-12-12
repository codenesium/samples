using Codenesium.DataConversionExtensions;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public abstract class AbstractApiEfmigrationshistoryServerRequestModelValidator : AbstractValidator<ApiEfmigrationshistoryServerRequestModel>
	{
		private string existingRecordId;

		protected IEfmigrationshistoryRepository EfmigrationshistoryRepository { get; private set; }

		public AbstractApiEfmigrationshistoryServerRequestModelValidator(IEfmigrationshistoryRepository efmigrationshistoryRepository)
		{
			this.EfmigrationshistoryRepository = efmigrationshistoryRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiEfmigrationshistoryServerRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ProductVersionRules()
		{
			this.RuleFor(x => x.ProductVersion).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.ProductVersion).Length(0, 32).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>3e61466007df5c64eb3cfeb9b322afb0</Hash>
</Codenesium>*/