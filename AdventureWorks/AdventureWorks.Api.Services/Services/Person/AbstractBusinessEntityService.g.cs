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
	public abstract class AbstractBusinessEntityService : AbstractService
	{
		private IBusinessEntityRepository businessEntityRepository;

		private IApiBusinessEntityRequestModelValidator businessEntityModelValidator;

		private IBOLBusinessEntityMapper bolBusinessEntityMapper;

		private IDALBusinessEntityMapper dalBusinessEntityMapper;

		private IBOLBusinessEntityAddressMapper bolBusinessEntityAddressMapper;

		private IDALBusinessEntityAddressMapper dalBusinessEntityAddressMapper;
		private IBOLBusinessEntityContactMapper bolBusinessEntityContactMapper;

		private IDALBusinessEntityContactMapper dalBusinessEntityContactMapper;
		private IBOLPersonMapper bolPersonMapper;

		private IDALPersonMapper dalPersonMapper;

		private ILogger logger;

		public AbstractBusinessEntityService(
			ILogger logger,
			IBusinessEntityRepository businessEntityRepository,
			IApiBusinessEntityRequestModelValidator businessEntityModelValidator,
			IBOLBusinessEntityMapper bolBusinessEntityMapper,
			IDALBusinessEntityMapper dalBusinessEntityMapper,
			IBOLBusinessEntityAddressMapper bolBusinessEntityAddressMapper,
			IDALBusinessEntityAddressMapper dalBusinessEntityAddressMapper,
			IBOLBusinessEntityContactMapper bolBusinessEntityContactMapper,
			IDALBusinessEntityContactMapper dalBusinessEntityContactMapper,
			IBOLPersonMapper bolPersonMapper,
			IDALPersonMapper dalPersonMapper)
			: base()
		{
			this.businessEntityRepository = businessEntityRepository;
			this.businessEntityModelValidator = businessEntityModelValidator;
			this.bolBusinessEntityMapper = bolBusinessEntityMapper;
			this.dalBusinessEntityMapper = dalBusinessEntityMapper;
			this.bolBusinessEntityAddressMapper = bolBusinessEntityAddressMapper;
			this.dalBusinessEntityAddressMapper = dalBusinessEntityAddressMapper;
			this.bolBusinessEntityContactMapper = bolBusinessEntityContactMapper;
			this.dalBusinessEntityContactMapper = dalBusinessEntityContactMapper;
			this.bolPersonMapper = bolPersonMapper;
			this.dalPersonMapper = dalPersonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBusinessEntityResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.businessEntityRepository.All(limit, offset);

			return this.bolBusinessEntityMapper.MapBOToModel(this.dalBusinessEntityMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiBusinessEntityResponseModel> Get(int businessEntityID)
		{
			var record = await this.businessEntityRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolBusinessEntityMapper.MapBOToModel(this.dalBusinessEntityMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiBusinessEntityResponseModel>> Create(
			ApiBusinessEntityRequestModel model)
		{
			CreateResponse<ApiBusinessEntityResponseModel> response = new CreateResponse<ApiBusinessEntityResponseModel>(await this.businessEntityModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolBusinessEntityMapper.MapModelToBO(default(int), model);
				var record = await this.businessEntityRepository.Create(this.dalBusinessEntityMapper.MapBOToEF(bo));

				response.SetRecord(this.bolBusinessEntityMapper.MapBOToModel(this.dalBusinessEntityMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiBusinessEntityResponseModel>> Update(
			int businessEntityID,
			ApiBusinessEntityRequestModel model)
		{
			var validationResult = await this.businessEntityModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolBusinessEntityMapper.MapModelToBO(businessEntityID, model);
				await this.businessEntityRepository.Update(this.dalBusinessEntityMapper.MapBOToEF(bo));

				var record = await this.businessEntityRepository.Get(businessEntityID);

				return new UpdateResponse<ApiBusinessEntityResponseModel>(this.bolBusinessEntityMapper.MapBOToModel(this.dalBusinessEntityMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiBusinessEntityResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.businessEntityModelValidator.ValidateDeleteAsync(businessEntityID));
			if (response.Success)
			{
				await this.businessEntityRepository.Delete(businessEntityID);
			}

			return response;
		}

		public async virtual Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddresses(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			List<BusinessEntityAddress> records = await this.businessEntityRepository.BusinessEntityAddresses(businessEntityID, limit, offset);

			return this.bolBusinessEntityAddressMapper.MapBOToModel(this.dalBusinessEntityAddressMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContacts(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			List<BusinessEntityContact> records = await this.businessEntityRepository.BusinessEntityContacts(businessEntityID, limit, offset);

			return this.bolBusinessEntityContactMapper.MapBOToModel(this.dalBusinessEntityContactMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPersonResponseModel>> People(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			List<Person> records = await this.businessEntityRepository.People(businessEntityID, limit, offset);

			return this.bolPersonMapper.MapBOToModel(this.dalPersonMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>184b4ceec99b64a1f75707ab7576b9b7</Hash>
</Codenesium>*/