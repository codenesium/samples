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
	public abstract class AbstractApiCallAssignmentServerRequestModelValidator : AbstractValidator<ApiCallAssignmentServerRequestModel>
	{
		private int existingRecordId;

		protected ICallAssignmentRepository CallAssignmentRepository { get; private set; }

		public AbstractApiCallAssignmentServerRequestModelValidator(ICallAssignmentRepository callAssignmentRepository)
		{
			this.CallAssignmentRepository = callAssignmentRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCallAssignmentServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CallIdRules()
		{
			this.RuleFor(x => x.CallId).MustAsync(this.BeValidCallByCallId).When(x => !x?.CallId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void UnitIdRules()
		{
			this.RuleFor(x => x.UnitId).MustAsync(this.BeValidUnitByUnitId).When(x => !x?.UnitId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidCallByCallId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.CallAssignmentRepository.CallByCallId(id);

			return record != null;
		}

		protected async Task<bool> BeValidUnitByUnitId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.CallAssignmentRepository.UnitByUnitId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>d7818a6f38045b43c34f8af22eeed271</Hash>
</Codenesium>*/