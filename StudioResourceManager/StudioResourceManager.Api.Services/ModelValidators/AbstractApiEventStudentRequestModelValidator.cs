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

		public virtual void StudentIdRules()
		{
			this.RuleFor(x => x.StudentId).MustAsync(this.BeValidStudentByStudentId).When(x => x?.StudentId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidEventByEventId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.eventStudentRepository.EventByEventId(id);

			return record != null;
		}

		private async Task<bool> BeValidStudentByStudentId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.eventStudentRepository.StudentByStudentId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>240dfa83fd05a9b27fc57d41e8b3b39a</Hash>
</Codenesium>*/