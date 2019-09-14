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
	public class ApiVPersonServerRequestModelValidator : AbstractValidator<ApiVPersonServerRequestModel>, IApiVPersonServerRequestModelValidator
	{
		private int existingRecordId;

		protected IVPersonRepository VPersonRepository { get; private set; }

		public ApiVPersonServerRequestModelValidator(IVPersonRepository vPersonRepository)
		{
			this.VPersonRepository = vPersonRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVPersonServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVPersonServerRequestModel model)
		{
			this.PersonNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVPersonServerRequestModel model)
		{
			this.PersonNameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void PersonNameRules()
		{
			this.RuleFor(x => x.PersonName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.PersonName).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>4e71468becf570e689e398a28e9573a7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/