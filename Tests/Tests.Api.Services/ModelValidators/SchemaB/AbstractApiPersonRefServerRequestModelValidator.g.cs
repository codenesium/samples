using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiPersonRefServerRequestModelValidator : AbstractValidator<ApiPersonRefServerRequestModel>
	{
		private int existingRecordId;

		private IPersonRefRepository personRefRepository;

		public AbstractApiPersonRefServerRequestModelValidator(IPersonRefRepository personRefRepository)
		{
			this.personRefRepository = personRefRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPersonRefServerRequestModel model, int id)
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
    <Hash>4ab0ae6a2836d389e313ee6d081015d3</Hash>
</Codenesium>*/