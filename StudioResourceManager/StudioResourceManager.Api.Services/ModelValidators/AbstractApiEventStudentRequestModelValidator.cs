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
	public abstract class AbstractApiEventStudentRequestModelValidator : AbstractValidator<ApiEventStudentRequestModel>
	{
		private int existingRecordId;

		private IEventStudentRepository eventStudentRepository;

		public AbstractApiEventStudentRequestModelValidator(IEventStudentRepository eventStudentRepository)
		{
			this.eventStudentRepository = eventStudentRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiEventStudentRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void EventIdRules()
		{
			this.RuleFor(x => x.EventId).MustAsync(this.BeValidEvent).When(x => x?.EventId != null).WithMessage("Invalid reference");
		}

		public virtual void StudentIdRules()
		{
			this.RuleFor(x => x.StudentId).MustAsync(this.BeValidStudent).When(x => x?.StudentId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidEvent(int id,  CancellationToken cancellationToken)
		{
			var record = await this.eventStudentRepository.GetEvent(id);

			return record != null;
		}

		private async Task<bool> BeValidStudent(int id,  CancellationToken cancellationToken)
		{
			var record = await this.eventStudentRepository.GetStudent(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>5782d622c8b3ef289674c8f0bdb0c0a4</Hash>
</Codenesium>*/