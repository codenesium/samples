using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.BusinessObjects
{
	public interface IVersionInfoModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(VersionInfoModel model);
		Task<ValidationResult>  ValidateUpdateAsync(long id, VersionInfoModel model);
		Task<ValidationResult>  ValidateDeleteAsync(long id);
	}
}

/*<Codenesium>
    <Hash>096c5866b0d2961d8f7db14840137f57</Hash>
</Codenesium>*/