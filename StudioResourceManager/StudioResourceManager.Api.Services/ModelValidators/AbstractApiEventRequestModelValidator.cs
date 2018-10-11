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
	public abstract class AbstractApiEventRequestModelValidator : AbstractValidator<ApiEventRequestModel>
	{
		private int existingRecordId;

		private IEventRepository eventRepository;

		public AbstractApiEventRequestModelValidator(IEventRepository eventRepository)
		{
			this.eventRepository = eventRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiEventRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ActualEndDateRules()
		{
		}

		public virtual void ActualStartDateRules()
		{
		}

		public virtual void BillAmountRules()
		{
		}

		public virtual void EventStatusIdRules()
		{
			this.RuleFor(x => x.EventStatusId).MustAsync(this.BeValidEventStatusByEventStatusId).When(x => x?.EventStatusId != null).WithMessage("Invalid reference");
		}

		public virtual void ScheduledEndDateRules()
		{
		}

		public virtual void ScheduledStartDateRules()
		{
		}

		public virtual void StudentNoteRules()
		{
			this.RuleFor(x => x.StudentNote).Length(0, 2147483647);
		}

		public virtual void TeacherNoteRules()
		{
			this.RuleFor(x => x.TeacherNote).Length(0, 2147483647);
		}

		private async Task<bool> BeValidEventStatusByEventStatusId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.eventRepository.EventStatusByEventStatusId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>92cca29bc9e95af6c7aecbb8a24eada3</Hash>
</Codenesium>*/