using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services

{
	public abstract class AbstractApiFamilyRequestModelValidator: AbstractValidator<ApiFamilyRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiFamilyRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiFamilyRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public IStudioRepository StudioRepository { get; set; }
		public virtual void NotesRules()
		{
			this.RuleFor(x => x.Notes).NotNull();
			this.RuleFor(x => x.Notes).Length(0, 2147483647);
		}

		public virtual void PcEmailRules()
		{
			this.RuleFor(x => x.PcEmail).NotNull();
			this.RuleFor(x => x.PcEmail).Length(0, 128);
		}

		public virtual void PcFirstNameRules()
		{
			this.RuleFor(x => x.PcFirstName).NotNull();
			this.RuleFor(x => x.PcFirstName).Length(0, 128);
		}

		public virtual void PcLastNameRules()
		{
			this.RuleFor(x => x.PcLastName).NotNull();
			this.RuleFor(x => x.PcLastName).Length(0, 128);
		}

		public virtual void PcPhoneRules()
		{
			this.RuleFor(x => x.PcPhone).NotNull();
			this.RuleFor(x => x.PcPhone).Length(0, 128);
		}

		public virtual void StudioIdRules()
		{
			this.RuleFor(x => x.StudioId).NotNull();
			this.RuleFor(x => x.StudioId).MustAsync(this.BeValidStudio).When(x => x ?.StudioId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidStudio(int id,  CancellationToken cancellationToken)
		{
			var record = await this.StudioRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>d2a35fc2205f942395e30b31f17acb28</Hash>
</Codenesium>*/