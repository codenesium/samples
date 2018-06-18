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
        public abstract class AbstractPhoneNumberTypeService: AbstractService
        {
                private IPhoneNumberTypeRepository phoneNumberTypeRepository;

                private IApiPhoneNumberTypeRequestModelValidator phoneNumberTypeModelValidator;

                private IBOLPhoneNumberTypeMapper bolPhoneNumberTypeMapper;

                private IDALPhoneNumberTypeMapper dalPhoneNumberTypeMapper;

                private IBOLPersonPhoneMapper bolPersonPhoneMapper;

                private IDALPersonPhoneMapper dalPersonPhoneMapper;

                private ILogger logger;

                public AbstractPhoneNumberTypeService(
                        ILogger logger,
                        IPhoneNumberTypeRepository phoneNumberTypeRepository,
                        IApiPhoneNumberTypeRequestModelValidator phoneNumberTypeModelValidator,
                        IBOLPhoneNumberTypeMapper bolPhoneNumberTypeMapper,
                        IDALPhoneNumberTypeMapper dalPhoneNumberTypeMapper

                        ,
                        IBOLPersonPhoneMapper bolPersonPhoneMapper,
                        IDALPersonPhoneMapper dalPersonPhoneMapper

                        )
                        : base()

                {
                        this.phoneNumberTypeRepository = phoneNumberTypeRepository;
                        this.phoneNumberTypeModelValidator = phoneNumberTypeModelValidator;
                        this.bolPhoneNumberTypeMapper = bolPhoneNumberTypeMapper;
                        this.dalPhoneNumberTypeMapper = dalPhoneNumberTypeMapper;
                        this.bolPersonPhoneMapper = bolPersonPhoneMapper;
                        this.dalPersonPhoneMapper = dalPersonPhoneMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiPhoneNumberTypeResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.phoneNumberTypeRepository.All(limit, offset);

                        return this.bolPhoneNumberTypeMapper.MapBOToModel(this.dalPhoneNumberTypeMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiPhoneNumberTypeResponseModel> Get(int phoneNumberTypeID)
                {
                        var record = await this.phoneNumberTypeRepository.Get(phoneNumberTypeID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolPhoneNumberTypeMapper.MapBOToModel(this.dalPhoneNumberTypeMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiPhoneNumberTypeResponseModel>> Create(
                        ApiPhoneNumberTypeRequestModel model)
                {
                        CreateResponse<ApiPhoneNumberTypeResponseModel> response = new CreateResponse<ApiPhoneNumberTypeResponseModel>(await this.phoneNumberTypeModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolPhoneNumberTypeMapper.MapModelToBO(default (int), model);
                                var record = await this.phoneNumberTypeRepository.Create(this.dalPhoneNumberTypeMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolPhoneNumberTypeMapper.MapBOToModel(this.dalPhoneNumberTypeMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int phoneNumberTypeID,
                        ApiPhoneNumberTypeRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.phoneNumberTypeModelValidator.ValidateUpdateAsync(phoneNumberTypeID, model));

                        if (response.Success)
                        {
                                var bo = this.bolPhoneNumberTypeMapper.MapModelToBO(phoneNumberTypeID, model);
                                await this.phoneNumberTypeRepository.Update(this.dalPhoneNumberTypeMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int phoneNumberTypeID)
                {
                        ActionResponse response = new ActionResponse(await this.phoneNumberTypeModelValidator.ValidateDeleteAsync(phoneNumberTypeID));

                        if (response.Success)
                        {
                                await this.phoneNumberTypeRepository.Delete(phoneNumberTypeID);
                        }

                        return response;
                }

                public async virtual Task<List<ApiPersonPhoneResponseModel>> PersonPhones(int phoneNumberTypeID, int limit = int.MaxValue, int offset = 0)
                {
                        List<PersonPhone> records = await this.phoneNumberTypeRepository.PersonPhones(phoneNumberTypeID, limit, offset);

                        return this.bolPersonPhoneMapper.MapBOToModel(this.dalPersonPhoneMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>7423caee8348d223c99ef68001b0e293</Hash>
</Codenesium>*/