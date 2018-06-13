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
        public abstract class AbstractStateProvinceService: AbstractService
        {
                private IStateProvinceRepository stateProvinceRepository;

                private IApiStateProvinceRequestModelValidator stateProvinceModelValidator;

                private IBOLStateProvinceMapper bolStateProvinceMapper;

                private IDALStateProvinceMapper dalStateProvinceMapper;

                private IBOLAddressMapper bolAddressMapper;

                private IDALAddressMapper dalAddressMapper;

                private ILogger logger;

                public AbstractStateProvinceService(
                        ILogger logger,
                        IStateProvinceRepository stateProvinceRepository,
                        IApiStateProvinceRequestModelValidator stateProvinceModelValidator,
                        IBOLStateProvinceMapper bolStateProvinceMapper,
                        IDALStateProvinceMapper dalStateProvinceMapper

                        ,
                        IBOLAddressMapper bolAddressMapper,
                        IDALAddressMapper dalAddressMapper

                        )
                        : base()

                {
                        this.stateProvinceRepository = stateProvinceRepository;
                        this.stateProvinceModelValidator = stateProvinceModelValidator;
                        this.bolStateProvinceMapper = bolStateProvinceMapper;
                        this.dalStateProvinceMapper = dalStateProvinceMapper;
                        this.bolAddressMapper = bolAddressMapper;
                        this.dalAddressMapper = dalAddressMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiStateProvinceResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.stateProvinceRepository.All(limit, offset, orderClause);

                        return this.bolStateProvinceMapper.MapBOToModel(this.dalStateProvinceMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiStateProvinceResponseModel> Get(int stateProvinceID)
                {
                        var record = await this.stateProvinceRepository.Get(stateProvinceID);

                        return this.bolStateProvinceMapper.MapBOToModel(this.dalStateProvinceMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiStateProvinceResponseModel>> Create(
                        ApiStateProvinceRequestModel model)
                {
                        CreateResponse<ApiStateProvinceResponseModel> response = new CreateResponse<ApiStateProvinceResponseModel>(await this.stateProvinceModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolStateProvinceMapper.MapModelToBO(default (int), model);
                                var record = await this.stateProvinceRepository.Create(this.dalStateProvinceMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolStateProvinceMapper.MapBOToModel(this.dalStateProvinceMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int stateProvinceID,
                        ApiStateProvinceRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.stateProvinceModelValidator.ValidateUpdateAsync(stateProvinceID, model));

                        if (response.Success)
                        {
                                var bo = this.bolStateProvinceMapper.MapModelToBO(stateProvinceID, model);
                                await this.stateProvinceRepository.Update(this.dalStateProvinceMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int stateProvinceID)
                {
                        ActionResponse response = new ActionResponse(await this.stateProvinceModelValidator.ValidateDeleteAsync(stateProvinceID));

                        if (response.Success)
                        {
                                await this.stateProvinceRepository.Delete(stateProvinceID);
                        }

                        return response;
                }

                public async Task<ApiStateProvinceResponseModel> GetName(string name)
                {
                        StateProvince record = await this.stateProvinceRepository.GetName(name);

                        return this.bolStateProvinceMapper.MapBOToModel(this.dalStateProvinceMapper.MapEFToBO(record));
                }
                public async Task<ApiStateProvinceResponseModel> GetStateProvinceCodeCountryRegionCode(string stateProvinceCode, string countryRegionCode)
                {
                        StateProvince record = await this.stateProvinceRepository.GetStateProvinceCodeCountryRegionCode(stateProvinceCode, countryRegionCode);

                        return this.bolStateProvinceMapper.MapBOToModel(this.dalStateProvinceMapper.MapEFToBO(record));
                }

                public async virtual Task<List<ApiAddressResponseModel>> Addresses(int stateProvinceID, int limit = int.MaxValue, int offset = 0)
                {
                        List<Address> records = await this.stateProvinceRepository.Addresses(stateProvinceID, limit, offset);

                        return this.bolAddressMapper.MapBOToModel(this.dalAddressMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>43df6b8d43dd4a10e759687f7ecc246b</Hash>
</Codenesium>*/