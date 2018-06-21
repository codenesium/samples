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
        public abstract class AbstractBusinessEntityAddressService : AbstractService
        {
                private IBusinessEntityAddressRepository businessEntityAddressRepository;

                private IApiBusinessEntityAddressRequestModelValidator businessEntityAddressModelValidator;

                private IBOLBusinessEntityAddressMapper bolBusinessEntityAddressMapper;

                private IDALBusinessEntityAddressMapper dalBusinessEntityAddressMapper;

                private ILogger logger;

                public AbstractBusinessEntityAddressService(
                        ILogger logger,
                        IBusinessEntityAddressRepository businessEntityAddressRepository,
                        IApiBusinessEntityAddressRequestModelValidator businessEntityAddressModelValidator,
                        IBOLBusinessEntityAddressMapper bolBusinessEntityAddressMapper,
                        IDALBusinessEntityAddressMapper dalBusinessEntityAddressMapper)
                        : base()
                {
                        this.businessEntityAddressRepository = businessEntityAddressRepository;
                        this.businessEntityAddressModelValidator = businessEntityAddressModelValidator;
                        this.bolBusinessEntityAddressMapper = bolBusinessEntityAddressMapper;
                        this.dalBusinessEntityAddressMapper = dalBusinessEntityAddressMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiBusinessEntityAddressResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.businessEntityAddressRepository.All(limit, offset);

                        return this.bolBusinessEntityAddressMapper.MapBOToModel(this.dalBusinessEntityAddressMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiBusinessEntityAddressResponseModel> Get(int businessEntityID)
                {
                        var record = await this.businessEntityAddressRepository.Get(businessEntityID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolBusinessEntityAddressMapper.MapBOToModel(this.dalBusinessEntityAddressMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiBusinessEntityAddressResponseModel>> Create(
                        ApiBusinessEntityAddressRequestModel model)
                {
                        CreateResponse<ApiBusinessEntityAddressResponseModel> response = new CreateResponse<ApiBusinessEntityAddressResponseModel>(await this.businessEntityAddressModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolBusinessEntityAddressMapper.MapModelToBO(default(int), model);
                                var record = await this.businessEntityAddressRepository.Create(this.dalBusinessEntityAddressMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolBusinessEntityAddressMapper.MapBOToModel(this.dalBusinessEntityAddressMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int businessEntityID,
                        ApiBusinessEntityAddressRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.businessEntityAddressModelValidator.ValidateUpdateAsync(businessEntityID, model));
                        if (response.Success)
                        {
                                var bo = this.bolBusinessEntityAddressMapper.MapModelToBO(businessEntityID, model);
                                await this.businessEntityAddressRepository.Update(this.dalBusinessEntityAddressMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int businessEntityID)
                {
                        ActionResponse response = new ActionResponse(await this.businessEntityAddressModelValidator.ValidateDeleteAsync(businessEntityID));
                        if (response.Success)
                        {
                                await this.businessEntityAddressRepository.Delete(businessEntityID);
                        }

                        return response;
                }

                public async Task<List<ApiBusinessEntityAddressResponseModel>> ByAddressID(int addressID)
                {
                        List<BusinessEntityAddress> records = await this.businessEntityAddressRepository.ByAddressID(addressID);

                        return this.bolBusinessEntityAddressMapper.MapBOToModel(this.dalBusinessEntityAddressMapper.MapEFToBO(records));
                }

                public async Task<List<ApiBusinessEntityAddressResponseModel>> ByAddressTypeID(int addressTypeID)
                {
                        List<BusinessEntityAddress> records = await this.businessEntityAddressRepository.ByAddressTypeID(addressTypeID);

                        return this.bolBusinessEntityAddressMapper.MapBOToModel(this.dalBusinessEntityAddressMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>a01a57f87cc4325618bd6183b7dccf66</Hash>
</Codenesium>*/