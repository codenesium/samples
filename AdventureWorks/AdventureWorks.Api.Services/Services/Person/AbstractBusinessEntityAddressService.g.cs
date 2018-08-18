using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBusinessEntityAddressService : AbstractService
	{
		protected IBusinessEntityAddressRepository BusinessEntityAddressRepository { get; private set; }

		protected IApiBusinessEntityAddressRequestModelValidator BusinessEntityAddressModelValidator { get; private set; }

		protected IBOLBusinessEntityAddressMapper BolBusinessEntityAddressMapper { get; private set; }

		protected IDALBusinessEntityAddressMapper DalBusinessEntityAddressMapper { get; private set; }

		private ILogger logger;

		public AbstractBusinessEntityAddressService(
			ILogger logger,
			IBusinessEntityAddressRepository businessEntityAddressRepository,
			IApiBusinessEntityAddressRequestModelValidator businessEntityAddressModelValidator,
			IBOLBusinessEntityAddressMapper bolBusinessEntityAddressMapper,
			IDALBusinessEntityAddressMapper dalBusinessEntityAddressMapper)
			: base()
		{
			this.BusinessEntityAddressRepository = businessEntityAddressRepository;
			this.BusinessEntityAddressModelValidator = businessEntityAddressModelValidator;
			this.BolBusinessEntityAddressMapper = bolBusinessEntityAddressMapper;
			this.DalBusinessEntityAddressMapper = dalBusinessEntityAddressMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBusinessEntityAddressResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.BusinessEntityAddressRepository.All(limit, offset);

			return this.BolBusinessEntityAddressMapper.MapBOToModel(this.DalBusinessEntityAddressMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiBusinessEntityAddressResponseModel> Get(int businessEntityID)
		{
			var record = await this.BusinessEntityAddressRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolBusinessEntityAddressMapper.MapBOToModel(this.DalBusinessEntityAddressMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiBusinessEntityAddressResponseModel>> Create(
			ApiBusinessEntityAddressRequestModel model)
		{
			CreateResponse<ApiBusinessEntityAddressResponseModel> response = new CreateResponse<ApiBusinessEntityAddressResponseModel>(await this.BusinessEntityAddressModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolBusinessEntityAddressMapper.MapModelToBO(default(int), model);
				var record = await this.BusinessEntityAddressRepository.Create(this.DalBusinessEntityAddressMapper.MapBOToEF(bo));

				response.SetRecord(this.BolBusinessEntityAddressMapper.MapBOToModel(this.DalBusinessEntityAddressMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiBusinessEntityAddressResponseModel>> Update(
			int businessEntityID,
			ApiBusinessEntityAddressRequestModel model)
		{
			var validationResult = await this.BusinessEntityAddressModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolBusinessEntityAddressMapper.MapModelToBO(businessEntityID, model);
				await this.BusinessEntityAddressRepository.Update(this.DalBusinessEntityAddressMapper.MapBOToEF(bo));

				var record = await this.BusinessEntityAddressRepository.Get(businessEntityID);

				return new UpdateResponse<ApiBusinessEntityAddressResponseModel>(this.BolBusinessEntityAddressMapper.MapBOToModel(this.DalBusinessEntityAddressMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiBusinessEntityAddressResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.BusinessEntityAddressModelValidator.ValidateDeleteAsync(businessEntityID));
			if (response.Success)
			{
				await this.BusinessEntityAddressRepository.Delete(businessEntityID);
			}

			return response;
		}

		public async Task<List<ApiBusinessEntityAddressResponseModel>> ByAddressID(int addressID, int limit = 0, int offset = int.MaxValue)
		{
			List<BusinessEntityAddress> records = await this.BusinessEntityAddressRepository.ByAddressID(addressID, limit, offset);

			return this.BolBusinessEntityAddressMapper.MapBOToModel(this.DalBusinessEntityAddressMapper.MapEFToBO(records));
		}

		public async Task<List<ApiBusinessEntityAddressResponseModel>> ByAddressTypeID(int addressTypeID, int limit = 0, int offset = int.MaxValue)
		{
			List<BusinessEntityAddress> records = await this.BusinessEntityAddressRepository.ByAddressTypeID(addressTypeID, limit, offset);

			return this.BolBusinessEntityAddressMapper.MapBOToModel(this.DalBusinessEntityAddressMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>808946b89eee2a5cd68ef929ca70342e</Hash>
</Codenesium>*/