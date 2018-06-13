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
        public abstract class AbstractShoppingCartItemService: AbstractService
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
                        IDALShoppingCartItemMapper dalShoppingCartItemMapper

                        )
                        : base()

                {
                        this.shoppingCartItemRepository = shoppingCartItemRepository;
                        this.shoppingCartItemModelValidator = shoppingCartItemModelValidator;
                        this.bolShoppingCartItemMapper = bolShoppingCartItemMapper;
                        this.dalShoppingCartItemMapper = dalShoppingCartItemMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiShoppingCartItemResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.shoppingCartItemRepository.All(limit, offset, orderClause);

                        return this.bolShoppingCartItemMapper.MapBOToModel(this.dalShoppingCartItemMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiShoppingCartItemResponseModel> Get(int shoppingCartItemID)
                {
                        var record = await this.shoppingCartItemRepository.Get(shoppingCartItemID);

                        return this.bolShoppingCartItemMapper.MapBOToModel(this.dalShoppingCartItemMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiShoppingCartItemResponseModel>> Create(
                        ApiShoppingCartItemRequestModel model)
                {
                        CreateResponse<ApiShoppingCartItemResponseModel> response = new CreateResponse<ApiShoppingCartItemResponseModel>(await this.shoppingCartItemModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolShoppingCartItemMapper.MapModelToBO(default (int), model);
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

                public async Task<List<ApiShoppingCartItemResponseModel>> GetShoppingCartIDProductID(string shoppingCartID, int productID)
                {
                        List<ShoppingCartItem> records = await this.shoppingCartItemRepository.GetShoppingCartIDProductID(shoppingCartID, productID);

                        return this.bolShoppingCartItemMapper.MapBOToModel(this.dalShoppingCartItemMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>636ab47a992cdb61453afff7e986d443</Hash>
</Codenesium>*/