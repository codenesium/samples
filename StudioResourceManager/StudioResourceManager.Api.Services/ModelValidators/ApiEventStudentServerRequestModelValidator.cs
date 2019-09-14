using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiEventStudentServerRequestModelValidator : AbstractValidator<ApiEventStudentServerRequestModel>, IApiEventStudentServerRequestModelValidator
	{
		private int existingRecordId;

		protected IEventStudentRepository EventStudentRepository { get; private set; }

		public ApiEventStudentServerRequestModelValidator(IEventStudentRepository eventStudentRepository)
		{
			this.EventStudentRepository = eventStudentRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiEventStudentServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEventStudentServerRequestModel model)
		{
			this.EventIdRules();
			this.StudentIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventStudentServerRequestModel model)
		{
			this.EventIdRules();
			this.StudentIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void EventIdRules()
		{
			this.RuleFor(x => x.EventId).MustAsync(this.BeValidEventByEventId).When(x => !x?.EventId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void StudentIdRules()
		{
			this.RuleFor(x => x.StudentId).MustAsync(this.BeValidStudentByStudentId).When(x => !x?.StudentId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidEventByEventId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.EventStudentRepository.EventByEventId(id);

			return record != null;
		}

		protected async Task<bool> BeValidStudentByStudentId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.EventStudentRepository.StudentByStudentId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>a6e352ea65004cb0146b9f4a1a78c10a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/