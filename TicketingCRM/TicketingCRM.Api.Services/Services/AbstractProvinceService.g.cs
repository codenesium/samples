using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractProvinceService: AbstractService
        {
                private IProvinceRepository provinceRepository;

                private IApiProvinceRequestModelValidator provinceModelValidator;

                private IBOLProvinceMapper bolProvinceMapper;

                private IDALProvinceMapper dalProvinceMapper;

                private ILogger logger;

                public AbstractProvinceService(
                        ILogger logger,
                        IProvinceRepository provinceRepository,
                        IApiProvinceRequestModelValidator provinceModelValidator,
                        IBOLProvinceMapper bolprovinceMapper,
                        IDALProvinceMapper dalprovinceMapper)
                        : base()

                {
                        this.provinceRepository = provinceRepository;
                        this.provinceModelValidator = provinceModelValidator;
                        this.bolProvinceMapper = bolprovinceMapper;
                        this.dalProvinceMapper = dalprovinceMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProvinceResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.provinceRepository.All(skip, take, orderClause);

                        return this.bolProvinceMapper.MapBOToModel(this.dalProvinceMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProvinceResponseModel> Get(int id)
                {
                        var record = await this.provinceRepository.Get(id);

                        return this.bolProvinceMapper.MapBOToModel(this.dalProvinceMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiProvinceResponseModel>> Create(
                        ApiProvinceRequestModel model)
                {
                        CreateResponse<ApiProvinceResponseModel> response = new CreateResponse<ApiProvinceResponseModel>(await this.provinceModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProvinceMapper.MapModelToBO(default (int), model);
                                var record = await this.provinceRepository.Create(this.dalProvinceMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolProvinceMapper.MapBOToModel(this.dalProvinceMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiProvinceRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.provinceModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolProvinceMapper.MapModelToBO(id, model);
                                await this.provinceRepository.Update(this.dalProvinceMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.provinceModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.provinceRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<List<ApiProvinceResponseModel>> GetCountryId(int countryId)
                {
                        List<Province> records = await this.provinceRepository.GetCountryId(countryId);

                        return this.bolProvinceMapper.MapBOToModel(this.dalProvinceMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>715bb1c5e10ef7e90a04f9367d5107aa</Hash>
</Codenesium>*/