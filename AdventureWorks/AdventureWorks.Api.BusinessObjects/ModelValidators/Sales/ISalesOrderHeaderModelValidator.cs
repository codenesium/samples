using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ISalesOrderHeaderModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(SalesOrderHeaderModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, SalesOrderHeaderModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cbf2fb9814d27902ab6c5c3c2b20a83d</Hash>
</Codenesium>*/