using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiColumnSameAsFKTableServerRequestModelValidator : AbstractValidator<ApiColumnSameAsFKTableServerRequestModel>
	{
		private int existingRecordId;

		private IColumnSameAsFKTableRepository columnSameAsFKTableRepository;

		public AbstractApiColumnSameAsFKTableServerRequestModelValidator(IColumnSameAsFKTableRepository columnSameAsFKTableRepository)
		{
			this.columnSameAsFKTableRepository = columnSameAsFKTableRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiColumnSameAsFKTableServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void PersonRules()
		{
		}

		public virtual void PersonIdRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>99b85f47bdedf87b5db2afdce6a87c4b</Hash>
</Codenesium>*/