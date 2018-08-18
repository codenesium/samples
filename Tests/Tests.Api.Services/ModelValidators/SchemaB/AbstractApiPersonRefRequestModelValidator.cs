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
			this.RuleFor(x => x.PersonBId).MustAsync(this.BeValidSchemaBPerson).When(x => x?.PersonBId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidSchemaBPerson(int id,  CancellationToken cancellationToken)
		{
			var record = await this.personRefRepository.GetSchemaBPerson(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>13458ede78a5df6b823a94a97ad88c4a</Hash>
</Codenesium>*/