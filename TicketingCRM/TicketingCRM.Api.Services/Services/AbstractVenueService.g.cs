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
        public abstract class AbstractVenueService : AbstractService
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
                        IBOLVenueMapper bolVenueMapper,
                        IDALVenueMapper dalVenueMapper)
                        : base()
                {
                        this.venueRepository = venueRepository;
                        this.venueModelValidator = venueModelValidator;
                        this.bolVenueMapper = bolVenueMapper;
                        this.dalVenueMapper = dalVenueMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiVenueResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.venueRepository.All(limit, offset);

                        return this.bolVenueMapper.MapBOToModel(this.dalVenueMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiVenueResponseModel> Get(int id)
                {
                        var record = await this.venueRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolVenueMapper.MapBOToModel(this.dalVenueMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiVenueResponseModel>> Create(
                        ApiVenueRequestModel model)
                {
                        CreateResponse<ApiVenueResponseModel> response = new CreateResponse<ApiVenueResponseModel>(await this.venueModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolVenueMapper.MapModelToBO(default(int), model);
                                var record = await this.venueRepository.Create(this.dalVenueMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolVenueMapper.MapBOToModel(this.dalVenueMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiVenueResponseModel>> Update(
                        int id,
                        ApiVenueRequestModel model)
                {
                        var validationResult = await this.venueModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolVenueMapper.MapModelToBO(id, model);
                                await this.venueRepository.Update(this.dalVenueMapper.MapBOToEF(bo));

                                var record = await this.venueRepository.Get(id);

                                return new UpdateResponse<ApiVenueResponseModel>(this.bolVenueMapper.MapBOToModel(this.dalVenueMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiVenueResponseModel>(validationResult);
                        }
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

                public async Task<List<ApiVenueResponseModel>> ByAdminId(int adminId)
                {
                        List<Venue> records = await this.venueRepository.ByAdminId(adminId);

                        return this.bolVenueMapper.MapBOToModel(this.dalVenueMapper.MapEFToBO(records));
                }

                public async Task<List<ApiVenueResponseModel>> ByProvinceId(int provinceId)
                {
                        List<Venue> records = await this.venueRepository.ByProvinceId(provinceId);

                        return this.bolVenueMapper.MapBOToModel(this.dalVenueMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>5b2d1c9501ea8ebe3cca80bb8af4c177</Hash>
</Codenesium>*/