using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.BusinessObjects
{
	public interface IVersionInfoModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(VersionInfoModel model);
		Task<ValidationResult> ValidateUpdateAsync(long id, VersionInfoModel model);
		Task<ValidationResult> ValidateDeleteAsync(long id);
	}
}

/*<Codenesium>
    <Hash>e410aa145c2411aa4539ba8d996153f2</Hash>
</Codenesium>*/