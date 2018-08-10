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
	public abstract class AbstractSalesTaxRateService : AbstractService
	{
		protected ISalesTaxRateRepository SalesTaxRateRepository { get; private set; }

		protected IApiSalesTaxRateRequestModelValidator SalesTaxRateModelValidator { get; private set; }

		protected IBOLSalesTaxRateMapper BolSalesTaxRateMapper { get; private set; }

		protected IDALSalesTaxRateMapper DalSalesTaxRateMapper { get; private set; }

		private ILogger logger;

		public AbstractSalesTaxRateService(
			ILogger logger,
			ISalesTaxRateRepository salesTaxRateRepository,
			IApiSalesTaxRateRequestModelValidator salesTaxRateModelValidator,
			IBOLSalesTaxRateMapper bolSalesTaxRateMapper,
			IDALSalesTaxRateMapper dalSalesTaxRateMapper)
			: base()
		{
			this.SalesTaxRateRepository = salesTaxRateRepository;
			this.SalesTaxRateModelValidator = salesTaxRateModelValidator;
			this.BolSalesTaxRateMapper = bolSalesTaxRateMapper;
			this.DalSalesTaxRateMapper = dalSalesTaxRateMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesTaxRateResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SalesTaxRateRepository.All(limit, offset);

			return this.BolSalesTaxRateMapper.MapBOToModel(this.DalSalesTaxRateMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesTaxRateResponseModel> Get(int salesTaxRateID)
		{
			var record = await this.SalesTaxRateRepository.Get(salesTaxRateID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSalesTaxRateMapper.MapBOToModel(this.DalSalesTaxRateMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSalesTaxRateResponseModel>> Create(
			ApiSalesTaxRateRequestModel model)
		{
			CreateResponse<ApiSalesTaxRateResponseModel> response = new CreateResponse<ApiSalesTaxRateResponseModel>(await this.SalesTaxRateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSalesTaxRateMapper.MapModelToBO(default(int), model);
				var record = await this.SalesTaxRateRepository.Create(this.DalSalesTaxRateMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSalesTaxRateMapper.MapBOToModel(this.DalSalesTaxRateMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSalesTaxRateResponseModel>> Update(
			int salesTaxRateID,
			ApiSalesTaxRateRequestModel model)
		{
			var validationResult = await this.SalesTaxRateModelValidator.ValidateUpdateAsync(salesTaxRateID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSalesTaxRateMapper.MapModelToBO(salesTaxRateID, model);
				await this.SalesTaxRateRepository.Update(this.DalSalesTaxRateMapper.MapBOToEF(bo));

				var record = await this.SalesTaxRateRepository.Get(salesTaxRateID);

				return new UpdateResponse<ApiSalesTaxRateResponseModel>(this.BolSalesTaxRateMapper.MapBOToModel(this.DalSalesTaxRateMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSalesTaxRateResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int salesTaxRateID)
		{
			ActionResponse response = new ActionResponse(await this.SalesTaxRateModelValidator.ValidateDeleteAsync(salesTaxRateID));
			if (response.Success)
			{
				await this.SalesTaxRateRepository.Delete(salesTaxRateID);
			}

			return response;
		}

		public async Task<ApiSalesTaxRateResponseModel> ByStateProvinceIDTaxType(int stateProvinceID, int taxType)
		{
			SalesTaxRate record = await this.SalesTaxRateRepository.ByStateProvinceIDTaxType(stateProvinceID, taxType);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSalesTaxRateMapper.MapBOToModel(this.DalSalesTaxRateMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>8a733e06baf3a090a6deb653fb7727b3</Hash>
</Codenesium>*/