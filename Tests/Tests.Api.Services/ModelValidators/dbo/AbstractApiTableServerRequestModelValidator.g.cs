using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiTableServerRequestModelValidator : AbstractValidator<ApiTableServerRequestModel>
	{
		private int existingRecordId;

		private ITableRepository tableRepository;

		public AbstractApiTableServerRequestModelValidator(ITableRepository tableRepository)
		{
			this.tableRepository = tableRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTableServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>0cd978a39e2b93f871735b18b601698e</Hash>
</Codenesium>*/