using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiSalesOrderDetailRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesOrderDetailRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesOrderDetailRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5c271674910fae7b3733d5b043b51a30</Hash>
</Codenesium>*/