using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IDatabaseLogModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(DatabaseLogModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, DatabaseLogModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>83496315c1085e17e295024cf259da94</Hash>
</Codenesium>*/