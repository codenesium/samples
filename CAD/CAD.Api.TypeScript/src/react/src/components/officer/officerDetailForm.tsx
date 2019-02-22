import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import OfficerMapper from './officerMapper';
import OfficerViewModel from './officerViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {NoteTableComponent} from '../shared/noteTable'
	import {OfficerRefCapabilityTableComponent} from '../shared/officerRefCapabilityTable'
	import {UnitOfficerTableComponent} from '../shared/unitOfficerTable'
	import {VehicleOfficerTableComponent} from '../shared/vehicleOfficerTable'
	



interface OfficerDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface OfficerDetailComponentState {
  model?: OfficerViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class OfficerDetailComponent extends React.Component<
OfficerDetailComponentProps,
OfficerDetailComponentState
> {
  state = {
    model: new OfficerViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Officers + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Officers +
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
          let response = resp.data as Api.OfficerClientResponseModel;

          console.log(response);

          let mapper = new OfficerMapper();

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
							<h3>badge</h3>
							<p>{String(this.state.model!.badge)}</p>
						 </div>
					   						 <div>
							<h3>email</h3>
							<p>{String(this.state.model!.email)}</p>
						 </div>
					   						 <div>
							<h3>firstName</h3>
							<p>{String(this.state.model!.firstName)}</p>
						 </div>
					   						 <div>
							<h3>lastName</h3>
							<p>{String(this.state.model!.lastName)}</p>
						 </div>
					   						 <div>
							<h3>password</h3>
							<p>{String(this.state.model!.password)}</p>
						 </div>
					   		  </div>
          {message}
		 <div>
            <h3>Notes</h3>
            <NoteTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Officers + '/' + this.state.model!.id + '/' + ApiRoutes.Notes}
			/>
         </div>
			 <div>
            <h3>OfficerRefCapabilities</h3>
            <OfficerRefCapabilityTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Officers + '/' + this.state.model!.id + '/' + ApiRoutes.OfficerRefCapabilities}
			/>
         </div>
			 <div>
            <h3>UnitOfficers</h3>
            <UnitOfficerTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Officers + '/' + this.state.model!.id + '/' + ApiRoutes.UnitOfficers}
			/>
         </div>
			 <div>
            <h3>VehicleOfficers</h3>
            <VehicleOfficerTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Officers + '/' + this.state.model!.id + '/' + ApiRoutes.VehicleOfficers}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedOfficerDetailComponent = Form.create({ name: 'Officer Detail' })(
  OfficerDetailComponent
);

/*<Codenesium>
    <Hash>95d95544c11a7db589064d907175136c</Hash>
</Codenesium>*/