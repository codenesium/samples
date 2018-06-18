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
        public abstract class AbstractSpecialOfferService: AbstractService
        {
                private ISpecialOfferRepository specialOfferRepository;

                private IApiSpecialOfferRequestModelValidator specialOfferModelValidator;

                private IBOLSpecialOfferMapper bolSpecialOfferMapper;

                private IDALSpecialOfferMapper dalSpecialOfferMapper;

                private IBOLSpecialOfferProductMapper bolSpecialOfferProductMapper;

                private IDALSpecialOfferProductMapper dalSpecialOfferProductMapper;

                private ILogger logger;

                public AbstractSpecialOfferService(
                        ILogger logger,
                        ISpecialOfferRepository specialOfferRepository,
                        IApiSpecialOfferRequestModelValidator specialOfferModelValidator,
                        IBOLSpecialOfferMapper bolSpecialOfferMapper,
                        IDALSpecialOfferMapper dalSpecialOfferMapper

                        ,
                        IBOLSpecialOfferProductMapper bolSpecialOfferProductMapper,
                        IDALSpecialOfferProductMapper dalSpecialOfferProductMapper

                        )
                        : base()

                {
                        this.specialOfferRepository = specialOfferRepository;
                        this.specialOfferModelValidator = specialOfferModelValidator;
                        this.bolSpecialOfferMapper = bolSpecialOfferMapper;
                        this.dalSpecialOfferMapper = dalSpecialOfferMapper;
                        this.bolSpecialOfferProductMapper = bolSpecialOfferProductMapper;
                        this.dalSpecialOfferProductMapper = dalSpecialOfferProductMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSpecialOfferResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.specialOfferRepository.All(limit, offset);

                        return this.bolSpecialOfferMapper.MapBOToModel(this.dalSpecialOfferMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSpecialOfferResponseModel> Get(int specialOfferID)
                {
                        var record = await this.specialOfferRepository.Get(specialOfferID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolSpecialOfferMapper.MapBOToModel(this.dalSpecialOfferMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiSpecialOfferResponseModel>> Create(
                        ApiSpecialOfferRequestModel model)
                {
                        CreateResponse<ApiSpecialOfferResponseModel> response = new CreateResponse<ApiSpecialOfferResponseModel>(await this.specialOfferModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSpecialOfferMapper.MapModelToBO(default (int), model);
                                var record = await this.specialOfferRepository.Create(this.dalSpecialOfferMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSpecialOfferMapper.MapBOToModel(this.dalSpecialOfferMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int specialOfferID,
                        ApiSpecialOfferRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.specialOfferModelValidator.ValidateUpdateAsync(specialOfferID, model));

                        if (response.Success)
                        {
                                var bo = this.bolSpecialOfferMapper.MapModelToBO(specialOfferID, model);
                                await this.specialOfferRepository.Update(this.dalSpecialOfferMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int specialOfferID)
                {
                        ActionResponse response = new ActionResponse(await this.specialOfferModelValidator.ValidateDeleteAsync(specialOfferID));

                        if (response.Success)
                        {
                                await this.specialOfferRepository.Delete(specialOfferID);
                        }

                        return response;
                }

                public async virtual Task<List<ApiSpecialOfferProductResponseModel>> SpecialOfferProducts(int specialOfferID, int limit = int.MaxValue, int offset = 0)
                {
                        List<SpecialOfferProduct> records = await this.specialOfferRepository.SpecialOfferProducts(specialOfferID, limit, offset);

                        return this.bolSpecialOfferProductMapper.MapBOToModel(this.dalSpecialOfferProductMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>9ece0ad6baa395111e3cdade9f81dc99</Hash>
</Codenesium>*/