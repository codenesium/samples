using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IDatabaseLogModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(DatabaseLogModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, DatabaseLogModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e8209dbac771bf4aada276efbb71d979</Hash>
</Codenesium>*/