using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractSalesReasonService : AbstractService
	{
		private IMediator mediator;

		protected ISalesReasonRepository SalesReasonRepository { get; private set; }

		protected IApiSalesReasonServerRequestModelValidator SalesReasonModelValidator { get; private set; }

		protected IDALSalesReasonMapper DalSalesReasonMapper { get; private set; }

		private ILogger logger;

		public AbstractSalesReasonService(
			ILogger logger,
			IMediator mediator,
			ISalesReasonRepository salesReasonRepository,
			IApiSalesReasonServerRequestModelValidator salesReasonModelValidator,
			IDALSalesReasonMapper dalSalesReasonMapper)
			: base()
		{
			this.SalesReasonRepository = salesReasonRepository;
			this.SalesReasonModelValidator = salesReasonModelValidator;
			this.DalSalesReasonMapper = dalSalesReasonMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiSalesReasonServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			var records = await this.SalesReasonRepository.All(limit, offset, query);

			return this.DalSalesReasonMapper.MapBOToModel(records);
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
				return this.DalSalesReasonMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiSalesReasonServerResponseModel>> Create(
			ApiSalesReasonServerRequestModel model)
		{
			CreateResponse<ApiSalesReasonServerResponseModel> response = ValidationResponseFactory<ApiSalesReasonServerResponseModel>.CreateResponse(await this.SalesReasonModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalSalesReasonMapper.MapModelToBO(default(int), model);
				var record = await this.SalesReasonRepository.Create(bo);

				response.SetRecord(this.DalSalesReasonMapper.MapBOToModel(record));
				await this.mediator.Publish(new SalesReasonCreatedNotification(response.Record));
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
				var bo = this.DalSalesReasonMapper.MapModelToBO(salesReasonID, model);
				await this.SalesReasonRepository.Update(bo);

				var record = await this.SalesReasonRepository.Get(salesReasonID);

				var apiModel = this.DalSalesReasonMapper.MapBOToModel(record);
				await this.mediator.Publish(new SalesReasonUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiSalesReasonServerResponseModel>.UpdateResponse(apiModel);
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

				await this.mediator.Publish(new SalesReasonDeletedNotification(salesReasonID));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2c0f204f8b94838104afb36e31747f75</Hash>
</Codenesium>*/