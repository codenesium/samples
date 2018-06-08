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
        public abstract class AbstractStudioService: AbstractService
        {
                private IStudioRepository studioRepository;

                private IApiStudioRequestModelValidator studioModelValidator;

                private IBOLStudioMapper bolStudioMapper;

                private IDALStudioMapper dalStudioMapper;

                private ILogger logger;

                public AbstractStudioService(
                        ILogger logger,
                        IStudioRepository studioRepository,
                        IApiStudioRequestModelValidator studioModelValidator,
                        IBOLStudioMapper bolstudioMapper,
                        IDALStudioMapper dalstudioMapper)
                        : base()

                {
                        this.studioRepository = studioRepository;
                        this.studioModelValidator = studioModelValidator;
                        this.bolStudioMapper = bolstudioMapper;
                        this.dalStudioMapper = dalstudioMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiStudioResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.studioRepository.All(skip, take, orderClause);

                        return this.bolStudioMapper.MapBOToModel(this.dalStudioMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiStudioResponseModel> Get(int id)
                {
                        var record = await this.studioRepository.Get(id);

                        return this.bolStudioMapper.MapBOToModel(this.dalStudioMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiStudioResponseModel>> Create(
                        ApiStudioRequestModel model)
                {
                        CreateResponse<ApiStudioResponseModel> response = new CreateResponse<ApiStudioResponseModel>(await this.studioModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolStudioMapper.MapModelToBO(default (int), model);
                                var record = await this.studioRepository.Create(this.dalStudioMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolStudioMapper.MapBOToModel(this.dalStudioMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiStudioRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.studioModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolStudioMapper.MapModelToBO(id, model);
                                await this.studioRepository.Update(this.dalStudioMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.studioModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.studioRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>cb5eb148f9575b053beea3c4998f71ab</Hash>
</Codenesium>*/