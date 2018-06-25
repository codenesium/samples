using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractTagSetService : AbstractService
        {
                private ITagSetRepository tagSetRepository;

                private IApiTagSetRequestModelValidator tagSetModelValidator;

                private IBOLTagSetMapper bolTagSetMapper;

                private IDALTagSetMapper dalTagSetMapper;

                private ILogger logger;

                public AbstractTagSetService(
                        ILogger logger,
                        ITagSetRepository tagSetRepository,
                        IApiTagSetRequestModelValidator tagSetModelValidator,
                        IBOLTagSetMapper bolTagSetMapper,
                        IDALTagSetMapper dalTagSetMapper)
                        : base()
                {
                        this.tagSetRepository = tagSetRepository;
                        this.tagSetModelValidator = tagSetModelValidator;
                        this.bolTagSetMapper = bolTagSetMapper;
                        this.dalTagSetMapper = dalTagSetMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiTagSetResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.tagSetRepository.All(limit, offset);

                        return this.bolTagSetMapper.MapBOToModel(this.dalTagSetMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiTagSetResponseModel> Get(string id)
                {
                        var record = await this.tagSetRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolTagSetMapper.MapBOToModel(this.dalTagSetMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiTagSetResponseModel>> Create(
                        ApiTagSetRequestModel model)
                {
                        CreateResponse<ApiTagSetResponseModel> response = new CreateResponse<ApiTagSetResponseModel>(await this.tagSetModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolTagSetMapper.MapModelToBO(default(string), model);
                                var record = await this.tagSetRepository.Create(this.dalTagSetMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolTagSetMapper.MapBOToModel(this.dalTagSetMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiTagSetRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.tagSetModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolTagSetMapper.MapModelToBO(id, model);
                                await this.tagSetRepository.Update(this.dalTagSetMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.tagSetModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.tagSetRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiTagSetResponseModel> ByName(string name)
                {
                        TagSet record = await this.tagSetRepository.ByName(name);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolTagSetMapper.MapBOToModel(this.dalTagSetMapper.MapEFToBO(record));
                        }
                }

                public async Task<List<ApiTagSetResponseModel>> ByDataVersion(byte[] dataVersion)
                {
                        List<TagSet> records = await this.tagSetRepository.ByDataVersion(dataVersion);

                        return this.bolTagSetMapper.MapBOToModel(this.dalTagSetMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>b54b26a6490ddbe7da69a93246a8d4f9</Hash>
</Codenesium>*/