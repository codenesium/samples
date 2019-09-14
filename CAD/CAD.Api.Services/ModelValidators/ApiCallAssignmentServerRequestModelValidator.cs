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
	public class ApiCallAssignmentServerRequestModelValidator : AbstractValidator<ApiCallAssignmentServerRequestModel>, IApiCallAssignmentServerRequestModelValidator
	{
		private int existingRecordId;

		protected ICallAssignmentRepository CallAssignmentRepository { get; private set; }

		public ApiCallAssignmentServerRequestModelValidator(ICallAssignmentRepository callAssignmentRepository)
		{
			this.CallAssignmentRepository = callAssignmentRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCallAssignmentServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCallAssignmentServerRequestModel model)
		{
			this.CallIdRules();
			this.UnitIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCallAssignmentServerRequestModel model)
		{
			this.CallIdRules();
			this.UnitIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>dd34f3b7f1eb126ce664101a6beafa65</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/