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
	public abstract class AbstractBusinessEntityAddressService: AbstractService
	{
		private IBusinessEntityAddressRepository businessEntityAddressRepository;
		private IApiBusinessEntityAddressRequestModelValidator businessEntityAddressModelValidator;
		private IBOLBusinessEntityAddressMapper BOLBusinessEntityAddressMapper;
		private IDALBusinessEntityAddressMapper DALBusinessEntityAddressMapper;
		private ILogger logger;

		public AbstractBusinessEntityAddressService(
			ILogger logger,
			IBusinessEntityAddressRepository businessEntityAddressRepository,
			IApiBusinessEntityAddressRequestModelValidator businessEntityAddressModelValidator,
			IBOLBusinessEntityAddressMapper bolbusinessEntityAddressMapper,
			IDALBusinessEntityAddressMapper dalbusinessEntityAddressMapper)
			: base()

		{
			this.businessEntityAddressRepository = businessEntityAddressRepository;
			this.businessEntityAddressModelValidator = businessEntityAddressModelValidator;
			this.BOLBusinessEntityAddressMapper = bolbusinessEntityAddressMapper;
			this.DALBusinessEntityAddressMapper = dalbusinessEntityAddressMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBusinessEntityAddressResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.businessEntityAddressRepository.All(skip, take, orderClause);

			return this.BOLBusinessEntityAddressMapper.MapBOToModel(this.DALBusinessEntityAddressMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiBusinessEntityAddressResponseModel> Get(int businessEntityID)
		{
			var record = await businessEntityAddressRepository.Get(businessEntityID);

			return this.BOLBusinessEntityAddressMapper.MapBOToModel(this.DALBusinessEntityAddressMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiBusinessEntityAddressResponseModel>> Create(
			ApiBusinessEntityAddressRequestModel model)
		{
			CreateResponse<ApiBusinessEntityAddressResponseModel> response = new CreateResponse<ApiBusinessEntityAddressResponseModel>(await this.businessEntityAddressModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLBusinessEntityAddressMapper.MapModelToBO(default (int), model);
				var record = await this.businessEntityAddressRepository.Create(this.DALBusinessEntityAddressMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLBusinessEntityAddressMapper.MapBOToModel(this.DALBusinessEntityAddressMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiBusinessEntityAddressRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.businessEntityAddressModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				var bo = this.BOLBusinessEntityAddressMapper.MapModelToBO(businessEntityID, model);
				await this.businessEntityAddressRepository.Update(this.DALBusinessEntityAddressMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.businessEntityAddressModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.businessEntityAddressRepository.Delete(businessEntityID);
			}
			return response;
		}

		public async Task<List<ApiBusinessEntityAddressResponseModel>> GetAddressID(int addressID)
		{
			List<BusinessEntityAddress> records = await this.businessEntityAddressRepository.GetAddressID(addressID);

			return this.BOLBusinessEntityAddressMapper.MapBOToModel(this.DALBusinessEntityAddressMapper.MapEFToBO(records));
		}
		public async Task<List<ApiBusinessEntityAddressResponseModel>> GetAddressTypeID(int addressTypeID)
		{
			List<BusinessEntityAddress> records = await this.businessEntityAddressRepository.GetAddressTypeID(addressTypeID);

			return this.BOLBusinessEntityAddressMapper.MapBOToModel(this.DALBusinessEntityAddressMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>594d3af78b961f7b935eb0c7a2d74cf8</Hash>
</Codenesium>*/