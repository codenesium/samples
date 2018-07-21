using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractCountryService : AbstractService
        {
                private ICountryRepository countryRepository;

                private IApiCountryRequestModelValidator countryModelValidator;

                private IBOLCountryMapper bolCountryMapper;

                private IDALCountryMapper dalCountryMapper;

                private IBOLProvinceMapper bolProvinceMapper;

                private IDALProvinceMapper dalProvinceMapper;

                private ILogger logger;

                public AbstractCountryService(
                        ILogger logger,
                        ICountryRepository countryRepository,
                        IApiCountryRequestModelValidator countryModelValidator,
                        IBOLCountryMapper bolCountryMapper,
                        IDALCountryMapper dalCountryMapper,
                        IBOLProvinceMapper bolProvinceMapper,
                        IDALProvinceMapper dalProvinceMapper)
                        : base()
                {
                        this.countryRepository = countryRepository;
                        this.countryModelValidator = countryModelValidator;
                        this.bolCountryMapper = bolCountryMapper;
                        this.dalCountryMapper = dalCountryMapper;
                        this.bolProvinceMapper = bolProvinceMapper;
                        this.dalProvinceMapper = dalProvinceMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiCountryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.countryRepository.All(limit, offset);

                        return this.bolCountryMapper.MapBOToModel(this.dalCountryMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiCountryResponseModel> Get(int id)
                {
                        var record = await this.countryRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolCountryMapper.MapBOToModel(this.dalCountryMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiCountryResponseModel>> Create(
                        ApiCountryRequestModel model)
                {
                        CreateResponse<ApiCountryResponseModel> response = new CreateResponse<ApiCountryResponseModel>(await this.countryModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolCountryMapper.MapModelToBO(default(int), model);
                                var record = await this.countryRepository.Create(this.dalCountryMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolCountryMapper.MapBOToModel(this.dalCountryMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiCountryResponseModel>> Update(
                        int id,
                        ApiCountryRequestModel model)
                {
                        var validationResult = await this.countryModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolCountryMapper.MapModelToBO(id, model);
                                await this.countryRepository.Update(this.dalCountryMapper.MapBOToEF(bo));

                                var record = await this.countryRepository.Get(id);

                                return new UpdateResponse<ApiCountryResponseModel>(this.bolCountryMapper.MapBOToModel(this.dalCountryMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiCountryResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.countryModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.countryRepository.Delete(id);
                        }

                        return response;
                }

                public async virtual Task<List<ApiProvinceResponseModel>> Provinces(int countryId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Province> records = await this.countryRepository.Provinces(countryId, limit, offset);

                        return this.bolProvinceMapper.MapBOToModel(this.dalProvinceMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>3c517f1030d6d1df720931661741c4ee</Hash>
</Codenesium>*/