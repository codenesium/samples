using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ISalesOrderDetailModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(SalesOrderDetailModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, SalesOrderDetailModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ac4c68795b198141d384df40c483154a</Hash>
</Codenesium>*/