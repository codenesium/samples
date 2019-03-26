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
	public abstract class AbstractApiEventStudentServerRequestModelValidator : AbstractValidator<ApiEventStudentServerRequestModel>
	{
		private int existingRecordId;

		protected IEventStudentRepository EventStudentRepository { get; private set; }

		public AbstractApiEventStudentServerRequestModelValidator(IEventStudentRepository eventStudentRepository)
		{
			this.EventStudentRepository = eventStudentRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiEventStudentServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
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
    <Hash>0a3a92cc436ce6abab132b1db713955a</Hash>
</Codenesium>*/