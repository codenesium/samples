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
        public abstract class AbstractTagSetService: AbstractService
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
                        IBOLTagSetMapper boltagSetMapper,
                        IDALTagSetMapper daltagSetMapper)
                        : base()

                {
                        this.tagSetRepository = tagSetRepository;
                        this.tagSetModelValidator = tagSetModelValidator;
                        this.bolTagSetMapper = boltagSetMapper;
                        this.dalTagSetMapper = daltagSetMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiTagSetResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.tagSetRepository.All(skip, take, orderClause);

                        return this.bolTagSetMapper.MapBOToModel(this.dalTagSetMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiTagSetResponseModel> Get(string id)
                {
                        var record = await this.tagSetRepository.Get(id);

                        return this.bolTagSetMapper.MapBOToModel(this.dalTagSetMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiTagSetResponseModel>> Create(
                        ApiTagSetRequestModel model)
                {
                        CreateResponse<ApiTagSetResponseModel> response = new CreateResponse<ApiTagSetResponseModel>(await this.tagSetModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolTagSetMapper.MapModelToBO(default (string), model);
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

                public async Task<ApiTagSetResponseModel> GetName(string name)
                {
                        TagSet record = await this.tagSetRepository.GetName(name);

                        return this.bolTagSetMapper.MapBOToModel(this.dalTagSetMapper.MapEFToBO(record));
                }
                public async Task<List<ApiTagSetResponseModel>> GetDataVersion(byte[] dataVersion)
                {
                        List<TagSet> records = await this.tagSetRepository.GetDataVersion(dataVersion);

                        return this.bolTagSetMapper.MapBOToModel(this.dalTagSetMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>7c6e1be9dd0dea50111155f0c94833f6</Hash>
</Codenesium>*/