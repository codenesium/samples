using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ISalesOrderHeaderModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(SalesOrderHeaderModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, SalesOrderHeaderModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1864ff5b8f2d339b89c61294b04b71f4</Hash>
</Codenesium>*/