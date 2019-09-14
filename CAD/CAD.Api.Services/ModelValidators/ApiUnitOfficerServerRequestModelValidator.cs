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
	public class ApiUnitOfficerServerRequestModelValidator : AbstractValidator<ApiUnitOfficerServerRequestModel>, IApiUnitOfficerServerRequestModelValidator
	{
		private int existingRecordId;

		protected IUnitOfficerRepository UnitOfficerRepository { get; private set; }

		public ApiUnitOfficerServerRequestModelValidator(IUnitOfficerRepository unitOfficerRepository)
		{
			this.UnitOfficerRepository = unitOfficerRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiUnitOfficerServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiUnitOfficerServerRequestModel model)
		{
			this.OfficerIdRules();
			this.UnitIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiUnitOfficerServerRequestModel model)
		{
			this.OfficerIdRules();
			this.UnitIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>7a43a3728f448ab8ead1494a1d270b4e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/