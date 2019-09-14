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
	public class ApiUnitServerRequestModelValidator : AbstractValidator<ApiUnitServerRequestModel>, IApiUnitServerRequestModelValidator
	{
		private int existingRecordId;

		protected IUnitRepository UnitRepository { get; private set; }

		public ApiUnitServerRequestModelValidator(IUnitRepository unitRepository)
		{
			this.UnitRepository = unitRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiUnitServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiUnitServerRequestModel model)
		{
			this.CallSignRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiUnitServerRequestModel model)
		{
			this.CallSignRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void CallSignRules()
		{
			this.RuleFor(x => x.CallSign).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>d406b668d1025209c39ae76862c9e53d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/