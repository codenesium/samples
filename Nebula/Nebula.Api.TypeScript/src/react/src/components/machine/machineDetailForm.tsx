import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import MachineMapper from './machineMapper';
import MachineViewModel from './machineViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {LinkTableComponent} from '../shared/linkTable'
	



interface MachineDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface MachineDetailComponentState {
  model?: MachineViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class MachineDetailComponent extends React.Component<
MachineDetailComponentProps,
MachineDetailComponentState
> {
  state = {
    model: new MachineViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Machines + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Machines +
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
          let response = resp.data as Api.MachineClientResponseModel;

          console.log(response);

          let mapper = new MachineMapper();

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
							<h3>Description</h3>
							<p>{String(this.state.model!.description)}</p>
						 </div>
					   						 <div>
							<h3>Id</h3>
							<p>{String(this.state.model!.id)}</p>
						 </div>
					   						 <div>
							<h3>JwtKey</h3>
							<p>{String(this.state.model!.jwtKey)}</p>
						 </div>
					   						 <div>
							<h3>LastIpAddress</h3>
							<p>{String(this.state.model!.lastIpAddress)}</p>
						 </div>
					   						 <div>
							<h3>MachineGuid</h3>
							<p>{String(this.state.model!.machineGuid)}</p>
						 </div>
					   						 <div>
							<h3>Name</h3>
							<p>{String(this.state.model!.name)}</p>
						 </div>
					   		  </div>
          {message}
		 <div>
            <h3>Links</h3>
            <LinkTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Machines + '/' + this.state.model!.id + '/' + ApiRoutes.Links}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedMachineDetailComponent = Form.create({ name: 'Machine Detail' })(
  MachineDetailComponent
);

/*<Codenesium>
    <Hash>ab6ff82c3b0b6c76d4436e198cafd8e0</Hash>
</Codenesium>*/