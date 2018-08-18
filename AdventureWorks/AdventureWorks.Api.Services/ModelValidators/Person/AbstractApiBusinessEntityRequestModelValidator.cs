using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiBusinessEntityRequestModelValidator : AbstractValidator<ApiBusinessEntityRequestModel>
	{
		private int existingRecordId;

		private IBusinessEntityRepository businessEntityRepository;

		public AbstractApiBusinessEntityRequestModelValidator(IBusinessEntityRepository businessEntityRepository)
		{
			this.businessEntityRepository = businessEntityRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiBusinessEntityRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void RowguidRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>abd72c1e9eea8a7166235292d18652c6</Hash>
</Codenesium>*/