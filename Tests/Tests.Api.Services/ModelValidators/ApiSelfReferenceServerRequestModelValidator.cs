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
	public class ApiSelfReferenceServerRequestModelValidator : AbstractValidator<ApiSelfReferenceServerRequestModel>, IApiSelfReferenceServerRequestModelValidator
	{
		private int existingRecordId;

		protected ISelfReferenceRepository SelfReferenceRepository { get; private set; }

		public ApiSelfReferenceServerRequestModelValidator(ISelfReferenceRepository selfReferenceRepository)
		{
			this.SelfReferenceRepository = selfReferenceRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSelfReferenceServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSelfReferenceServerRequestModel model)
		{
			this.SelfReferenceIdRules();
			this.SelfReferenceId2Rules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSelfReferenceServerRequestModel model)
		{
			this.SelfReferenceIdRules();
			this.SelfReferenceId2Rules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>0f7263e22a65ea2f99d41e07d0b03883</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/