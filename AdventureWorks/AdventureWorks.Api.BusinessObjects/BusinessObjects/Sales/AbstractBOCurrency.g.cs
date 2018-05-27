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

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOCurrency: AbstractBOManager
	{
		private ICurrencyRepository currencyRepository;
		private IApiCurrencyRequestModelValidator currencyModelValidator;
		private IBOLCurrencyMapper currencyMapper;
		private ILogger logger;

		public AbstractBOCurrency(
			ILogger logger,
			ICurrencyRepository currencyRepository,
			IApiCurrencyRequestModelValidator currencyModelValidator,
			IBOLCurrencyMapper currencyMapper)
			: base()

		{
			this.currencyRepository = currencyRepository;
			this.currencyModelValidator = currencyModelValidator;
			this.currencyMapper = currencyMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCurrencyResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.currencyRepository.All(skip, take, orderClause);

			return this.currencyMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiCurrencyResponseModel> Get(string currencyCode)
		{
			var record = await currencyRepository.Get(currencyCode);

			return this.currencyMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiCurrencyResponseModel>> Create(
			ApiCurrencyRequestModel model)
		{
			CreateResponse<ApiCurrencyResponseModel> response = new CreateResponse<ApiCurrencyResponseModel>(await this.currencyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.currencyMapper.MapModelToDTO(default (string), model);
				var record = await this.currencyRepository.Create(dto);

				response.SetRecord(this.currencyMapper.MapDTOToModel(record));
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
				var dto = this.currencyMapper.MapModelToDTO(currencyCode, model);
				await this.currencyRepository.Update(currencyCode, dto);
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
			DTOCurrency record = await this.currencyRepository.GetName(name);

			return this.currencyMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>0ec4a30a3f8da7e114a676cb08150993</Hash>
</Codenesium>*/