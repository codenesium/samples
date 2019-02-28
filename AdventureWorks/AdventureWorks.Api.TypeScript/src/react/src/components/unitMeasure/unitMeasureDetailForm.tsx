import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import UnitMeasureMapper from './unitMeasureMapper';
import UnitMeasureViewModel from './unitMeasureViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {BillOfMaterialTableComponent} from '../shared/billOfMaterialTable'
	import {ProductTableComponent} from '../shared/productTable'
	



interface UnitMeasureDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface UnitMeasureDetailComponentState {
  model?: UnitMeasureViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class UnitMeasureDetailComponent extends React.Component<
UnitMeasureDetailComponentProps,
UnitMeasureDetailComponentState
> {
  state = {
    model: new UnitMeasureViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.UnitMeasures + '/edit/' + this.state.model!.unitMeasureCode);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.UnitMeasures +
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
          let response = resp.data as Api.UnitMeasureClientResponseModel;

          console.log(response);

          let mapper = new UnitMeasureMapper();

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
							<h3>UnitMeasureCode</h3>
							<p>{String(this.state.model!.unitMeasureCode)}</p>
						 </div>
					   		  </div>
          {message}
		 <div>
            <h3>BillOfMaterials</h3>
            <BillOfMaterialTableComponent 
			billOfMaterialsID={this.state.model!.billOfMaterialsID} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.UnitMeasures + '/' + this.state.model!.unitMeasureCode + '/' + ApiRoutes.BillOfMaterials}
			/>
         </div>
			 <div>
            <h3>Products</h3>
            <ProductTableComponent 
			productID={this.state.model!.productID} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.UnitMeasures + '/' + this.state.model!.unitMeasureCode + '/' + ApiRoutes.Products}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedUnitMeasureDetailComponent = Form.create({ name: 'UnitMeasure Detail' })(
  UnitMeasureDetailComponent
);

/*<Codenesium>
    <Hash>455e03a17ebc708b65b0c114655d7361</Hash>
</Codenesium>*/