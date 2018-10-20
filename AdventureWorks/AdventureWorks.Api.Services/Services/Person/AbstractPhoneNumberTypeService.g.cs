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
	public abstract class AbstractPhoneNumberTypeService : AbstractService
	{
		protected IPhoneNumberTypeRepository PhoneNumberTypeRepository { get; private set; }

		protected IApiPhoneNumberTypeRequestModelValidator PhoneNumberTypeModelValidator { get; private set; }

		protected IBOLPhoneNumberTypeMapper BolPhoneNumberTypeMapper { get; private set; }

		protected IDALPhoneNumberTypeMapper DalPhoneNumberTypeMapper { get; private set; }

		protected IBOLPersonPhoneMapper BolPersonPhoneMapper { get; private set; }

		protected IDALPersonPhoneMapper DalPersonPhoneMapper { get; private set; }

		private ILogger logger;

		public AbstractPhoneNumberTypeService(
			ILogger logger,
			IPhoneNumberTypeRepository phoneNumberTypeRepository,
			IApiPhoneNumberTypeRequestModelValidator phoneNumberTypeModelValidator,
			IBOLPhoneNumberTypeMapper bolPhoneNumberTypeMapper,
			IDALPhoneNumberTypeMapper dalPhoneNumberTypeMapper,
			IBOLPersonPhoneMapper bolPersonPhoneMapper,
			IDALPersonPhoneMapper dalPersonPhoneMapper)
			: base()
		{
			this.PhoneNumberTypeRepository = phoneNumberTypeRepository;
			this.PhoneNumberTypeModelValidator = phoneNumberTypeModelValidator;
			this.BolPhoneNumberTypeMapper = bolPhoneNumberTypeMapper;
			this.DalPhoneNumberTypeMapper = dalPhoneNumberTypeMapper;
			this.BolPersonPhoneMapper = bolPersonPhoneMapper;
			this.DalPersonPhoneMapper = dalPersonPhoneMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPhoneNumberTypeResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PhoneNumberTypeRepository.All(limit, offset);

			return this.BolPhoneNumberTypeMapper.MapBOToModel(this.DalPhoneNumberTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPhoneNumberTypeResponseModel> Get(int phoneNumberTypeID)
		{
			var record = await this.PhoneNumberTypeRepository.Get(phoneNumberTypeID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPhoneNumberTypeMapper.MapBOToModel(this.DalPhoneNumberTypeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPhoneNumberTypeResponseModel>> Create(
			ApiPhoneNumberTypeRequestModel model)
		{
			CreateResponse<ApiPhoneNumberTypeResponseModel> response = new CreateResponse<ApiPhoneNumberTypeResponseModel>(await this.PhoneNumberTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPhoneNumberTypeMapper.MapModelToBO(default(int), model);
				var record = await this.PhoneNumberTypeRepository.Create(this.DalPhoneNumberTypeMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPhoneNumberTypeMapper.MapBOToModel(this.DalPhoneNumberTypeMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPhoneNumberTypeResponseModel>> Update(
			int phoneNumberTypeID,
			ApiPhoneNumberTypeRequestModel model)
		{
			var validationResult = await this.PhoneNumberTypeModelValidator.ValidateUpdateAsync(phoneNumberTypeID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPhoneNumberTypeMapper.MapModelToBO(phoneNumberTypeID, model);
				await this.PhoneNumberTypeRepository.Update(this.DalPhoneNumberTypeMapper.MapBOToEF(bo));

				var record = await this.PhoneNumberTypeRepository.Get(phoneNumberTypeID);

				return new UpdateResponse<ApiPhoneNumberTypeResponseModel>(this.BolPhoneNumberTypeMapper.MapBOToModel(this.DalPhoneNumberTypeMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPhoneNumberTypeResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int phoneNumberTypeID)
		{
			ActionResponse response = new ActionResponse(await this.PhoneNumberTypeModelValidator.ValidateDeleteAsync(phoneNumberTypeID));
			if (response.Success)
			{
				await this.PhoneNumberTypeRepository.Delete(phoneNumberTypeID);
			}

			return response;
		}

		public async virtual Task<List<ApiPersonPhoneResponseModel>> PersonPhonesByPhoneNumberTypeID(int phoneNumberTypeID, int limit = int.MaxValue, int offset = 0)
		{
			List<PersonPhone> records = await this.PhoneNumberTypeRepository.PersonPhonesByPhoneNumberTypeID(phoneNumberTypeID, limit, offset);

			return this.BolPersonPhoneMapper.MapBOToModel(this.DalPersonPhoneMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>c7faaa2d1082739502c1431fb44aa58b</Hash>
</Codenesium>*/