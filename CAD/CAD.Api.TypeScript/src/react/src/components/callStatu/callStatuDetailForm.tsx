import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CallStatuMapper from './callStatuMapper';
import CallStatuViewModel from './callStatuViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {CallTableComponent} from '../shared/callTable'
	



interface CallStatuDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CallStatuDetailComponentState {
  model?: CallStatuViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class CallStatuDetailComponent extends React.Component<
CallStatuDetailComponentProps,
CallStatuDetailComponentState
> {
  state = {
    model: new CallStatuViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.CallStatus + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.CallStatus +
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
          let response = resp.data as Api.CallStatuClientResponseModel;

          console.log(response);

          let mapper = new CallStatuMapper();

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
            <h3>Calls</h3>
            <CallTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.CallStatus + '/' + this.state.model!.id + '/' + ApiRoutes.Calls}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedCallStatuDetailComponent = Form.create({ name: 'CallStatu Detail' })(
  CallStatuDetailComponent
);

/*<Codenesium>
    <Hash>1130e5cab2e8bcc5014e30c860ff2dce</Hash>
</Codenesium>*/