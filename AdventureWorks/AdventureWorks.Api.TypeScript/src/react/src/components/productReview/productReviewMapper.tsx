import * as Api from '../../api/models';
import ProductReviewViewModel from  './productReviewViewModel';
	import ProductViewModel from '../product/productViewModel'
	export default class ProductReviewMapper {
    
	mapApiResponseToViewModel(dto: Api.ProductReviewClientResponseModel) : ProductReviewViewModel 
	{
		let response = new ProductReviewViewModel();
		response.setProperties(dto.comment,dto.emailAddress,dto.modifiedDate,dto.productID,dto.productReviewID,dto.rating,dto.reviewDate,dto.reviewerName);
		
						if(dto.productIDNavigation != null)
				{
				  response.productIDNavigation = new ProductViewModel();
				  response.productIDNavigation.setProperties(
				  dto.productIDNavigation.color,dto.productIDNavigation.daysToManufacture,dto.productIDNavigation.discontinuedDate,dto.productIDNavigation.finishedGoodsFlag,dto.productIDNavigation.listPrice,dto.productIDNavigation.makeFlag,dto.productIDNavigation.modifiedDate,dto.productIDNavigation.name,dto.productIDNavigation.productID,dto.productIDNavigation.productLine,dto.productIDNavigation.productModelID,dto.productIDNavigation.productNumber,dto.productIDNavigation.productSubcategoryID,dto.productIDNavigation.reorderPoint,dto.productIDNavigation.rowguid,dto.productIDNavigation.safetyStockLevel,dto.productIDNavigation.sellEndDate,dto.productIDNavigation.sellStartDate,dto.productIDNavigation.size,dto.productIDNavigation.sizeUnitMeasureCode,dto.productIDNavigation.standardCost,dto.productIDNavigation.style,dto.productIDNavigation.weight,dto.productIDNavigation.weightUnitMeasureCode
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: ProductReviewViewModel) : Api.ProductReviewClientRequestModel
	{
		let response = new Api.ProductReviewClientRequestModel();
		response.setProperties(model.comment,model.emailAddress,model.modifiedDate,model.productID,model.productReviewID,model.rating,model.reviewDate,model.reviewerName);
		return response;
	}
};

/*<Codenesium>
    <Hash>9289ba01dbc8a27a0d1283b67ff95b43</Hash>
</Codenesium>*/