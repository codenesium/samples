import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ChainMapper from './chainMapper';
import ChainViewModel from './chainViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {ClaspTableComponent} from '../shared/claspTable'
	import {LinkTableComponent} from '../shared/linkTable'
	



interface ChainDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ChainDetailComponentState {
  model?: ChainViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ChainDetailComponent extends React.Component<
ChainDetailComponentProps,
ChainDetailComponentState
> {
  state = {
    model: new ChainViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Chains + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Chains +
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
          let response = resp.data as Api.ChainClientResponseModel;

          console.log(response);

          let mapper = new ChainMapper();

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
							<h3>ChainStatusId</h3>
							<p>{String(this.state.model!.chainStatusIdNavigation!.toDisplay())}</p>
						 </div>
					   						 <div>
							<h3>ExternalId</h3>
							<p>{String(this.state.model!.externalId)}</p>
						 </div>
					   						 <div>
							<h3>Id</h3>
							<p>{String(this.state.model!.id)}</p>
						 </div>
					   						 <div>
							<h3>Name</h3>
							<p>{String(this.state.model!.name)}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>TeamId</h3>
							<p>{String(this.state.model!.teamIdNavigation!.toDisplay())}</p>
						 </div>
					   		  </div>
          {message}
		 <div>
            <h3>Clasps</h3>
            <ClaspTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Chains + '/' + this.state.model!.id + '/' + ApiRoutes.Clasps}
			/>
         </div>
			 <div>
            <h3>Links</h3>
            <LinkTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Chains + '/' + this.state.model!.id + '/' + ApiRoutes.Links}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedChainDetailComponent = Form.create({ name: 'Chain Detail' })(
  ChainDetailComponent
);

/*<Codenesium>
    <Hash>17a1593cf0ec907847240aa353e66a65</Hash>
</Codenesium>*/