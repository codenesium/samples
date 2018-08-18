using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractApiFamilyRequestModelValidator : AbstractValidator<ApiFamilyRequestModel>
	{
		private int existingRecordId;

		private IFamilyRepository familyRepository;

		public AbstractApiFamilyRequestModelValidator(IFamilyRepository familyRepository)
		{
			this.familyRepository = familyRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiFamilyRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NotesRules()
		{
			this.RuleFor(x => x.Notes).Length(0, 2147483647);
		}

		public virtual void PcEmailRules()
		{
			this.RuleFor(x => x.PcEmail).Length(0, 128);
		}

		public virtual void PcFirstNameRules()
		{
			this.RuleFor(x => x.PcFirstName).Length(0, 128);
		}

		public virtual void PcLastNameRules()
		{
			this.RuleFor(x => x.PcLastName).Length(0, 128);
		}

		public virtual void PcPhoneRules()
		{
			this.RuleFor(x => x.PcPhone).Length(0, 128);
		}

		public virtual void StudioIdRules()
		{
			this.RuleFor(x => x.StudioId).MustAsync(this.BeValidStudio).When(x => x?.StudioId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidStudio(int id,  CancellationToken cancellationToken)
		{
			var record = await this.familyRepository.GetStudio(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>84ff839c15e4921e866251668078dfa5</Hash>
</Codenesium>*/