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
        public abstract class AbstractShoppingCartItemService : AbstractService
        {
                private IShoppingCartItemRepository shoppingCartItemRepository;

                private IApiShoppingCartItemRequestModelValidator shoppingCartItemModelValidator;

                private IBOLShoppingCartItemMapper bolShoppingCartItemMapper;

                private IDALShoppingCartItemMapper dalShoppingCartItemMapper;

                private ILogger logger;

                public AbstractShoppingCartItemService(
                        ILogger logger,
                        IShoppingCartItemRepository shoppingCartItemRepository,
                        IApiShoppingCartItemRequestModelValidator shoppingCartItemModelValidator,
                        IBOLShoppingCartItemMapper bolShoppingCartItemMapper,
                        IDALShoppingCartItemMapper dalShoppingCartItemMapper)
                        : base()
                {
                        this.shoppingCartItemRepository = shoppingCartItemRepository;
                        this.shoppingCartItemModelValidator = shoppingCartItemModelValidator;
                        this.bolShoppingCartItemMapper = bolShoppingCartItemMapper;
                        this.dalShoppingCartItemMapper = dalShoppingCartItemMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiShoppingCartItemResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.shoppingCartItemRepository.All(limit, offset);

                        return this.bolShoppingCartItemMapper.MapBOToModel(this.dalShoppingCartItemMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiShoppingCartItemResponseModel> Get(int shoppingCartItemID)
                {
                        var record = await this.shoppingCartItemRepository.Get(shoppingCartItemID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolShoppingCartItemMapper.MapBOToModel(this.dalShoppingCartItemMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiShoppingCartItemResponseModel>> Create(
                        ApiShoppingCartItemRequestModel model)
                {
                        CreateResponse<ApiShoppingCartItemResponseModel> response = new CreateResponse<ApiShoppingCartItemResponseModel>(await this.shoppingCartItemModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolShoppingCartItemMapper.MapModelToBO(default(int), model);
                                var record = await this.shoppingCartItemRepository.Create(this.dalShoppingCartItemMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolShoppingCartItemMapper.MapBOToModel(this.dalShoppingCartItemMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int shoppingCartItemID,
                        ApiShoppingCartItemRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.shoppingCartItemModelValidator.ValidateUpdateAsync(shoppingCartItemID, model));
                        if (response.Success)
                        {
                                var bo = this.bolShoppingCartItemMapper.MapModelToBO(shoppingCartItemID, model);
                                await this.shoppingCartItemRepository.Update(this.dalShoppingCartItemMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int shoppingCartItemID)
                {
                        ActionResponse response = new ActionResponse(await this.shoppingCartItemModelValidator.ValidateDeleteAsync(shoppingCartItemID));
                        if (response.Success)
                        {
                                await this.shoppingCartItemRepository.Delete(shoppingCartItemID);
                        }

                        return response;
                }

                public async Task<List<ApiShoppingCartItemResponseModel>> ByShoppingCartIDProductID(string shoppingCartID, int productID)
                {
                        List<ShoppingCartItem> records = await this.shoppingCartItemRepository.ByShoppingCartIDProductID(shoppingCartID, productID);

                        return this.bolShoppingCartItemMapper.MapBOToModel(this.dalShoppingCartItemMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>2bb0e01016f5514f156aa77afd386144</Hash>
</Codenesium>*/