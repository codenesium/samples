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
	public abstract class AbstractBOVendor: AbstractBOManager
	{
		private IVendorRepository vendorRepository;
		private IApiVendorRequestModelValidator vendorModelValidator;
		private IBOLVendorMapper vendorMapper;
		private ILogger logger;

		public AbstractBOVendor(
			ILogger logger,
			IVendorRepository vendorRepository,
			IApiVendorRequestModelValidator vendorModelValidator,
			IBOLVendorMapper vendorMapper)
			: base()

		{
			this.vendorRepository = vendorRepository;
			this.vendorModelValidator = vendorModelValidator;
			this.vendorMapper = vendorMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiVendorResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.vendorRepository.All(skip, take, orderClause);

			return this.vendorMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiVendorResponseModel> Get(int businessEntityID)
		{
			var record = await vendorRepository.Get(businessEntityID);

			return this.vendorMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiVendorResponseModel>> Create(
			ApiVendorRequestModel model)
		{
			CreateResponse<ApiVendorResponseModel> response = new CreateResponse<ApiVendorResponseModel>(await this.vendorModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.vendorMapper.MapModelToDTO(default (int), model);
				var record = await this.vendorRepository.Create(dto);

				response.SetRecord(this.vendorMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiVendorRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.vendorModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				var dto = this.vendorMapper.MapModelToDTO(businessEntityID, model);
				await this.vendorRepository.Update(businessEntityID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.vendorModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.vendorRepository.Delete(businessEntityID);
			}
			return response;
		}

		public async Task<ApiVendorResponseModel> GetAccountNumber(string accountNumber)
		{
			DTOVendor record = await this.vendorRepository.GetAccountNumber(accountNumber);

			return this.vendorMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>790ad7b81a4260a2238f14c37f13aae7</Hash>
</Codenesium>*/