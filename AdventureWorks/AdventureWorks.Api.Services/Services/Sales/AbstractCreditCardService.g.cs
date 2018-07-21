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
        public abstract class AbstractCreditCardService : AbstractService
        {
                private ICreditCardRepository creditCardRepository;

                private IApiCreditCardRequestModelValidator creditCardModelValidator;

                private IBOLCreditCardMapper bolCreditCardMapper;

                private IDALCreditCardMapper dalCreditCardMapper;

                private IBOLPersonCreditCardMapper bolPersonCreditCardMapper;

                private IDALPersonCreditCardMapper dalPersonCreditCardMapper;
                private IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper;

                private IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper;

                private ILogger logger;

                public AbstractCreditCardService(
                        ILogger logger,
                        ICreditCardRepository creditCardRepository,
                        IApiCreditCardRequestModelValidator creditCardModelValidator,
                        IBOLCreditCardMapper bolCreditCardMapper,
                        IDALCreditCardMapper dalCreditCardMapper,
                        IBOLPersonCreditCardMapper bolPersonCreditCardMapper,
                        IDALPersonCreditCardMapper dalPersonCreditCardMapper,
                        IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
                        IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper)
                        : base()
                {
                        this.creditCardRepository = creditCardRepository;
                        this.creditCardModelValidator = creditCardModelValidator;
                        this.bolCreditCardMapper = bolCreditCardMapper;
                        this.dalCreditCardMapper = dalCreditCardMapper;
                        this.bolPersonCreditCardMapper = bolPersonCreditCardMapper;
                        this.dalPersonCreditCardMapper = dalPersonCreditCardMapper;
                        this.bolSalesOrderHeaderMapper = bolSalesOrderHeaderMapper;
                        this.dalSalesOrderHeaderMapper = dalSalesOrderHeaderMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiCreditCardResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.creditCardRepository.All(limit, offset);

                        return this.bolCreditCardMapper.MapBOToModel(this.dalCreditCardMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiCreditCardResponseModel> Get(int creditCardID)
                {
                        var record = await this.creditCardRepository.Get(creditCardID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolCreditCardMapper.MapBOToModel(this.dalCreditCardMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiCreditCardResponseModel>> Create(
                        ApiCreditCardRequestModel model)
                {
                        CreateResponse<ApiCreditCardResponseModel> response = new CreateResponse<ApiCreditCardResponseModel>(await this.creditCardModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolCreditCardMapper.MapModelToBO(default(int), model);
                                var record = await this.creditCardRepository.Create(this.dalCreditCardMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolCreditCardMapper.MapBOToModel(this.dalCreditCardMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiCreditCardResponseModel>> Update(
                        int creditCardID,
                        ApiCreditCardRequestModel model)
                {
                        var validationResult = await this.creditCardModelValidator.ValidateUpdateAsync(creditCardID, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolCreditCardMapper.MapModelToBO(creditCardID, model);
                                await this.creditCardRepository.Update(this.dalCreditCardMapper.MapBOToEF(bo));

                                var record = await this.creditCardRepository.Get(creditCardID);

                                return new UpdateResponse<ApiCreditCardResponseModel>(this.bolCreditCardMapper.MapBOToModel(this.dalCreditCardMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiCreditCardResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int creditCardID)
                {
                        ActionResponse response = new ActionResponse(await this.creditCardModelValidator.ValidateDeleteAsync(creditCardID));
                        if (response.Success)
                        {
                                await this.creditCardRepository.Delete(creditCardID);
                        }

                        return response;
                }

                public async Task<ApiCreditCardResponseModel> ByCardNumber(string cardNumber)
                {
                        CreditCard record = await this.creditCardRepository.ByCardNumber(cardNumber);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolCreditCardMapper.MapBOToModel(this.dalCreditCardMapper.MapEFToBO(record));
                        }
                }

                public async virtual Task<List<ApiPersonCreditCardResponseModel>> PersonCreditCards(int creditCardID, int limit = int.MaxValue, int offset = 0)
                {
                        List<PersonCreditCard> records = await this.creditCardRepository.PersonCreditCards(creditCardID, limit, offset);

                        return this.bolPersonCreditCardMapper.MapBOToModel(this.dalPersonCreditCardMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaders(int creditCardID, int limit = int.MaxValue, int offset = 0)
                {
                        List<SalesOrderHeader> records = await this.creditCardRepository.SalesOrderHeaders(creditCardID, limit, offset);

                        return this.bolSalesOrderHeaderMapper.MapBOToModel(this.dalSalesOrderHeaderMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>ad6337e4a24bfd2615028b6313c1b764</Hash>
</Codenesium>*/