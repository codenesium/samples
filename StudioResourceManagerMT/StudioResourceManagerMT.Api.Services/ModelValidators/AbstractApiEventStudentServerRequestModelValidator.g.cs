using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>8d42aded20261f5a558d594b3394301a</Hash>
</Codenesium>*/