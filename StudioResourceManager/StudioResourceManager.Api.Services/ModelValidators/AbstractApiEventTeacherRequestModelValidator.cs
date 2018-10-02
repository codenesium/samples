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

		public virtual void EventIdRules()
		{
			this.RuleFor(x => x.EventId).MustAsync(this.BeValidEvent).When(x => x?.EventId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidEvent(int id,  CancellationToken cancellationToken)
		{
			var record = await this.eventTeacherRepository.GetEvent(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>64210302c572d7d1d4a1762bc57ace49</Hash>
</Codenesium>*/