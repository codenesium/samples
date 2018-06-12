using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractNuGetPackageService: AbstractService
        {
                private INuGetPackageRepository nuGetPackageRepository;

                private IApiNuGetPackageRequestModelValidator nuGetPackageModelValidator;

                private IBOLNuGetPackageMapper bolNuGetPackageMapper;

                private IDALNuGetPackageMapper dalNuGetPackageMapper;

                private ILogger logger;

                public AbstractNuGetPackageService(
                        ILogger logger,
                        INuGetPackageRepository nuGetPackageRepository,
                        IApiNuGetPackageRequestModelValidator nuGetPackageModelValidator,
                        IBOLNuGetPackageMapper bolnuGetPackageMapper,
                        IDALNuGetPackageMapper dalnuGetPackageMapper)
                        : base()

                {
                        this.nuGetPackageRepository = nuGetPackageRepository;
                        this.nuGetPackageModelValidator = nuGetPackageModelValidator;
                        this.bolNuGetPackageMapper = bolnuGetPackageMapper;
                        this.dalNuGetPackageMapper = dalnuGetPackageMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiNuGetPackageResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.nuGetPackageRepository.All(skip, take, orderClause);

                        return this.bolNuGetPackageMapper.MapBOToModel(this.dalNuGetPackageMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiNuGetPackageResponseModel> Get(string id)
                {
                        var record = await this.nuGetPackageRepository.Get(id);

                        return this.bolNuGetPackageMapper.MapBOToModel(this.dalNuGetPackageMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiNuGetPackageResponseModel>> Create(
                        ApiNuGetPackageRequestModel model)
                {
                        CreateResponse<ApiNuGetPackageResponseModel> response = new CreateResponse<ApiNuGetPackageResponseModel>(await this.nuGetPackageModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolNuGetPackageMapper.MapModelToBO(default (string), model);
                                var record = await this.nuGetPackageRepository.Create(this.dalNuGetPackageMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolNuGetPackageMapper.MapBOToModel(this.dalNuGetPackageMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiNuGetPackageRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.nuGetPackageModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolNuGetPackageMapper.MapModelToBO(id, model);
                                await this.nuGetPackageRepository.Update(this.dalNuGetPackageMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.nuGetPackageModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.nuGetPackageRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>d53076c2af67b2914f9d186d5cef6f10</Hash>
</Codenesium>*/