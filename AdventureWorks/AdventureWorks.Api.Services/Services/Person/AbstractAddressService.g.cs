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
        public abstract class AbstractAddressService: AbstractService
        {
                private IAddressRepository addressRepository;

                private IApiAddressRequestModelValidator addressModelValidator;

                private IBOLAddressMapper bolAddressMapper;

                private IDALAddressMapper dalAddressMapper;

                private IBOLBusinessEntityAddressMapper bolBusinessEntityAddressMapper;

                private IDALBusinessEntityAddressMapper dalBusinessEntityAddressMapper;

                private ILogger logger;

                public AbstractAddressService(
                        ILogger logger,
                        IAddressRepository addressRepository,
                        IApiAddressRequestModelValidator addressModelValidator,
                        IBOLAddressMapper bolAddressMapper,
                        IDALAddressMapper dalAddressMapper

                        ,
                        IBOLBusinessEntityAddressMapper bolBusinessEntityAddressMapper,
                        IDALBusinessEntityAddressMapper dalBusinessEntityAddressMapper

                        )
                        : base()

                {
                        this.addressRepository = addressRepository;
                        this.addressModelValidator = addressModelValidator;
                        this.bolAddressMapper = bolAddressMapper;
                        this.dalAddressMapper = dalAddressMapper;
                        this.bolBusinessEntityAddressMapper = bolBusinessEntityAddressMapper;
                        this.dalBusinessEntityAddressMapper = dalBusinessEntityAddressMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiAddressResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.addressRepository.All(limit, offset);

                        return this.bolAddressMapper.MapBOToModel(this.dalAddressMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiAddressResponseModel> Get(int addressID)
                {
                        var record = await this.addressRepository.Get(addressID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolAddressMapper.MapBOToModel(this.dalAddressMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiAddressResponseModel>> Create(
                        ApiAddressRequestModel model)
                {
                        CreateResponse<ApiAddressResponseModel> response = new CreateResponse<ApiAddressResponseModel>(await this.addressModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolAddressMapper.MapModelToBO(default (int), model);
                                var record = await this.addressRepository.Create(this.dalAddressMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolAddressMapper.MapBOToModel(this.dalAddressMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int addressID,
                        ApiAddressRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.addressModelValidator.ValidateUpdateAsync(addressID, model));

                        if (response.Success)
                        {
                                var bo = this.bolAddressMapper.MapModelToBO(addressID, model);
                                await this.addressRepository.Update(this.dalAddressMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int addressID)
                {
                        ActionResponse response = new ActionResponse(await this.addressModelValidator.ValidateDeleteAsync(addressID));

                        if (response.Success)
                        {
                                await this.addressRepository.Delete(addressID);
                        }

                        return response;
                }

                public async Task<ApiAddressResponseModel> ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1, string addressLine2, string city, int stateProvinceID, string postalCode)
                {
                        Address record = await this.addressRepository.ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(addressLine1, addressLine2, city, stateProvinceID, postalCode);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolAddressMapper.MapBOToModel(this.dalAddressMapper.MapEFToBO(record));
                        }
                }
                public async Task<List<ApiAddressResponseModel>> ByStateProvinceID(int stateProvinceID)
                {
                        List<Address> records = await this.addressRepository.ByStateProvinceID(stateProvinceID);

                        return this.bolAddressMapper.MapBOToModel(this.dalAddressMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddresses(int addressID, int limit = int.MaxValue, int offset = 0)
                {
                        List<BusinessEntityAddress> records = await this.addressRepository.BusinessEntityAddresses(addressID, limit, offset);

                        return this.bolBusinessEntityAddressMapper.MapBOToModel(this.dalBusinessEntityAddressMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>ea4601f35c17f46b6b82965b3309d3b3</Hash>
</Codenesium>*/