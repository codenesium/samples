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
	public abstract class AbstractContactTypeService : AbstractService
	{
		protected IContactTypeRepository ContactTypeRepository { get; private set; }

		protected IApiContactTypeRequestModelValidator ContactTypeModelValidator { get; private set; }

		protected IBOLContactTypeMapper BolContactTypeMapper { get; private set; }

		protected IDALContactTypeMapper DalContactTypeMapper { get; private set; }

		protected IBOLBusinessEntityContactMapper BolBusinessEntityContactMapper { get; private set; }

		protected IDALBusinessEntityContactMapper DalBusinessEntityContactMapper { get; private set; }

		private ILogger logger;

		public AbstractContactTypeService(
			ILogger logger,
			IContactTypeRepository contactTypeRepository,
			IApiContactTypeRequestModelValidator contactTypeModelValidator,
			IBOLContactTypeMapper bolContactTypeMapper,
			IDALContactTypeMapper dalContactTypeMapper,
			IBOLBusinessEntityContactMapper bolBusinessEntityContactMapper,
			IDALBusinessEntityContactMapper dalBusinessEntityContactMapper)
			: base()
		{
			this.ContactTypeRepository = contactTypeRepository;
			this.ContactTypeModelValidator = contactTypeModelValidator;
			this.BolContactTypeMapper = bolContactTypeMapper;
			this.DalContactTypeMapper = dalContactTypeMapper;
			this.BolBusinessEntityContactMapper = bolBusinessEntityContactMapper;
			this.DalBusinessEntityContactMapper = dalBusinessEntityContactMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiContactTypeResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ContactTypeRepository.All(limit, offset);

			return this.BolContactTypeMapper.MapBOToModel(this.DalContactTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiContactTypeResponseModel> Get(int contactTypeID)
		{
			var record = await this.ContactTypeRepository.Get(contactTypeID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolContactTypeMapper.MapBOToModel(this.DalContactTypeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiContactTypeResponseModel>> Create(
			ApiContactTypeRequestModel model)
		{
			CreateResponse<ApiContactTypeResponseModel> response = new CreateResponse<ApiContactTypeResponseModel>(await this.ContactTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolContactTypeMapper.MapModelToBO(default(int), model);
				var record = await this.ContactTypeRepository.Create(this.DalContactTypeMapper.MapBOToEF(bo));

				response.SetRecord(this.BolContactTypeMapper.MapBOToModel(this.DalContactTypeMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiContactTypeResponseModel>> Update(
			int contactTypeID,
			ApiContactTypeRequestModel model)
		{
			var validationResult = await this.ContactTypeModelValidator.ValidateUpdateAsync(contactTypeID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolContactTypeMapper.MapModelToBO(contactTypeID, model);
				await this.ContactTypeRepository.Update(this.DalContactTypeMapper.MapBOToEF(bo));

				var record = await this.ContactTypeRepository.Get(contactTypeID);

				return new UpdateResponse<ApiContactTypeResponseModel>(this.BolContactTypeMapper.MapBOToModel(this.DalContactTypeMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiContactTypeResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int contactTypeID)
		{
			ActionResponse response = new ActionResponse(await this.ContactTypeModelValidator.ValidateDeleteAsync(contactTypeID));
			if (response.Success)
			{
				await this.ContactTypeRepository.Delete(contactTypeID);
			}

			return response;
		}

		public async Task<ApiContactTypeResponseModel> ByName(string name)
		{
			ContactType record = await this.ContactTypeRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolContactTypeMapper.MapBOToModel(this.DalContactTypeMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContacts(int contactTypeID, int limit = int.MaxValue, int offset = 0)
		{
			List<BusinessEntityContact> records = await this.ContactTypeRepository.BusinessEntityContacts(contactTypeID, limit, offset);

			return this.BolBusinessEntityContactMapper.MapBOToModel(this.DalBusinessEntityContactMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>6b34439ca0c3e7bc58ad100017aaf9ab</Hash>
</Codenesium>*/