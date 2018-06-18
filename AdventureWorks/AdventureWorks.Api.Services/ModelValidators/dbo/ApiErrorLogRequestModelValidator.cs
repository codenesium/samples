using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiErrorLogRequestModelValidator: AbstractApiErrorLogRequestModelValidator, IApiErrorLogRequestModelValidator
        {
                public ApiErrorLogRequestModelValidator(IErrorLogRepository errorLogRepository)
                        : base(errorLogRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiErrorLogRequestModel model)
                {
                        this.ErrorLineRules();
                        this.ErrorMessageRules();
                        this.ErrorNumberRules();
                        this.ErrorProcedureRules();
                        this.ErrorSeverityRules();
                        this.ErrorStateRules();
                        this.ErrorTimeRules();
                        this.UserNameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiErrorLogRequestModel model)
                {
                        this.ErrorLineRules();
                        this.ErrorMessageRules();
                        this.ErrorNumberRules();
                        this.ErrorProcedureRules();
                        this.ErrorSeverityRules();
                        this.ErrorStateRules();
                        this.ErrorTimeRules();
                        this.UserNameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>2a1de9e387220189ff24fc3ba474a633</Hash>
</Codenesium>*/