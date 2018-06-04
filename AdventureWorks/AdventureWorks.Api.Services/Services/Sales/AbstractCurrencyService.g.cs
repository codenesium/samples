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
	public abstract class AbstractCurrencyService: AbstractService
	{
		private ICurrencyRepository currencyRepository;
		private IApiCurrencyRequestModelValidator currencyModelValidator;
		private IBOLCurrencyMapper BOLCurrencyMapper;
		private IDALCurrencyMapper DALCurrencyMapper;
		private ILogger logger;

		public AbstractCurrencyService(
			ILogger logger,
			ICurrencyRepository currencyRepository,
			IApiCurrencyRequestModelValidator currencyModelValidator,
			IBOLCurrencyMapper bolcurrencyMapper,
			IDALCurrencyMapper dalcurrencyMapper)
			: base()

		{
			this.currencyRepository = currencyRepository;
			this.currencyModelValidator = currencyModelValidator;
			this.BOLCurrencyMapper = bolcurrencyMapper;
			this.DALCurrencyMapper = dalcurrencyMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCurrencyResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.currencyRepository.All(skip, take, orderClause);

			return this.BOLCurrencyMapper.MapBOToModel(this.DALCurrencyMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCurrencyResponseModel> Get(string currencyCode)
		{
			var record = await currencyRepository.Get(currencyCode);

			return this.BOLCurrencyMapper.MapBOToModel(this.DALCurrencyMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiCurrencyResponseModel>> Create(
			ApiCurrencyRequestModel model)
		{
			CreateResponse<ApiCurrencyResponseModel> response = new CreateResponse<ApiCurrencyResponseModel>(await this.currencyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLCurrencyMapper.MapModelToBO(default (string), model);
				var record = await this.currencyRepository.Create(this.DALCurrencyMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLCurrencyMapper.MapBOToModel(this.DALCurrencyMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			string currencyCode,
			ApiCurrencyRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.currencyModelValidator.ValidateUpdateAsync(currencyCode, model));

			if (response.Success)
			{
				var bo = this.BOLCurrencyMapper.MapModelToBO(currencyCode, model);
				await this.currencyRepository.Update(this.DALCurrencyMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			string currencyCode)
		{
			ActionResponse response = new ActionResponse(await this.currencyModelValidator.ValidateDeleteAsync(currencyCode));

			if (response.Success)
			{
				await this.currencyRepository.Delete(currencyCode);
			}
			return response;
		}

		public async Task<ApiCurrencyResponseModel> GetName(string name)
		{
			Currency record = await this.currencyRepository.GetName(name);

			return this.BOLCurrencyMapper.MapBOToModel(this.DALCurrencyMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>af6823a89c2ceef2d5880f8b52baf862</Hash>
</Codenesium>*/