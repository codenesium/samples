using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ISalesOrderHeaderSalesReasonModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(SalesOrderHeaderSalesReasonModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, SalesOrderHeaderSalesReasonModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>36071e81a0920a98ef51951fa50cf27b</Hash>
</Codenesium>*/