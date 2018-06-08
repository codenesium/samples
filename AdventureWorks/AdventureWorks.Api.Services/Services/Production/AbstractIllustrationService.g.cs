using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractIllustrationService: AbstractService
        {
                private IIllustrationRepository illustrationRepository;

                private IApiIllustrationRequestModelValidator illustrationModelValidator;

                private IBOLIllustrationMapper bolIllustrationMapper;

                private IDALIllustrationMapper dalIllustrationMapper;

                private ILogger logger;

                public AbstractIllustrationService(
                        ILogger logger,
                        IIllustrationRepository illustrationRepository,
                        IApiIllustrationRequestModelValidator illustrationModelValidator,
                        IBOLIllustrationMapper bolillustrationMapper,
                        IDALIllustrationMapper dalillustrationMapper)
                        : base()

                {
                        this.illustrationRepository = illustrationRepository;
                        this.illustrationModelValidator = illustrationModelValidator;
                        this.bolIllustrationMapper = bolillustrationMapper;
                        this.dalIllustrationMapper = dalillustrationMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiIllustrationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.illustrationRepository.All(skip, take, orderClause);

                        return this.bolIllustrationMapper.MapBOToModel(this.dalIllustrationMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiIllustrationResponseModel> Get(int illustrationID)
                {
                        var record = await this.illustrationRepository.Get(illustrationID);

                        return this.bolIllustrationMapper.MapBOToModel(this.dalIllustrationMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiIllustrationResponseModel>> Create(
                        ApiIllustrationRequestModel model)
                {
                        CreateResponse<ApiIllustrationResponseModel> response = new CreateResponse<ApiIllustrationResponseModel>(await this.illustrationModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolIllustrationMapper.MapModelToBO(default (int), model);
                                var record = await this.illustrationRepository.Create(this.dalIllustrationMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolIllustrationMapper.MapBOToModel(this.dalIllustrationMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int illustrationID,
                        ApiIllustrationRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.illustrationModelValidator.ValidateUpdateAsync(illustrationID, model));

                        if (response.Success)
                        {
                                var bo = this.bolIllustrationMapper.MapModelToBO(illustrationID, model);
                                await this.illustrationRepository.Update(this.dalIllustrationMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int illustrationID)
                {
                        ActionResponse response = new ActionResponse(await this.illustrationModelValidator.ValidateDeleteAsync(illustrationID));

                        if (response.Success)
                        {
                                await this.illustrationRepository.Delete(illustrationID);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>7cbcb5e9ec8fb1173c9018b3e0e72240</Hash>
</Codenesium>*/