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
			List<SalesReason> records = await this.SalesReasonRepository.All(limit, offset, query);

			return this.DalSalesReasonMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiSalesReasonServerResponseModel> Get(int salesReasonID)
		{
			SalesReason record = await this.SalesReasonRepository.Get(salesReasonID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalSalesReasonMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiSalesReasonServerResponseModel>> Create(
			ApiSalesReasonServerRequestModel model)
		{
			CreateResponse<ApiSalesReasonServerResponseModel> response = ValidationResponseFactory<ApiSalesReasonServerResponseModel>.CreateResponse(await this.SalesReasonModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				SalesReason record = this.DalSalesReasonMapper.MapModelToEntity(default(int), model);
				record = await this.SalesReasonRepository.Create(record);

				response.SetRecord(this.DalSalesReasonMapper.MapEntityToModel(record));
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
				SalesReason record = this.DalSalesReasonMapper.MapModelToEntity(salesReasonID, model);
				await this.SalesReasonRepository.Update(record);

				record = await this.SalesReasonRepository.Get(salesReasonID);

				ApiSalesReasonServerResponseModel apiModel = this.DalSalesReasonMapper.MapEntityToModel(record);
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
    <Hash>dec2ea670f873da52b3f1147fad89650</Hash>
</Codenesium>*/