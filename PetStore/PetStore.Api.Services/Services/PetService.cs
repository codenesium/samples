using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial class PetService : AbstractPetService, IPetService
	{
		public PetService(
			ILogger<IPetRepository> logger,
			IPetRepository petRepository,
			IApiPetRequestModelValidator petModelValidator,
			IBOLPetMapper bolpetMapper,
			IDALPetMapper dalpetMapper,
			IBOLSaleMapper bolSaleMapper,
			IDALSaleMapper dalSaleMapper)
			: base(logger,
			       petRepository,
			       petModelValidator,
			       bolpetMapper,
			       dalpetMapper,
			       bolSaleMapper,
			       dalSaleMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>cd0ddbcd5573e959179b2cf2b2dac52b</Hash>
</Codenesium>*/