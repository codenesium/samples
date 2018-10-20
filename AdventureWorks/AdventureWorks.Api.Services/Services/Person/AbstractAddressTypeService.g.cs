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
	public abstract class AbstractAddressTypeService : AbstractService
	{
		protected IAddressTypeRepository AddressTypeRepository { get; private set; }

		protected IApiAddressTypeRequestModelValidator AddressTypeModelValidator { get; private set; }

		protected IBOLAddressTypeMapper BolAddressTypeMapper { get; private set; }

		protected IDALAddressTypeMapper DalAddressTypeMapper { get; private set; }

		protected IBOLBusinessEntityAddressMapper BolBusinessEntityAddressMapper { get; private set; }

		protected IDALBusinessEntityAddressMapper DalBusinessEntityAddressMapper { get; private set; }

		private ILogger logger;

		public AbstractAddressTypeService(
			ILogger logger,
			IAddressTypeRepository addressTypeRepository,
			IApiAddressTypeRequestModelValidator addressTypeModelValidator,
			IBOLAddressTypeMapper bolAddressTypeMapper,
			IDALAddressTypeMapper dalAddressTypeMapper,
			IBOLBusinessEntityAddressMapper bolBusinessEntityAddressMapper,
			IDALBusinessEntityAddressMapper dalBusinessEntityAddressMapper)
			: base()
		{
			this.AddressTypeRepository = addressTypeRepository;
			this.AddressTypeModelValidator = addressTypeModelValidator;
			this.BolAddressTypeMapper = bolAddressTypeMapper;
			this.DalAddressTypeMapper = dalAddressTypeMapper;
			this.BolBusinessEntityAddressMapper = bolBusinessEntityAddressMapper;
			this.DalBusinessEntityAddressMapper = dalBusinessEntityAddressMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiAddressTypeResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.AddressTypeRepository.All(limit, offset);

			return this.BolAddressTypeMapper.MapBOToModel(this.DalAddressTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiAddressTypeResponseModel> Get(int addressTypeID)
		{
			var record = await this.AddressTypeRepository.Get(addressTypeID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolAddressTypeMapper.MapBOToModel(this.DalAddressTypeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiAddressTypeResponseModel>> Create(
			ApiAddressTypeRequestModel model)
		{
			CreateResponse<ApiAddressTypeResponseModel> response = new CreateResponse<ApiAddressTypeResponseModel>(await this.AddressTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolAddressTypeMapper.MapModelToBO(default(int), model);
				var record = await this.AddressTypeRepository.Create(this.DalAddressTypeMapper.MapBOToEF(bo));

				response.SetRecord(this.BolAddressTypeMapper.MapBOToModel(this.DalAddressTypeMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiAddressTypeResponseModel>> Update(
			int addressTypeID,
			ApiAddressTypeRequestModel model)
		{
			var validationResult = await this.AddressTypeModelValidator.ValidateUpdateAsync(addressTypeID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolAddressTypeMapper.MapModelToBO(addressTypeID, model);
				await this.AddressTypeRepository.Update(this.DalAddressTypeMapper.MapBOToEF(bo));

				var record = await this.AddressTypeRepository.Get(addressTypeID);

				return new UpdateResponse<ApiAddressTypeResponseModel>(this.BolAddressTypeMapper.MapBOToModel(this.DalAddressTypeMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiAddressTypeResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int addressTypeID)
		{
			ActionResponse response = new ActionResponse(await this.AddressTypeModelValidator.ValidateDeleteAsync(addressTypeID));
			if (response.Success)
			{
				await this.AddressTypeRepository.Delete(addressTypeID);
			}

			return response;
		}

		public async Task<ApiAddressTypeResponseModel> ByName(string name)
		{
			AddressType record = await this.AddressTypeRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolAddressTypeMapper.MapBOToModel(this.DalAddressTypeMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddressesByAddressTypeID(int addressTypeID, int limit = int.MaxValue, int offset = 0)
		{
			List<BusinessEntityAddress> records = await this.AddressTypeRepository.BusinessEntityAddressesByAddressTypeID(addressTypeID, limit, offset);

			return this.BolBusinessEntityAddressMapper.MapBOToModel(this.DalBusinessEntityAddressMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>9822eb0966a07d3e71a62ec542a4b71c</Hash>
</Codenesium>*/