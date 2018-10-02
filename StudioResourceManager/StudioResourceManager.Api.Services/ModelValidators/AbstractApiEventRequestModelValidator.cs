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
	}
}

/*<Codenesium>
    <Hash>fa26a41e224e234fa9aaffdfe60f033f</Hash>
</Codenesium>*/