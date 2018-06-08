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
        public abstract class AbstractPersonCreditCardService: AbstractService
        {
                private IPersonCreditCardRepository personCreditCardRepository;

                private IApiPersonCreditCardRequestModelValidator personCreditCardModelValidator;

                private IBOLPersonCreditCardMapper bolPersonCreditCardMapper;

                private IDALPersonCreditCardMapper dalPersonCreditCardMapper;

                private ILogger logger;

                public AbstractPersonCreditCardService(
                        ILogger logger,
                        IPersonCreditCardRepository personCreditCardRepository,
                        IApiPersonCreditCardRequestModelValidator personCreditCardModelValidator,
                        IBOLPersonCreditCardMapper bolpersonCreditCardMapper,
                        IDALPersonCreditCardMapper dalpersonCreditCardMapper)
                        : base()

                {
                        this.personCreditCardRepository = personCreditCardRepository;
                        this.personCreditCardModelValidator = personCreditCardModelValidator;
                        this.bolPersonCreditCardMapper = bolpersonCreditCardMapper;
                        this.dalPersonCreditCardMapper = dalpersonCreditCardMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiPersonCreditCardResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.personCreditCardRepository.All(skip, take, orderClause);

                        return this.bolPersonCreditCardMapper.MapBOToModel(this.dalPersonCreditCardMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiPersonCreditCardResponseModel> Get(int businessEntityID)
                {
                        var record = await this.personCreditCardRepository.Get(businessEntityID);

                        return this.bolPersonCreditCardMapper.MapBOToModel(this.dalPersonCreditCardMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiPersonCreditCardResponseModel>> Create(
                        ApiPersonCreditCardRequestModel model)
                {
                        CreateResponse<ApiPersonCreditCardResponseModel> response = new CreateResponse<ApiPersonCreditCardResponseModel>(await this.personCreditCardModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolPersonCreditCardMapper.MapModelToBO(default (int), model);
                                var record = await this.personCreditCardRepository.Create(this.dalPersonCreditCardMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolPersonCreditCardMapper.MapBOToModel(this.dalPersonCreditCardMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int businessEntityID,
                        ApiPersonCreditCardRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.personCreditCardModelValidator.ValidateUpdateAsync(businessEntityID, model));

                        if (response.Success)
                        {
                                var bo = this.bolPersonCreditCardMapper.MapModelToBO(businessEntityID, model);
                                await this.personCreditCardRepository.Update(this.dalPersonCreditCardMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int businessEntityID)
                {
                        ActionResponse response = new ActionResponse(await this.personCreditCardModelValidator.ValidateDeleteAsync(businessEntityID));

                        if (response.Success)
                        {
                                await this.personCreditCardRepository.Delete(businessEntityID);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>f065c9236f95cf31e958ef6b8be97ca1</Hash>
</Codenesium>*/