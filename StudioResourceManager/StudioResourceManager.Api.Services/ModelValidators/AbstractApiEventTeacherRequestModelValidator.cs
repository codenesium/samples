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
	public abstract class AbstractApiEventTeacherRequestModelValidator : AbstractValidator<ApiEventTeacherRequestModel>
	{
		private int existingRecordId;

		private IEventTeacherRepository eventTeacherRepository;

		public AbstractApiEventTeacherRequestModelValidator(IEventTeacherRepository eventTeacherRepository)
		{
			this.eventTeacherRepository = eventTeacherRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiEventTeacherRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void TeacherIdRules()
		{
			this.RuleFor(x => x.TeacherId).MustAsync(this.BeValidTeacherByTeacherId).When(x => x?.TeacherId != null).WithMessage("Invalid reference");
		}

		public virtual void IsDeletedRules()
		{
		}

		private async Task<bool> BeValidEventByEventId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.eventTeacherRepository.EventByEventId(id);

			return record != null;
		}

		private async Task<bool> BeValidTeacherByTeacherId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.eventTeacherRepository.TeacherByTeacherId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>21b758fbe50637fed3654a947e7f894d</Hash>
</Codenesium>*/