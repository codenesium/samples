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
	public abstract class AbstractApiUnitDispositionServerRequestModelValidator : AbstractValidator<ApiUnitDispositionServerRequestModel>
	{
		private int existingRecordId;

		protected IUnitDispositionRepository UnitDispositionRepository { get; private set; }

		public AbstractApiUnitDispositionServerRequestModelValidator(IUnitDispositionRepository unitDispositionRepository)
		{
			this.UnitDispositionRepository = unitDispositionRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiUnitDispositionServerRequestModel model, int id)
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
    <Hash>46e85e884921d5704808196cbfe8c4e9</Hash>
</Codenesium>*/