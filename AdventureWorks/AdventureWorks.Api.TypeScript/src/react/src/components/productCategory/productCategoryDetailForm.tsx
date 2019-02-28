import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductCategoryMapper from './productCategoryMapper';
import ProductCategoryViewModel from './productCategoryViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {ProductSubcategoryTableComponent} from '../shared/productSubcategoryTable'
	



interface ProductCategoryDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ProductCategoryDetailComponentState {
  model?: ProductCategoryViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ProductCategoryDetailComponent extends React.Component<
ProductCategoryDetailComponentProps,
ProductCategoryDetailComponentState
> {
  state = {
    model: new ProductCategoryViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.ProductCategories + '/edit/' + this.state.model!.productCategoryID);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.ProductCategories +
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
          let response = resp.data as Api.ProductCategoryClientResponseModel;

          console.log(response);

          let mapper = new ProductCategoryMapper();

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
							<h3>ModifiedDate</h3>
							<p>{String(this.state.model!.modifiedDate)}</p>
						 </div>
					   						 <div>
							<h3>Name</h3>
							<p>{String(this.state.model!.name)}</p>
						 </div>
					   						 <div>
							<h3>ProductCategoryID</h3>
							<p>{String(this.state.model!.productCategoryID)}</p>
						 </div>
					   						 <div>
							<h3>rowguid</h3>
							<p>{String(this.state.model!.rowguid)}</p>
						 </div>
					   		  </div>
          {message}
		 <div>
            <h3>ProductSubcategories</h3>
            <ProductSubcategoryTableComponent 
			productSubcategoryID={this.state.model!.productSubcategoryID} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.ProductCategories + '/' + this.state.model!.productCategoryID + '/' + ApiRoutes.ProductSubcategories}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedProductCategoryDetailComponent = Form.create({ name: 'ProductCategory Detail' })(
  ProductCategoryDetailComponent
);

/*<Codenesium>
    <Hash>39abd6ed5d06b124c547753c37a2fb8c</Hash>
</Codenesium>*/