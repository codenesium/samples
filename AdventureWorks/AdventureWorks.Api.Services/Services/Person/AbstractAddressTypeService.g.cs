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
	public abstract class AbstractAddressTypeService: AbstractService
	{
		private IAddressTypeRepository addressTypeRepository;
		private IApiAddressTypeRequestModelValidator addressTypeModelValidator;
		private IBOLAddressTypeMapper bolAddressTypeMapper;
		private IDALAddressTypeMapper dalAddressTypeMapper;
		private ILogger logger;

		public AbstractAddressTypeService(
			ILogger logger,
			IAddressTypeRepository addressTypeRepository,
			IApiAddressTypeRequestModelValidator addressTypeModelValidator,
			IBOLAddressTypeMapper boladdressTypeMapper,
			IDALAddressTypeMapper daladdressTypeMapper)
			: base()

		{
			this.addressTypeRepository = addressTypeRepository;
			this.addressTypeModelValidator = addressTypeModelValidator;
			this.bolAddressTypeMapper = boladdressTypeMapper;
			this.dalAddressTypeMapper = daladdressTypeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiAddressTypeResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.addressTypeRepository.All(skip, take, orderClause);

			return this.bolAddressTypeMapper.MapBOToModel(this.dalAddressTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiAddressTypeResponseModel> Get(int addressTypeID)
		{
			var record = await addressTypeRepository.Get(addressTypeID);

			return this.bolAddressTypeMapper.MapBOToModel(this.dalAddressTypeMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiAddressTypeResponseModel>> Create(
			ApiAddressTypeRequestModel model)
		{
			CreateResponse<ApiAddressTypeResponseModel> response = new CreateResponse<ApiAddressTypeResponseModel>(await this.addressTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolAddressTypeMapper.MapModelToBO(default (int), model);
				var record = await this.addressTypeRepository.Create(this.dalAddressTypeMapper.MapBOToEF(bo));

				response.SetRecord(this.bolAddressTypeMapper.MapBOToModel(this.dalAddressTypeMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int addressTypeID,
			ApiAddressTypeRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.addressTypeModelValidator.ValidateUpdateAsync(addressTypeID, model));

			if (response.Success)
			{
				var bo = this.bolAddressTypeMapper.MapModelToBO(addressTypeID, model);
				await this.addressTypeRepository.Update(this.dalAddressTypeMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int addressTypeID)
		{
			ActionResponse response = new ActionResponse(await this.addressTypeModelValidator.ValidateDeleteAsync(addressTypeID));

			if (response.Success)
			{
				await this.addressTypeRepository.Delete(addressTypeID);
			}
			return response;
		}

		public async Task<ApiAddressTypeResponseModel> GetName(string name)
		{
			AddressType record = await this.addressTypeRepository.GetName(name);

			return this.bolAddressTypeMapper.MapBOToModel(this.dalAddressTypeMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>35519736a048bde26b5736cda951bb82</Hash>
</Codenesium>*/