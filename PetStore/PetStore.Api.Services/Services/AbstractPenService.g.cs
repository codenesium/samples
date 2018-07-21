using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
        public abstract class AbstractPenService : AbstractService
        {
                private IPenRepository penRepository;

                private IApiPenRequestModelValidator penModelValidator;

                private IBOLPenMapper bolPenMapper;

                private IDALPenMapper dalPenMapper;

                private IBOLPetMapper bolPetMapper;

                private IDALPetMapper dalPetMapper;

                private ILogger logger;

                public AbstractPenService(
                        ILogger logger,
                        IPenRepository penRepository,
                        IApiPenRequestModelValidator penModelValidator,
                        IBOLPenMapper bolPenMapper,
                        IDALPenMapper dalPenMapper,
                        IBOLPetMapper bolPetMapper,
                        IDALPetMapper dalPetMapper)
                        : base()
                {
                        this.penRepository = penRepository;
                        this.penModelValidator = penModelValidator;
                        this.bolPenMapper = bolPenMapper;
                        this.dalPenMapper = dalPenMapper;
                        this.bolPetMapper = bolPetMapper;
                        this.dalPetMapper = dalPetMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiPenResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.penRepository.All(limit, offset);

                        return this.bolPenMapper.MapBOToModel(this.dalPenMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiPenResponseModel> Get(int id)
                {
                        var record = await this.penRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolPenMapper.MapBOToModel(this.dalPenMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiPenResponseModel>> Create(
                        ApiPenRequestModel model)
                {
                        CreateResponse<ApiPenResponseModel> response = new CreateResponse<ApiPenResponseModel>(await this.penModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolPenMapper.MapModelToBO(default(int), model);
                                var record = await this.penRepository.Create(this.dalPenMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolPenMapper.MapBOToModel(this.dalPenMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiPenResponseModel>> Update(
                        int id,
                        ApiPenRequestModel model)
                {
                        var validationResult = await this.penModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolPenMapper.MapModelToBO(id, model);
                                await this.penRepository.Update(this.dalPenMapper.MapBOToEF(bo));

                                var record = await this.penRepository.Get(id);

                                return new UpdateResponse<ApiPenResponseModel>(this.bolPenMapper.MapBOToModel(this.dalPenMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiPenResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.penModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.penRepository.Delete(id);
                        }

                        return response;
                }

                public async virtual Task<List<ApiPetResponseModel>> Pets(int penId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Pet> records = await this.penRepository.Pets(penId, limit, offset);

                        return this.bolPetMapper.MapBOToModel(this.dalPetMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>77bf2568f270e6a36268c78e89be7799</Hash>
</Codenesium>*/