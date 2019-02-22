import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import BillOfMaterialMapper from './billOfMaterialMapper';
import BillOfMaterialViewModel from './billOfMaterialViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';




interface BillOfMaterialDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface BillOfMaterialDetailComponentState {
  model?: BillOfMaterialViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class BillOfMaterialDetailComponent extends React.Component<
BillOfMaterialDetailComponentProps,
BillOfMaterialDetailComponentState
> {
  state = {
    model: new BillOfMaterialViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.BillOfMaterials + '/edit/' + this.state.model!.billOfMaterialsID);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.BillOfMaterials +
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
          let response = resp.data as Api.BillOfMaterialClientResponseModel;

          console.log(response);

          let mapper = new BillOfMaterialMapper();

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
							<h3>BillOfMaterialsID</h3>
							<p>{String(this.state.model!.billOfMaterialsID)}</p>
						 </div>
					   						 <div>
							<h3>BOMLevel</h3>
							<p>{String(this.state.model!.bOMLevel)}</p>
						 </div>
					   						 <div>
							<h3>ComponentID</h3>
							<p>{String(this.state.model!.componentID)}</p>
						 </div>
					   						 <div>
							<h3>EndDate</h3>
							<p>{String(this.state.model!.endDate)}</p>
						 </div>
					   						 <div>
							<h3>ModifiedDate</h3>
							<p>{String(this.state.model!.modifiedDate)}</p>
						 </div>
					   						 <div>
							<h3>PerAssemblyQty</h3>
							<p>{String(this.state.model!.perAssemblyQty)}</p>
						 </div>
					   						 <div>
							<h3>ProductAssemblyID</h3>
							<p>{String(this.state.model!.productAssemblyID)}</p>
						 </div>
					   						 <div>
							<h3>StartDate</h3>
							<p>{String(this.state.model!.startDate)}</p>
						 </div>
					   						 <div>
							<h3>UnitMeasureCode</h3>
							<p>{String(this.state.model!.unitMeasureCode)}</p>
						 </div>
					   		  </div>
          {message}


        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedBillOfMaterialDetailComponent = Form.create({ name: 'BillOfMaterial Detail' })(
  BillOfMaterialDetailComponent
);

/*<Codenesium>
    <Hash>8f8497580f5f1a40cabec974f54569fe</Hash>
</Codenesium>*/