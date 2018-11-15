using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiBusinessEntityServerRequestModelValidator : AbstractValidator<ApiBusinessEntityServerRequestModel>
	{
		private int existingRecordId;

		private IBusinessEntityRepository businessEntityRepository;

		public AbstractApiBusinessEntityServerRequestModelValidator(IBusinessEntityRepository businessEntityRepository)
		{
			this.businessEntityRepository = businessEntityRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiBusinessEntityServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => !x?.Rowguid.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiBusinessEntityServerRequestModel.Rowguid));
		}

		private async Task<bool> BeUniqueByRowguid(ApiBusinessEntityServerRequestModel model,  CancellationToken cancellationToken)
		{
			BusinessEntity record = await this.businessEntityRepository.ByRowguid(model.Rowguid);

			if (record == null || (this.existingRecordId != default(int) && record.BusinessEntityID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>4a420bec800a16f27e140cd3d225b81a</Hash>
</Codenesium>*/