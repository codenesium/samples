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
			IApiProductPhotoRequestModelValidator productPhotoModelValidator,
			IBOLProductPhotoMapper productPhotoMapper)
			: base(logger, productPhotoRepository, productPhotoModelValidator, productPhotoMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>50a78b00a63a48cea75c4614ad8910f6</Hash>
</Codenesium>*/