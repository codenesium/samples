using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractApiUnitOfficerServerRequestModelValidator : AbstractValidator<ApiUnitOfficerServerRequestModel>
	{
		private int existingRecordId;

		protected IUnitOfficerRepository UnitOfficerRepository { get; private set; }

		public AbstractApiUnitOfficerServerRequestModelValidator(IUnitOfficerRepository unitOfficerRepository)
		{
			this.UnitOfficerRepository = unitOfficerRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiUnitOfficerServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void OfficerIdRules()
		{
			this.RuleFor(x => x.OfficerId).MustAsync(this.BeValidOfficerByOfficerId).When(x => !x?.OfficerId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void UnitIdRules()
		{
			this.RuleFor(x => x.UnitId).MustAsync(this.BeValidUnitByUnitId).When(x => !x?.UnitId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidOfficerByOfficerId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.UnitOfficerRepository.OfficerByOfficerId(id);

			return record != null;
		}

		protected async Task<bool> BeValidUnitByUnitId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.UnitOfficerRepository.UnitByUnitId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>9b080b740de492938be5a18a9b049018</Hash>
</Codenesium>*/