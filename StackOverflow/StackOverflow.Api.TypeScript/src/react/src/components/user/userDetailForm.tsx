import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { LoadingForm } from '../../lib/components/loadingForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import UserMapper from './userMapper';
import UserViewModel from './userViewModel';
import { Form, Input, Button } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface UserDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface UserDetailComponentState {
  model?: UserViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class UserDetailComponent extends React.Component<
UserDetailComponentProps,
UserDetailComponentState
> {
  state = {
    model: new UserViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Users + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Users +
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
          let response = resp.data as Api.UserClientResponseModel;

          console.log(response);

          let mapper = new UserMapper();

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
            loaded: false,
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
      return <LoadingForm />;
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
							<div>aboutMe</div>
							<div>{this.state.model!.aboutMe}</div>
						 </div>
					   						 <div>
							<div>accountId</div>
							<div>{this.state.model!.accountId}</div>
						 </div>
					   						 <div>
							<div>age</div>
							<div>{this.state.model!.age}</div>
						 </div>
					   						 <div>
							<div>creationDate</div>
							<div>{this.state.model!.creationDate}</div>
						 </div>
					   						 <div>
							<div>displayName</div>
							<div>{this.state.model!.displayName}</div>
						 </div>
					   						 <div>
							<div>downVote</div>
							<div>{this.state.model!.downVote}</div>
						 </div>
					   						 <div>
							<div>emailHash</div>
							<div>{this.state.model!.emailHash}</div>
						 </div>
					   						 <div>
							<div>lastAccessDate</div>
							<div>{this.state.model!.lastAccessDate}</div>
						 </div>
					   						 <div>
							<div>location</div>
							<div>{this.state.model!.location}</div>
						 </div>
					   						 <div>
							<div>reputation</div>
							<div>{this.state.model!.reputation}</div>
						 </div>
					   						 <div>
							<div>upVote</div>
							<div>{this.state.model!.upVote}</div>
						 </div>
					   						 <div>
							<div>view</div>
							<div>{this.state.model!.view}</div>
						 </div>
					   						 <div>
							<div>websiteUrl</div>
							<div>{this.state.model!.websiteUrl}</div>
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

export const WrappedUserDetailComponent = Form.create({ name: 'User Detail' })(
  UserDetailComponent
);

/*<Codenesium>
    <Hash>bbafc30670ce9aa38e5dfa00254d3bac</Hash>
</Codenesium>*/