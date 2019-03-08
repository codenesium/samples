import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostHistoryTypesMapper from './postHistoryTypesMapper';
import PostHistoryTypesViewModel from './postHistoryTypesViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {PostHistoryTableComponent} from '../shared/postHistoryTable'
	



interface PostHistoryTypesDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PostHistoryTypesDetailComponentState {
  model?: PostHistoryTypesViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class PostHistoryTypesDetailComponent extends React.Component<
PostHistoryTypesDetailComponentProps,
PostHistoryTypesDetailComponentState
> {
  state = {
    model: new PostHistoryTypesViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.PostHistoryTypes + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.PostHistoryTypes +
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
          let response = resp.data as Api.PostHistoryTypesClientResponseModel;

          console.log(response);

          let mapper = new PostHistoryTypesMapper();

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
            <h3>PostHistory</h3>
            <PostHistoryTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.PostHistoryTypes + '/' + this.state.model!.id + '/' + ApiRoutes.PostHistory}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedPostHistoryTypesDetailComponent = Form.create({ name: 'PostHistoryTypes Detail' })(
  PostHistoryTypesDetailComponent
);

/*<Codenesium>
    <Hash>5fc03a943912eea8d24d19ab77d21ad4</Hash>
</Codenesium>*/