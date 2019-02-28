import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductMapper from './productMapper';
import ProductViewModel from './productViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {BillOfMaterialTableComponent} from '../shared/billOfMaterialTable'
	import {ProductCostHistoryTableComponent} from '../shared/productCostHistoryTable'
	import {ProductInventoryTableComponent} from '../shared/productInventoryTable'
	import {ProductListPriceHistoryTableComponent} from '../shared/productListPriceHistoryTable'
	import {ProductProductPhotoTableComponent} from '../shared/productProductPhotoTable'
	import {ProductReviewTableComponent} from '../shared/productReviewTable'
	import {TransactionHistoryTableComponent} from '../shared/transactionHistoryTable'
	import {WorkOrderTableComponent} from '../shared/workOrderTable'
	



interface ProductDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ProductDetailComponentState {
  model?: ProductViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ProductDetailComponent extends React.Component<
ProductDetailComponentProps,
ProductDetailComponentState
> {
  state = {
    model: new ProductViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Products + '/edit/' + this.state.model!.productID);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Products +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.ProductClientResponseModel;

          console.log(response);

          let mapper = new ProductMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    } 
  
    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
		<Button 
			style={{'float':'right'}}
			type="primary" 
			onClick={(e:any) => {
				this.handleEditClick(e)
				}}
			>
             <i className="fas fa-edit" />
		  </Button>
		  <div>
									 <div>
							<h3>Color</h3>
							<p>{String(this.state.model!.color)}</p>
						 </div>
					   						 <div>
							<h3>DaysToManufacture</h3>
							<p>{String(this.state.model!.daysToManufacture)}</p>
						 </div>
					   						 <div>
							<h3>DiscontinuedDate</h3>
							<p>{String(this.state.model!.discontinuedDate)}</p>
						 </div>
					   						 <div>
							<h3>FinishedGoodsFlag</h3>
							<p>{String(this.state.model!.finishedGoodsFlag)}</p>
						 </div>
					   						 <div>
							<h3>ListPrice</h3>
							<p>{String(this.state.model!.listPrice)}</p>
						 </div>
					   						 <div>
							<h3>MakeFlag</h3>
							<p>{String(this.state.model!.makeFlag)}</p>
						 </div>
					   						 <div>
							<h3>ModifiedDate</h3>
							<p>{String(this.state.model!.modifiedDate)}</p>
						 </div>
					   						 <div>
							<h3>Name</h3>
							<p>{String(this.state.model!.name)}</p>
						 </div>
					   						 <div>
							<h3>ProductID</h3>
							<p>{String(this.state.model!.productID)}</p>
						 </div>
					   						 <div>
							<h3>ProductLine</h3>
							<p>{String(this.state.model!.productLine)}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>ProductModelID</h3>
							<p>{String(this.state.model!.productModelIDNavigation!.toDisplay())}</p>
						 </div>
					   						 <div>
							<h3>ProductNumber</h3>
							<p>{String(this.state.model!.productNumber)}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>ProductSubcategoryID</h3>
							<p>{String(this.state.model!.productSubcategoryIDNavigation!.toDisplay())}</p>
						 </div>
					   						 <div>
							<h3>ReorderPoint</h3>
							<p>{String(this.state.model!.reorderPoint)}</p>
						 </div>
					   						 <div>
							<h3>rowguid</h3>
							<p>{String(this.state.model!.rowguid)}</p>
						 </div>
					   						 <div>
							<h3>SafetyStockLevel</h3>
							<p>{String(this.state.model!.safetyStockLevel)}</p>
						 </div>
					   						 <div>
							<h3>SellEndDate</h3>
							<p>{String(this.state.model!.sellEndDate)}</p>
						 </div>
					   						 <div>
							<h3>SellStartDate</h3>
							<p>{String(this.state.model!.sellStartDate)}</p>
						 </div>
					   						 <div>
							<h3>Size</h3>
							<p>{String(this.state.model!.size)}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>SizeUnitMeasureCode</h3>
							<p>{String(this.state.model!.sizeUnitMeasureCodeNavigation!.toDisplay())}</p>
						 </div>
					   						 <div>
							<h3>StandardCost</h3>
							<p>{String(this.state.model!.standardCost)}</p>
						 </div>
					   						 <div>
							<h3>Style</h3>
							<p>{String(this.state.model!.style)}</p>
						 </div>
					   						 <div>
							<h3>Weight</h3>
							<p>{String(this.state.model!.weight)}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>WeightUnitMeasureCode</h3>
							<p>{String(this.state.model!.weightUnitMeasureCodeNavigation!.toDisplay())}</p>
						 </div>
					   		  </div>
          {message}
		 <div>
            <h3>BillOfMaterials</h3>
            <BillOfMaterialTableComponent 
			billOfMaterialsID={this.state.model!.billOfMaterialsID} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Products + '/' + this.state.model!.productID + '/' + ApiRoutes.BillOfMaterials}
			/>
         </div>
			 <div>
            <h3>ProductCostHistories</h3>
            <ProductCostHistoryTableComponent 
			productID={this.state.model!.productID} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Products + '/' + this.state.model!.productID + '/' + ApiRoutes.ProductCostHistories}
			/>
         </div>
			 <div>
            <h3>ProductInventories</h3>
            <ProductInventoryTableComponent 
			productID={this.state.model!.productID} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Products + '/' + this.state.model!.productID + '/' + ApiRoutes.ProductInventories}
			/>
         </div>
			 <div>
            <h3>ProductListPriceHistories</h3>
            <ProductListPriceHistoryTableComponent 
			productID={this.state.model!.productID} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Products + '/' + this.state.model!.productID + '/' + ApiRoutes.ProductListPriceHistories}
			/>
         </div>
			 <div>
            <h3>ProductProductPhotoes</h3>
            <ProductProductPhotoTableComponent 
			productID={this.state.model!.productID} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Products + '/' + this.state.model!.productID + '/' + ApiRoutes.ProductProductPhotoes}
			/>
         </div>
			 <div>
            <h3>ProductReviews</h3>
            <ProductReviewTableComponent 
			productReviewID={this.state.model!.productReviewID} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Products + '/' + this.state.model!.productID + '/' + ApiRoutes.ProductReviews}
			/>
         </div>
			 <div>
            <h3>TransactionHistories</h3>
            <TransactionHistoryTableComponent 
			transactionID={this.state.model!.transactionID} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Products + '/' + this.state.model!.productID + '/' + ApiRoutes.TransactionHistories}
			/>
         </div>
			 <div>
            <h3>WorkOrders</h3>
            <WorkOrderTableComponent 
			workOrderID={this.state.model!.workOrderID} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Products + '/' + this.state.model!.productID + '/' + ApiRoutes.WorkOrders}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedProductDetailComponent = Form.create({ name: 'Product Detail' })(
  ProductDetailComponent
);

/*<Codenesium>
    <Hash>456830dfcfa0147be71b0e5176b588c1</Hash>
</Codenesium>*/