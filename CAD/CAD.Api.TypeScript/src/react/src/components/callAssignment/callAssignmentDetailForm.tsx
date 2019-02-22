import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CallAssignmentMapper from './callAssignmentMapper';
import CallAssignmentViewModel from './callAssignmentViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';




interface CallAssignmentDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CallAssignmentDetailComponentState {
  model?: CallAssignmentViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class CallAssignmentDetailComponent extends React.Component<
CallAssignmentDetailComponentProps,
CallAssignmentDetailComponentState
> {
  state = {
    model: new CallAssignmentViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.CallAssignments + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.CallAssignments +
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
          let response = resp.data as Api.CallAssignmentClientResponseModel;

          console.log(response);

          let mapper = new CallAssignmentMapper();

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
									 <div style={{"marginBottom":"10px"}}>
							<h3>callId</h3>
							<p>{String(this.state.model!.callIdNavigation!.toDisplay())}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>unitId</h3>
							<p>{String(this.state.model!.unitIdNavigation!.toDisplay())}</p>
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

export const WrappedCallAssignmentDetailComponent = Form.create({ name: 'CallAssignment Detail' })(
  CallAssignmentDetailComponent
);

/*<Codenesium>
    <Hash>8ed41cfa7d171eb723cab19cef9cfa6b</Hash>
</Codenesium>*/