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
	public abstract class AbstractApiPersonRefRequestModelValidator : AbstractValidator<ApiPersonRefRequestModel>
	{
		private int existingRecordId;

		private IPersonRefRepository personRefRepository;

		public AbstractApiPersonRefRequestModelValidator(IPersonRefRepository personRefRepository)
		{
			this.personRefRepository = personRefRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPersonRefRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void PersonAIdRules()
		{
		}

		public virtual void PersonBIdRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>af45ac550f4f2aa406a74aa32d017ca1</Hash>
</Codenesium>*/