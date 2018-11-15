using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractSalesReasonService : AbstractService
	{
		protected ISalesReasonRepository SalesReasonRepository { get; private set; }

		protected IApiSalesReasonServerRequestModelValidator SalesReasonModelValidator { get; private set; }

		protected IBOLSalesReasonMapper BolSalesReasonMapper { get; private set; }

		protected IDALSalesReasonMapper DalSalesReasonMapper { get; private set; }

		private ILogger logger;

		public AbstractSalesReasonService(
			ILogger logger,
			ISalesReasonRepository salesReasonRepository,
			IApiSalesReasonServerRequestModelValidator salesReasonModelValidator,
			IBOLSalesReasonMapper bolSalesReasonMapper,
			IDALSalesReasonMapper dalSalesReasonMapper)
			: base()
		{
			this.SalesReasonRepository = salesReasonRepository;
			this.SalesReasonModelValidator = salesReasonModelValidator;
			this.BolSalesReasonMapper = bolSalesReasonMapper;
			this.DalSalesReasonMapper = dalSalesReasonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesReasonServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SalesReasonRepository.All(limit, offset);

			return this.BolSalesReasonMapper.MapBOToModel(this.DalSalesReasonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesReasonServerResponseModel> Get(int salesReasonID)
		{
			var record = await this.SalesReasonRepository.Get(salesReasonID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSalesReasonMapper.MapBOToModel(this.DalSalesReasonMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSalesReasonServerResponseModel>> Create(
			ApiSalesReasonServerRequestModel model)
		{
			CreateResponse<ApiSalesReasonServerResponseModel> response = ValidationResponseFactory<ApiSalesReasonServerResponseModel>.CreateResponse(await this.SalesReasonModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolSalesReasonMapper.MapModelToBO(default(int), model);
				var record = await this.SalesReasonRepository.Create(this.DalSalesReasonMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSalesReasonMapper.MapBOToModel(this.DalSalesReasonMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSalesReasonServerResponseModel>> Update(
			int salesReasonID,
			ApiSalesReasonServerRequestModel model)
		{
			var validationResult = await this.SalesReasonModelValidator.ValidateUpdateAsync(salesReasonID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSalesReasonMapper.MapModelToBO(salesReasonID, model);
				await this.SalesReasonRepository.Update(this.DalSalesReasonMapper.MapBOToEF(bo));

				var record = await this.SalesReasonRepository.Get(salesReasonID);

				return ValidationResponseFactory<ApiSalesReasonServerResponseModel>.UpdateResponse(this.BolSalesReasonMapper.MapBOToModel(this.DalSalesReasonMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiSalesReasonServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int salesReasonID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.SalesReasonModelValidator.ValidateDeleteAsync(salesReasonID));

			if (response.Success)
			{
				await this.SalesReasonRepository.Delete(salesReasonID);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9f78a3652b872814e3cff1c3dea00d86</Hash>
</Codenesium>*/