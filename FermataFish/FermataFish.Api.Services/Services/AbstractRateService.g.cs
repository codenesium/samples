using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractRateService: AbstractService
        {
                private IRateRepository rateRepository;

                private IApiRateRequestModelValidator rateModelValidator;

                private IBOLRateMapper bolRateMapper;

                private IDALRateMapper dalRateMapper;

                private ILogger logger;

                public AbstractRateService(
                        ILogger logger,
                        IRateRepository rateRepository,
                        IApiRateRequestModelValidator rateModelValidator,
                        IBOLRateMapper bolrateMapper,
                        IDALRateMapper dalrateMapper)
                        : base()

                {
                        this.rateRepository = rateRepository;
                        this.rateModelValidator = rateModelValidator;
                        this.bolRateMapper = bolrateMapper;
                        this.dalRateMapper = dalrateMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiRateResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.rateRepository.All(skip, take, orderClause);

                        return this.bolRateMapper.MapBOToModel(this.dalRateMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiRateResponseModel> Get(int id)
                {
                        var record = await this.rateRepository.Get(id);

                        return this.bolRateMapper.MapBOToModel(this.dalRateMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiRateResponseModel>> Create(
                        ApiRateRequestModel model)
                {
                        CreateResponse<ApiRateResponseModel> response = new CreateResponse<ApiRateResponseModel>(await this.rateModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolRateMapper.MapModelToBO(default (int), model);
                                var record = await this.rateRepository.Create(this.dalRateMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolRateMapper.MapBOToModel(this.dalRateMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiRateRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.rateModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolRateMapper.MapModelToBO(id, model);
                                await this.rateRepository.Update(this.dalRateMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.rateModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.rateRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>4267037bfc7159e49b4bc8bc9fe31d7c</Hash>
</Codenesium>*/