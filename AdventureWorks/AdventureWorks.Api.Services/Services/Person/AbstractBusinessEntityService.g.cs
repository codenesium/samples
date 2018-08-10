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
		protected IBusinessEntityRepository BusinessEntityRepository { get; private set; }

		protected IApiBusinessEntityRequestModelValidator BusinessEntityModelValidator { get; private set; }

		protected IBOLBusinessEntityMapper BolBusinessEntityMapper { get; private set; }

		protected IDALBusinessEntityMapper DalBusinessEntityMapper { get; private set; }

		protected IBOLBusinessEntityAddressMapper BolBusinessEntityAddressMapper { get; private set; }

		protected IDALBusinessEntityAddressMapper DalBusinessEntityAddressMapper { get; private set; }
		protected IBOLBusinessEntityContactMapper BolBusinessEntityContactMapper { get; private set; }

		protected IDALBusinessEntityContactMapper DalBusinessEntityContactMapper { get; private set; }
		protected IBOLPersonMapper BolPersonMapper { get; private set; }

		protected IDALPersonMapper DalPersonMapper { get; private set; }

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
			this.BusinessEntityRepository = businessEntityRepository;
			this.BusinessEntityModelValidator = businessEntityModelValidator;
			this.BolBusinessEntityMapper = bolBusinessEntityMapper;
			this.DalBusinessEntityMapper = dalBusinessEntityMapper;
			this.BolBusinessEntityAddressMapper = bolBusinessEntityAddressMapper;
			this.DalBusinessEntityAddressMapper = dalBusinessEntityAddressMapper;
			this.BolBusinessEntityContactMapper = bolBusinessEntityContactMapper;
			this.DalBusinessEntityContactMapper = dalBusinessEntityContactMapper;
			this.BolPersonMapper = bolPersonMapper;
			this.DalPersonMapper = dalPersonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBusinessEntityResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.BusinessEntityRepository.All(limit, offset);

			return this.BolBusinessEntityMapper.MapBOToModel(this.DalBusinessEntityMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiBusinessEntityResponseModel> Get(int businessEntityID)
		{
			var record = await this.BusinessEntityRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolBusinessEntityMapper.MapBOToModel(this.DalBusinessEntityMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiBusinessEntityResponseModel>> Create(
			ApiBusinessEntityRequestModel model)
		{
			CreateResponse<ApiBusinessEntityResponseModel> response = new CreateResponse<ApiBusinessEntityResponseModel>(await this.BusinessEntityModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolBusinessEntityMapper.MapModelToBO(default(int), model);
				var record = await this.BusinessEntityRepository.Create(this.DalBusinessEntityMapper.MapBOToEF(bo));

				response.SetRecord(this.BolBusinessEntityMapper.MapBOToModel(this.DalBusinessEntityMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiBusinessEntityResponseModel>> Update(
			int businessEntityID,
			ApiBusinessEntityRequestModel model)
		{
			var validationResult = await this.BusinessEntityModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolBusinessEntityMapper.MapModelToBO(businessEntityID, model);
				await this.BusinessEntityRepository.Update(this.DalBusinessEntityMapper.MapBOToEF(bo));

				var record = await this.BusinessEntityRepository.Get(businessEntityID);

				return new UpdateResponse<ApiBusinessEntityResponseModel>(this.BolBusinessEntityMapper.MapBOToModel(this.DalBusinessEntityMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiBusinessEntityResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.BusinessEntityModelValidator.ValidateDeleteAsync(businessEntityID));
			if (response.Success)
			{
				await this.BusinessEntityRepository.Delete(businessEntityID);
			}

			return response;
		}

		public async virtual Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddresses(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			List<BusinessEntityAddress> records = await this.BusinessEntityRepository.BusinessEntityAddresses(businessEntityID, limit, offset);

			return this.BolBusinessEntityAddressMapper.MapBOToModel(this.DalBusinessEntityAddressMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContacts(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			List<BusinessEntityContact> records = await this.BusinessEntityRepository.BusinessEntityContacts(businessEntityID, limit, offset);

			return this.BolBusinessEntityContactMapper.MapBOToModel(this.DalBusinessEntityContactMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPersonResponseModel>> People(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			List<Person> records = await this.BusinessEntityRepository.People(businessEntityID, limit, offset);

			return this.BolPersonMapper.MapBOToModel(this.DalPersonMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>8ec8944057936235ea04908890b081c9</Hash>
</Codenesium>*/