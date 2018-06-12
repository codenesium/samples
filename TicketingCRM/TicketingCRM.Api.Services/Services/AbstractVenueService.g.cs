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
        public abstract class AbstractVenueService: AbstractService
        {
                private IVenueRepository venueRepository;

                private IApiVenueRequestModelValidator venueModelValidator;

                private IBOLVenueMapper bolVenueMapper;

                private IDALVenueMapper dalVenueMapper;

                private ILogger logger;

                public AbstractVenueService(
                        ILogger logger,
                        IVenueRepository venueRepository,
                        IApiVenueRequestModelValidator venueModelValidator,
                        IBOLVenueMapper bolvenueMapper,
                        IDALVenueMapper dalvenueMapper)
                        : base()

                {
                        this.venueRepository = venueRepository;
                        this.venueModelValidator = venueModelValidator;
                        this.bolVenueMapper = bolvenueMapper;
                        this.dalVenueMapper = dalvenueMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiVenueResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.venueRepository.All(skip, take, orderClause);

                        return this.bolVenueMapper.MapBOToModel(this.dalVenueMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiVenueResponseModel> Get(int id)
                {
                        var record = await this.venueRepository.Get(id);

                        return this.bolVenueMapper.MapBOToModel(this.dalVenueMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiVenueResponseModel>> Create(
                        ApiVenueRequestModel model)
                {
                        CreateResponse<ApiVenueResponseModel> response = new CreateResponse<ApiVenueResponseModel>(await this.venueModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolVenueMapper.MapModelToBO(default (int), model);
                                var record = await this.venueRepository.Create(this.dalVenueMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolVenueMapper.MapBOToModel(this.dalVenueMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiVenueRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.venueModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolVenueMapper.MapModelToBO(id, model);
                                await this.venueRepository.Update(this.dalVenueMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.venueModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.venueRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<List<ApiVenueResponseModel>> GetAdminId(int adminId)
                {
                        List<Venue> records = await this.venueRepository.GetAdminId(adminId);

                        return this.bolVenueMapper.MapBOToModel(this.dalVenueMapper.MapEFToBO(records));
                }
                public async Task<List<ApiVenueResponseModel>> GetProvinceId(int provinceId)
                {
                        List<Venue> records = await this.venueRepository.GetProvinceId(provinceId);

                        return this.bolVenueMapper.MapBOToModel(this.dalVenueMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>9d7d8b08ecf5561075b6b75fbc051173</Hash>
</Codenesium>*/