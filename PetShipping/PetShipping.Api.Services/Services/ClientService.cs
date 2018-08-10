using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial class ClientService : AbstractClientService, IClientService
	{
		public ClientService(
			ILogger<IClientRepository> logger,
			IClientRepository clientRepository,
			IApiClientRequestModelValidator clientModelValidator,
			IBOLClientMapper bolclientMapper,
			IDALClientMapper dalclientMapper,
			IBOLClientCommunicationMapper bolClientCommunicationMapper,
			IDALClientCommunicationMapper dalClientCommunicationMapper,
			IBOLPetMapper bolPetMapper,
			IDALPetMapper dalPetMapper,
			IBOLSaleMapper bolSaleMapper,
			IDALSaleMapper dalSaleMapper
			)
			: base(logger,
			       clientRepository,
			       clientModelValidator,
			       bolclientMapper,
			       dalclientMapper,
			       bolClientCommunicationMapper,
			       dalClientCommunicationMapper,
			       bolPetMapper,
			       dalPetMapper,
			       bolSaleMapper,
			       dalSaleMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>91466ade8369348c3b15a73877760179</Hash>
</Codenesium>*/