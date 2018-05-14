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
	public class BOProductProductPhoto: AbstractBOProductProductPhoto, IBOProductProductPhoto
	{
		public BOProductProductPhoto(
			ILogger<ProductProductPhotoRepository> logger,
			IProductProductPhotoRepository productProductPhotoRepository,
			IApiProductProductPhotoModelValidator productProductPhotoModelValidator)
			: base(logger, productProductPhotoRepository, productProductPhotoModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>0f2c6a7422e7aece95f44c386bc5ff7c</Hash>
</Codenesium>*/