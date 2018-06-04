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
	public abstract class AbstractProductDocumentService: AbstractService
	{
		private IProductDocumentRepository productDocumentRepository;
		private IApiProductDocumentRequestModelValidator productDocumentModelValidator;
		private IBOLProductDocumentMapper BOLProductDocumentMapper;
		private IDALProductDocumentMapper DALProductDocumentMapper;
		private ILogger logger;

		public AbstractProductDocumentService(
			ILogger logger,
			IProductDocumentRepository productDocumentRepository,
			IApiProductDocumentRequestModelValidator productDocumentModelValidator,
			IBOLProductDocumentMapper bolproductDocumentMapper,
			IDALProductDocumentMapper dalproductDocumentMapper)
			: base()

		{
			this.productDocumentRepository = productDocumentRepository;
			this.productDocumentModelValidator = productDocumentModelValidator;
			this.BOLProductDocumentMapper = bolproductDocumentMapper;
			this.DALProductDocumentMapper = dalproductDocumentMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductDocumentResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productDocumentRepository.All(skip, take, orderClause);

			return this.BOLProductDocumentMapper.MapBOToModel(this.DALProductDocumentMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductDocumentResponseModel> Get(int productID)
		{
			var record = await productDocumentRepository.Get(productID);

			return this.BOLProductDocumentMapper.MapBOToModel(this.DALProductDocumentMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiProductDocumentResponseModel>> Create(
			ApiProductDocumentRequestModel model)
		{
			CreateResponse<ApiProductDocumentResponseModel> response = new CreateResponse<ApiProductDocumentResponseModel>(await this.productDocumentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLProductDocumentMapper.MapModelToBO(default (int), model);
				var record = await this.productDocumentRepository.Create(this.DALProductDocumentMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLProductDocumentMapper.MapBOToModel(this.DALProductDocumentMapper.MapEFToBO(record)));
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
				var bo = this.BOLProductDocumentMapper.MapModelToBO(productID, model);
				await this.productDocumentRepository.Update(this.DALProductDocumentMapper.MapBOToEF(bo));
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
    <Hash>61b75f74e2e567f3e7b11f22fc770c6c</Hash>
</Codenesium>*/