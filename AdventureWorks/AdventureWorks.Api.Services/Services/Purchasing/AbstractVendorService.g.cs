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
	public abstract class AbstractVendorService: AbstractService
	{
		private IVendorRepository vendorRepository;
		private IApiVendorRequestModelValidator vendorModelValidator;
		private IBOLVendorMapper BOLVendorMapper;
		private IDALVendorMapper DALVendorMapper;
		private ILogger logger;

		public AbstractVendorService(
			ILogger logger,
			IVendorRepository vendorRepository,
			IApiVendorRequestModelValidator vendorModelValidator,
			IBOLVendorMapper bolvendorMapper,
			IDALVendorMapper dalvendorMapper)
			: base()

		{
			this.vendorRepository = vendorRepository;
			this.vendorModelValidator = vendorModelValidator;
			this.BOLVendorMapper = bolvendorMapper;
			this.DALVendorMapper = dalvendorMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiVendorResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.vendorRepository.All(skip, take, orderClause);

			return this.BOLVendorMapper.MapBOToModel(this.DALVendorMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiVendorResponseModel> Get(int businessEntityID)
		{
			var record = await vendorRepository.Get(businessEntityID);

			return this.BOLVendorMapper.MapBOToModel(this.DALVendorMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiVendorResponseModel>> Create(
			ApiVendorRequestModel model)
		{
			CreateResponse<ApiVendorResponseModel> response = new CreateResponse<ApiVendorResponseModel>(await this.vendorModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLVendorMapper.MapModelToBO(default (int), model);
				var record = await this.vendorRepository.Create(this.DALVendorMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLVendorMapper.MapBOToModel(this.DALVendorMapper.MapEFToBO(record)));
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
				var bo = this.BOLVendorMapper.MapModelToBO(businessEntityID, model);
				await this.vendorRepository.Update(this.DALVendorMapper.MapBOToEF(bo));
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
			Vendor record = await this.vendorRepository.GetAccountNumber(accountNumber);

			return this.BOLVendorMapper.MapBOToModel(this.DALVendorMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>ae24b7b6364adc650b6a0f09c00ef52f</Hash>
</Codenesium>*/