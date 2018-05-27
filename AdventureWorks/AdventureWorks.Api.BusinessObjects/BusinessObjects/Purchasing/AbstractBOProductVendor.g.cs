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
	public abstract class AbstractBOProductVendor: AbstractBOManager
	{
		private IProductVendorRepository productVendorRepository;
		private IApiProductVendorRequestModelValidator productVendorModelValidator;
		private IBOLProductVendorMapper productVendorMapper;
		private ILogger logger;

		public AbstractBOProductVendor(
			ILogger logger,
			IProductVendorRepository productVendorRepository,
			IApiProductVendorRequestModelValidator productVendorModelValidator,
			IBOLProductVendorMapper productVendorMapper)
			: base()

		{
			this.productVendorRepository = productVendorRepository;
			this.productVendorModelValidator = productVendorModelValidator;
			this.productVendorMapper = productVendorMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductVendorResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productVendorRepository.All(skip, take, orderClause);

			return this.productVendorMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiProductVendorResponseModel> Get(int productID)
		{
			var record = await productVendorRepository.Get(productID);

			return this.productVendorMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiProductVendorResponseModel>> Create(
			ApiProductVendorRequestModel model)
		{
			CreateResponse<ApiProductVendorResponseModel> response = new CreateResponse<ApiProductVendorResponseModel>(await this.productVendorModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.productVendorMapper.MapModelToDTO(default (int), model);
				var record = await this.productVendorRepository.Create(dto);

				response.SetRecord(this.productVendorMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productID,
			ApiProductVendorRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.productVendorModelValidator.ValidateUpdateAsync(productID, model));

			if (response.Success)
			{
				var dto = this.productVendorMapper.MapModelToDTO(productID, model);
				await this.productVendorRepository.Update(productID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.productVendorModelValidator.ValidateDeleteAsync(productID));

			if (response.Success)
			{
				await this.productVendorRepository.Delete(productID);
			}
			return response;
		}

		public async Task<List<ApiProductVendorResponseModel>> GetBusinessEntityID(int businessEntityID)
		{
			List<DTOProductVendor> records = await this.productVendorRepository.GetBusinessEntityID(businessEntityID);

			return this.productVendorMapper.MapDTOToModel(records);
		}
		public async Task<List<ApiProductVendorResponseModel>> GetUnitMeasureCode(string unitMeasureCode)
		{
			List<DTOProductVendor> records = await this.productVendorRepository.GetUnitMeasureCode(unitMeasureCode);

			return this.productVendorMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>dc6ae9cc8573efb2bee87f858fdedd29</Hash>
</Codenesium>*/