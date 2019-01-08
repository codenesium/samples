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
	public abstract class AbstractApiSelfReferenceServerRequestModelValidator : AbstractValidator<ApiSelfReferenceServerRequestModel>
	{
		private int existingRecordId;

		protected ISelfReferenceRepository SelfReferenceRepository { get; private set; }

		public AbstractApiSelfReferenceServerRequestModelValidator(ISelfReferenceRepository selfReferenceRepository)
		{
			this.SelfReferenceRepository = selfReferenceRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSelfReferenceServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void SelfReferenceIdRules()
		{
			this.RuleFor(x => x.SelfReferenceId).MustAsync(this.BeValidSelfReferenceBySelfReferenceId).When(x => !x?.SelfReferenceId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void SelfReferenceId2Rules()
		{
			this.RuleFor(x => x.SelfReferenceId2).MustAsync(this.BeValidSelfReferenceBySelfReferenceId2).When(x => !x?.SelfReferenceId2.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidSelfReferenceBySelfReferenceId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.SelfReferenceRepository.SelfReferenceBySelfReferenceId(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeValidSelfReferenceBySelfReferenceId2(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.SelfReferenceRepository.SelfReferenceBySelfReferenceId2(id.GetValueOrDefault());

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>ca80c4c9b009f2ebd911b6c4fcf1150f</Hash>
</Codenesium>*/