using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOProductPhoto: AbstractBOProductPhoto, IBOProductPhoto
	{
		public BOProductPhoto(
			ILogger<ProductPhotoRepository> logger,
			IProductPhotoRepository productPhotoRepository,
			IApiProductPhotoModelValidator productPhotoModelValidator)
			: base(logger, productPhotoRepository, productPhotoModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>88f0cd6b7d2dd849c2dd51fc76e6f56b</Hash>
</Codenesium>*/