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
		private IBOLCurrencyMapper bolCurrencyMapper;
		private IDALCurrencyMapper dalCurrencyMapper;
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
			this.bolCurrencyMapper = bolcurrencyMapper;
			this.dalCurrencyMapper = dalcurrencyMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCurrencyResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.currencyRepository.All(skip, take, orderClause);

			return this.bolCurrencyMapper.MapBOToModel(this.dalCurrencyMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCurrencyResponseModel> Get(string currencyCode)
		{
			var record = await currencyRepository.Get(currencyCode);

			return this.bolCurrencyMapper.MapBOToModel(this.dalCurrencyMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiCurrencyResponseModel>> Create(
			ApiCurrencyRequestModel model)
		{
			CreateResponse<ApiCurrencyResponseModel> response = new CreateResponse<ApiCurrencyResponseModel>(await this.currencyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolCurrencyMapper.MapModelToBO(default (string), model);
				var record = await this.currencyRepository.Create(this.dalCurrencyMapper.MapBOToEF(bo));

				response.SetRecord(this.bolCurrencyMapper.MapBOToModel(this.dalCurrencyMapper.MapEFToBO(record)));
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
				var bo = this.bolCurrencyMapper.MapModelToBO(currencyCode, model);
				await this.currencyRepository.Update(this.dalCurrencyMapper.MapBOToEF(bo));
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

			return this.bolCurrencyMapper.MapBOToModel(this.dalCurrencyMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>50d2a71676929432621fe2e8d2690d96</Hash>
</Codenesium>*/