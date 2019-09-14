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
	public class ApiEventTeacherServerRequestModelValidator : AbstractValidator<ApiEventTeacherServerRequestModel>, IApiEventTeacherServerRequestModelValidator
	{
		private int existingRecordId;

		protected IEventTeacherRepository EventTeacherRepository { get; private set; }

		public ApiEventTeacherServerRequestModelValidator(IEventTeacherRepository eventTeacherRepository)
		{
			this.EventTeacherRepository = eventTeacherRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiEventTeacherServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEventTeacherServerRequestModel model)
		{
			this.EventIdRules();
			this.TeacherIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventTeacherServerRequestModel model)
		{
			this.EventIdRules();
			this.TeacherIdRules();
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
    <Hash>2d9103b79cebed16ad4b0c99d691c2f3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/