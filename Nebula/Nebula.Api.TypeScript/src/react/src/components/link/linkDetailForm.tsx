import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import LinkMapper from './linkMapper';
import LinkViewModel from './linkViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {LinkLogTableComponent} from '../shared/linkLogTable'
	



interface LinkDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface LinkDetailComponentState {
  model?: LinkViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class LinkDetailComponent extends React.Component<
LinkDetailComponentProps,
LinkDetailComponentState
> {
  state = {
    model: new LinkViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Links + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Links +
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
          let response = resp.data as Api.LinkClientResponseModel;

          console.log(response);

          let mapper = new LinkMapper();

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
							<h3>AssignedMachineId</h3>
							<p>{String(this.state.model!.assignedMachineIdNavigation!.toDisplay())}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>ChainId</h3>
							<p>{String(this.state.model!.chainIdNavigation!.toDisplay())}</p>
						 </div>
					   						 <div>
							<h3>DateCompleted</h3>
							<p>{String(this.state.model!.dateCompleted)}</p>
						 </div>
					   						 <div>
							<h3>DateStarted</h3>
							<p>{String(this.state.model!.dateStarted)}</p>
						 </div>
					   						 <div>
							<h3>DynamicParameter</h3>
							<p>{String(this.state.model!.dynamicParameter)}</p>
						 </div>
					   						 <div>
							<h3>ExternalId</h3>
							<p>{String(this.state.model!.externalId)}</p>
						 </div>
					   						 <div>
							<h3>Id</h3>
							<p>{String(this.state.model!.id)}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>LinkStatusId</h3>
							<p>{String(this.state.model!.linkStatusIdNavigation!.toDisplay())}</p>
						 </div>
					   						 <div>
							<h3>Name</h3>
							<p>{String(this.state.model!.name)}</p>
						 </div>
					   						 <div>
							<h3>Order</h3>
							<p>{String(this.state.model!.order)}</p>
						 </div>
					   						 <div>
							<h3>Response</h3>
							<p>{String(this.state.model!.response)}</p>
						 </div>
					   						 <div>
							<h3>StaticParameter</h3>
							<p>{String(this.state.model!.staticParameter)}</p>
						 </div>
					   						 <div>
							<h3>TimeoutInSecond</h3>
							<p>{String(this.state.model!.timeoutInSecond)}</p>
						 </div>
					   		  </div>
          {message}
		 <div>
            <h3>LinkLogs</h3>
            <LinkLogTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Links + '/' + this.state.model!.id + '/' + ApiRoutes.LinkLogs}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedLinkDetailComponent = Form.create({ name: 'Link Detail' })(
  LinkDetailComponent
);

/*<Codenesium>
    <Hash>53d345d0e83c0d6b1cc7073515732d80</Hash>
</Codenesium>*/