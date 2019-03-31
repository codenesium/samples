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
	public abstract class AbstractApiEventTeacherServerRequestModelValidator : AbstractValidator<ApiEventTeacherServerRequestModel>
	{
		private int existingRecordId;

		protected IEventTeacherRepository EventTeacherRepository { get; private set; }

		public AbstractApiEventTeacherServerRequestModelValidator(IEventTeacherRepository eventTeacherRepository)
		{
			this.EventTeacherRepository = eventTeacherRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiEventTeacherServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void EventIdRules()
		{
			this.RuleFor(x => x.EventId).MustAsync(this.BeValidEventByEventId).When(x => !x?.EventId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void TeacherIdRules()
		{
			this.RuleFor(x => x.TeacherId).MustAsync(this.BeValidTeacherByTeacherId).When(x => !x?.TeacherId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidEventByEventId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.EventTeacherRepository.EventByEventId(id);

			return record != null;
		}

		protected async Task<bool> BeValidTeacherByTeacherId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.EventTeacherRepository.TeacherByTeacherId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>7dc2fc186b0d182395c1aca1dc55c9cc</Hash>
</Codenesium>*/