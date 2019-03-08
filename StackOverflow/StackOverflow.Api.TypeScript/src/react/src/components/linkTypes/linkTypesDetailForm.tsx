import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import LinkTypesMapper from './linkTypesMapper';
import LinkTypesViewModel from './linkTypesViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {PostLinksTableComponent} from '../shared/postLinksTable'
	



interface LinkTypesDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface LinkTypesDetailComponentState {
  model?: LinkTypesViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class LinkTypesDetailComponent extends React.Component<
LinkTypesDetailComponentProps,
LinkTypesDetailComponentState
> {
  state = {
    model: new LinkTypesViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.LinkTypes + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.LinkTypes +
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
          let response = resp.data as Api.LinkTypesClientResponseModel;

          console.log(response);

          let mapper = new LinkTypesMapper();

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
							<h3>Rw Type</h3>
							<p>{String(this.state.model!.rwType)}</p>
						 </div>
					   		  </div>
          {message}
		 <div>
            <h3>PostLinks</h3>
            <PostLinksTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.LinkTypes + '/' + this.state.model!.id + '/' + ApiRoutes.PostLinks}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedLinkTypesDetailComponent = Form.create({ name: 'LinkTypes Detail' })(
  LinkTypesDetailComponent
);

/*<Codenesium>
    <Hash>ee51af2eb1da27accaa3cdba05c94a2c</Hash>
</Codenesium>*/