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
	public abstract class AbstractBOTransactionHistoryArchive: AbstractBOManager
	{
		private ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository;
		private IApiTransactionHistoryArchiveRequestModelValidator transactionHistoryArchiveModelValidator;
		private IBOLTransactionHistoryArchiveMapper transactionHistoryArchiveMapper;
		private ILogger logger;

		public AbstractBOTransactionHistoryArchive(
			ILogger logger,
			ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository,
			IApiTransactionHistoryArchiveRequestModelValidator transactionHistoryArchiveModelValidator,
			IBOLTransactionHistoryArchiveMapper transactionHistoryArchiveMapper)
			: base()

		{
			this.transactionHistoryArchiveRepository = transactionHistoryArchiveRepository;
			this.transactionHistoryArchiveModelValidator = transactionHistoryArchiveModelValidator;
			this.transactionHistoryArchiveMapper = transactionHistoryArchiveMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTransactionHistoryArchiveResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.transactionHistoryArchiveRepository.All(skip, take, orderClause);

			return this.transactionHistoryArchiveMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiTransactionHistoryArchiveResponseModel> Get(int transactionID)
		{
			var record = await transactionHistoryArchiveRepository.Get(transactionID);

			return this.transactionHistoryArchiveMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiTransactionHistoryArchiveResponseModel>> Create(
			ApiTransactionHistoryArchiveRequestModel model)
		{
			CreateResponse<ApiTransactionHistoryArchiveResponseModel> response = new CreateResponse<ApiTransactionHistoryArchiveResponseModel>(await this.transactionHistoryArchiveModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.transactionHistoryArchiveMapper.MapModelToDTO(default (int), model);
				var record = await this.transactionHistoryArchiveRepository.Create(dto);

				response.SetRecord(this.transactionHistoryArchiveMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int transactionID,
			ApiTransactionHistoryArchiveRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.transactionHistoryArchiveModelValidator.ValidateUpdateAsync(transactionID, model));

			if (response.Success)
			{
				var dto = this.transactionHistoryArchiveMapper.MapModelToDTO(transactionID, model);
				await this.transactionHistoryArchiveRepository.Update(transactionID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int transactionID)
		{
			ActionResponse response = new ActionResponse(await this.transactionHistoryArchiveModelValidator.ValidateDeleteAsync(transactionID));

			if (response.Success)
			{
				await this.transactionHistoryArchiveRepository.Delete(transactionID);
			}
			return response;
		}

		public async Task<List<ApiTransactionHistoryArchiveResponseModel>> GetProductID(int productID)
		{
			List<DTOTransactionHistoryArchive> records = await this.transactionHistoryArchiveRepository.GetProductID(productID);

			return this.transactionHistoryArchiveMapper.MapDTOToModel(records);
		}
		public async Task<List<ApiTransactionHistoryArchiveResponseModel>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID)
		{
			List<DTOTransactionHistoryArchive> records = await this.transactionHistoryArchiveRepository.GetReferenceOrderIDReferenceOrderLineID(referenceOrderID,referenceOrderLineID);

			return this.transactionHistoryArchiveMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>e8de479ba5f3eb788570dad3b637ad84</Hash>
</Codenesium>*/