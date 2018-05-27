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
	public abstract class AbstractBOTransactionHistory: AbstractBOManager
	{
		private ITransactionHistoryRepository transactionHistoryRepository;
		private IApiTransactionHistoryRequestModelValidator transactionHistoryModelValidator;
		private IBOLTransactionHistoryMapper transactionHistoryMapper;
		private ILogger logger;

		public AbstractBOTransactionHistory(
			ILogger logger,
			ITransactionHistoryRepository transactionHistoryRepository,
			IApiTransactionHistoryRequestModelValidator transactionHistoryModelValidator,
			IBOLTransactionHistoryMapper transactionHistoryMapper)
			: base()

		{
			this.transactionHistoryRepository = transactionHistoryRepository;
			this.transactionHistoryModelValidator = transactionHistoryModelValidator;
			this.transactionHistoryMapper = transactionHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTransactionHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.transactionHistoryRepository.All(skip, take, orderClause);

			return this.transactionHistoryMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiTransactionHistoryResponseModel> Get(int transactionID)
		{
			var record = await transactionHistoryRepository.Get(transactionID);

			return this.transactionHistoryMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiTransactionHistoryResponseModel>> Create(
			ApiTransactionHistoryRequestModel model)
		{
			CreateResponse<ApiTransactionHistoryResponseModel> response = new CreateResponse<ApiTransactionHistoryResponseModel>(await this.transactionHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.transactionHistoryMapper.MapModelToDTO(default (int), model);
				var record = await this.transactionHistoryRepository.Create(dto);

				response.SetRecord(this.transactionHistoryMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int transactionID,
			ApiTransactionHistoryRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.transactionHistoryModelValidator.ValidateUpdateAsync(transactionID, model));

			if (response.Success)
			{
				var dto = this.transactionHistoryMapper.MapModelToDTO(transactionID, model);
				await this.transactionHistoryRepository.Update(transactionID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int transactionID)
		{
			ActionResponse response = new ActionResponse(await this.transactionHistoryModelValidator.ValidateDeleteAsync(transactionID));

			if (response.Success)
			{
				await this.transactionHistoryRepository.Delete(transactionID);
			}
			return response;
		}

		public async Task<List<ApiTransactionHistoryResponseModel>> GetProductID(int productID)
		{
			List<DTOTransactionHistory> records = await this.transactionHistoryRepository.GetProductID(productID);

			return this.transactionHistoryMapper.MapDTOToModel(records);
		}
		public async Task<List<ApiTransactionHistoryResponseModel>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID)
		{
			List<DTOTransactionHistory> records = await this.transactionHistoryRepository.GetReferenceOrderIDReferenceOrderLineID(referenceOrderID,referenceOrderLineID);

			return this.transactionHistoryMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>1bec81fbcdc24e669f385d54edd14044</Hash>
</Codenesium>*/