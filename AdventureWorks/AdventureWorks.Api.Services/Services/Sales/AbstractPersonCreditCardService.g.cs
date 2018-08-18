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
	public abstract class AbstractPersonCreditCardService : AbstractService
	{
		protected IPersonCreditCardRepository PersonCreditCardRepository { get; private set; }

		protected IApiPersonCreditCardRequestModelValidator PersonCreditCardModelValidator { get; private set; }

		protected IBOLPersonCreditCardMapper BolPersonCreditCardMapper { get; private set; }

		protected IDALPersonCreditCardMapper DalPersonCreditCardMapper { get; private set; }

		private ILogger logger;

		public AbstractPersonCreditCardService(
			ILogger logger,
			IPersonCreditCardRepository personCreditCardRepository,
			IApiPersonCreditCardRequestModelValidator personCreditCardModelValidator,
			IBOLPersonCreditCardMapper bolPersonCreditCardMapper,
			IDALPersonCreditCardMapper dalPersonCreditCardMapper)
			: base()
		{
			this.PersonCreditCardRepository = personCreditCardRepository;
			this.PersonCreditCardModelValidator = personCreditCardModelValidator;
			this.BolPersonCreditCardMapper = bolPersonCreditCardMapper;
			this.DalPersonCreditCardMapper = dalPersonCreditCardMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPersonCreditCardResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PersonCreditCardRepository.All(limit, offset);

			return this.BolPersonCreditCardMapper.MapBOToModel(this.DalPersonCreditCardMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPersonCreditCardResponseModel> Get(int businessEntityID)
		{
			var record = await this.PersonCreditCardRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPersonCreditCardMapper.MapBOToModel(this.DalPersonCreditCardMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPersonCreditCardResponseModel>> Create(
			ApiPersonCreditCardRequestModel model)
		{
			CreateResponse<ApiPersonCreditCardResponseModel> response = new CreateResponse<ApiPersonCreditCardResponseModel>(await this.PersonCreditCardModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPersonCreditCardMapper.MapModelToBO(default(int), model);
				var record = await this.PersonCreditCardRepository.Create(this.DalPersonCreditCardMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPersonCreditCardMapper.MapBOToModel(this.DalPersonCreditCardMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPersonCreditCardResponseModel>> Update(
			int businessEntityID,
			ApiPersonCreditCardRequestModel model)
		{
			var validationResult = await this.PersonCreditCardModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPersonCreditCardMapper.MapModelToBO(businessEntityID, model);
				await this.PersonCreditCardRepository.Update(this.DalPersonCreditCardMapper.MapBOToEF(bo));

				var record = await this.PersonCreditCardRepository.Get(businessEntityID);

				return new UpdateResponse<ApiPersonCreditCardResponseModel>(this.BolPersonCreditCardMapper.MapBOToModel(this.DalPersonCreditCardMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPersonCreditCardResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.PersonCreditCardModelValidator.ValidateDeleteAsync(businessEntityID));
			if (response.Success)
			{
				await this.PersonCreditCardRepository.Delete(businessEntityID);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>da9ff6b6b809d286cbb7c397c813a2b5</Hash>
</Codenesium>*/