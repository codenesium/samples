using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
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
        public abstract class AbstractProductPhotoService : AbstractService
        {
                private IProductPhotoRepository productPhotoRepository;

                private IApiProductPhotoRequestModelValidator productPhotoModelValidator;

                private IBOLProductPhotoMapper bolProductPhotoMapper;

                private IDALProductPhotoMapper dalProductPhotoMapper;

                private IBOLProductProductPhotoMapper bolProductProductPhotoMapper;

                private IDALProductProductPhotoMapper dalProductProductPhotoMapper;

                private ILogger logger;

                public AbstractProductPhotoService(
                        ILogger logger,
                        IProductPhotoRepository productPhotoRepository,
                        IApiProductPhotoRequestModelValidator productPhotoModelValidator,
                        IBOLProductPhotoMapper bolProductPhotoMapper,
                        IDALProductPhotoMapper dalProductPhotoMapper,
                        IBOLProductProductPhotoMapper bolProductProductPhotoMapper,
                        IDALProductProductPhotoMapper dalProductProductPhotoMapper)
                        : base()
                {
                        this.productPhotoRepository = productPhotoRepository;
                        this.productPhotoModelValidator = productPhotoModelValidator;
                        this.bolProductPhotoMapper = bolProductPhotoMapper;
                        this.dalProductPhotoMapper = dalProductPhotoMapper;
                        this.bolProductProductPhotoMapper = bolProductProductPhotoMapper;
                        this.dalProductProductPhotoMapper = dalProductProductPhotoMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProductPhotoResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.productPhotoRepository.All(limit, offset);

                        return this.bolProductPhotoMapper.MapBOToModel(this.dalProductPhotoMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProductPhotoResponseModel> Get(int productPhotoID)
                {
                        var record = await this.productPhotoRepository.Get(productPhotoID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolProductPhotoMapper.MapBOToModel(this.dalProductPhotoMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiProductPhotoResponseModel>> Create(
                        ApiProductPhotoRequestModel model)
                {
                        CreateResponse<ApiProductPhotoResponseModel> response = new CreateResponse<ApiProductPhotoResponseModel>(await this.productPhotoModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProductPhotoMapper.MapModelToBO(default(int), model);
                                var record = await this.productPhotoRepository.Create(this.dalProductPhotoMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolProductPhotoMapper.MapBOToModel(this.dalProductPhotoMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int productPhotoID,
                        ApiProductPhotoRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.productPhotoModelValidator.ValidateUpdateAsync(productPhotoID, model));
                        if (response.Success)
                        {
                                var bo = this.bolProductPhotoMapper.MapModelToBO(productPhotoID, model);
                                await this.productPhotoRepository.Update(this.dalProductPhotoMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int productPhotoID)
                {
                        ActionResponse response = new ActionResponse(await this.productPhotoModelValidator.ValidateDeleteAsync(productPhotoID));
                        if (response.Success)
                        {
                                await this.productPhotoRepository.Delete(productPhotoID);
                        }

                        return response;
                }

                public async virtual Task<List<ApiProductProductPhotoResponseModel>> ProductProductPhotoes(int productPhotoID, int limit = int.MaxValue, int offset = 0)
                {
                        List<ProductProductPhoto> records = await this.productPhotoRepository.ProductProductPhotoes(productPhotoID, limit, offset);

                        return this.bolProductProductPhotoMapper.MapBOToModel(this.dalProductProductPhotoMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>ffb189502a654fbabc57e2f808df45bd</Hash>
</Codenesium>*/