using Codenesium.DataConversionExtensions;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
        public abstract class AbstractApiFileTypeRequestModelValidator : AbstractValidator<ApiFileTypeRequestModel>
        {
                private int existingRecordId;

                private IFileTypeRepository fileTypeRepository;

                public AbstractApiFileTypeRequestModelValidator(IFileTypeRepository fileTypeRepository)
                {
                        this.fileTypeRepository = fileTypeRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiFileTypeRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).Length(0, 255);
                }
        }
}

/*<Codenesium>
    <Hash>7ddb76448c92d3ff5678f272ec29f513</Hash>
</Codenesium>*/