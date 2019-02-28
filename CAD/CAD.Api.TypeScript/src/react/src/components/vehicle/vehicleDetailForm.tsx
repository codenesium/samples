import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VehicleMapper from './vehicleMapper';
import VehicleViewModel from './vehicleViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {VehicleCapabilitiesTableComponent} from '../shared/vehicleCapabilitiesTable'
	import {VehicleOfficerTableComponent} from '../shared/vehicleOfficerTable'
	



interface VehicleDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface VehicleDetailComponentState {
  model?: VehicleViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class VehicleDetailComponent extends React.Component<
VehicleDetailComponentProps,
VehicleDetailComponentState
> {
  state = {
    model: new VehicleViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Vehicles + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Vehicles +
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
          let response = resp.data as Api.VehicleClientResponseModel;

          console.log(response);

          let mapper = new VehicleMapper();

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
							<h3>name</h3>
							<p>{String(this.state.model!.name)}</p>
						 </div>
					   		  </div>
          {message}
		 <div>
            <h3>VehicleCapabilities</h3>
            <VehicleCapabilitiesTableComponent 
			vehicleId={this.state.model!.vehicleId} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Vehicles + '/' + this.state.model!.id + '/' + ApiRoutes.VehicleCapabilities}
			/>
         </div>
			 <div>
            <h3>VehicleOfficers</h3>
            <VehicleOfficerTableComponent 
			officerId={this.state.model!.officerId} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Vehicles + '/' + this.state.model!.id + '/' + ApiRoutes.VehicleOfficers}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedVehicleDetailComponent = Form.create({ name: 'Vehicle Detail' })(
  VehicleDetailComponent
);

/*<Codenesium>
    <Hash>e9f32c92af482bcebd6f849c2913b3bc</Hash>
</Codenesium>*/