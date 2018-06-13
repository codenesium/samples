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
        public abstract class AbstractProductProductPhotoService: AbstractService
        {
                private IProductProductPhotoRepository productProductPhotoRepository;

                private IApiProductProductPhotoRequestModelValidator productProductPhotoModelValidator;

                private IBOLProductProductPhotoMapper bolProductProductPhotoMapper;

                private IDALProductProductPhotoMapper dalProductProductPhotoMapper;

                private ILogger logger;

                public AbstractProductProductPhotoService(
                        ILogger logger,
                        IProductProductPhotoRepository productProductPhotoRepository,
                        IApiProductProductPhotoRequestModelValidator productProductPhotoModelValidator,
                        IBOLProductProductPhotoMapper bolProductProductPhotoMapper,
                        IDALProductProductPhotoMapper dalProductProductPhotoMapper

                        )
                        : base()

                {
                        this.productProductPhotoRepository = productProductPhotoRepository;
                        this.productProductPhotoModelValidator = productProductPhotoModelValidator;
                        this.bolProductProductPhotoMapper = bolProductProductPhotoMapper;
                        this.dalProductProductPhotoMapper = dalProductProductPhotoMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProductProductPhotoResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.productProductPhotoRepository.All(limit, offset, orderClause);

                        return this.bolProductProductPhotoMapper.MapBOToModel(this.dalProductProductPhotoMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProductProductPhotoResponseModel> Get(int productID)
                {
                        var record = await this.productProductPhotoRepository.Get(productID);

                        return this.bolProductProductPhotoMapper.MapBOToModel(this.dalProductProductPhotoMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiProductProductPhotoResponseModel>> Create(
                        ApiProductProductPhotoRequestModel model)
                {
                        CreateResponse<ApiProductProductPhotoResponseModel> response = new CreateResponse<ApiProductProductPhotoResponseModel>(await this.productProductPhotoModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProductProductPhotoMapper.MapModelToBO(default (int), model);
                                var record = await this.productProductPhotoRepository.Create(this.dalProductProductPhotoMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolProductProductPhotoMapper.MapBOToModel(this.dalProductProductPhotoMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int productID,
                        ApiProductProductPhotoRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.productProductPhotoModelValidator.ValidateUpdateAsync(productID, model));

                        if (response.Success)
                        {
                                var bo = this.bolProductProductPhotoMapper.MapModelToBO(productID, model);
                                await this.productProductPhotoRepository.Update(this.dalProductProductPhotoMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int productID)
                {
                        ActionResponse response = new ActionResponse(await this.productProductPhotoModelValidator.ValidateDeleteAsync(productID));

                        if (response.Success)
                        {
                                await this.productProductPhotoRepository.Delete(productID);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>914da640da227287e1c903239848e21e</Hash>
</Codenesium>*/