using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractJobCandidateService : AbstractService
        {
                private IJobCandidateRepository jobCandidateRepository;

                private IApiJobCandidateRequestModelValidator jobCandidateModelValidator;

                private IBOLJobCandidateMapper bolJobCandidateMapper;

                private IDALJobCandidateMapper dalJobCandidateMapper;

                private ILogger logger;

                public AbstractJobCandidateService(
                        ILogger logger,
                        IJobCandidateRepository jobCandidateRepository,
                        IApiJobCandidateRequestModelValidator jobCandidateModelValidator,
                        IBOLJobCandidateMapper bolJobCandidateMapper,
                        IDALJobCandidateMapper dalJobCandidateMapper)
                        : base()
                {
                        this.jobCandidateRepository = jobCandidateRepository;
                        this.jobCandidateModelValidator = jobCandidateModelValidator;
                        this.bolJobCandidateMapper = bolJobCandidateMapper;
                        this.dalJobCandidateMapper = dalJobCandidateMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiJobCandidateResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.jobCandidateRepository.All(limit, offset);

                        return this.bolJobCandidateMapper.MapBOToModel(this.dalJobCandidateMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiJobCandidateResponseModel> Get(int jobCandidateID)
                {
                        var record = await this.jobCandidateRepository.Get(jobCandidateID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolJobCandidateMapper.MapBOToModel(this.dalJobCandidateMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiJobCandidateResponseModel>> Create(
                        ApiJobCandidateRequestModel model)
                {
                        CreateResponse<ApiJobCandidateResponseModel> response = new CreateResponse<ApiJobCandidateResponseModel>(await this.jobCandidateModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolJobCandidateMapper.MapModelToBO(default(int), model);
                                var record = await this.jobCandidateRepository.Create(this.dalJobCandidateMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolJobCandidateMapper.MapBOToModel(this.dalJobCandidateMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int jobCandidateID,
                        ApiJobCandidateRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.jobCandidateModelValidator.ValidateUpdateAsync(jobCandidateID, model));
                        if (response.Success)
                        {
                                var bo = this.bolJobCandidateMapper.MapModelToBO(jobCandidateID, model);
                                await this.jobCandidateRepository.Update(this.dalJobCandidateMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int jobCandidateID)
                {
                        ActionResponse response = new ActionResponse(await this.jobCandidateModelValidator.ValidateDeleteAsync(jobCandidateID));
                        if (response.Success)
                        {
                                await this.jobCandidateRepository.Delete(jobCandidateID);
                        }

                        return response;
                }

                public async Task<List<ApiJobCandidateResponseModel>> ByBusinessEntityID(Nullable<int> businessEntityID)
                {
                        List<JobCandidate> records = await this.jobCandidateRepository.ByBusinessEntityID(businessEntityID);

                        return this.bolJobCandidateMapper.MapBOToModel(this.dalJobCandidateMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>6875048548365ea04d05e0a296e64134</Hash>
</Codenesium>*/