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
	public abstract class AbstractBOProductDocument: AbstractBOManager
	{
		private IProductDocumentRepository productDocumentRepository;
		private IApiProductDocumentRequestModelValidator productDocumentModelValidator;
		private IBOLProductDocumentMapper productDocumentMapper;
		private ILogger logger;

		public AbstractBOProductDocument(
			ILogger logger,
			IProductDocumentRepository productDocumentRepository,
			IApiProductDocumentRequestModelValidator productDocumentModelValidator,
			IBOLProductDocumentMapper productDocumentMapper)
			: base()

		{
			this.productDocumentRepository = productDocumentRepository;
			this.productDocumentModelValidator = productDocumentModelValidator;
			this.productDocumentMapper = productDocumentMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductDocumentResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productDocumentRepository.All(skip, take, orderClause);

			return this.productDocumentMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiProductDocumentResponseModel> Get(int productID)
		{
			var record = await productDocumentRepository.Get(productID);

			return this.productDocumentMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiProductDocumentResponseModel>> Create(
			ApiProductDocumentRequestModel model)
		{
			CreateResponse<ApiProductDocumentResponseModel> response = new CreateResponse<ApiProductDocumentResponseModel>(await this.productDocumentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.productDocumentMapper.MapModelToDTO(default (int), model);
				var record = await this.productDocumentRepository.Create(dto);

				response.SetRecord(this.productDocumentMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productID,
			ApiProductDocumentRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.productDocumentModelValidator.ValidateUpdateAsync(productID, model));

			if (response.Success)
			{
				var dto = this.productDocumentMapper.MapModelToDTO(productID, model);
				await this.productDocumentRepository.Update(productID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.productDocumentModelValidator.ValidateDeleteAsync(productID));

			if (response.Success)
			{
				await this.productDocumentRepository.Delete(productID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7347bb5f1a00b4b43b106bf86c2ef80e</Hash>
</Codenesium>*/