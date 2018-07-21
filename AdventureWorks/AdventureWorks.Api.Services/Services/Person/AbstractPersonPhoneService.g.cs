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
        public abstract class AbstractPersonPhoneService : AbstractService
        {
                private IPersonPhoneRepository personPhoneRepository;

                private IApiPersonPhoneRequestModelValidator personPhoneModelValidator;

                private IBOLPersonPhoneMapper bolPersonPhoneMapper;

                private IDALPersonPhoneMapper dalPersonPhoneMapper;

                private ILogger logger;

                public AbstractPersonPhoneService(
                        ILogger logger,
                        IPersonPhoneRepository personPhoneRepository,
                        IApiPersonPhoneRequestModelValidator personPhoneModelValidator,
                        IBOLPersonPhoneMapper bolPersonPhoneMapper,
                        IDALPersonPhoneMapper dalPersonPhoneMapper)
                        : base()
                {
                        this.personPhoneRepository = personPhoneRepository;
                        this.personPhoneModelValidator = personPhoneModelValidator;
                        this.bolPersonPhoneMapper = bolPersonPhoneMapper;
                        this.dalPersonPhoneMapper = dalPersonPhoneMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiPersonPhoneResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.personPhoneRepository.All(limit, offset);

                        return this.bolPersonPhoneMapper.MapBOToModel(this.dalPersonPhoneMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiPersonPhoneResponseModel> Get(int businessEntityID)
                {
                        var record = await this.personPhoneRepository.Get(businessEntityID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolPersonPhoneMapper.MapBOToModel(this.dalPersonPhoneMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiPersonPhoneResponseModel>> Create(
                        ApiPersonPhoneRequestModel model)
                {
                        CreateResponse<ApiPersonPhoneResponseModel> response = new CreateResponse<ApiPersonPhoneResponseModel>(await this.personPhoneModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolPersonPhoneMapper.MapModelToBO(default(int), model);
                                var record = await this.personPhoneRepository.Create(this.dalPersonPhoneMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolPersonPhoneMapper.MapBOToModel(this.dalPersonPhoneMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiPersonPhoneResponseModel>> Update(
                        int businessEntityID,
                        ApiPersonPhoneRequestModel model)
                {
                        var validationResult = await this.personPhoneModelValidator.ValidateUpdateAsync(businessEntityID, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolPersonPhoneMapper.MapModelToBO(businessEntityID, model);
                                await this.personPhoneRepository.Update(this.dalPersonPhoneMapper.MapBOToEF(bo));

                                var record = await this.personPhoneRepository.Get(businessEntityID);

                                return new UpdateResponse<ApiPersonPhoneResponseModel>(this.bolPersonPhoneMapper.MapBOToModel(this.dalPersonPhoneMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiPersonPhoneResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int businessEntityID)
                {
                        ActionResponse response = new ActionResponse(await this.personPhoneModelValidator.ValidateDeleteAsync(businessEntityID));
                        if (response.Success)
                        {
                                await this.personPhoneRepository.Delete(businessEntityID);
                        }

                        return response;
                }

                public async Task<List<ApiPersonPhoneResponseModel>> ByPhoneNumber(string phoneNumber)
                {
                        List<PersonPhone> records = await this.personPhoneRepository.ByPhoneNumber(phoneNumber);

                        return this.bolPersonPhoneMapper.MapBOToModel(this.dalPersonPhoneMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>61e377f384d5cb08b47e570b4b134b05</Hash>
</Codenesium>*/