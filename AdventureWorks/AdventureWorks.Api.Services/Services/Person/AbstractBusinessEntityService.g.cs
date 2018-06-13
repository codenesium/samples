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
        public abstract class AbstractBusinessEntityService: AbstractService
        {
                private IBusinessEntityRepository businessEntityRepository;

                private IApiBusinessEntityRequestModelValidator businessEntityModelValidator;

                private IBOLBusinessEntityMapper bolBusinessEntityMapper;

                private IDALBusinessEntityMapper dalBusinessEntityMapper;

                private IBOLBusinessEntityAddressMapper bolBusinessEntityAddressMapper;

                private IDALBusinessEntityAddressMapper dalBusinessEntityAddressMapper;
                private IBOLBusinessEntityContactMapper bolBusinessEntityContactMapper;

                private IDALBusinessEntityContactMapper dalBusinessEntityContactMapper;
                private IBOLPersonMapper bolPersonMapper;

                private IDALPersonMapper dalPersonMapper;

                private ILogger logger;

                public AbstractBusinessEntityService(
                        ILogger logger,
                        IBusinessEntityRepository businessEntityRepository,
                        IApiBusinessEntityRequestModelValidator businessEntityModelValidator,
                        IBOLBusinessEntityMapper bolBusinessEntityMapper,
                        IDALBusinessEntityMapper dalBusinessEntityMapper

                        ,
                        IBOLBusinessEntityAddressMapper bolBusinessEntityAddressMapper,
                        IDALBusinessEntityAddressMapper dalBusinessEntityAddressMapper
                        ,
                        IBOLBusinessEntityContactMapper bolBusinessEntityContactMapper,
                        IDALBusinessEntityContactMapper dalBusinessEntityContactMapper
                        ,
                        IBOLPersonMapper bolPersonMapper,
                        IDALPersonMapper dalPersonMapper

                        )
                        : base()

                {
                        this.businessEntityRepository = businessEntityRepository;
                        this.businessEntityModelValidator = businessEntityModelValidator;
                        this.bolBusinessEntityMapper = bolBusinessEntityMapper;
                        this.dalBusinessEntityMapper = dalBusinessEntityMapper;
                        this.bolBusinessEntityAddressMapper = bolBusinessEntityAddressMapper;
                        this.dalBusinessEntityAddressMapper = dalBusinessEntityAddressMapper;
                        this.bolBusinessEntityContactMapper = bolBusinessEntityContactMapper;
                        this.dalBusinessEntityContactMapper = dalBusinessEntityContactMapper;
                        this.bolPersonMapper = bolPersonMapper;
                        this.dalPersonMapper = dalPersonMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiBusinessEntityResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.businessEntityRepository.All(limit, offset, orderClause);

                        return this.bolBusinessEntityMapper.MapBOToModel(this.dalBusinessEntityMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiBusinessEntityResponseModel> Get(int businessEntityID)
                {
                        var record = await this.businessEntityRepository.Get(businessEntityID);

                        return this.bolBusinessEntityMapper.MapBOToModel(this.dalBusinessEntityMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiBusinessEntityResponseModel>> Create(
                        ApiBusinessEntityRequestModel model)
                {
                        CreateResponse<ApiBusinessEntityResponseModel> response = new CreateResponse<ApiBusinessEntityResponseModel>(await this.businessEntityModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolBusinessEntityMapper.MapModelToBO(default (int), model);
                                var record = await this.businessEntityRepository.Create(this.dalBusinessEntityMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolBusinessEntityMapper.MapBOToModel(this.dalBusinessEntityMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int businessEntityID,
                        ApiBusinessEntityRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.businessEntityModelValidator.ValidateUpdateAsync(businessEntityID, model));

                        if (response.Success)
                        {
                                var bo = this.bolBusinessEntityMapper.MapModelToBO(businessEntityID, model);
                                await this.businessEntityRepository.Update(this.dalBusinessEntityMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int businessEntityID)
                {
                        ActionResponse response = new ActionResponse(await this.businessEntityModelValidator.ValidateDeleteAsync(businessEntityID));

                        if (response.Success)
                        {
                                await this.businessEntityRepository.Delete(businessEntityID);
                        }

                        return response;
                }

                public async virtual Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddresses(int businessEntityID, int limit = int.MaxValue, int offset = 0)
                {
                        List<BusinessEntityAddress> records = await this.businessEntityRepository.BusinessEntityAddresses(businessEntityID, limit, offset);

                        return this.bolBusinessEntityAddressMapper.MapBOToModel(this.dalBusinessEntityAddressMapper.MapEFToBO(records));
                }
                public async virtual Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContacts(int businessEntityID, int limit = int.MaxValue, int offset = 0)
                {
                        List<BusinessEntityContact> records = await this.businessEntityRepository.BusinessEntityContacts(businessEntityID, limit, offset);

                        return this.bolBusinessEntityContactMapper.MapBOToModel(this.dalBusinessEntityContactMapper.MapEFToBO(records));
                }
                public async virtual Task<List<ApiPersonResponseModel>> People(int businessEntityID, int limit = int.MaxValue, int offset = 0)
                {
                        List<Person> records = await this.businessEntityRepository.People(businessEntityID, limit, offset);

                        return this.bolPersonMapper.MapBOToModel(this.dalPersonMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>41955341a2870067082e577aed68c1ad</Hash>
</Codenesium>*/