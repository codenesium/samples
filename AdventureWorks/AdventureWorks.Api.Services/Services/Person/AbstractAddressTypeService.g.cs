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
        public abstract class AbstractAddressTypeService: AbstractService
        {
                private IAddressTypeRepository addressTypeRepository;

                private IApiAddressTypeRequestModelValidator addressTypeModelValidator;

                private IBOLAddressTypeMapper bolAddressTypeMapper;

                private IDALAddressTypeMapper dalAddressTypeMapper;

                private IBOLBusinessEntityAddressMapper bolBusinessEntityAddressMapper;

                private IDALBusinessEntityAddressMapper dalBusinessEntityAddressMapper;

                private ILogger logger;

                public AbstractAddressTypeService(
                        ILogger logger,
                        IAddressTypeRepository addressTypeRepository,
                        IApiAddressTypeRequestModelValidator addressTypeModelValidator,
                        IBOLAddressTypeMapper bolAddressTypeMapper,
                        IDALAddressTypeMapper dalAddressTypeMapper

                        ,
                        IBOLBusinessEntityAddressMapper bolBusinessEntityAddressMapper,
                        IDALBusinessEntityAddressMapper dalBusinessEntityAddressMapper

                        )
                        : base()

                {
                        this.addressTypeRepository = addressTypeRepository;
                        this.addressTypeModelValidator = addressTypeModelValidator;
                        this.bolAddressTypeMapper = bolAddressTypeMapper;
                        this.dalAddressTypeMapper = dalAddressTypeMapper;
                        this.bolBusinessEntityAddressMapper = bolBusinessEntityAddressMapper;
                        this.dalBusinessEntityAddressMapper = dalBusinessEntityAddressMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiAddressTypeResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.addressTypeRepository.All(limit, offset, orderClause);

                        return this.bolAddressTypeMapper.MapBOToModel(this.dalAddressTypeMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiAddressTypeResponseModel> Get(int addressTypeID)
                {
                        var record = await this.addressTypeRepository.Get(addressTypeID);

                        return this.bolAddressTypeMapper.MapBOToModel(this.dalAddressTypeMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiAddressTypeResponseModel>> Create(
                        ApiAddressTypeRequestModel model)
                {
                        CreateResponse<ApiAddressTypeResponseModel> response = new CreateResponse<ApiAddressTypeResponseModel>(await this.addressTypeModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolAddressTypeMapper.MapModelToBO(default (int), model);
                                var record = await this.addressTypeRepository.Create(this.dalAddressTypeMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolAddressTypeMapper.MapBOToModel(this.dalAddressTypeMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int addressTypeID,
                        ApiAddressTypeRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.addressTypeModelValidator.ValidateUpdateAsync(addressTypeID, model));

                        if (response.Success)
                        {
                                var bo = this.bolAddressTypeMapper.MapModelToBO(addressTypeID, model);
                                await this.addressTypeRepository.Update(this.dalAddressTypeMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int addressTypeID)
                {
                        ActionResponse response = new ActionResponse(await this.addressTypeModelValidator.ValidateDeleteAsync(addressTypeID));

                        if (response.Success)
                        {
                                await this.addressTypeRepository.Delete(addressTypeID);
                        }

                        return response;
                }

                public async Task<ApiAddressTypeResponseModel> GetName(string name)
                {
                        AddressType record = await this.addressTypeRepository.GetName(name);

                        return this.bolAddressTypeMapper.MapBOToModel(this.dalAddressTypeMapper.MapEFToBO(record));
                }

                public async virtual Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddresses(int addressTypeID, int limit = int.MaxValue, int offset = 0)
                {
                        List<BusinessEntityAddress> records = await this.addressTypeRepository.BusinessEntityAddresses(addressTypeID, limit, offset);

                        return this.bolBusinessEntityAddressMapper.MapBOToModel(this.dalBusinessEntityAddressMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>0b70c03b6f3c7f89fce19e88fe8d24e2</Hash>
</Codenesium>*/